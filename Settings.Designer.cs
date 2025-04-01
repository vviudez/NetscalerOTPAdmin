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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbLDAPServer = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbDomain = new System.Windows.Forms.TextBox();
            this.bntOKSettings = new System.Windows.Forms.Button();
            this.btnCloseSettings = new System.Windows.Forms.Button();
            this.gbLDAP = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tbBaseDN = new System.Windows.Forms.TextBox();
            this.lblEnc = new System.Windows.Forms.Label();
            this.cbLDAPSecurity = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbOTP = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbOTPAccountDesc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbOTPDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbOTPAttribute = new System.Windows.Forms.TextBox();
            this.lbOTPAttribute = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbEmailConfig = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbSMTPSubject = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbSMTPTemplate = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbSMTPSSL = new System.Windows.Forms.CheckBox();
            this.tbSMTPPort = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbSMTPServer = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbSMTPFrom = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSMTPPassword = new System.Windows.Forms.TextBox();
            this.tbSMTPUsername = new System.Windows.Forms.TextBox();
            this.gpApplication = new System.Windows.Forms.GroupBox();
            this.cbChangePwd = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbMasterPwd = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbLDAP.SuspendLayout();
            this.gbOTP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpApplication.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "LDAP Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Domain";
            // 
            // tbLDAPServer
            // 
            this.tbLDAPServer.Location = new System.Drawing.Point(103, 36);
            this.tbLDAPServer.Name = "tbLDAPServer";
            this.tbLDAPServer.Size = new System.Drawing.Size(341, 23);
            this.tbLDAPServer.TabIndex = 1;
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(104, 174);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(341, 23);
            this.tbUsername.TabIndex = 5;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(103, 209);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(341, 23);
            this.tbPassword.TabIndex = 6;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // tbDomain
            // 
            this.tbDomain.Location = new System.Drawing.Point(104, 105);
            this.tbDomain.Name = "tbDomain";
            this.tbDomain.Size = new System.Drawing.Size(341, 23);
            this.tbDomain.TabIndex = 3;
            this.tbDomain.TextChanged += new System.EventHandler(this.tbDomain_TextChanged);
            // 
            // bntOKSettings
            // 
            this.bntOKSettings.Location = new System.Drawing.Point(844, 477);
            this.bntOKSettings.Name = "bntOKSettings";
            this.bntOKSettings.Size = new System.Drawing.Size(87, 37);
            this.bntOKSettings.TabIndex = 20;
            this.bntOKSettings.Text = "&Ok";
            this.bntOKSettings.UseVisualStyleBackColor = true;
            this.bntOKSettings.Click += new System.EventHandler(this.bntOK_Click);
            // 
            // btnCloseSettings
            // 
            this.btnCloseSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCloseSettings.Location = new System.Drawing.Point(950, 477);
            this.btnCloseSettings.Name = "btnCloseSettings";
            this.btnCloseSettings.Size = new System.Drawing.Size(87, 37);
            this.btnCloseSettings.TabIndex = 21;
            this.btnCloseSettings.Text = "&Close";
            this.btnCloseSettings.UseVisualStyleBackColor = false;
            this.btnCloseSettings.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbLDAP
            // 
            this.gbLDAP.Controls.Add(this.label24);
            this.gbLDAP.Controls.Add(this.label23);
            this.gbLDAP.Controls.Add(this.tbBaseDN);
            this.gbLDAP.Controls.Add(this.lblEnc);
            this.gbLDAP.Controls.Add(this.cbLDAPSecurity);
            this.gbLDAP.Controls.Add(this.label9);
            this.gbLDAP.Controls.Add(this.label8);
            this.gbLDAP.Controls.Add(this.label7);
            this.gbLDAP.Controls.Add(this.tbLDAPServer);
            this.gbLDAP.Controls.Add(this.label1);
            this.gbLDAP.Controls.Add(this.label2);
            this.gbLDAP.Controls.Add(this.label3);
            this.gbLDAP.Controls.Add(this.tbDomain);
            this.gbLDAP.Controls.Add(this.label4);
            this.gbLDAP.Controls.Add(this.tbPassword);
            this.gbLDAP.Controls.Add(this.tbUsername);
            this.gbLDAP.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLDAP.Location = new System.Drawing.Point(14, 14);
            this.gbLDAP.Name = "gbLDAP";
            this.gbLDAP.Size = new System.Drawing.Size(486, 259);
            this.gbLDAP.TabIndex = 11;
            this.gbLDAP.TabStop = false;
            this.gbLDAP.Text = "LDAP Config";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(450, 109);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(13, 15);
            this.label24.TabIndex = 18;
            this.label24.Text = "*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(9, 144);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 15);
            this.label23.TabIndex = 17;
            this.label23.Text = "Base DN";
            // 
            // tbBaseDN
            // 
            this.tbBaseDN.Location = new System.Drawing.Point(103, 140);
            this.tbBaseDN.Name = "tbBaseDN";
            this.tbBaseDN.Size = new System.Drawing.Size(340, 23);
            this.tbBaseDN.TabIndex = 4;
            // 
            // lblEnc
            // 
            this.lblEnc.AutoSize = true;
            this.lblEnc.Location = new System.Drawing.Point(9, 74);
            this.lblEnc.Name = "lblEnc";
            this.lblEnc.Size = new System.Drawing.Size(53, 15);
            this.lblEnc.TabIndex = 15;
            this.lblEnc.Text = "Protocol";
            // 
            // cbLDAPSecurity
            // 
            this.cbLDAPSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLDAPSecurity.FormattingEnabled = true;
            this.cbLDAPSecurity.Items.AddRange(new object[] {
            "Unencrypted",
            "SSL",
            "TLS"});
            this.cbLDAPSecurity.Location = new System.Drawing.Point(104, 70);
            this.cbLDAPSecurity.Name = "cbLDAPSecurity";
            this.cbLDAPSecurity.Size = new System.Drawing.Size(105, 23);
            this.cbLDAPSecurity.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cbLDAPSecurity, "Select encryption method to access LDAP servers");
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(450, 214);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(451, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(450, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "*";
            // 
            // gbOTP
            // 
            this.gbOTP.Controls.Add(this.label10);
            this.gbOTP.Controls.Add(this.tbOTPAccountDesc);
            this.gbOTP.Controls.Add(this.label6);
            this.gbOTP.Controls.Add(this.tbOTPDescription);
            this.gbOTP.Controls.Add(this.label5);
            this.gbOTP.Controls.Add(this.tbOTPAttribute);
            this.gbOTP.Controls.Add(this.lbOTPAttribute);
            this.gbOTP.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOTP.Location = new System.Drawing.Point(14, 279);
            this.gbOTP.Name = "gbOTP";
            this.gbOTP.Size = new System.Drawing.Size(486, 155);
            this.gbOTP.TabIndex = 12;
            this.gbOTP.TabStop = false;
            this.gbOTP.Text = "OTP Config";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(450, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "*";
            // 
            // tbOTPAccountDesc
            // 
            this.tbOTPAccountDesc.Location = new System.Drawing.Point(114, 111);
            this.tbOTPAccountDesc.Name = "tbOTPAccountDesc";
            this.tbOTPAccountDesc.Size = new System.Drawing.Size(330, 23);
            this.tbOTPAccountDesc.TabIndex = 9;
            this.tbOTPAccountDesc.Text = "Web OTP Access";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Account Issuer";
            // 
            // tbOTPDescription
            // 
            this.tbOTPDescription.Location = new System.Drawing.Point(114, 72);
            this.tbOTPDescription.Name = "tbOTPDescription";
            this.tbOTPDescription.Size = new System.Drawing.Size(330, 23);
            this.tbOTPDescription.TabIndex = 8;
            this.tbOTPDescription.Text = "OTP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Def. Device Name";
            // 
            // tbOTPAttribute
            // 
            this.tbOTPAttribute.Location = new System.Drawing.Point(114, 36);
            this.tbOTPAttribute.Name = "tbOTPAttribute";
            this.tbOTPAttribute.Size = new System.Drawing.Size(330, 23);
            this.tbOTPAttribute.TabIndex = 7;
            this.tbOTPAttribute.Text = "userParameters";
            // 
            // lbOTPAttribute
            // 
            this.lbOTPAttribute.AutoSize = true;
            this.lbOTPAttribute.Location = new System.Drawing.Point(9, 39);
            this.lbOTPAttribute.Name = "lbOTPAttribute";
            this.lbOTPAttribute.Size = new System.Drawing.Size(83, 15);
            this.lbOTPAttribute.TabIndex = 4;
            this.lbOTPAttribute.Text = "OTP Attribute";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbEmailConfig);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tbSMTPSubject);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cbSMTPTemplate);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.cbSMTPSSL);
            this.groupBox1.Controls.Add(this.tbSMTPPort);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.tbSMTPServer);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tbSMTPFrom);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbSMTPPassword);
            this.groupBox1.Controls.Add(this.tbSMTPUsername);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(519, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 325);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Email Config";
            // 
            // cbEmailConfig
            // 
            this.cbEmailConfig.AutoSize = true;
            this.cbEmailConfig.Location = new System.Drawing.Point(26, 290);
            this.cbEmailConfig.Name = "cbEmailConfig";
            this.cbEmailConfig.Size = new System.Drawing.Size(145, 19);
            this.cbEmailConfig.TabIndex = 17;
            this.cbEmailConfig.Text = "Don\'t use Email config";
            this.cbEmailConfig.UseVisualStyleBackColor = true;
            this.cbEmailConfig.CheckedChanged += new System.EventHandler(this.cbEmailConfig_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(427, 256);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 15);
            this.label20.TabIndex = 25;
            this.label20.Text = "*";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(176, 70);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 15);
            this.label19.TabIndex = 24;
            this.label19.Text = "*";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(426, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 15);
            this.label15.TabIndex = 14;
            this.label15.Text = "*";
            // 
            // tbSMTPSubject
            // 
            this.tbSMTPSubject.Location = new System.Drawing.Point(120, 213);
            this.tbSMTPSubject.Name = "tbSMTPSubject";
            this.tbSMTPSubject.Size = new System.Drawing.Size(307, 23);
            this.tbSMTPSubject.TabIndex = 15;
            this.tbSMTPSubject.Text = "Your new OTP Token";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 217);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 15);
            this.label18.TabIndex = 22;
            this.label18.Text = "Email Subject";
            // 
            // cbSMTPTemplate
            // 
            this.cbSMTPTemplate.FormattingEnabled = true;
            this.cbSMTPTemplate.Location = new System.Drawing.Point(142, 252);
            this.cbSMTPTemplate.Name = "cbSMTPTemplate";
            this.cbSMTPTemplate.Size = new System.Drawing.Size(285, 23);
            this.cbSMTPTemplate.TabIndex = 16;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(23, 256);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(112, 15);
            this.label17.TabIndex = 20;
            this.label17.Text = "Email Template File";
            // 
            // cbSMTPSSL
            // 
            this.cbSMTPSSL.AutoSize = true;
            this.cbSMTPSSL.Checked = true;
            this.cbSMTPSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSMTPSSL.Location = new System.Drawing.Point(446, 36);
            this.cbSMTPSSL.Name = "cbSMTPSSL";
            this.cbSMTPSSL.Size = new System.Drawing.Size(67, 19);
            this.cbSMTPSSL.TabIndex = 14;
            this.cbSMTPSSL.Text = "Use SSL";
            this.cbSMTPSSL.UseVisualStyleBackColor = true;
            // 
            // tbSMTPPort
            // 
            this.tbSMTPPort.Location = new System.Drawing.Point(120, 66);
            this.tbSMTPPort.Name = "tbSMTPPort";
            this.tbSMTPPort.Size = new System.Drawing.Size(54, 23);
            this.tbSMTPPort.TabIndex = 11;
            this.tbSMTPPort.Text = "587";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(23, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 15);
            this.label16.TabIndex = 18;
            this.label16.Text = "SMTP Port";
            // 
            // tbSMTPServer
            // 
            this.tbSMTPServer.Location = new System.Drawing.Point(120, 34);
            this.tbSMTPServer.Name = "tbSMTPServer";
            this.tbSMTPServer.Size = new System.Drawing.Size(307, 23);
            this.tbSMTPServer.TabIndex = 10;
            this.tbSMTPServer.Text = "smtp.gmail.com";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 8;
            this.label11.Text = "SMTP Server";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 15);
            this.label12.TabIndex = 9;
            this.label12.Text = "SMTP Username";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 15);
            this.label13.TabIndex = 10;
            this.label13.Text = "SMTP Password";
            // 
            // tbSMTPFrom
            // 
            this.tbSMTPFrom.Location = new System.Drawing.Point(120, 179);
            this.tbSMTPFrom.Name = "tbSMTPFrom";
            this.tbSMTPFrom.Size = new System.Drawing.Size(307, 23);
            this.tbSMTPFrom.TabIndex = 14;
            this.tbSMTPFrom.Text = "userfrom@domain.com";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 183);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 15);
            this.label14.TabIndex = 11;
            this.label14.Text = "Email From";
            // 
            // tbSMTPPassword
            // 
            this.tbSMTPPassword.Location = new System.Drawing.Point(120, 134);
            this.tbSMTPPassword.Name = "tbSMTPPassword";
            this.tbSMTPPassword.Size = new System.Drawing.Size(307, 23);
            this.tbSMTPPassword.TabIndex = 13;
            this.tbSMTPPassword.UseSystemPasswordChar = true;
            // 
            // tbSMTPUsername
            // 
            this.tbSMTPUsername.Location = new System.Drawing.Point(120, 100);
            this.tbSMTPUsername.Name = "tbSMTPUsername";
            this.tbSMTPUsername.Size = new System.Drawing.Size(307, 23);
            this.tbSMTPUsername.TabIndex = 12;
            // 
            // gpApplication
            // 
            this.gpApplication.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.gpApplication.Controls.Add(this.cbChangePwd);
            this.gpApplication.Controls.Add(this.label21);
            this.gpApplication.Controls.Add(this.tbMasterPwd);
            this.gpApplication.Controls.Add(this.label22);
            this.gpApplication.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpApplication.Location = new System.Drawing.Point(14, 454);
            this.gpApplication.Name = "gpApplication";
            this.gpApplication.Size = new System.Drawing.Size(672, 63);
            this.gpApplication.TabIndex = 14;
            this.gpApplication.TabStop = false;
            this.gpApplication.Text = "Application";
            // 
            // cbChangePwd
            // 
            this.cbChangePwd.AutoSize = true;
            this.cbChangePwd.Location = new System.Drawing.Point(518, 29);
            this.cbChangePwd.Name = "cbChangePwd";
            this.cbChangePwd.Size = new System.Drawing.Size(121, 19);
            this.cbChangePwd.TabIndex = 19;
            this.cbChangePwd.Text = "Change Password";
            this.toolTip1.SetToolTip(this.cbChangePwd, "Check only if you want to change your Master Password");
            this.cbChangePwd.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(473, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(13, 15);
            this.label21.TabIndex = 17;
            this.label21.Text = "*";
            // 
            // tbMasterPwd
            // 
            this.tbMasterPwd.Location = new System.Drawing.Point(115, 26);
            this.tbMasterPwd.Name = "tbMasterPwd";
            this.tbMasterPwd.PasswordChar = '*';
            this.tbMasterPwd.Size = new System.Drawing.Size(353, 23);
            this.tbMasterPwd.TabIndex = 18;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(9, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 15);
            this.label22.TabIndex = 15;
            this.label22.Text = "Master Password";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 529);
            this.Controls.Add(this.gpApplication);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbOTP);
            this.Controls.Add(this.gbLDAP);
            this.Controls.Add(this.btnCloseSettings);
            this.Controls.Add(this.bntOKSettings);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.Text = "Settings...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.gbLDAP.ResumeLayout(false);
            this.gbLDAP.PerformLayout();
            this.gbOTP.ResumeLayout(false);
            this.gbOTP.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpApplication.ResumeLayout(false);
            this.gpApplication.PerformLayout();
            this.ResumeLayout(false);

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
    }
}