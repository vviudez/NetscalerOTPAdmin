using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetscalerOTPAdmin
{
    public partial class frmEmail : Form
    {
        public string htmlEmail { get; set; }
        public string displayName { get; set; }
        public string userEmail { get; set; }

        //IniFile ini;
        private string baseDir;
        private string userAppDir;
        public Point pntLocation;
        KeyValueConfigurationCollection settings;

        public frmEmail()
        {
            InitializeComponent();

            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string userDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            userAppDir = userDir + "\\NetscalerOTPAdmin\\";

            string userAppConfigFile = userAppDir + "user.config";
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = userAppConfigFile;

            // Get the mapped configuration file.
            Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            settings = configFile.AppSettings.Settings;
        }

        private string getUserSetting(KeyValueConfigurationCollection col, string settingName)
        {
            string SettingValue = "";

            if (col[settingName] != null)
            {
                SettingValue = col[settingName].Value;
            }

            return SettingValue;
        }

        private void frmEmail_Shown(object sender, EventArgs e)
        {
            tbDisplayName.Text = displayName;
            tbEmail.Text = userEmail;
            wbDisplayEmail.DocumentText=htmlEmail;

            string UseEmail = getUserSetting(settings, "UseEmail");
            if (UseEmail == "0") {
                btnSendEmail.Enabled = false;
            }
        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            string token = (string)e.UserState;
            string msg = "";

            if (e.Cancelled)
            {
                msg="["+token+"] Send canceled.";
            }
            if (e.Error != null)
            {
                msg="["+token+"] " + e.Error.ToString();
            }
            else
            {
                msg="Message sent!";
            }

            MessageBox.Show(msg);
            btnSendEmail.Enabled = true;
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                string SMTPServer = getUserSetting(settings, "SMTPServer");
                string SMTPPort = getUserSetting(settings, "SMTPPort");
                string SMTPUsername = getUserSetting(settings, "SMTPUsername");
                SMTPUsername = SimmetricAES.DecryptString(SMTPUsername);
                string SMTPPassword = getUserSetting(settings, "SMTPPassword");
                SMTPPassword = SimmetricAES.DecryptString(SMTPPassword);
                string SMTPSSL = getUserSetting(settings, "SMTPSSL");
                string SMTPFrom = getUserSetting(settings, "SMTPFrom");
                SMTPFrom = SimmetricAES.DecryptString(SMTPFrom);
                string SMTPSubject = getUserSetting(settings, "SMTPSubject");

                SmtpClient mySmtpClient = new SmtpClient(SMTPServer);
                mySmtpClient.Port = int.Parse(SMTPPort);

                mySmtpClient.EnableSsl = false; 
                if (SMTPSSL=="1") mySmtpClient.EnableSsl = true;

                mySmtpClient.Timeout = 60;

                // set smtp-client with basicAuthentication
                mySmtpClient.UseDefaultCredentials = false;
                mySmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                System.Net.NetworkCredential basicAuthenticationInfo = new
                System.Net.NetworkCredential(SMTPUsername, SMTPPassword);
                mySmtpClient.Credentials = basicAuthenticationInfo;

                // add from,to mailaddresses
                MailAddress from = new MailAddress(SMTPFrom, "OTP Configuration");
                MailAddress to = new MailAddress(userEmail, displayName);
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                //MailAddress replyTo = new MailAddress("reply@example.com");
                //myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = SMTPSubject;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = htmlEmail;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                //mySmtpClient.Send(myMail);
                mySmtpClient.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                string userState = "Send OTP";
                mySmtpClient.SendAsync(myMail, userState);
                //mySmtpClient.SendMailAsync(myMail);
                btnSendEmail.Enabled = false;
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException("Exception on SMTP module has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            //htmlEmail
            try
            {
                using (var sfd = new SaveFileDialog())
                {
                    sfd.Title = "Save Email Data";
                    sfd.Filter = "html files (*.html)|*.html|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    sfd.FilterIndex = 1;
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, htmlEmail);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            this.Location = pntLocation;
        }
    }
}
