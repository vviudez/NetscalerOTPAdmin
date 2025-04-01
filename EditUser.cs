using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using System.Configuration;

namespace NetscalerOTPAdmin
{
    public partial class frmEditUser : Form
    {
        public LDAP objLDAP { get; set; }
        public string username { get; set; }
        public string displayname { get; set; }

        private string UseEmail; 
        private string userAttribute;
        private string OTPDefaultDescription;
        private string OTPAccountDesciption;
        private string SMTPTemplate;
        private string email;

        private string qrCodeUri;
        private string qrCodeImageAsBase64;

        private string baseDir;
        private string userAppDir;
        public Point pntLocation;

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

        public frmEditUser()
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
            var settings = configFile.AppSettings.Settings;

            UseEmail = getUserSetting(settings, "UseEmail"); 
            userAttribute = getUserSetting(settings, "UserAttribute");
            OTPDefaultDescription = getUserSetting(settings, "OTPDefaultDescription");
            OTPAccountDesciption = getUserSetting(settings, "OTPAccountDesciption");
            SMTPTemplate = getUserSetting(settings, "EmailTemplate");

        }

        private class Seed
        {
            string device;
            string seedtoken;
            string edit;
            string remove;
            string email;
            string qr;
            public Seed(string device, string seedtoken)
            {
                this.device = device;
                this.seedtoken = seedtoken;
                this.edit = "Edit";
                this.remove = "Remove";
                this.email = "Send Email";
                this.qr = "Show QR";
            }
            public string Device
            {
                get { return device; }
                set { device = value; }
            }
            public string SeedToken
            {
                get { return seedtoken; }
                set { seedtoken = value; }
            }
            public string Edit
            {
                get { return edit; }
                set { edit = value; }
            }
            public string Remove
            {
                get { return remove; }
                set { remove = value; }
            }

            public string Email
            {
                get { return email; }
                set { email = value; }
            }
            public string QR
            {
                get { return qr; }
                set { qr = value; }
            }
        }

        private void frmEditUser_Shown(object sender, EventArgs e)
        {
            populateDeviceList(true);

            email=objLDAP.GetEmail(username);
        }

        private void populateDeviceList(bool firstTime)
        {
            olvSeeds.Items.Clear();
            lblUser.Text = "Selected User: " + displayname + " (" + username + ")";

            string seeds = objLDAP.GetAttribute(username, objLDAP.userAttribute);
            seeds = seeds.Substring(2);

            string[] arr_seeds = seeds.Split(',');

            foreach (string seedt in arr_seeds)
            {
                string[] seedarr = seedt.Split('=');
                if (seedt != "")
                {
                    Seed s = new Seed(seedarr[0], seedarr[1].TrimEnd('&'));
                    olvSeeds.AddObject(s);
                }
            }

            if (firstTime)
            {
            this.olvSeeds.ButtonClick += delegate (object sender2, CellClickEventArgs e2)
            {
                //MessageBox.Show(String.Format("Button clicked: (ROW: {0}, SUBITEM: {1}, MODEL: {2})", e2.RowIndex, e2.SubItem.Text, e2.Model));
                switch (e2.SubItem.Text)
                {
                    case "Edit":
                        //MessageBox.Show(String.Format("EDIT Button clicked: (ROW: {0}, DEVICE: {1}, SEED: {2})", e2.RowIndex, this.olvSeeds.Items[e2.RowIndex].SubItems[0].Text, this.olvSeeds.Items[e2.RowIndex].SubItems[1].Text));

                        frmEditDevice frmE = new frmEditDevice();
                        
                        frmE.objLDAP = objLDAP;
                        frmE.username = username;
                        //frmE.objUser = objUser;
                        frmE.username = username;
                        frmE.DeviceName = this.olvSeeds.Items[e2.RowIndex].SubItems[0].Text;
                        frmE.Seed = this.olvSeeds.Items[e2.RowIndex].SubItems[1].Text;
                        frmE.pntLocation = new Point(this.Location.X + 20, this.Location.Y + 20);

                        frmE.ShowDialog();
                        frmE.Dispose();

                        populateDeviceList(false);

                        break;
                    case "Remove":
                        try { 
                            // Show a Warning to the user, to allow to remove the Device/Seed selected.
                            if (MessageBox.Show(string.Format("Warning, If you continue you will REMOVE the seed defined for the device {0}!!\n\nDo you want to remove the seed {1}?", this.olvSeeds.Items[e2.RowIndex].SubItems[0].Text, this.olvSeeds.Items[e2.RowIndex].SubItems[1].Text), "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                // Once accepted, we remove the Device/Seed from the list
                                this.olvSeeds.Items.RemoveAt(e2.RowIndex);

                                // After the row remove, we compile a list of Device/Seeds remaining
                                string updatedattribute = OTPSeeds.RegenerateSeedString(olvSeeds.Items);
                                                        
                                // After the list is compiled, we update the attribute of the user
                                objLDAP.updateUser(username, updatedattribute);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "Send Email":
                        //MessageBox.Show(String.Format("SEND EMAIL Button clicked: (ROW: {0}, DEVICE: {1}, SEED: {2})", e2.RowIndex, this.olvSeeds.Items[e2.RowIndex].SubItems[0].Text, this.olvSeeds.Items[e2.RowIndex].SubItems[1].Text));

                        QRCodeGenerator qrGenerator = new QRCodeGenerator();
                        string seed = this.olvSeeds.Items[e2.RowIndex].SubItems[1].Text;
                        qrCodeUri = $"otpauth://totp/{Uri.EscapeDataString(OTPAccountDesciption)}?secret={seed}&device={Uri.EscapeDataString(this.olvSeeds.Items[e2.RowIndex].SubItems[0].Text)}";
                        using (var qrCodeData = qrGenerator.CreateQrCode(qrCodeUri, QRCodeGenerator.ECCLevel.Q))
                        {
                            var qrCode = new QRCode(qrCodeData);

                            var imgType = Base64QRCode.ImageType.Jpeg;
                            Base64QRCode qrCodeB64 = new Base64QRCode(qrCodeData);
                            qrCodeImageAsBase64 = qrCodeB64.GetGraphic(20, Color.Black, Color.White, true, imgType);
                        }

                        //string originalFile = "emailTemplate.md";
                        string originalFile = SMTPTemplate;

                        //string htmlEmail = string.Empty;
                        string htmlEmail = "<html><head><style>"
                        + "body {"
                        + "background - color:#d2E0EF;}"
                        + "h2 { color: blue; }"
                        + "strong { color: blue; }"
                        + "* { font - family: Consolas; }"
                        + "</style></head>"
                        + "<body>"
                        + "<h2>OTP QR Code for: {{user}}</h2>"
                          + "<h3>Please scan the code with an Authenticator(Microsoft Authenticator, Google Authenticator, etc...)</h3>"
                        + "<img alt = 'Embedded QR Code' width = '200' src = 'data:image/jpg;base64,{{qrCodeBase64}}' />"
                        + "<br/><p>Secret: {{Secret}}<br/>"
                        + "<p><a href='{{qrCodeUri}}'>Auth Link</a>"
                        + "</body></html>";

                        try
                        {

                            if (File.Exists(originalFile))
                            {
                                using (StreamReader reader = new StreamReader(originalFile))
                                {
                                    htmlEmail = reader.ReadToEnd();
                                    reader.Close();
                                }
                            }

                            htmlEmail = Regex.Replace(htmlEmail, "{{user}}", username);
                            htmlEmail = Regex.Replace(htmlEmail, "{{qrCodeBase64}}", qrCodeImageAsBase64);
                            htmlEmail = Regex.Replace(htmlEmail, "{{Secret}}", seed);
                            htmlEmail = Regex.Replace(htmlEmail, "{{qrCodeUri}}", qrCodeUri);

                            frmEmail frm = new frmEmail();
                            frm.htmlEmail = htmlEmail;
                            frm.displayName = displayname;
                            frm.userEmail = email;
                            frm.pntLocation = new Point(this.Location.X + 20, this.Location.Y + 20);
                            frm.ShowDialog();

                            frm.Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error generating email template: " + ex.Message);
                        }

                        break;
                    case "Show QR":
                        //MessageBox.Show(String.Format("SHOW QR Button clicked: (ROW: {0}, DEVICE: {1}, SEED: {2})", e2.RowIndex, this.olvSeeds.Items[e2.RowIndex].SubItems[0].Text, this.olvSeeds.Items[e2.RowIndex].SubItems[1].Text));
                        frmShowQR frmQR = new frmShowQR();

                        frmQR.DeviceName = this.olvSeeds.Items[e2.RowIndex].SubItems[0].Text;
                        frmQR.Seed = this.olvSeeds.Items[e2.RowIndex].SubItems[1].Text;
                        frmQR.pntLocation = new Point(this.Location.X + 20, this.Location.Y + 20);
                        frmQR.ShowDialog();

                        frmQR.Dispose();
                        break;
                    default: // code block 
                        break;
                }

                // If something about the object changed, you probably want to refresh the model                             
                this.olvSeeds.RefreshObject(e2.Model);
            };
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.olvSeeds.Dispose();
            this.Close();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            frmAddDevice frm = new frmAddDevice();

            frm.objLDAP = objLDAP;
            frm.username = username;
            frm.email = email;
            frm.displayname = displayname;
            frm.pntLocation = new Point(this.Location.X + 20, this.Location.Y + 20);
            frm.ShowDialog();

            frm.Dispose();
            populateDeviceList(false);

        }

        private void frmEditUser_Load(object sender, EventArgs e)
        {
            this.Location = pntLocation;
        }
    }
}
