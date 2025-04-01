using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using OtpNet;
using QRCoder;

namespace NetscalerOTPAdmin
{
    public partial class frmShowQR : Form
    {
		public string DeviceName { get; set; }
		public string Seed { get; set; }


		private string OTPAccountDesciption;

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

        public frmShowQR()
        {
            InitializeComponent();
			baseDir = AppDomain.CurrentDomain.BaseDirectory;

            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string userDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            userAppDir = userDir + "\\NetscalerOTPAdmin\\";

            string userAppConfigFile = userAppDir + "user.config";
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = userAppConfigFile;

            // Get the mapped configuration file.
            Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            OTPAccountDesciption = getUserSetting(settings, "OTPAccountDesciption");

		}

        private void btnClose_Click(object sender, EventArgs e)
        {
			this.Close();
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

		private void frmEditDevice_Shown(object sender, EventArgs e)
        {
			lblDevice.Text = "Device: " + DeviceName;
			tbSeed.Text = Seed;

			qrCodeUri = $"otpauth://totp/{Uri.EscapeDataString(OTPAccountDesciption)}?secret={Seed}&device={Uri.EscapeDataString(DeviceName)}";
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
		}

		private void btnSaveQR_Click(object sender, EventArgs e)
		{
            FileDialog sfd = null;

            try
			{
				using (sfd = new SaveFileDialog())
				{
					sfd.Title = "Save QR as JPG";
					sfd.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
					sfd.FilterIndex = 1;
					sfd.RestoreDirectory = true;

					if (sfd.ShowDialog() == DialogResult.OK)
					{
						pbQRCode.Image.Save(sfd.FileName, ImageFormat.Jpeg);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Save JPG error: " + ex.ToString());
				throw;
			}
			finally
			{
				sfd?.Dispose();
			}

        }

		private void frmShowQR_Load(object sender, EventArgs e)
		{
			this.Location = pntLocation;
		}
	}
}
