namespace NetscalerOTPAdmin
{
    partial class frmMasterPasswd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMasterPasswd));
            this.label1 = new System.Windows.Forms.Label();
            this.tbMPwd = new System.Windows.Forms.TextBox();
            this.btnSubmitPasswd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insert your Master Password to open the application:";
            // 
            // tbMPwd
            // 
            this.tbMPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMPwd.Location = new System.Drawing.Point(12, 61);
            this.tbMPwd.Name = "tbMPwd";
            this.tbMPwd.PasswordChar = '*';
            this.tbMPwd.Size = new System.Drawing.Size(720, 27);
            this.tbMPwd.TabIndex = 1;
            this.tbMPwd.TextChanged += new System.EventHandler(this.tbMPwd_TextChanged);
            // 
            // btnSubmitPasswd
            // 
            this.btnSubmitPasswd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSubmitPasswd.Enabled = false;
            this.btnSubmitPasswd.Location = new System.Drawing.Point(636, 111);
            this.btnSubmitPasswd.Name = "btnSubmitPasswd";
            this.btnSubmitPasswd.Size = new System.Drawing.Size(96, 39);
            this.btnSubmitPasswd.TabIndex = 2;
            this.btnSubmitPasswd.Text = "&Submit";
            this.btnSubmitPasswd.UseVisualStyleBackColor = false;
            this.btnSubmitPasswd.Click += new System.EventHandler(this.btnSubmitPasswd_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Location = new System.Drawing.Point(522, 111);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 39);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMasterPasswd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(744, 162);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmitPasswd);
            this.Controls.Add(this.tbMPwd);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMasterPasswd";
            this.Text = "Master Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMasterPasswd_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMPwd;
        private System.Windows.Forms.Button btnSubmitPasswd;
        private System.Windows.Forms.Button btnClose;
    }
}