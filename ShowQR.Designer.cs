namespace NetscalerOTPAdmin
{
    partial class frmShowQR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowQR));
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblSeed = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            this.btnSaveQR = new System.Windows.Forms.Button();
            this.tbSeed = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(14, 9);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(43, 15);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.Text = "Device";
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(14, 33);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(32, 15);
            this.lblSeed.TabIndex = 2;
            this.lblSeed.Text = "Seed";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Location = new System.Drawing.Point(222, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 45);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pbQRCode
            // 
            this.pbQRCode.Location = new System.Drawing.Point(17, 54);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(280, 280);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 6;
            this.pbQRCode.TabStop = false;
            // 
            // btnSaveQR
            // 
            this.btnSaveQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveQR.Location = new System.Drawing.Point(17, 341);
            this.btnSaveQR.Name = "btnSaveQR";
            this.btnSaveQR.Size = new System.Drawing.Size(107, 44);
            this.btnSaveQR.TabIndex = 7;
            this.btnSaveQR.Text = "&Save QR as JPG";
            this.btnSaveQR.UseVisualStyleBackColor = false;
            this.btnSaveQR.Click += new System.EventHandler(this.btnSaveQR_Click);
            // 
            // tbSeed
            // 
            this.tbSeed.BackColor = System.Drawing.SystemColors.Control;
            this.tbSeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSeed.Location = new System.Drawing.Point(52, 31);
            this.tbSeed.Name = "tbSeed";
            this.tbSeed.Size = new System.Drawing.Size(244, 16);
            this.tbSeed.TabIndex = 8;
            // 
            // frmShowQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 397);
            this.Controls.Add(this.tbSeed);
            this.Controls.Add(this.btnSaveQR);
            this.Controls.Add(this.pbQRCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.lblDevice);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowQR";
            this.Text = "Show QR";
            this.Load += new System.EventHandler(this.frmShowQR_Load);
            this.Shown += new System.EventHandler(this.frmEditDevice_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pbQRCode;
        private System.Windows.Forms.Button btnSaveQR;
        private System.Windows.Forms.TextBox tbSeed;
    }
}