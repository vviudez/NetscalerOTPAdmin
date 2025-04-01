namespace NetscalerOTPAdmin
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lbLDAPServer = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.clmUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUserParameters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attributes = new System.Windows.Forms.TextBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.lblDeviceSeeds = new System.Windows.Forms.Label();
            this.btnCloseMain = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLDAPServer
            // 
            this.lbLDAPServer.AutoSize = true;
            this.lbLDAPServer.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLDAPServer.Location = new System.Drawing.Point(15, 33);
            this.lbLDAPServer.Name = "lbLDAPServer";
            this.lbLDAPServer.Size = new System.Drawing.Size(87, 18);
            this.lbLDAPServer.TabIndex = 0;
            this.lbLDAPServer.Text = "LDAP Server:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1203, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "&Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // lvUsers
            // 
            this.lvUsers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvUsers.AllowColumnReorder = true;
            this.lvUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmUsername,
            this.clmDisplayName,
            this.clmUserParameters});
            this.lvUsers.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.HideSelection = false;
            this.lvUsers.Location = new System.Drawing.Point(17, 58);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(772, 481);
            this.lvUsers.TabIndex = 5;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            // 
            // clmUsername
            // 
            this.clmUsername.Text = "User Name";
            this.clmUsername.Width = 96;
            // 
            // clmDisplayName
            // 
            this.clmDisplayName.Text = "Display Name";
            this.clmDisplayName.Width = 181;
            // 
            // clmUserParameters
            // 
            this.clmUserParameters.Text = "userParameters";
            this.clmUserParameters.Width = 454;
            // 
            // attributes
            // 
            this.attributes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attributes.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attributes.Location = new System.Drawing.Point(797, 58);
            this.attributes.Multiline = true;
            this.attributes.Name = "attributes";
            this.attributes.ReadOnly = true;
            this.attributes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.attributes.Size = new System.Drawing.Size(392, 346);
            this.attributes.TabIndex = 6;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.Color.Black;
            this.tbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbLog.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLog.ForeColor = System.Drawing.Color.Lime;
            this.tbLog.Location = new System.Drawing.Point(17, 546);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.Size = new System.Drawing.Size(1171, 101);
            this.tbLog.TabIndex = 7;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(797, 411);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(192, 58);
            this.btnAddUser.TabIndex = 8;
            this.btnAddUser.Text = "Add New Device to New User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnRefresh.Location = new System.Drawing.Point(797, 475);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 58);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "&Refresh user list";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Enabled = false;
            this.btnEditUser.Location = new System.Drawing.Point(996, 411);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(192, 58);
            this.btnEditUser.TabIndex = 10;
            this.btnEditUser.Text = "Edit Existing User";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // lblDeviceSeeds
            // 
            this.lblDeviceSeeds.AutoSize = true;
            this.lblDeviceSeeds.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceSeeds.Location = new System.Drawing.Point(793, 32);
            this.lblDeviceSeeds.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeviceSeeds.Name = "lblDeviceSeeds";
            this.lblDeviceSeeds.Size = new System.Drawing.Size(97, 18);
            this.lblDeviceSeeds.TabIndex = 11;
            this.lblDeviceSeeds.Text = "Device Seeds: ";
            // 
            // btnCloseMain
            // 
            this.btnCloseMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCloseMain.Location = new System.Drawing.Point(1049, 475);
            this.btnCloseMain.Name = "btnCloseMain";
            this.btnCloseMain.Size = new System.Drawing.Size(140, 58);
            this.btnCloseMain.TabIndex = 12;
            this.btnCloseMain.Text = "&Close";
            this.btnCloseMain.UseVisualStyleBackColor = false;
            this.btnCloseMain.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblFilter.Location = new System.Drawing.Point(503, 32);
            this.lblFilter.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(45, 18);
            this.lblFilter.TabIndex = 13;
            this.lblFilter.Text = "Filter:";
            // 
            // tbFilter
            // 
            this.tbFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFilter.Location = new System.Drawing.Point(560, 28);
            this.tbFilter.Margin = new System.Windows.Forms.Padding(2);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(228, 23);
            this.tbFilter.TabIndex = 14;
            this.tbFilter.TextChanged += new System.EventHandler(this.tbFilter_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 661);
            this.Controls.Add(this.tbFilter);
            this.Controls.Add(this.lblFilter);
            this.Controls.Add(this.btnCloseMain);
            this.Controls.Add(this.lblDeviceSeeds);
            this.Controls.Add(this.btnEditUser);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.attributes);
            this.Controls.Add(this.lvUsers);
            this.Controls.Add(this.lbLDAPServer);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Netscaler OTP Admin";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLDAPServer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.ColumnHeader clmUsername;
        private System.Windows.Forms.ColumnHeader clmUserParameters;
        private System.Windows.Forms.TextBox attributes;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Label lblDeviceSeeds;
        private System.Windows.Forms.ColumnHeader clmDisplayName;
        private System.Windows.Forms.Button btnCloseMain;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.TextBox tbFilter;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

