using Newtonsoft.Json;
using Org.BouncyCastle.Utilities;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace NetscalerOTPAdmin
{
    class OTPSeeds
    {

        public class OTPData
        {
            public Dictionary<string, string> devices { get; set; }
        }

        public class OTPRoot
        {
            public OTPData otpdata { get; set; }
        }




        CultureInfo CurrentCulture = new CultureInfo("es-ES");
        internal static string GenerateSeedString(string device,string seed) {

            string updatedattribute = "";
            if ((String.IsNullOrEmpty(device)) || (String.IsNullOrEmpty(seed)))
            {
                throw new Exception("Device name or Seed value are not valid!");
            }
            
            updatedattribute += device + "=" + seed + "&,";

            if (!String.IsNullOrEmpty(updatedattribute))
            {
                updatedattribute = "#@" + updatedattribute;
            }

            return updatedattribute;
        }

        internal static string AddNewSeed(string allseeds,string device, string seed)
        {

            string updatedattribute = "";
            if ((String.IsNullOrEmpty(device)) || (String.IsNullOrEmpty(seed)))
            {
                throw new Exception("Device name or Seed value are not valid!");
            }

            updatedattribute += device + "=" + seed + "&,";

            if (!String.IsNullOrEmpty(allseeds))
            {
                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    allseeds += updatedattribute;
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    allseeds = "#@" + updatedattribute;
                }
            }

            return allseeds;
        }

        internal static string RegenerateSeedString(ListViewItemCollection items)
        {
            string updatedattribute = "";
            if (items != null)
            {
                foreach (ListViewItem li in items)
                {
                    string device = li.SubItems[0].Text;
                    string seed = li.SubItems[1].Text;
                    updatedattribute += device + "=" + seed + "&,";
                }

                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    updatedattribute = "#@" + updatedattribute;
                }
            }
            else
            {
                throw new Exception("List Itemss Collection are not valid!");
            }
            return updatedattribute;
        }

        internal static string RegenerateSeedString(string[] items)
        {
            string updatedattribute = "";
            if (items != null)
            {
                foreach (string seedt in items)
                {
                    string[] seedarr = seedt.Split('=');
                    updatedattribute += seedarr[0] + "=" + seedarr[1] + ",";
                }

                if (!String.IsNullOrEmpty(updatedattribute))
                {
                    updatedattribute = "#@" + updatedattribute;
                }
            }
            else
            {
                throw new Exception("Items array are not valid!");
            }
            return updatedattribute;
        }

        internal static string RenameDevice(string seeds, string oldname, string newname)
        {

            if ((String.IsNullOrEmpty(seeds)) || (String.IsNullOrEmpty(oldname)) || (String.IsNullOrEmpty(newname)))
            {
                throw new Exception("Incorrect parameters o null parameters!");
            }

            if (seeds.StartsWith("#@",StringComparison.Ordinal)) { 
                seeds = seeds.Substring(2);
            }
            // Remove the last , of the seed string
            seeds = seeds.Remove(seeds.Length - 1);

            // split all the seeds 
            string[] arr_seeds = seeds.Split(',');

            string updatedattribute = "";
            // and search all the seeds for the device to modify
            foreach (string seedt in arr_seeds)
            {
                string[] seedarr = seedt.Split('=');
                // If the device name of the seed corresponds with the original device name, we change this name using the input of the user
                if (oldname == seedarr[0])
                {
                    seedarr[0] = newname;
                }
                updatedattribute += seedarr[0] + "=" + seedarr[1] + ",";
            }

            if (!String.IsNullOrEmpty(updatedattribute))
            {
                updatedattribute = "#@" + updatedattribute;
            }

            return updatedattribute;
        }


        ///
        /// TODO: check for Citrix updates on the code, and test different methods to decrypt the seed.
        /// 
        /// <summary>
        /// Encryption and decryption of the seed using the OTP certificate and private key
        /// 
        /// The seed is encrypted using AES GCM with a symmetric key generated from the OTP certificate and private key.
        /// This implemetation is based on the Citrix OTP Encryption Tool, but the Citrix python code has some issues that
        /// can't be fixed. For example, we can't decrypt a OTP Seed encrypted with the Citrix OTP Encryption Tool, because the
        /// python code is not saving the data as the indicates in their documentation, TAG is not saved on the data, and we can 
        /// decrypt the seed using AESGCM.
        /// 
        /// </summary>

        internal static string DecryptSeed(string encseed,string OTPCertificate, string OTPPrivateKey)
        {

            try {

                string seed = null;

                string[] secret = encseed.Split('.');

                string kid = secret[0];
                string iv = secret[1];
                string ciphertext = secret[2];
                
                // Replace kid, iv and ciphertext to be compatible with Base64 decoding
                kid = kid.Replace('-', '+').Replace('_', '/');

                // Base64 strings must have a length that is a multiple of 4, that's why we add padding if necessary
                switch (kid.Length % 4)
                {
                    case 2: kid += "=="; break;
                    case 3: kid += "="; break;
                }

                byte[] bkid = Convert.FromBase64String(kid);
                kid = Encoding.UTF8.GetString(bkid);

                // We can use this KID to verify if the certificate used to encrypt the seed is the correct one.
                // The KID is the SHA1 hash of the certificate used to encrypt the seed, encoded in Base64.
                // To verify the KID, we need to generate a SHA1 hash of the certificate and compare it with the KID.

                /*
                iv = iv.Replace('-', '+').Replace('_', '/');
                switch (iv.Length % 4)
                {
                    case 2: iv += "=="; break;
                    case 3: iv += "="; break;
                }
                byte[] binitVector = Convert.FromBase64String(iv);
                //iv = Encoding.UTF8.GetString(biv);



                ciphertext = ciphertext.Replace('-', '+').Replace('_', '/');
                switch (ciphertext.Length % 4)
                {
                    case 2: ciphertext += "=="; break;
                    case 3: ciphertext += "="; break;
                }
                byte[] bciphertext = Convert.FromBase64String(ciphertext);
                //ciphertext = Encoding.UTF8.GetString(bciphertext);
                */

                byte[] bciphertext = Convert.FromBase64String(ciphertext.Replace('-', '+').Replace('_', '/'));
                byte[] binitVector = Convert.FromBase64String(iv.Replace('-', '+').Replace('_', '/'));

                // Generate the symmetric key
                SymmetricKeyGenerator skg = new SymmetricKeyGenerator(OTPCertificate,OTPPrivateKey);

                byte[] symmetric_key = skg.GenerateSymmetricKey();
                //string smK = Convert.ToBase64String(symmetric_key);

                
                // Testing with different decryption methods

                // seed = SimmetricAES.DecryptString(ciphertext, smK, iv);
                // seed = SimmetricAES.DecryptStringGCM(ciphertext, smK, iv, kid);
                byte[] bseed = SimmetricAES.DecryptBouncyCastle(bciphertext, symmetric_key, binitVector);

                if (bseed != null)
                {
                    seed = Convert.ToBase64String(bseed);
                }

                return seed;

            }
            catch (CryptographicException ex)
            {
                Console.Error.WriteLine($"Incorrect decryption: {ex.Message}");
                return null;
            }
            catch (ArgumentNullException ex)
            {
                Console.Error.WriteLine($"Incorrect decryption: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Incorrect decryption: {ex.Message}");
                return null;
            }

        }

    }
}

