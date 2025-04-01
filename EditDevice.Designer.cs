namespace NetscalerOTPAdmin
{
    partial class frmEditDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDevice));
            this.lblDevice = new System.Windows.Forms.Label();
            this.tbDevice = new System.Windows.Forms.TextBox();
            this.lblSeed = new System.Windows.Forms.Label();
            this.tbSeed = new System.Windows.Forms.TextBox();
            this.btnCloseEditDevice = new System.Windows.Forms.Button();
            this.btnOkEditDevice = new System.Windows.Forms.Button();
            this.pbQRCode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(14, 31);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(43, 15);
            this.lblDevice.TabIndex = 0;
            this.lblDevice.Text = "Device";
            // 
            // tbDevice
            // 
            this.tbDevice.Location = new System.Drawing.Point(63, 28);
            this.tbDevice.Name = "tbDevice";
            this.tbDevice.Size = new System.Drawing.Size(280, 23);
            this.tbDevice.TabIndex = 1;
            // 
            // lblSeed
            // 
            this.lblSeed.AutoSize = true;
            this.lblSeed.Location = new System.Drawing.Point(17, 78);
            this.lblSeed.Name = "lblSeed";
            this.lblSeed.Size = new System.Drawing.Size(32, 15);
            this.lblSeed.TabIndex = 2;
            this.lblSeed.Text = "Seed";
            // 
            // tbSeed
            // 
            this.tbSeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSeed.Location = new System.Drawing.Point(63, 75);
            this.tbSeed.Name = "tbSeed";
            this.tbSeed.ReadOnly = true;
            this.tbSeed.Size = new System.Drawing.Size(280, 16);
            this.tbSeed.TabIndex = 3;
            // 
            // btnCloseEditDevice
            // 
            this.btnCloseEditDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCloseEditDevice.Location = new System.Drawing.Point(272, 365);
            this.btnCloseEditDevice.Name = "btnCloseEditDevice";
            this.btnCloseEditDevice.Size = new System.Drawing.Size(75, 45);
            this.btnCloseEditDevice.TabIndex = 4;
            this.btnCloseEditDevice.Text = "&Close";
            this.btnCloseEditDevice.UseVisualStyleBackColor = false;
            this.btnCloseEditDevice.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOkEditDevice
            // 
            this.btnOkEditDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnOkEditDevice.Location = new System.Drawing.Point(191, 365);
            this.btnOkEditDevice.Name = "btnOkEditDevice";
            this.btnOkEditDevice.Size = new System.Drawing.Size(75, 45);
            this.btnOkEditDevice.TabIndex = 5;
            this.btnOkEditDevice.Text = "&Ok";
            this.btnOkEditDevice.UseVisualStyleBackColor = false;
            this.btnOkEditDevice.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // pbQRCode
            // 
            this.pbQRCode.Location = new System.Drawing.Point(53, 100);
            this.pbQRCode.Name = "pbQRCode";
            this.pbQRCode.Size = new System.Drawing.Size(258, 250);
            this.pbQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbQRCode.TabIndex = 6;
            this.pbQRCode.TabStop = false;
            // 
            // frmEditDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 418);
            this.Controls.Add(this.pbQRCode);
            this.Controls.Add(this.btnOkEditDevice);
            this.Controls.Add(this.btnCloseEditDevice);
            this.Controls.Add(this.tbSeed);
            this.Controls.Add(this.lblSeed);
            this.Controls.Add(this.tbDevice);
            this.Controls.Add(this.lblDevice);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditDevice";
            this.Text = "Edit Device";
            this.Load += new System.EventHandler(this.frmEditDevice_Load);
            this.Shown += new System.EventHandler(this.frmEditDevice_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbQRCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.TextBox tbDevice;
        private System.Windows.Forms.Label lblSeed;
        private System.Windows.Forms.TextBox tbSeed;
        private System.Windows.Forms.Button btnCloseEditDevice;
        private System.Windows.Forms.Button btnOkEditDevice;
        private System.Windows.Forms.PictureBox pbQRCode;
    }
}