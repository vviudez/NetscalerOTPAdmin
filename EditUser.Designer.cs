namespace NetscalerOTPAdmin
{
    partial class frmEditUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditUser));
            this.lblUser = new System.Windows.Forms.Label();
            this.olvSeeds = new BrightIdeasSoftware.ObjectListView();
            this.clDevice = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clSeed = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clEdit = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clRemove = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clEmail = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clQR = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.btnCloseEditUser = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.olvSeeds)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(13, 13);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(86, 15);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "User Selected:";
            // 
            // olvSeeds
            // 
            this.olvSeeds.AllColumns.Add(this.clDevice);
            this.olvSeeds.AllColumns.Add(this.clSeed);
            this.olvSeeds.AllColumns.Add(this.clEdit);
            this.olvSeeds.AllColumns.Add(this.clRemove);
            this.olvSeeds.AllColumns.Add(this.clEmail);
            this.olvSeeds.AllColumns.Add(this.clQR);
            this.olvSeeds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.olvSeeds.CellEditUseWholeCell = false;
            this.olvSeeds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clDevice,
            this.clSeed,
            this.clEdit,
            this.clRemove,
            this.clEmail,
            this.clQR});
            this.olvSeeds.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvSeeds.GridLines = true;
            this.olvSeeds.HeaderUsesThemes = true;
            this.olvSeeds.HeaderWordWrap = true;
            this.olvSeeds.HideSelection = false;
            this.olvSeeds.Location = new System.Drawing.Point(12, 31);
            this.olvSeeds.Name = "olvSeeds";
            this.olvSeeds.RowHeight = 30;
            this.olvSeeds.ShowGroups = false;
            this.olvSeeds.Size = new System.Drawing.Size(798, 442);
            this.olvSeeds.SortGroupItemsByPrimaryColumn = false;
            this.olvSeeds.TabIndex = 1;
            this.olvSeeds.UseCompatibleStateImageBehavior = false;
            this.olvSeeds.UseOverlays = false;
            this.olvSeeds.View = System.Windows.Forms.View.Details;
            // 
            // clDevice
            // 
            this.clDevice.AspectName = "Device";
            this.clDevice.IsEditable = false;
            this.clDevice.Text = "Device";
            // 
            // clSeed
            // 
            this.clSeed.AspectName = "SeedToken";
            this.clSeed.Hideable = false;
            this.clSeed.IsEditable = false;
            this.clSeed.Text = "Seed";
            this.clSeed.Width = 300;
            // 
            // clEdit
            // 
            this.clEdit.AspectName = "Edit";
            this.clEdit.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.clEdit.Hideable = false;
            this.clEdit.IsButton = true;
            this.clEdit.IsEditable = false;
            this.clEdit.Text = "Edit Device";
            this.clEdit.Width = 100;
            // 
            // clRemove
            // 
            this.clRemove.AspectName = "Remove";
            this.clRemove.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.clRemove.Hideable = false;
            this.clRemove.IsButton = true;
            this.clRemove.IsEditable = false;
            this.clRemove.Text = "Remove Device";
            this.clRemove.Width = 100;
            // 
            // clEmail
            // 
            this.clEmail.AspectName = "Email";
            this.clEmail.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.clEmail.IsButton = true;
            this.clEmail.Text = "Email";
            this.clEmail.Width = 100;
            // 
            // clQR
            // 
            this.clQR.AspectName = "QR";
            this.clQR.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.clQR.IsButton = true;
            this.clQR.IsEditable = false;
            this.clQR.Text = "QR";
            // 
            // btnCloseEditUser
            // 
            this.btnCloseEditUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCloseEditUser.Location = new System.Drawing.Point(721, 479);
            this.btnCloseEditUser.Name = "btnCloseEditUser";
            this.btnCloseEditUser.Size = new System.Drawing.Size(90, 48);
            this.btnCloseEditUser.TabIndex = 2;
            this.btnCloseEditUser.Text = "&Close";
            this.btnCloseEditUser.UseVisualStyleBackColor = false;
            this.btnCloseEditUser.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAddDevice.Location = new System.Drawing.Point(12, 479);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(172, 48);
            this.btnAddDevice.TabIndex = 3;
            this.btnAddDevice.Text = "Add &New Device";
            this.btnAddDevice.UseVisualStyleBackColor = false;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // frmEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 539);
            this.Controls.Add(this.btnAddDevice);
            this.Controls.Add(this.btnCloseEditUser);
            this.Controls.Add(this.olvSeeds);
            this.Controls.Add(this.lblUser);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEditUser";
            this.Text = "Edit User";
            this.Shown += new System.EventHandler(this.frmEditUser_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.olvSeeds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUser;
        private BrightIdeasSoftware.ObjectListView olvSeeds;
        private BrightIdeasSoftware.OLVColumn clSeed;
        private BrightIdeasSoftware.OLVColumn clEdit;
        private BrightIdeasSoftware.OLVColumn clRemove;
        private BrightIdeasSoftware.OLVColumn clDevice;
        private BrightIdeasSoftware.OLVColumn clEmail;
        private BrightIdeasSoftware.OLVColumn clQR;
        private System.Windows.Forms.Button btnCloseEditUser;
        private System.Windows.Forms.Button btnAddDevice;
    }
}