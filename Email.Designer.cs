namespace NetscalerOTPAdmin
{
    partial class frmEmail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
            this.wbDisplayEmail = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnCloseEmailPreview = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.tbDisplayName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // wbDisplayEmail
            // 
            this.wbDisplayEmail.AllowNavigation = false;
            this.wbDisplayEmail.AllowWebBrowserDrop = false;
            this.wbDisplayEmail.Location = new System.Drawing.Point(13, 13);
            this.wbDisplayEmail.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDisplayEmail.Name = "wbDisplayEmail";
            this.wbDisplayEmail.Size = new System.Drawing.Size(764, 463);
            this.wbDisplayEmail.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(784, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Email";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(798, 115);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(291, 23);
            this.tbEmail.TabIndex = 2;
            // 
            // btnCloseEmailPreview
            // 
            this.btnCloseEmailPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCloseEmailPreview.Location = new System.Drawing.Point(1014, 432);
            this.btnCloseEmailPreview.Name = "btnCloseEmailPreview";
            this.btnCloseEmailPreview.Size = new System.Drawing.Size(75, 44);
            this.btnCloseEmailPreview.TabIndex = 3;
            this.btnCloseEmailPreview.Text = "&Close";
            this.btnCloseEmailPreview.UseVisualStyleBackColor = false;
            this.btnCloseEmailPreview.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(911, 432);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(97, 44);
            this.btnSendEmail.TabIndex = 4;
            this.btnSendEmail.Text = "&Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // tbDisplayName
            // 
            this.tbDisplayName.Location = new System.Drawing.Point(798, 38);
            this.tbDisplayName.Name = "tbDisplayName";
            this.tbDisplayName.Size = new System.Drawing.Size(291, 23);
            this.tbDisplayName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(784, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "User";
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(798, 432);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(93, 44);
            this.btnSaveData.TabIndex = 7;
            this.btnSaveData.Text = "Save as &HTML";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 490);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.tbDisplayName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.btnCloseEmailPreview);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wbDisplayEmail);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmail";
            this.Text = "Email Preview";
            this.Shown += new System.EventHandler(this.frmEmail_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbDisplayEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Button btnCloseEmailPreview;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.TextBox tbDisplayName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveData;
    }
}