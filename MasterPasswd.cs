using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace NetscalerOTPAdmin
{
    public partial class frmMasterPasswd : Form
    {
        public frmMasterPasswd()
        {
            InitializeComponent();
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

            }
            return hash;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSubmitPasswd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbMPwd.Text))
            {
                string hashedpwd=ConvertToHash(tbMPwd.Text);
                MainForm.MasterPasswdUser = hashedpwd;

                this.Close();
            }
        }

        private void tbMPwd_TextChanged(object sender, EventArgs e)
        {
            if (tbMPwd.Text.Length > 0) {
                btnSubmitPasswd.Enabled = true;
            }
            else
            {
                btnSubmitPasswd.Enabled = false;   
            }
        }

        private void frmMasterPasswd_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbMPwd.Text))
            {
                Application.Exit();
            }
        }
    }
}
