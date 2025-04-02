using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using OtpNet;
using QRCoder;

namespace NetscalerOTPAdmin
{
    public partial class frmEditDevice : Form
    {
        CultureInfo CurrentCulture = new CultureInfo("es-ES");

        public LDAP objLDAP { get; set; }
		public string username { get; set; }
		public string DeviceName { get; set; }
		public string Seed { get; set; }

		private string OTPDefaultDescription;
		private string OTPAccountDesciption;

		private string qrCodeUri;
		private string qrCodeImageAsBase64;

		private string baseDir;
        private string userAppDir;
        //public Point pntLocation;


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

        public frmEditDevice()
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

            OTPDefaultDescription = getUserSetting(settings, "OTPDefaultDescription");
            OTPAccountDesciption = getUserSetting(settings, "OTPAccountDesciption");

		}

        private void btnOk_Click(object sender, EventArgs e)
        {
			// If the device name is not empty or not changed, we do nothing
			if (!string.IsNullOrEmpty(tbDevice.Text) && (tbDevice.Text != DeviceName)) { 
				// Grab all Seeds on the user attribute
				string seeds = objLDAP.GetAttribute(username, objLDAP.userAttribute);

				string updatedattribute = OTPSeeds.RenameDevice(seeds, DeviceName, tbDevice.Text);
				
				objLDAP.updateUser(username, updatedattribute);

				this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private static Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));
            System.Drawing.Bitmap bitmap = null;

            try
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder();
                    enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                    enc.Save(outStream);
                    bitmap = new Bitmap(outStream);

                    return new Bitmap(bitmap);
                }
            }
            catch
            {
                // Dispose bitmap if an exception occurs
                if (bitmap != null) bitmap.Dispose();
                throw;
            }
        }

        private void frmEditDevice_Shown(object sender, EventArgs e)
        {
			tbDevice.Text = DeviceName;
			tbSeed.Text = Seed;

			qrCodeUri = $"otpauth://totp/{Uri.EscapeDataString(OTPAccountDesciption)}?secret={Seed}&device={Uri.EscapeDataString(tbDevice.Text)}";
			
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
                qrCode.Dispose();
                qrCodeB64.Dispose();
            }

			qrGenerator.Dispose();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Dispose of the image when the form is closed
            if (pbQRCode.Image != null)
            {
                pbQRCode.Image.Dispose();
                pbQRCode.Image = null;
            }

            base.OnFormClosed(e);
        }
    }
}
