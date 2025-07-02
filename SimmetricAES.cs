using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Input;
using System.Configuration;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Net.NetworkInformation;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace NetscalerOTPAdmin
{
    static public class SimmetricAES
    {
        static private CultureInfo CurrentCulture = new CultureInfo("es-ES");

        private static string CreateKeyWithUserName()
        {            
            string baseW = Convert.ToBase64String(Encoding.UTF8.GetBytes(Environment.UserName.ToLower(CurrentCulture)));
            string baseWClean = Regex.Replace(baseW, @"[^a-zA-Z0-9\s]", "");

            string result = string.Empty;
            while (result.Length < 32)
            {
                result += baseWClean;
            }

            return result.Substring(0, 32);
        }
    
        private static string GetAESKey()
        {
            string AESKey="";
            string AESKeyRev = "";
            string AESKeyRevENC = "";
            try
            {
                // Get the roaming configuration that applies to the current user.
                //Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);

                string userDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string userAppConfigFile = userDir + "\\NetscalerOTPAdmin\\user.config";
                
                //string userNameKey = CreateKeyWithWord(),32);
                string userNameKey = CreateKeyWithUserName();
                string defaultIV = Convert.ToBase64String(new byte[16]);

                // Map the roaming configuration file. This enables the application to access 
                // the configuration file using the System.Configuration.Configuration class
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = userAppConfigFile; // roamingConfig.FilePath;
  

                // Get the mapped configuration file.
                Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings["OTPADMUserKey"] == null)
                {
                    // Generate new AES Key
                    AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                    aes.GenerateKey();

                    // Convert to Base64
                    AESKey = Convert.ToBase64String(aes.Key);

                    // Reverse the string key
                    char[] charArray = AESKey.ToCharArray();
                    Array.Reverse(charArray);
                    AESKeyRev = new string(charArray);

                    // Encrypt the reversed string with the username of the enviroment
                    AESKeyRevENC = EncryptString(AESKeyRev, userNameKey, defaultIV);

                    // Save the key to the user config file
                    settings.Add("OTPADMUserKey", AESKeyRevENC);

                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                    aes.Dispose();
                }
                else
                {
                    AESKeyRevENC = settings["OTPADMUserKey"].Value;

                    // Decrypt the saved string with the username of the enviroment
                    AESKeyRev = DecryptString(AESKeyRevENC, userNameKey, defaultIV);

                    // Reverse the string key
                    char[] charArray = AESKeyRev.ToCharArray();
                    Array.Reverse(charArray);
                    AESKey = new string(charArray);
                }
            }
            catch (ConfigurationErrorsException c)
            {
                MessageBox.Show("Error writing/reading app user settings\r\n" + c.Message + "\r\nFile:" + c.Filename ,"Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return AESKey;
        }

        private static string GetAESIV()
        {
            string AESIV = "";
            try
            {
                // Get the roaming configuration that applies to the current user.
                //Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);

                string userDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string userAppConfigFile = userDir + "\\NetscalerOTPAdmin\\user.config";

                // Map the roaming configuration file. This enables the application to access 
                // the configuration file using the System.Configuration.Configuration class
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = userAppConfigFile; // roamingConfig.FilePath;

                // Get the mapped configuration file.
                Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings["OTPADMUserRnd"] == null)
                {
                     AesCryptoServiceProvider aes = new AesCryptoServiceProvider();

                    // Generate new AES IV
                    aes.GenerateIV();

                    // Convert to Base64
                    AESIV = Convert.ToBase64String(aes.IV);

                    // Save the key to the user config file
                    settings.Add("OTPADMUserRnd", AESIV);

                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                    aes.Dispose();
                }
                else
                {
                    AESIV = settings["OTPADMUserRnd"].Value;
                }
            }
            catch (ConfigurationErrorsException c)
            {
                MessageBox.Show("Error writing/reading app user settings\r\n" + c.Message + "\r\nFile:" + c.Filename, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return AESIV;
        }

        public static string EncryptString(string plainText)
        {
            //byte[] iv = new byte[16];
            byte[] array;

            string AESKey = GetAESKey();
            string AESIV = GetAESIV();

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(AESKey); // Encoding.UTF8.GetBytes(AESKey);
                aes.IV = Convert.FromBase64String(AESIV); ;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string EncryptString(string plainText, string AESKey, string AESIV)
        {
            //byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(AESKey); // Encoding.UTF8.GetBytes(AESKey);
                aes.IV = Convert.FromBase64String(AESIV);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            string AESKey = GetAESKey();
            string AESIV = GetAESIV();

            using (Aes aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(AESKey); //Encoding.UTF8.GetBytes(AESKey);
                aes.IV = Convert.FromBase64String(AESIV);
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string DecryptString(string cipherText, string AESKey, string AESIV)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                //byte[] ivt =Convert.FromBase64String(AESIV);                

                aes.Key = Convert.FromBase64String(AESKey); //Encoding.UTF8.GetBytes(AESKey);
                aes.IV = Convert.FromBase64String(AESIV);

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }




        // Using .NET Native AES GCM Decryption 
        public static string DecryptStringGCM(string cipherText, string AESKey, string AESIV, string tag)
        {
            try
            {
                using (var aes = new AesGcm(Convert.FromBase64String(AESKey)))
                {
                    byte[] cyphertxt = Convert.FromBase64String(cipherText);
                    var plaintext = new byte[cyphertxt.Length];

                    aes.Decrypt(Convert.FromBase64String(AESIV), cyphertxt, Convert.FromBase64String(tag), plaintext);

                    // Logging the decrypted message (optional)
                    // Console.WriteLine($"The decrypted message is: {Encoding.UTF8.GetString(plaintext)}");

                    return Convert.ToBase64String(plaintext);
                }
            }
            catch (CryptographicException ex)
            {
                Console.Error.WriteLine($"Incorrect decryption: {ex.Message}");
                return null;
            }
        }



        // Using BouncyCastle AES GCM Decryption
        public static byte[] DecryptBouncyCastle(byte[] ciphertext, byte[] sessionKey, byte[] initVector)
        {
            try
            {
                byte[] plaintext = null ;

                if (ciphertext != null) {

                    // Create the GCM cipher with the AES engine
                    GcmBlockCipher cipher = new GcmBlockCipher(new AesEngine());

                    // Set the parameters for decryption
                    AeadParameters parameters = new AeadParameters(new KeyParameter(sessionKey), 128, initVector, null);
                    cipher.Init(false, parameters); // false to indicate decryption operation

                    // Set the output size for the plaintext buffer
                    plaintext = new byte[cipher.GetOutputSize(ciphertext.Length)];

                    // Process the ciphertext bytes
                    int len = cipher.ProcessBytes(ciphertext, 0, ciphertext.Length, plaintext, 0);

                    // Ends decryption and returns the number of bytes written to the output buffer
                    cipher.DoFinal(plaintext, len);                
                }
                return plaintext;
            }
            catch (CryptographicException ex)
            {
                MessageBox.Show($"Incorrect decryption: {ex.Message}");
                return null;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show($"Incorrect decryption: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Incorrect decryption: {ex.Message}");
                return null;
            }
        }



    }
}
