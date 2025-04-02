namespace NetscalerOTPAdmin
{
    partial class frmAddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddUser));
            this.lbUserNameSearch = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvFoundUsers = new System.Windows.Forms.ListView();
            this.clmUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.tbQRCode = new System.Windows.Forms.TextBox();
            this.tbOTPDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // lbUserNameSearch
            // 
            this.lbUserNameSearch.AutoSize = true;
            this.lbUserNameSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserNameSearch.Location = new System.Drawing.Point(26, 25);
            this.lbUserNameSearch.Name = "lbUserNameSearch";
            this.lbUserNameSearch.Size = new System.Drawing.Size(63, 15);
            this.lbUserNameSearch.TabIndex = 0;
            this.lbUserNameSearch.Text = "UserName";
            // 
            // tbUserName
            // 
            this.tbUserName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUserName.Location = new System.Drawing.Point(99, 22);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(195, 23);
            this.tbUserName.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSearch.Location = new System.Drawing.Point(307, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 26);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "&Search users";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvFoundUsers
            // 
            this.lvFoundUsers.AllowColumnReorder = true;
            this.lvFoundUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmUsername,
            this.clmFullName,
            this.clmEmail});
            this.lvFoundUsers.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvFoundUsers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvFoundUsers.FullRowSelect = true;
            this.lvFoundUsers.GridLines = true;
            this.lvFoundUsers.HideSelection = false;
            this.lvFoundUsers.Location = new System.Drawing.Point(29, 58);
            this.lvFoundUsers.Name = "lvFoundUsers";
            this.lvFoundUsers.Size = new System.Drawing.Size(486, 380);
            this.lvFoundUsers.TabIndex = 3;
            this.lvFoundUsers.UseCompatibleStateImageBehavior = false;
            this.lvFoundUsers.View = System.Windows.Forms.View.Details;
            this.lvFoundUsers.SelectedIndexChanged += new System.EventHandler(this.lvFoundUsers_SelectedIndexChanged);
            // 
            // clmUsername
            // 
            this.clmUsername.Text = "UserName";
            this.clmUsername.Width = 91;
            // 
            // clmFullName
            // 
            this.clmFullName.Text = "Full Name";
            this.clmFullName.Width = 162;
            // 
            // clmEmail
            // 
            this.clmEmail.Text = "Email";
            this.clmEmail.Width = 162;
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddDevice.Enabled = false;
            this.btnAddDevice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDevice.Location = new System.Drawing.Point(533, 58);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(298, 33);
            this.btnAddDevice.TabIndex = 4;
            this.btnAddDevice.Text = "Add Device for selected user";
            this.btnAddDevice.UseVisualStyleBackColor = false;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // pbQRCode
            // 
            this.pbQRCode.Location = new System.Drawing.Point(585, 134);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(200, 200);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 5;
            this.pbQRCode.TabStop = false;
            // 
            // tbQRCode
            // 
            this.tbQRCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbQRCode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQRCode.Location = new System.Drawing.Point(540, 344);
            this.tbQRCode.Name = "tbQRCode";
            this.tbQRCode.ReadOnly = true;
            this.tbQRCode.Size = new System.Drawing.Size(291, 23);
            this.tbQRCode.TabIndex = 6;
            this.tbQRCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOTPDescription
            // 
            this.tbOTPDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOTPDescription.Location = new System.Drawing.Point(612, 101);
            this.tbOTPDescription.Name = "tbOTPDescription";
            this.tbOTPDescription.Size = new System.Drawing.Size(208, 23);
            this.tbOTPDescription.TabIndex = 7;
            this.tbOTPDescription.Text = "OTP";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(537, 106);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(70, 15);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(540, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 48);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "&Save Device";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Location = new System.Drawing.Point(636, 390);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(99, 48);
            this.btnEmail.TabIndex = 10;
            this.btnEmail.Text = "Save and Prepare &Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(741, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 48);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmAddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbOTPDescription);
            this.Controls.Add(this.tbQRCode);
            this.Controls.Add(this.pbQRCode);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.lvFoundUsers);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.lbUserNameSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddUser";
            this.Text = "Add OTP seed to new User";
            this.Shown += new System.EventHandler(this.frmAddUser_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUserNameSearch;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvFoundUsers;
        private System.Windows.Forms.ColumnHeader clmUsername;
        private System.Windows.Forms.ColumnHeader clmFullName;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.ColumnHeader clmEmail;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.TextBox tbQRCode;
        private System.Windows.Forms.TextBox tbOTPDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnCancel;
    }
}