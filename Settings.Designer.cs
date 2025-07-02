namespace NetscalerOTPAdmin
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tbLDAPServer = new System.Windows.Forms.TextBox();
            tbUsername = new System.Windows.Forms.TextBox();
            tbPassword = new System.Windows.Forms.TextBox();
            tbDomain = new System.Windows.Forms.TextBox();
            bntOKSettings = new System.Windows.Forms.Button();
            btnCloseSettings = new System.Windows.Forms.Button();
            gbLDAP = new System.Windows.Forms.GroupBox();
            label24 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            tbBaseDN = new System.Windows.Forms.TextBox();
            lblEnc = new System.Windows.Forms.Label();
            cbLDAPSecurity = new System.Windows.Forms.ComboBox();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            gbOTP = new System.Windows.Forms.GroupBox();
            lblPrivateKey = new System.Windows.Forms.Label();
            btnSelectPrivateKey = new System.Windows.Forms.Button();
            lblCertificate = new System.Windows.Forms.Label();
            btnSelectCertificate = new System.Windows.Forms.Button();
            label27 = new System.Windows.Forms.Label();
            label26 = new System.Windows.Forms.Label();
            cbOTPEncrypt = new System.Windows.Forms.CheckBox();
            label25 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            tbOTPAccountDesc = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            tbOTPDescription = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            tbOTPAttribute = new System.Windows.Forms.TextBox();
            lbOTPAttribute = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            cbEmailConfig = new System.Windows.Forms.CheckBox();
            label20 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            tbSMTPSubject = new System.Windows.Forms.TextBox();
            label18 = new System.Windows.Forms.Label();
            cbSMTPTemplate = new System.Windows.Forms.ComboBox();
            label17 = new System.Windows.Forms.Label();
            cbSMTPSSL = new System.Windows.Forms.CheckBox();
            tbSMTPPort = new System.Windows.Forms.TextBox();
            label16 = new System.Windows.Forms.Label();
            tbSMTPServer = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            tbSMTPFrom = new System.Windows.Forms.TextBox();
            label14 = new System.Windows.Forms.Label();
            tbSMTPPassword = new System.Windows.Forms.TextBox();
            tbSMTPUsername = new System.Windows.Forms.TextBox();
            gpApplication = new System.Windows.Forms.GroupBox();
            cbChangePwd = new System.Windows.Forms.CheckBox();
            label21 = new System.Windows.Forms.Label();
            tbMasterPwd = new System.Windows.Forms.TextBox();
            label22 = new System.Windows.Forms.Label();
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            lblOTPEncryptMessage = new System.Windows.Forms.Label();
            gbLDAP.SuspendLayout();
            gbOTP.SuspendLayout();
            groupBox1.SuspendLayout();
            gpApplication.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 43);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 15);
            label1.TabIndex = 0;
            label1.Text = "LDAP Server";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 177);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(63, 15);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 209);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(59, 15);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(10, 109);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 15);
            label4.TabIndex = 3;
            label4.Text = "Domain";
            // 
            // tbLDAPServer
            // 
            tbLDAPServer.Location = new System.Drawing.Point(103, 36);
            tbLDAPServer.Name = "tbLDAPServer";
            tbLDAPServer.Size = new System.Drawing.Size(341, 23);
            tbLDAPServer.TabIndex = 1;
            // 
            // tbUsername
            // 
            tbUsername.Location = new System.Drawing.Point(104, 174);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new System.Drawing.Size(341, 23);
            tbUsername.TabIndex = 5;
            // 
            // tbPassword
            // 
            tbPassword.Location = new System.Drawing.Point(103, 209);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new System.Drawing.Size(341, 23);
            tbPassword.TabIndex = 6;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // tbDomain
            // 
            tbDomain.Location = new System.Drawing.Point(104, 105);
            tbDomain.Name = "tbDomain";
            tbDomain.Size = new System.Drawing.Size(341, 23);
            tbDomain.TabIndex = 3;
            tbDomain.TextChanged += tbDomain_TextChanged;
            // 
            // bntOKSettings
            // 
            bntOKSettings.Location = new System.Drawing.Point(844, 553);
            bntOKSettings.Name = "bntOKSettings";
            bntOKSettings.Size = new System.Drawing.Size(87, 37);
            bntOKSettings.TabIndex = 20;
            bntOKSettings.Text = "&Ok";
            bntOKSettings.UseVisualStyleBackColor = true;
            bntOKSettings.Click += bntOK_Click;
            // 
            // btnCloseSettings
            // 
            btnCloseSettings.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            btnCloseSettings.Location = new System.Drawing.Point(950, 553);
            btnCloseSettings.Name = "btnCloseSettings";
            btnCloseSettings.Size = new System.Drawing.Size(87, 37);
            btnCloseSettings.TabIndex = 21;
            btnCloseSettings.Text = "&Close";
            btnCloseSettings.UseVisualStyleBackColor = false;
            btnCloseSettings.Click += btnCancel_Click;
            // 
            // gbLDAP
            // 
            gbLDAP.Controls.Add(label24);
            gbLDAP.Controls.Add(label23);
            gbLDAP.Controls.Add(tbBaseDN);
            gbLDAP.Controls.Add(lblEnc);
            gbLDAP.Controls.Add(cbLDAPSecurity);
            gbLDAP.Controls.Add(label9);
            gbLDAP.Controls.Add(label8);
            gbLDAP.Controls.Add(label7);
            gbLDAP.Controls.Add(tbLDAPServer);
            gbLDAP.Controls.Add(label1);
            gbLDAP.Controls.Add(label2);
            gbLDAP.Controls.Add(label3);
            gbLDAP.Controls.Add(tbDomain);
            gbLDAP.Controls.Add(label4);
            gbLDAP.Controls.Add(tbPassword);
            gbLDAP.Controls.Add(tbUsername);
            gbLDAP.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbLDAP.Location = new System.Drawing.Point(14, 14);
            gbLDAP.Name = "gbLDAP";
            gbLDAP.Size = new System.Drawing.Size(486, 259);
            gbLDAP.TabIndex = 11;
            gbLDAP.TabStop = false;
            gbLDAP.Text = "LDAP Config";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new System.Drawing.Point(450, 109);
            label24.Name = "label24";
            label24.Size = new System.Drawing.Size(13, 15);
            label24.TabIndex = 18;
            label24.Text = "*";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(9, 144);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(52, 15);
            label23.TabIndex = 17;
            label23.Text = "Base DN";
            // 
            // tbBaseDN
            // 
            tbBaseDN.Location = new System.Drawing.Point(103, 140);
            tbBaseDN.Name = "tbBaseDN";
            tbBaseDN.Size = new System.Drawing.Size(340, 23);
            tbBaseDN.TabIndex = 4;
            // 
            // lblEnc
            // 
            lblEnc.AutoSize = true;
            lblEnc.Location = new System.Drawing.Point(9, 74);
            lblEnc.Name = "lblEnc";
            lblEnc.Size = new System.Drawing.Size(53, 15);
            lblEnc.TabIndex = 15;
            lblEnc.Text = "Protocol";
            // 
            // cbLDAPSecurity
            // 
            cbLDAPSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbLDAPSecurity.FormattingEnabled = true;
            cbLDAPSecurity.Items.AddRange(new object[] { "Unencrypted", "SSL", "TLS" });
            cbLDAPSecurity.Location = new System.Drawing.Point(104, 70);
            cbLDAPSecurity.Name = "cbLDAPSecurity";
            cbLDAPSecurity.Size = new System.Drawing.Size(105, 23);
            cbLDAPSecurity.TabIndex = 2;
            toolTip1.SetToolTip(cbLDAPSecurity, "Select encryption method to access LDAP servers");
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(450, 214);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(13, 15);
            label9.TabIndex = 13;
            label9.Text = "*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(451, 180);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(13, 15);
            label8.TabIndex = 12;
            label8.Text = "*";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(450, 43);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(13, 15);
            label7.TabIndex = 11;
            label7.Text = "*";
            // 
            // gbOTP
            // 
            gbOTP.Controls.Add(lblOTPEncryptMessage);
            gbOTP.Controls.Add(lblPrivateKey);
            gbOTP.Controls.Add(btnSelectPrivateKey);
            gbOTP.Controls.Add(lblCertificate);
            gbOTP.Controls.Add(btnSelectCertificate);
            gbOTP.Controls.Add(label27);
            gbOTP.Controls.Add(label26);
            gbOTP.Controls.Add(cbOTPEncrypt);
            gbOTP.Controls.Add(label25);
            gbOTP.Controls.Add(label10);
            gbOTP.Controls.Add(tbOTPAccountDesc);
            gbOTP.Controls.Add(label6);
            gbOTP.Controls.Add(tbOTPDescription);
            gbOTP.Controls.Add(label5);
            gbOTP.Controls.Add(tbOTPAttribute);
            gbOTP.Controls.Add(lbOTPAttribute);
            gbOTP.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbOTP.Location = new System.Drawing.Point(14, 279);
            gbOTP.Name = "gbOTP";
            gbOTP.Size = new System.Drawing.Size(486, 293);
            gbOTP.TabIndex = 12;
            gbOTP.TabStop = false;
            gbOTP.Text = "OTP Config";
            // 
            // lblPrivateKey
            // 
            lblPrivateKey.AutoSize = true;
            lblPrivateKey.Location = new System.Drawing.Point(235, 261);
            lblPrivateKey.Name = "lblPrivateKey";
            lblPrivateKey.Size = new System.Drawing.Size(16, 15);
            lblPrivateKey.TabIndex = 22;
            lblPrivateKey.Text = "...";
            // 
            // btnSelectPrivateKey
            // 
            btnSelectPrivateKey.Enabled = false;
            btnSelectPrivateKey.Location = new System.Drawing.Point(153, 256);
            btnSelectPrivateKey.Name = "btnSelectPrivateKey";
            btnSelectPrivateKey.Size = new System.Drawing.Size(75, 23);
            btnSelectPrivateKey.TabIndex = 21;
            btnSelectPrivateKey.Text = "Select File";
            btnSelectPrivateKey.UseVisualStyleBackColor = true;
            btnSelectPrivateKey.Click += btnSelectPrivateKey_Click;
            // 
            // lblCertificate
            // 
            lblCertificate.AutoSize = true;
            lblCertificate.Location = new System.Drawing.Point(235, 227);
            lblCertificate.Name = "lblCertificate";
            lblCertificate.Size = new System.Drawing.Size(16, 15);
            lblCertificate.TabIndex = 20;
            lblCertificate.Text = "...";
            // 
            // btnSelectCertificate
            // 
            btnSelectCertificate.Enabled = false;
            btnSelectCertificate.Location = new System.Drawing.Point(153, 224);
            btnSelectCertificate.Name = "btnSelectCertificate";
            btnSelectCertificate.Size = new System.Drawing.Size(75, 23);
            btnSelectCertificate.TabIndex = 19;
            btnSelectCertificate.Text = "Select File";
            btnSelectCertificate.UseVisualStyleBackColor = true;
            btnSelectCertificate.Click += btnSelectCertificate_Click;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new System.Drawing.Point(10, 258);
            label27.Name = "label27";
            label27.Size = new System.Drawing.Size(130, 15);
            label27.TabIndex = 18;
            label27.Text = "Encryption Private Key";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(10, 227);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(125, 15);
            label26.TabIndex = 17;
            label26.Text = "Encryption Certificate";
            // 
            // cbOTPEncrypt
            // 
            cbOTPEncrypt.AutoSize = true;
            cbOTPEncrypt.Enabled = false;
            cbOTPEncrypt.Location = new System.Drawing.Point(113, 196);
            cbOTPEncrypt.Name = "cbOTPEncrypt";
            cbOTPEncrypt.Size = new System.Drawing.Size(15, 14);
            cbOTPEncrypt.TabIndex = 16;
            cbOTPEncrypt.UseVisualStyleBackColor = true;
            cbOTPEncrypt.CheckedChanged += cbOTPEncrypt_CheckedChanged;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new System.Drawing.Point(9, 194);
            label25.Name = "label25";
            label25.Size = new System.Drawing.Size(90, 15);
            label25.TabIndex = 15;
            label25.Text = "OTP Encryption";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(450, 44);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(13, 15);
            label10.TabIndex = 14;
            label10.Text = "*";
            // 
            // tbOTPAccountDesc
            // 
            tbOTPAccountDesc.Location = new System.Drawing.Point(114, 111);
            tbOTPAccountDesc.Name = "tbOTPAccountDesc";
            tbOTPAccountDesc.Size = new System.Drawing.Size(330, 23);
            tbOTPAccountDesc.TabIndex = 9;
            tbOTPAccountDesc.Text = "Web OTP Access";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(9, 115);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(86, 15);
            label6.TabIndex = 11;
            label6.Text = "Account Issuer";
            // 
            // tbOTPDescription
            // 
            tbOTPDescription.Location = new System.Drawing.Point(114, 72);
            tbOTPDescription.Name = "tbOTPDescription";
            tbOTPDescription.Size = new System.Drawing.Size(330, 23);
            tbOTPDescription.TabIndex = 8;
            tbOTPDescription.Text = "OTP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 76);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(103, 15);
            label5.TabIndex = 9;
            label5.Text = "Def. Device Name";
            // 
            // tbOTPAttribute
            // 
            tbOTPAttribute.Location = new System.Drawing.Point(114, 36);
            tbOTPAttribute.Name = "tbOTPAttribute";
            tbOTPAttribute.Size = new System.Drawing.Size(330, 23);
            tbOTPAttribute.TabIndex = 7;
            tbOTPAttribute.Text = "userParameters";
            // 
            // lbOTPAttribute
            // 
            lbOTPAttribute.AutoSize = true;
            lbOTPAttribute.Location = new System.Drawing.Point(9, 39);
            lbOTPAttribute.Name = "lbOTPAttribute";
            lbOTPAttribute.Size = new System.Drawing.Size(83, 15);
            lbOTPAttribute.TabIndex = 4;
            lbOTPAttribute.Text = "OTP Attribute";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbEmailConfig);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(tbSMTPSubject);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(cbSMTPTemplate);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(cbSMTPSSL);
            groupBox1.Controls.Add(tbSMTPPort);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(tbSMTPServer);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(tbSMTPFrom);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(tbSMTPPassword);
            groupBox1.Controls.Add(tbSMTPUsername);
            groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox1.Location = new System.Drawing.Point(519, 14);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(518, 325);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            groupBox1.Text = "Email Config";
            // 
            // cbEmailConfig
            // 
            cbEmailConfig.AutoSize = true;
            cbEmailConfig.Location = new System.Drawing.Point(26, 290);
            cbEmailConfig.Name = "cbEmailConfig";
            cbEmailConfig.Size = new System.Drawing.Size(145, 19);
            cbEmailConfig.TabIndex = 17;
            cbEmailConfig.Text = "Don't use Email config";
            cbEmailConfig.UseVisualStyleBackColor = true;
            cbEmailConfig.CheckedChanged += cbEmailConfig_CheckedChanged;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(427, 256);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(13, 15);
            label20.TabIndex = 25;
            label20.Text = "*";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(176, 70);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(13, 15);
            label19.TabIndex = 24;
            label19.Text = "*";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(426, 38);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(13, 15);
            label15.TabIndex = 14;
            label15.Text = "*";
            // 
            // tbSMTPSubject
            // 
            tbSMTPSubject.Location = new System.Drawing.Point(120, 213);
            tbSMTPSubject.Name = "tbSMTPSubject";
            tbSMTPSubject.Size = new System.Drawing.Size(307, 23);
            tbSMTPSubject.TabIndex = 15;
            tbSMTPSubject.Text = "Your new OTP Token";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(23, 217);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(79, 15);
            label18.TabIndex = 22;
            label18.Text = "Email Subject";
            // 
            // cbSMTPTemplate
            // 
            cbSMTPTemplate.FormattingEnabled = true;
            cbSMTPTemplate.Location = new System.Drawing.Point(142, 252);
            cbSMTPTemplate.Name = "cbSMTPTemplate";
            cbSMTPTemplate.Size = new System.Drawing.Size(285, 23);
            cbSMTPTemplate.TabIndex = 16;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(23, 256);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(112, 15);
            label17.TabIndex = 20;
            label17.Text = "Email Template File";
            // 
            // cbSMTPSSL
            // 
            cbSMTPSSL.AutoSize = true;
            cbSMTPSSL.Checked = true;
            cbSMTPSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            cbSMTPSSL.Location = new System.Drawing.Point(446, 36);
            cbSMTPSSL.Name = "cbSMTPSSL";
            cbSMTPSSL.Size = new System.Drawing.Size(67, 19);
            cbSMTPSSL.TabIndex = 14;
            cbSMTPSSL.Text = "Use SSL";
            cbSMTPSSL.UseVisualStyleBackColor = true;
            // 
            // tbSMTPPort
            // 
            tbSMTPPort.Location = new System.Drawing.Point(120, 66);
            tbSMTPPort.Name = "tbSMTPPort";
            tbSMTPPort.Size = new System.Drawing.Size(54, 23);
            tbSMTPPort.TabIndex = 11;
            tbSMTPPort.Text = "587";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(23, 73);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(64, 15);
            label16.TabIndex = 18;
            label16.Text = "SMTP Port";
            // 
            // tbSMTPServer
            // 
            tbSMTPServer.Location = new System.Drawing.Point(120, 34);
            tbSMTPServer.Name = "tbSMTPServer";
            tbSMTPServer.Size = new System.Drawing.Size(307, 23);
            tbSMTPServer.TabIndex = 10;
            tbSMTPServer.Text = "smtp.gmail.com";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(23, 41);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(76, 15);
            label11.TabIndex = 8;
            label11.Text = "SMTP Server";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(23, 103);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(96, 15);
            label12.TabIndex = 9;
            label12.Text = "SMTP Username";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(23, 137);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(92, 15);
            label13.TabIndex = 10;
            label13.Text = "SMTP Password";
            // 
            // tbSMTPFrom
            // 
            tbSMTPFrom.Location = new System.Drawing.Point(120, 179);
            tbSMTPFrom.Name = "tbSMTPFrom";
            tbSMTPFrom.Size = new System.Drawing.Size(307, 23);
            tbSMTPFrom.TabIndex = 14;
            tbSMTPFrom.Text = "userfrom@domain.com";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(23, 183);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(68, 15);
            label14.TabIndex = 11;
            label14.Text = "Email From";
            // 
            // tbSMTPPassword
            // 
            tbSMTPPassword.Location = new System.Drawing.Point(120, 134);
            tbSMTPPassword.Name = "tbSMTPPassword";
            tbSMTPPassword.Size = new System.Drawing.Size(307, 23);
            tbSMTPPassword.TabIndex = 13;
            tbSMTPPassword.UseSystemPasswordChar = true;
            // 
            // tbSMTPUsername
            // 
            tbSMTPUsername.Location = new System.Drawing.Point(120, 100);
            tbSMTPUsername.Name = "tbSMTPUsername";
            tbSMTPUsername.Size = new System.Drawing.Size(307, 23);
            tbSMTPUsername.TabIndex = 12;
            // 
            // gpApplication
            // 
            gpApplication.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
            gpApplication.Controls.Add(cbChangePwd);
            gpApplication.Controls.Add(label21);
            gpApplication.Controls.Add(tbMasterPwd);
            gpApplication.Controls.Add(label22);
            gpApplication.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gpApplication.Location = new System.Drawing.Point(519, 355);
            gpApplication.Name = "gpApplication";
            gpApplication.Size = new System.Drawing.Size(518, 109);
            gpApplication.TabIndex = 14;
            gpApplication.TabStop = false;
            gpApplication.Text = "Application";
            // 
            // cbChangePwd
            // 
            cbChangePwd.AutoSize = true;
            cbChangePwd.Location = new System.Drawing.Point(115, 71);
            cbChangePwd.Name = "cbChangePwd";
            cbChangePwd.Size = new System.Drawing.Size(121, 19);
            cbChangePwd.TabIndex = 19;
            cbChangePwd.Text = "Change Password";
            toolTip1.SetToolTip(cbChangePwd, "Check only if you want to change your Master Password");
            cbChangePwd.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(473, 34);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(13, 15);
            label21.TabIndex = 17;
            label21.Text = "*";
            // 
            // tbMasterPwd
            // 
            tbMasterPwd.Location = new System.Drawing.Point(115, 26);
            tbMasterPwd.Name = "tbMasterPwd";
            tbMasterPwd.PasswordChar = '*';
            tbMasterPwd.Size = new System.Drawing.Size(353, 23);
            tbMasterPwd.TabIndex = 18;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(9, 29);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(101, 15);
            label22.TabIndex = 15;
            label22.Text = "Master Password";
            // 
            // toolTip1
            // 
            toolTip1.AutomaticDelay = 200;
            // 
            // lblOTPEncryptMessage
            // 
            lblOTPEncryptMessage.AutoSize = true;
            lblOTPEncryptMessage.ForeColor = System.Drawing.Color.Red;
            lblOTPEncryptMessage.Location = new System.Drawing.Point(10, 155);
            lblOTPEncryptMessage.MaximumSize = new System.Drawing.Size(500, 0);
            lblOTPEncryptMessage.Name = "lblOTPEncryptMessage";
            lblOTPEncryptMessage.Size = new System.Drawing.Size(404, 30);
            lblOTPEncryptMessage.TabIndex = 23;
            lblOTPEncryptMessage.Text = "OTP Encryption is Incompatible until Citrix solves the problem with their OTP_encryption_tool, and how saves OTP info on the user attribute";
            lblOTPEncryptMessage.Click += lblOTPEncryptMessage_Click;
            // 
            // frmSettings
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1052, 602);
            Controls.Add(gpApplication);
            Controls.Add(groupBox1);
            Controls.Add(gbOTP);
            Controls.Add(gbLDAP);
            Controls.Add(btnCloseSettings);
            Controls.Add(bntOKSettings);
            Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "frmSettings";
            Text = "Settings...";
            TopMost = true;
            Load += frmSettings_Load;
            gbLDAP.ResumeLayout(false);
            gbLDAP.PerformLayout();
            gbOTP.ResumeLayout(false);
            gbOTP.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            gpApplication.ResumeLayout(false);
            gpApplication.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLDAPServer;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbDomain;
        private System.Windows.Forms.Button bntOKSettings;
        private System.Windows.Forms.Button btnCloseSettings;
        private System.Windows.Forms.GroupBox gbLDAP;
        private System.Windows.Forms.GroupBox gbOTP;
        private System.Windows.Forms.Label lbOTPAttribute;
        private System.Windows.Forms.TextBox tbOTPAttribute;
        private System.Windows.Forms.TextBox tbOTPAccountDesc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbOTPDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSMTPServer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbSMTPFrom;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSMTPPassword;
        private System.Windows.Forms.TextBox tbSMTPUsername;
        private System.Windows.Forms.ComboBox cbSMTPTemplate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox cbSMTPSSL;
        private System.Windows.Forms.TextBox tbSMTPPort;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbSMTPSubject;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbEmailConfig;
        private System.Windows.Forms.GroupBox gpApplication;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tbMasterPwd;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox cbChangePwd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cbLDAPSecurity;
        private System.Windows.Forms.Label lblEnc;
        private System.Windows.Forms.TextBox tbBaseDN;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox cbOTPEncrypt;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblCertificate;
        private System.Windows.Forms.Button btnSelectCertificate;
        private System.Windows.Forms.Label lblPrivateKey;
        private System.Windows.Forms.Button btnSelectPrivateKey;
        private System.Windows.Forms.Label lblOTPEncryptMessage;
    }
}