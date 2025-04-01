using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using OtpNet;
using QRCoder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NetscalerOTPAdmin
{
	public partial class frmAddUser : Form
	{
		public LDAP objLDAP { get; set; }

		//readonly QRCodeGenerator qrGenerator = new QRCodeGenerator();

		private string userAttribute;
		private string OTPDefaultDescription;
		private string OTPAccountDesciption;
		private string SMTPTemplate;
		private string usernameSelected;
		private string displayname;
		private string email;

		private string qrCodeUri;
		private string qrCodeImageAsBase64;
		private string Secret;

		private string baseDir;
        private string userAppDir;
        public Point pntLocation;

        SearchResultEntry userDirectoryEntry;

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

        public frmAddUser()
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

            userAttribute = getUserSetting(settings, "UserAttribute");
            OTPDefaultDescription = getUserSetting(settings, "OTPDefaultDescription");
            OTPAccountDesciption = getUserSetting(settings, "OTPAccountDesciption");
            SMTPTemplate = getUserSetting(settings, "EmailTemplate");

        }

        private void btnSearch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrWhiteSpace(tbUserName.Text) || tbUserName.Text.Contains("*") )
			{
				// Nothing
				tbUserName.Text = "";
			}
			else
			{
				lvFoundUsers.Items.Clear();
				lvFoundUsers.Refresh();

				foreach (SearchResultEntry result in objLDAP.searchNoOTPUsers(tbUserName.Text))
				{
					string username = result.Attributes["samaccountname"][0].ToString();

					// Need to filtering users????
					//if ( (username != "Administrator") && (username != "Administrador") && (username != "Guest") && (username != "Invitado"))
					//{

					displayname = username;
					email = username + "@" + objLDAP.ldapDomain;

					if (result.Attributes["displayName"] != null)
					{
						if (result.Attributes["displayName"].Count > 0)
						{
							displayname = result.Attributes["displayName"][0].ToString();
						}
					}
					if (result.Attributes["mail"] != null)
					{
						// if there's at least one email address
						if (result.Attributes["mail"].Count > 0)
						{
							email = result.Attributes["mail"][0].ToString();
						}
					}

					ListViewItem item = new ListViewItem(new[] { username, displayname, email });
					lvFoundUsers.Items.Add(item);

					//}

				}

			}
		}

		private void lvFoundUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvFoundUsers.SelectedItems.Count > 0)
			{
				//ListView lv = (ListView)sender;
				ListViewItem user = lvFoundUsers.SelectedItems[lvFoundUsers.SelectedItems.Count - 1];
				usernameSelected = user.SubItems[0].Text;
				displayname = user.SubItems[1].Text;
				email = user.SubItems[2].Text;

				btnAddDevice.Enabled = true;
				btnAddDevice.BackColor= System.Drawing.Color.FromArgb(255, 192, 255);
				tbOTPDescription.Enabled = true; 
				tbOTPDescription.Text = OTPDefaultDescription;
				btnSave.Enabled = false;
				btnEmail.Enabled = false;
			}
			else
			{
				usernameSelected = "";
				displayname = "";
				email = "";
				btnAddDevice.BackColor = System.Drawing.Color.LightGray;
				tbOTPDescription.Enabled = false;
				btnAddDevice.Enabled = false;
				btnSave.Enabled = false;
				btnEmail.Enabled = false;
			}
		}

		private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
		{
			// BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

			using (MemoryStream outStream = new MemoryStream())
			{
				BitmapEncoder enc = new BmpBitmapEncoder();
				enc.Frames.Add(BitmapFrame.Create(bitmapImage));
				enc.Save(outStream);
				System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);

				return new Bitmap(bitmap);
			}
		}

		private void btnAddDevice_Click(object sender, EventArgs e)
		{
			if (!(String.IsNullOrEmpty(usernameSelected)))
			{
				userDirectoryEntry = objLDAP.searchUser(usernameSelected);

                Secret = Base32Encoding.ToString(KeyGeneration.GenerateRandomKey(20));

				qrCodeUri = $"otpauth://totp/{Uri.EscapeDataString(OTPAccountDesciption)}?secret={Secret}&device={Uri.EscapeDataString(tbOTPDescription.Text)}";
                
				QRCodeGenerator qrGenerator = new QRCodeGenerator();

                using (var qrCodeData = qrGenerator.CreateQrCode(qrCodeUri, QRCodeGenerator.ECCLevel.Q))
				{
					var qrCode = new QRCode(qrCodeData);
					
					var imgType = Base64QRCode.ImageType.Jpeg;
					Base64QRCode qrCodeB64 = new Base64QRCode(qrCodeData);
					qrCodeImageAsBase64 = qrCodeB64.GetGraphic(20, Color.Black, Color.White, true, imgType);

					using (qrCode)
					{
						var qrCodeImage = qrCode.GetGraphic(20);

						using (var memory = new MemoryStream())
						{
							qrCodeImage.Save(memory, ImageFormat.Bmp);
							memory.Position = 0;
							var bitmapImage = new BitmapImage();
							bitmapImage.BeginInit();
							bitmapImage.StreamSource = memory;
							bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
							bitmapImage.EndInit();

							
							pbQRCode.Image = BitmapImage2Bitmap(bitmapImage);
							
						}
					}
				}
				tbQRCode.Text = Secret;
				btnSave.Enabled = true;
				btnEmail.Enabled = true;

				qrGenerator.Dispose();
            }

		}

		private void frmAddUser_Shown(object sender, EventArgs e)
		{			
			usernameSelected = "";
			btnAddDevice.BackColor = System.Drawing.Color.LightGray;
			tbOTPDescription.Enabled = false;
			tbOTPDescription.Text = "";
			btnAddDevice.Enabled = false;
			btnSave.Enabled = false;
			btnEmail.Enabled = false;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private bool addSeedOnUser()
		{
            
            // Adding the new device/seed on userparamter to the user
            string allseeds = objLDAP.GetAttribute(usernameSelected, userAttribute);
            string seedvalue = OTPSeeds.AddNewSeed(allseeds, tbOTPDescription.Text, Secret);

            return objLDAP.updateUser(userDirectoryEntry, seedvalue);
		}


		private void btnSave_Click(object sender, EventArgs e)
		{
			if (addSeedOnUser()) { 
				MessageBox.Show("Seed save completed!");
            }
            else
            {
                MessageBox.Show("Error in saving this Seed!");
            }

            this.Close();
		}

		private void btnEmail_Click(object sender, EventArgs e)
		{
            if (addSeedOnUser())
            {
                MessageBox.Show("Seed save completed!\nPreparing email template....");

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

				try {

					if (File.Exists(originalFile))
					{
						using (StreamReader reader = new StreamReader(originalFile))
						{
							htmlEmail = reader.ReadToEnd();
							reader.Close();
						}
					}

					htmlEmail = Regex.Replace(htmlEmail, "{{user}}", usernameSelected);
					htmlEmail = Regex.Replace(htmlEmail, "{{qrCodeBase64}}", qrCodeImageAsBase64);
					htmlEmail = Regex.Replace(htmlEmail, "{{Secret}}", Secret);
					htmlEmail = Regex.Replace(htmlEmail, "{{qrCodeUri}}", qrCodeUri);

					frmEmail frm = new frmEmail();
					frm.htmlEmail = htmlEmail;
					frm.displayName = displayname; 
					frm.userEmail = email;
					frm.pntLocation = new Point(this.Location.X + 20, this.Location.Y + 20);
					frm.ShowDialog();

					this.Close();

				}
				catch(Exception ex)
				{
					MessageBox.Show("Error generating email template: " + ex.Message);
				}
            }
			else
			{
                MessageBox.Show("Error in saving this Seed!");
            }
        }

		private void frmAddUser_Load(object sender, EventArgs e)
		{
			this.Location = pntLocation;
		}
	}

}
