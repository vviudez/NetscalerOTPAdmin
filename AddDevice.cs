using System;
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

namespace NetscalerOTPAdmin
{
	public partial class frmAddDevice : Form
	{
		public LDAP objLDAP { get; set; }
		public string username { get; set; }
		public string email { get; set; }
		public string displayname { get; set; }

		private string UseEmail;
		private string userAttribute;
		private string OTPDefaultDescription;
		private string OTPAccountDesciption;
		private string SMTPTemplate;

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

        public frmAddDevice()
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
			if (UseEmail == "0")
			{
				btnEmail.Enabled = false;
			}

            userAttribute = getUserSetting(settings, "UserAttribute");
            OTPDefaultDescription = getUserSetting(settings, "OTPDefaultDescription");
            OTPAccountDesciption = getUserSetting(settings, "OTPAccountDesciption");
            SMTPTemplate = getUserSetting(settings, "EmailTemplate");

            tbIssuer.Text = OTPAccountDesciption;
        }

		private void frmAddDevice_Shown(object sender, EventArgs e)
		{
			tbOTPDescription.Text = OTPDefaultDescription;

			btnSave.Enabled = false;
			btnEmail.Enabled = false;
		}


		private static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
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
			generateSeed();
		}

		private void generateSeed()
		{
			if (!(String.IsNullOrEmpty(username)))
			{
				userDirectoryEntry = objLDAP.searchUser(username);

				Secret = Base32Encoding.ToString(KeyGeneration.GenerateRandomKey(20));

				qrCodeUri = $"otpauth://totp/{Uri.EscapeDataString(OTPAccountDesciption)}:{Uri.EscapeDataString(username)}?secret={Secret}&device={Uri.EscapeDataString(tbOTPDescription.Text)}";
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
					qrCodeB64.Dispose();
				}

				qrGenerator.Dispose();

				tbQRCode.Text = Secret;
				btnSave.Enabled = true;				
				if (UseEmail == "0")
				{
					btnEmail.Enabled = false;
				}
				else
				{
					btnEmail.Enabled = true;
				}
			}
		}


		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private bool addSeedOnUser()
		{
            // Adding the new device/seed on userparamter
            string allseeds = objLDAP.GetAttribute(username, userAttribute);
			string seedvalue = OTPSeeds.AddNewSeed(allseeds, tbOTPDescription.Text, Secret);

            return objLDAP.updateUser(userDirectoryEntry, seedvalue);
		}


		private void btnSave_Click(object sender, EventArgs e)
		{
            if (addSeedOnUser())
            {
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
				+ "background - color:#fff;}"
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

					htmlEmail = Regex.Replace(htmlEmail, "{{user}}", username);
					htmlEmail = Regex.Replace(htmlEmail, "{{qrCodeBase64}}", qrCodeImageAsBase64);
					htmlEmail = Regex.Replace(htmlEmail, "{{Secret}}", Secret);
					htmlEmail = Regex.Replace(htmlEmail, "{{qrCodeUri}}", qrCodeUri);

					frmEmail frm = new frmEmail();
					frm.htmlEmail = htmlEmail;
					frm.displayName = displayname; 
					frm.userEmail = email;
					frm.pntLocation = new Point(this.Location.X + 20, this.Location.Y + 20);
					frm.ShowDialog();

					frm.Dispose();

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

		private void tbOTPDescription_TextChanged(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(tbOTPDescription.Text))
			{
				btnAddDevice.Enabled = false;
			}
			else
			{
				btnAddDevice.Enabled = true;
			}
		}

		private void frmAddDevice_Load(object sender, EventArgs e)
		{
			this.Location = pntLocation;
		}
	}

}
