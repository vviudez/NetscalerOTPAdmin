using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using NetscalerOTPAdmin.Properties;

namespace NetscalerOTPAdmin
{
    public partial class frmSettings : Form
    {
        private string MasterPasswd;

        private string ldapServer;
        private string ldapUser;
        private string ldapPass;
        private string ldapDomain;
        private string ldapBaseDN;
        private string ldapProtocol;

        private string userAttribute;
        private string OTPDefaultDescription;
        private string OTPAccountDesciption;

        private string UseEmail;
        private string SMTPServer;
        private string SMTPPort;
        private string SMTPUsername;
        private string SMTPPassword;
        private string SMTPSSL;
        private string SMTPFrom;
        private string SMTPSubject;
        private string SMTPTemplate;

        private string MPHash;

        private string baseDir;
        private string userAppDir;

        public frmSettings()
        {
            InitializeComponent();
            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string userDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            userAppDir = userDir + "\\NetscalerOTPAdmin\\";

            if (!Directory.Exists(userAppDir))
            {
                Directory.CreateDirectory(userAppDir);
            }

        }

        // Get settings from user.config
        private string getUserSetting(KeyValueConfigurationCollection col, string settingName)
        {
            string SettingValue = "";

            if (col[settingName] != null)
            {
                SettingValue = col[settingName].Value;
            }

            return SettingValue;
        }


        private void frmSettings_Load(object sender, EventArgs e)
        {
            string userAppConfigFile = userAppDir + "user.config";
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = userAppConfigFile;

            // Get the mapped configuration file.
            Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            MasterPasswd = getUserSetting(settings, "MPwd");

            ldapServer = getUserSetting(settings, "LDAP");
            ldapUser = getUserSetting(settings, "User");

            string passenc = getUserSetting(settings, "Password");
            if (!(String.IsNullOrEmpty(passenc)) && (!(String.IsNullOrEmpty(MasterPasswd))))
            {
                ldapPass = SimmetricAES.DecryptString(passenc);
            }

            ldapDomain = getUserSetting(settings, "Domain");
            ldapBaseDN = getUserSetting(settings, "BaseDN");
            ldapProtocol = getUserSetting(settings, "Protocol");

            userAttribute = getUserSetting(settings, "UserAttribute");
            OTPDefaultDescription = getUserSetting(settings, "OTPDefaultDescription");
            OTPAccountDesciption = getUserSetting(settings, "OTPAccountDesciption");


            tbLDAPServer.Text = ldapServer;
            tbUsername.Text = ldapUser;
            tbPassword.Text = ldapPass;
            tbDomain.Text = ldapDomain;
            tbBaseDN.Text = ldapBaseDN;

            if (String.IsNullOrEmpty(ldapProtocol)){
                cbLDAPSecurity.SelectedItem = "TLS";
            }
            else
            {
                cbLDAPSecurity.SelectedItem = ldapProtocol;
            }

            if (String.IsNullOrEmpty(userAttribute))
            {
                tbOTPAttribute.Text = "userParameters";
            }
            else
            {
                tbOTPAttribute.Text = userAttribute;
            }
                
            tbOTPDescription.Text = OTPDefaultDescription;
            tbOTPAccountDesc.Text = OTPAccountDesciption;

            UseEmail = getUserSetting(settings, "UseEmail");
            if (UseEmail == "1")
            {
                cbEmailConfig.Checked = false;
                enableEmailFields();
            }
            else
            {
                cbEmailConfig.Checked = true;
                disableEmailFields();
            }

            SMTPServer = getUserSetting(settings, "SMTPServer");
            SMTPPort = getUserSetting(settings, "SMTPPort");

            string smtpuserenc = getUserSetting(settings, "SMTPUsername");
            if (!(String.IsNullOrEmpty(smtpuserenc)))
            {
                SMTPUsername = SimmetricAES.DecryptString(smtpuserenc);
            }

            string smtppassenc = getUserSetting(settings, "SMTPPassword");
            if (!(String.IsNullOrEmpty(smtppassenc)))
            {
                SMTPPassword = SimmetricAES.DecryptString(smtppassenc);
            }

            SMTPSSL = getUserSetting(settings, "SMTPSSL");

            string smtpfromenc = getUserSetting(settings, "SMTPFrom");
            if (!(String.IsNullOrEmpty(smtpfromenc)))
            {
                SMTPFrom = SimmetricAES.DecryptString(smtpfromenc);
            }

            SMTPSubject = getUserSetting(settings, "SMTPSubject");

            SMTPTemplate = getUserSetting(settings, "EmailTemplate");
            if (String.IsNullOrEmpty(SMTPTemplate)) SMTPTemplate = "emailTemplate.md";

            tbSMTPServer.Text = SMTPServer;
            tbSMTPPort.Text = SMTPPort;
            tbSMTPUsername.Text = SMTPUsername;
            tbSMTPPassword.Text = SMTPPassword;
            tbSMTPFrom.Text = SMTPFrom;
            tbSMTPSubject.Text = SMTPSubject;

            if (SMTPSSL == "1") cbSMTPSSL.Checked = true;
            else cbSMTPSSL.Checked = false;


            string[] fileEntries= Directory.GetFiles(baseDir, "*.md");
            string fichero;
            foreach (string fileName in fileEntries)
            {
                fichero = fileName.Replace(baseDir, "");
                cbSMTPTemplate.Items.Add(fichero);
            }
            cbSMTPTemplate.SelectedIndex = cbSMTPTemplate.Items.IndexOf(SMTPTemplate);
        }

        private void disableEmailFields()
        {
            tbSMTPServer.Enabled = false;
            tbSMTPPort.Enabled = false;
            tbSMTPUsername.Enabled = false;
            tbSMTPPassword.Enabled = false;
            tbSMTPFrom.Enabled = false;
            tbSMTPSubject.Enabled = false;
            cbSMTPTemplate.Enabled = false;
            cbSMTPSSL.Enabled = false;
        }

        private void enableEmailFields()
        {
            tbSMTPServer.Enabled = true;
            tbSMTPPort.Enabled = true;
            tbSMTPUsername.Enabled = true;
            tbSMTPPassword.Enabled = true;
            tbSMTPFrom.Enabled = true;
            tbSMTPSubject.Enabled = true;
            cbSMTPTemplate.Enabled = true;
            cbSMTPSSL.Enabled = true;
        }

        private bool checkValues()
        {
            bool correctConfig_LDAP = false;
            bool correctConfig_SMTP = false;
            bool correctConfig_MP = false;

            if ((String.IsNullOrEmpty(tbLDAPServer.Text)) ||
                (String.IsNullOrEmpty(tbDomain.Text)) ||
                (String.IsNullOrEmpty(tbUsername.Text)) || 
                (String.IsNullOrEmpty(tbPassword.Text)) || 
                (String.IsNullOrEmpty(tbOTPAttribute.Text))
                )
            {
                MessageBox.Show("Settings are not correct!. Please fill at least an LDAP Server and access Credentials, and required attributes");
                correctConfig_LDAP=false;
            }
            else
            {
                correctConfig_LDAP=true;
            }

            correctConfig_SMTP = true;
            if (!cbEmailConfig.Checked) { 
                if ((String.IsNullOrEmpty(tbSMTPServer.Text)) ||
                    (String.IsNullOrEmpty(tbSMTPPort.Text))
                    )
                {
                    MessageBox.Show("SMTP Settings are not correct!. Please fill at least an SMTP Server and port, and required attributes");
                    correctConfig_SMTP = false;
                }
            }
            
            if (cbChangePwd.Checked) { 
                if (String.IsNullOrEmpty(tbMasterPwd.Text))
                {
                    MessageBox.Show("Master password is not set!. Please fill the Master password your want, and use always the same to access the application");
                    correctConfig_MP = false;
                }
                else
                {
                    correctConfig_MP = true;
                }
            }
            else
            {
                if ( (String.IsNullOrEmpty(MasterPasswd)) && (String.IsNullOrEmpty(tbMasterPwd.Text)) )
                {
                    MessageBox.Show("Master password is not set!. Please fill the Master password your want, and use always the same to access the application");
                    correctConfig_MP = false;
                }
                else
                {
                    correctConfig_MP = true;
                }
            }

            return correctConfig_LDAP && correctConfig_SMTP && correctConfig_MP;
        }

        static string generateRandomString(int lenOfTheNewStr)
        {
            string output = string.Empty;
            while (true)
            {
                output = output + Path.GetRandomFileName().Replace(".", string.Empty);
                if (output.Length > lenOfTheNewStr)
                {
                    output = output.Substring(0, lenOfTheNewStr);
                    break;
                }
            }
            return output;
        }

        public static string ConvertToHash(string dataToComputeHash)
        {
            var hash = "";
            var salt = "3zgW7OMUwgKbe78OrwGTbV.q.2024";
            try
            {
                var keyByte = Encoding.UTF8.GetBytes(salt);
                using (var hmacsha256 = new HMACSHA256(keyByte))
                {
                    hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(dataToComputeHash));
                    hash = Encoding.UTF8.GetString(hmacsha256.Hash);
                    
                    hash = System.Convert.ToBase64String(hmacsha256.Hash);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Password Hashing error!\r\n" + ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hash;
        }

        private void AddSetting(KeyValueConfigurationCollection settings, string key, string value)
        {
            if (settings[key] == null) { 
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
        }

        private void bntOK_Click(object sender, EventArgs e)
        {
            try {

                string userAppConfigFile = userAppDir + "user.config";
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = userAppConfigFile;

                // Get the mapped configuration file.
                Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;


                MPHash = ConvertToHash(tbMasterPwd.Text);

                string prefix = generateRandomString(10);
                string suffix = generateRandomString(10);

                if ((cbChangePwd.Checked) && (!String.IsNullOrEmpty(tbMasterPwd.Text))) {
                    AddSetting(settings, "MPwd", prefix + MPHash + suffix);
                }
                if ((String.IsNullOrEmpty(MasterPasswd)) && (!String.IsNullOrEmpty(tbMasterPwd.Text)))
                {
                    AddSetting(settings, "MPwd", prefix + MPHash + suffix);
                }

                AddSetting(settings, "LDAP", tbLDAPServer.Text);
                AddSetting(settings, "User", tbUsername.Text);

                string passEnc = SimmetricAES.EncryptString(tbPassword.Text);

                AddSetting(settings, "Password", passEnc);
                AddSetting(settings, "Domain", tbDomain.Text);
                AddSetting(settings, "BaseDN", tbBaseDN.Text);
                AddSetting(settings, "Protocol", cbLDAPSecurity.Text);

                AddSetting(settings, "UserAttribute", tbOTPAttribute.Text);
                AddSetting(settings, "OTPDefaultDescription", tbOTPDescription.Text);
                AddSetting(settings, "OTPAccountDesciption", tbOTPAccountDesc.Text);


                if (cbEmailConfig.Checked)
                {
                    AddSetting(settings, "UseEmail", "0");
                }
                else
                {
                    AddSetting(settings, "UseEmail", "1");
                }
              
                AddSetting(settings, "SMTPServer", tbSMTPServer.Text);
                AddSetting(settings, "SMTPPort", tbSMTPPort.Text);
                

                string smtpuserenc = SimmetricAES.EncryptString(tbSMTPUsername.Text);
                AddSetting(settings, "SMTPUsername", smtpuserenc);

                string smtppassenc = SimmetricAES.EncryptString(tbSMTPPassword.Text);
                AddSetting(settings, "SMTPPassword", smtppassenc);

                if (cbSMTPSSL.Checked)
                {
                    AddSetting(settings, "SMTPSSL", "1");
                }
                else
                {
                    AddSetting(settings, "SMTPSSL", "0");
                }

                string smtpfromenc = SimmetricAES.EncryptString(tbSMTPFrom.Text);                                       
                AddSetting(settings, "SMTPFrom", smtpfromenc);
                AddSetting(settings, "SMTPSubject", tbSMTPSubject.Text);

                if (cbSMTPTemplate.SelectedItem != null) {
                    AddSetting(settings, "EmailTemplate", cbSMTPTemplate.Items[cbSMTPTemplate.SelectedIndex].ToString());
                }
                else
                {
                    AddSetting(settings, "EmailTemplate", "emailTemplate.md");
                }

                if (checkValues()) {

                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbEmailConfig_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;
            if (c.Checked) { disableEmailFields(); }
            else { enableEmailFields(); }
        }

        private void tbDomain_TextChanged(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(tbDomain.Text))){
                string tmp = tbDomain.Text;
                string[] arrtmp = tmp.Split('.');
                string dn = "";
                foreach (string r in arrtmp)
                {
                    dn = dn + ", DC=" + r;
                }
                dn= dn.Substring(1);
                tbBaseDN.Text = dn.Trim();
            }
        }
    }
}
