using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Pkcs;
using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;

namespace NetscalerOTPAdmin
{
    public class SymmetricKeyGenerator
    {
        private string currentCertPath;
        private string currentPKeyPath;
        private CryptographyHelper crypt;

        public SymmetricKeyGenerator(string certPath, string pkeyPath)
        {

            string userDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string userAppDir = userDir + "\\NetscalerOTPAdmin\\";

            currentCertPath = userAppDir + certPath;
            currentPKeyPath = userAppDir + pkeyPath;
        }
        
        /*
         * Generate the symmetric key using the hkdf algorithm
         * 
         *  output - 32 byte symmetric key
         *  return False in case of an error
         */
        public byte[] GenerateSymmetricKey()
        {
            try
            {
                // ------------------------------------------
                // Generate the public key

                string certFileString = File.ReadAllText(currentCertPath);
                
                // Use a regular expression to extract the public key between the delimiters
                Match match = Regex.Match(certFileString, @"(?<=-----BEGIN CERTIFICATE-----).*?(?=-----END CERTIFICATE-----)", RegexOptions.Singleline);
                string ikm = string.Empty;

                if (match.Success)
                {
                    ikm = match.Value;
                }

                // Remove new lines and carriage returns
                ikm = ikm.Replace("\n", "").Replace("\r", "");

                // Convert the Base64 string to a byte array
                byte[] ikmBytes = Encoding.UTF8.GetBytes(ikm);


                // ------------------------------------------
                // Generate the private key

                string pkeyFileString = File.ReadAllText(currentPKeyPath);

                // Load the private key from the PEM file
                PemReader pemReader = new PemReader(new StringReader(pkeyFileString));
                AsymmetricKeyParameter privateKey = (AsymmetricKeyParameter)pemReader.ReadObject();

                // Convert the private key to ASN.1 format
                PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKey);
                byte[] asn1EncodedKey = privateKeyInfo.ToAsn1Object().GetEncoded();

                // Convert the ASN.1 encoded key to a Base64 string
                string pkm = Convert.ToBase64String(asn1EncodedKey);
                
                //byte[] pkmBytes = Encoding.UTF8.GetBytes(pkm);
                //string salt = Convert.ToBase64String(pkmBytes);
                //MessageBox.Show(asn1EncodedKey.SequenceEqual(pkmBytes).ToString());

                // Generate the symmetric key
                crypt = new CryptographyHelper();


                // WARNING!!!!!!! --- WARNING!!!!!!!
                // WARNING!!!!!!! --- WARNING!!!!!!!
                //
                // Has you can check, the HKDF implementation need the parameters on this order: lenth, IKM , SALT and optional Info
                // But in this call, IKM and SALT are inverted!!!! Because Citrix has also inverted on their OTP Encription tool
                // We understand that may be an error, but, we need to use the same order to generate the symmetric key
                // https://docs.netscaler.com/en-us/citrix-adc/current-release/aaa-tm/authentication-methods/native-otp-authentication/otp-encryption-tool                

                byte[] symmetricKey = crypt.Hkdf2(32, asn1EncodedKey, ikmBytes);
                
                // ------------------------

                return symmetricKey;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in processing the certificate, due to {ex.GetType().Name}");
                return null;
            }
        }
    }


    public class CryptographyHelper
    {

        // Second version of HKDF implementation using NET Native
        public byte[] Hkdf2(int length, byte[] ikm, byte[] salt)
        {
            // Use SHA256 for the hash algorithm
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;

            // Extract the pseudorandom key (PRK) from the input key material (IKM) and salt using HKDF Extract
            // Note: The salt is optional in HKDF, if not provided, a zero-length salt is used.
            byte[] prk = HKDF.Extract(hashAlgorithm, ikm, salt);

            // Expand the pseudorandom key (PRK) to generate the output key material (OKM)
            byte[] okm = HKDF.Expand(hashAlgorithm, prk, length, Array.Empty<byte>());

            return okm;
        }

        // Original HKDF implementation using HMAC SHA256
        public byte[] Hkdf(int length, byte[] ikm, byte[] salt, byte[] info = null)
        {
            if (info == null)
            {
                info = Array.Empty<byte>();
            }

            // Extract the pseudorandom key (PRK) from the input key material (IKM) and salt using HKDF Extract
            // Note: The salt is optional in HKDF, if not provided, a zero-length salt is used.
            byte[] prk = HmacSha256(salt.Length > 0 ? salt : new byte[32], ikm);

            // Expand the pseudorandom key (PRK) to generate the output key material (OKM)
            byte[] okm = new byte[length];
            byte[] t = Array.Empty<byte>();
            int generatedBytes = 0;
            int counter = 1;

            using (var hmac = new HMACSHA256(prk))
            {
                while (generatedBytes < length)
                {
                    // Concatenation of T, info, and counter
                    hmac.Initialize();
                    hmac.TransformBlock(t, 0, t.Length, t, 0);
                    hmac.TransformBlock(info, 0, info.Length, info, 0);
                    hmac.TransformFinalBlock(new byte[] { (byte)counter }, 0, 1);

                    t = hmac.Hash;
                    int bytesToCopy = Math.Min(t.Length, length - generatedBytes);
                    Array.Copy(t, 0, okm, generatedBytes, bytesToCopy);

                    generatedBytes += bytesToCopy;
                    counter++;
                }
            }

            return okm;
        }

        private byte[] HmacSha256(byte[] key, byte[] data)
        {
            using (var hmac = new HMACSHA256(key))
            {
                return hmac.ComputeHash(data);
            }
        }
    }


}
