namespace NetscalerOTPAdmin
{
    partial class frmAddDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDevice));
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.tbQRCode = new System.Windows.Forms.TextBox();
            this.tbOTPDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnCloseAddDevice = new System.Windows.Forms.Button();
            this.btnAddDevice = new System.Windows.Forms.Button();
            this.lblIssuer = new System.Windows.Forms.Label();
            this.tbIssuer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // pbQRCode
            // 
            this.pbQRCode.Location = new System.Drawing.Point(60, 114);
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
            this.tbQRCode.Location = new System.Drawing.Point(15, 324);
            this.tbQRCode.Name = "tbQRCode";
            this.tbQRCode.ReadOnly = true;
            this.tbQRCode.Size = new System.Drawing.Size(291, 23);
            this.tbQRCode.TabIndex = 6;
            this.tbQRCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbOTPDescription
            // 
            this.tbOTPDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOTPDescription.Location = new System.Drawing.Point(93, 46);
            this.tbOTPDescription.Name = "tbOTPDescription";
            this.tbOTPDescription.Size = new System.Drawing.Size(213, 23);
            this.tbOTPDescription.TabIndex = 7;
            this.tbOTPDescription.Text = "OTP";
            this.tbOTPDescription.TextChanged += new System.EventHandler(this.tbOTPDescription_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(10, 50);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 15);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Device Name";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(15, 370);
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
            this.btnEmail.Location = new System.Drawing.Point(111, 370);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(90, 48);
            this.btnEmail.TabIndex = 10;
            this.btnEmail.Text = "Send &Email";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnCloseAddDevice
            // 
            this.btnCloseAddDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCloseAddDevice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAddDevice.Location = new System.Drawing.Point(216, 370);
            this.btnCloseAddDevice.Name = "btnCloseAddDevice";
            this.btnCloseAddDevice.Size = new System.Drawing.Size(90, 48);
            this.btnCloseAddDevice.TabIndex = 11;
            this.btnCloseAddDevice.Text = "&Close";
            this.btnCloseAddDevice.UseVisualStyleBackColor = false;
            this.btnCloseAddDevice.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddDevice
            // 
            this.btnAddDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnAddDevice.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDevice.Location = new System.Drawing.Point(8, 75);
            this.btnAddDevice.Name = "btnAddDevice";
            this.btnAddDevice.Size = new System.Drawing.Size(298, 33);
            this.btnAddDevice.TabIndex = 4;
            this.btnAddDevice.Text = "Add New Device for selected user";
            this.btnAddDevice.UseVisualStyleBackColor = false;
            this.btnAddDevice.Click += new System.EventHandler(this.btnAddDevice_Click);
            // 
            // lblIssuer
            // 
            this.lblIssuer.AutoSize = true;
            this.lblIssuer.Location = new System.Drawing.Point(12, 15);
            this.lblIssuer.Name = "lblIssuer";
            this.lblIssuer.Size = new System.Drawing.Size(35, 13);
            this.lblIssuer.TabIndex = 12;
            this.lblIssuer.Text = "Issuer";
            // 
            // tbIssuer
            // 
            this.tbIssuer.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIssuer.Location = new System.Drawing.Point(60, 12);
            this.tbIssuer.Name = "tbIssuer";
            this.tbIssuer.Size = new System.Drawing.Size(246, 22);
            this.tbIssuer.TabIndex = 13;
            // 
            // frmAddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 430);
            this.Controls.Add(this.tbIssuer);
            this.Controls.Add(this.lblIssuer);
            this.Controls.Add(this.btnCloseAddDevice);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.tbOTPDescription);
            this.Controls.Add(this.tbQRCode);
            this.Controls.Add(this.pbQRCode);
            this.Controls.Add(this.btnAddDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddDevice";
            this.Text = "Add New Device";
            this.Shown += new System.EventHandler(this.frmAddDevice_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.TextBox tbQRCode;
        private System.Windows.Forms.TextBox tbOTPDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnCloseAddDevice;
        private System.Windows.Forms.Button btnAddDevice;
        private System.Windows.Forms.Label lblIssuer;
        private System.Windows.Forms.TextBox tbIssuer;
    }
}