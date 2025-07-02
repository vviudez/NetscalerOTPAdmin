using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.Protocols;
using System.Drawing;
using System.Globalization;
using System.Text.Json;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static NetscalerOTPAdmin.OTPSeeds;


namespace NetscalerOTPAdmin
{
    public partial class MainForm : Form
    {
        CultureInfo CurrentCulture = new CultureInfo("es-ES");

        private string MasterPasswd;
        static public string MasterPasswdUser { get; set; }
		private string ldapServer;
		private string ldapUser;
		private string ldapPass;
		private string ldapDomain;
		private string ldapBaseDN;
        private string ldapProtocol;
        private string userAttribute;
		private string OTPDefaultDescription;
		private string OTPAccountDesciption;
        private string OTPEncrypt;
        private string OTPCertificate;
        private string OTPPrivateKey;

        private string baseDir;
		private string userAppDir;


        List<ListViewItem> allItems = new List<ListViewItem>();
		private LDAP objLDAP = new LDAP();


		public MainForm()
        {
            InitializeComponent();
			
			Log("Initializing...");
			
			// Grab the base directory where the app is runnning
			baseDir = AppDomain.CurrentDomain.BaseDirectory;
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

        private void loadConfig()
		{
			Log("Loading configuration from user.config");

			// Load the needed config variables from the INI file

			string userDir=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            userAppDir = userDir + "\\NetscalerOTPAdmin\\";


            string userAppConfigFile = userAppDir + "user.config";
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = userAppConfigFile;

            // Get the mapped configuration file.
            Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            MasterPasswd = getUserSetting(settings, "MPwd");
            //MasterPasswd = ini.IniReadValue("AppPermissions", "MPwd");

            ldapServer = getUserSetting(settings, "LDAP");
            ldapUser = getUserSetting(settings, "User");
            ldapPass = getUserSetting(settings, "Password");
            ldapDomain = getUserSetting(settings, "Domain");
            ldapBaseDN = getUserSetting(settings, "BaseDN");
            ldapProtocol = getUserSetting(settings, "Protocol");

            userAttribute = getUserSetting(settings, "UserAttribute");
            OTPDefaultDescription = getUserSetting(settings, "OTPDefaultDescription");
            OTPAccountDesciption = getUserSetting(settings, "OTPAccountDesciption");
            OTPEncrypt = getUserSetting(settings, "OTPEncrypt");
            OTPCertificate = getUserSetting(settings, "OTPCertificate");
            OTPPrivateKey = getUserSetting(settings, "OTPPrivateKey");

        }

		private void startProcess()
		{
            loadConfig(); 
			Log("Configuration loaded!");
            
			Log("Master password needed");
            frmMasterPasswd frmMP = new frmMasterPasswd();
            frmMP.ShowDialog();

            frmMP.Dispose();

            Log("Master password check");

            MasterPasswd = MasterPasswd.Substring(10, MasterPasswd.Length - 20);
            //AESKey = MasterPasswd.Substring(0, 32);

            if (MasterPasswdUser == MasterPasswd)
            {
                Log("Master password correct!!!");
            }
            else
            {
                Log("Master password incorrect!!!");
                MessageBox.Show("Access Denied. Error in Master Password\r\nClosing application!");
                Application.Exit();
            }

            // Config seems to have the minimum variables correct defined
            lbLDAPServer.Text = "LDAP Server: " + ldapServer;

            // After initialization, first we need to connect to the LDAP server and search the users 
            // that already have an OTP seed defined on the selected attribute
            searchOTPUsers();
        }


		private void MainForm_Shown(object sender, EventArgs e)
		{
			// Call the function to load config variables.
			loadConfig();

			// Check some variables to dertermine if the config is complete or not
			if ((String.IsNullOrEmpty(MasterPasswd)) || (String.IsNullOrEmpty(ldapServer)) || (String.IsNullOrEmpty(ldapUser)) || (String.IsNullOrEmpty(ldapPass)))
			{
				// If config is not complete, show the Settings form
				Log("Configuration incomplete!");
				frmSettings frm = new frmSettings();
				frm.ShowDialog();

				frm.Dispose();
            }
			startProcess();
        }

		/*
		private PrincipalContext GetPrincipalContext(string sOU)
		{
			PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Domain, ldapDomain, sOU, ContextOptions.SimpleBind, ldapUser, ldapPass);
			return oPrincipalContext;
		}
		*/
		private void searchOTPUsers()
		{
			try
			{
				// Populate the LDAP object with the variables from the config file
				//objLDAP.AESKey = AESKey;
				objLDAP.ldapServer = ldapServer;
				objLDAP.ldapUser = ldapUser;
				objLDAP.ldapPass = ldapPass;
				objLDAP.ldapDomain = ldapDomain;
				objLDAP.ldapBaseDN = ldapBaseDN;
				objLDAP.ldapProtocol = ldapProtocol;
                objLDAP.userAttribute = userAttribute;

				// Try to make the binding with the LDAP server. If this function can't connect generates an Exception,
				// captured by the catch part.
				Log("Trying to connect to the LDAP server...");
				objLDAP.ldapConnect();

				// If no exception is raised, the binding is ok
				Log("Binding OK!");

				// Now we make a query to the LDAP Server to retrieve all users with an OTP enabled.
				Log("Listing users with OTP attribute defined...");
				foreach (SearchResultEntry result in objLDAP.SearchOTPUsers())
				{
					

					// Grab the samaccountname attribute as username
					string username = result.Attributes["samaccountname"][0].ToString();

					// Grab the displayname attribute if is populated
					string displayname = "";
					if (result.Attributes["displayName"] != null)
					{
						if (result.Attributes["displayName"].Count > 0)
						{
							displayname = result.Attributes["displayName"][0].ToString();
						}
					}

					// Grab the attribute where is configured to save the OTP Seeds.
					string attribute = result.Attributes[userAttribute][0].ToString();




					// Add the info of the user to the listview
					ListViewItem item = new ListViewItem(new[] { username, displayname, attribute });
					lvUsers.Items.Add(item);

				}

				// Once the listing is completed, we make a list "backup" with all the items on the user listview 
				// This backup will function as repopulate method for the Filter function.
				Log("Listing completed");
				allItems.Clear();
				allItems.AddRange(lvUsers.Items.Cast<ListViewItem>());
			}
            catch (CryptographicException ce)
            {
                // Exception catching, basically if problem with cryptographic modules
                Log("ERROR: Can't read config file - Incorrect encryption!");
                MessageBox.Show("Can't read config file. " + Environment.NewLine + "Incorrect encryption!" + Environment.NewLine + Environment.NewLine + ce.Message);
            }
            catch
			{
				// Exception catching, basically if a LDAP binding problem occurs. Possible uncaught exceptions.... 
				Log("ERROR: Can't connect to the LDAP Server");
				throw;				
			}

        }

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			frmSettings frm = new frmSettings();

			// Capture event of the close of Settings form, in order to reload the config
			frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmSettings_FormClosed);

			// Open the Setting form as modal
			frm.ShowDialog();
            // Dispose the form once closed
            frm.Dispose();
		}
		private void frmSettings_FormClosed(object sender, EventArgs e)
		{
			// Reload the config file
			loadConfig();
		}

		/************
		 * Log function
		 * 
		 * - Prints on the Log textbox the message passed as parameter
		 * 
		*************/

		private void Log(string s)
		{
			try { 
				// Append the parameter string to the log textbox
				tbLog.AppendText(Environment.NewLine + s);
				// And position the cursor on the last character, to make a scroll 
				tbLog.Select(tbLog.Text.Length, 0);
				tbLog.ScrollToCaret();
            }
			catch {
                MessageBox.Show("Can't append to log!");
				throw;
			}
        }

		private void lvUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			// When a row on the user listview is selected/clicked, we start to config
			// the rest of the components of the forms, to allow some operations

			// By default, the "Edit user" button is disabled and the seeds counter is 0
			btnEditUser.Enabled = false;
			lblDeviceSeeds.Text = "Device Seeds: 0";

			// We check if the change event is for selecting an item or deselecting.
			// If an item is selected, the counter must be higher than 0
			if (lvUsers.SelectedItems.Count > 0) {
				
				// We grab the selected row info
				ListViewItem user = lvUsers.SelectedItems[lvUsers.SelectedItems.Count - 1];
				string username = user.SubItems[0].Text;
				//string displayname = user.SubItems[1].Text; //not used
				string seeds = user.SubItems[2].Text;

                Log("Selected user: " + username + " SEEDS:" + seeds);

				string[] arr_seeds;

                if (seeds.Contains("{\"otpdata\":{\"devices\":{"))
				{
					Log("Selected encrypted seeds");


                    OTPRoot root = JsonSerializer.Deserialize<OTPRoot>(seeds);

                    Dictionary<string, string> devices = root.otpdata.devices;

					List <string> listseeds= new List<string>();

                    foreach (var device in devices)
                    {
						string plainseed = DecryptSeed(device.Value,OTPCertificate,OTPPrivateKey);

                        Log("DESC: " + device.Key + " -- SEED:" + plainseed);
						listseeds.Add(device.Key+"="+ plainseed);
                    }

                    //arr_seeds = devices.Select(kvp => $"{kvp.Key}:{kvp.Value}").ToArray();
					arr_seeds = listseeds.ToArray();

                }
				else
				{
                    Log("Selected plaintext seeds");
                    // Remove the first 2 chars of the seed string.
                    seeds = seeds.Substring(2);

                    // Split the multipe seeds, that are separated by ,
                    arr_seeds = seeds.Split(',');
                }


				// Clearing the TextBox to show the attributes
				attributes.Clear();

				// Print on the TextBox the list of seeds, to have a preview
				//int total_seeds = arr_seeds.Count() - 1;
                int total_seeds = arr_seeds.Length - 1;
                lblDeviceSeeds.Text = "Device Seeds: " + total_seeds.ToString(CurrentCulture);
				foreach (string seed in arr_seeds)
				{
					// add a seed and remove the last char &
					attributes.AppendText(seed.TrimEnd('&') + Environment.NewLine);
				}

				// and finally enable de Edit User button
				btnEditUser.Enabled = true;
			}			
		}


		

		private void btnAddUser_Click(object sender, EventArgs e)
		{
			frmAddUser frm = new frmAddUser();

			// Capture event of the close of AddUser form, in order to refresh the user listview
			frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmAddUser_FormClosed);

			// Pass the LDAP object
			frm.objLDAP = objLDAP;
			frm.Location = new Point(this.Location.X + 30, this.Location.Y + 30);
			// Open the Setting form as modal
			frm.ShowDialog();
            //userListRefresh();

            // Dispose the form once closed
            frm.Dispose();


        }
		private void btnEditUser_Click(object sender, EventArgs e)
		{
			frmEditUser frm = new frmEditUser();

			// Capture event of the close of EditUser form, in order to refresh the user listview
			frm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(frmEditUser_FormClosed);

			// Pass parameters to the form
			frm.objLDAP = objLDAP;
			frm.Location = new Point(this.Location.X + 30, this.Location.Y + 30);
			ListViewItem user = lvUsers.SelectedItems[lvUsers.SelectedItems.Count - 1];			
			frm.username = user.SubItems[0].Text;
			frm.displayname = user.SubItems[1].Text;

			// Open the Setting form as modal
			frm.ShowDialog();

			// Dispose the form once closed
            frm.Dispose();
        }

		private void frmAddUser_FormClosed(object sender, EventArgs e)
		{
			// Refresh the user listview on close the AddUser from
			Log("Add User form closed...");
			userListRefresh();

			btnEditUser.Enabled = false;
		}

		private void frmEditUser_FormClosed(object sender, EventArgs e)
		{
			// Refresh the user listview on close the EditUser from
			Log("Edit User form closed...");
			userListRefresh();

			btnEditUser.Enabled = false;
		}

		private void tbFilter_TextChanged(object sender, EventArgs e)
		{
			lvUsers.Items.Clear();   // clear all items we have on the user listview
			if (string.IsNullOrEmpty(tbFilter.Text))
			{
				lvUsers.Items.AddRange(allItems.ToArray());  // If no filter: add all items
				return;
			}
			// now we find all items that have a suitable text in any subitem/field/column
			var list = allItems.Cast<ListViewItem>()
							   .Where(x => x.SubItems
											.Cast<ListViewItem.ListViewSubItem>()
											.Any(y => y.Text.Contains(tbFilter.Text, StringComparison.OrdinalIgnoreCase)))
							   .ToArray();
			lvUsers.Items.AddRange(list);  // now we add the result on the listview
		}


		private void btnRefresh_Click(object sender, EventArgs e)
		{
			userListRefresh();
		}
		public void userListRefresh()
		{
			// Clear and refresh the user listview
			lvUsers.Items.Clear();
			lvUsers.Refresh();
			Log("Refreshing...");

			// Search for the users with OTP defined again and repopulate de user listview
			searchOTPUsers();
			
			// And refresh the user listview
			lvUsers.Refresh();
			Log("Refreshed...");

			// Now, clear de backup list, and regenerate using the new data on the user listview
			allItems.Clear();
			allItems.AddRange(lvUsers.Items.Cast<ListViewItem>());
		}



		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void btnClose_Click(object sender, EventArgs e)
		{
            Log("Closing application..."); 
			objLDAP.Dispose();            
            Application.Exit();
		}

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
            MessageBox.Show(Application.ProductName + "\nVersion " + Application.ProductVersion + "\n\nOTP administration for Native Netscaler authentication service.\n\n\nConfig loaded from:\n" + userAppDir + "user.config\n\n\n" + AssemblyCopyright,"About...",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
	}

}
