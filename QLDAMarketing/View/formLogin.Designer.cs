namespace ProjectManagement.View
{
    partial class formLogIn
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtEdtServerIP = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtPassword = new DevExpress.XtraEditors.TextEdit();
            this.cbbUsername = new System.Windows.Forms.ComboBox();
            this.chkBxRememberAccount = new System.Windows.Forms.CheckBox();
            this.btnChange = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtServerIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtEdtServerIP);
            this.panelControl1.Controls.Add(this.txtEdtPassword);
            this.panelControl1.Controls.Add(this.cbbUsername);
            this.panelControl1.Controls.Add(this.chkBxRememberAccount);
            this.panelControl1.Controls.Add(this.btnChange);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 181);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(563, 154);
            this.panelControl1.TabIndex = 0;
            // 
            // txtEdtServerIP
            // 
            this.txtEdtServerIP.Location = new System.Drawing.Point(96, 87);
            this.txtEdtServerIP.Name = "txtEdtServerIP";
            this.txtEdtServerIP.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdtServerIP.Properties.Appearance.Options.UseFont = true;
            this.txtEdtServerIP.Size = new System.Drawing.Size(352, 24);
            this.txtEdtServerIP.TabIndex = 2;
            this.txtEdtServerIP.TabStop = false;
            this.txtEdtServerIP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdtServerIP_KeyDown);
            // 
            // txtEdtPassword
            // 
            this.txtEdtPassword.EditValue = "";
            this.txtEdtPassword.Location = new System.Drawing.Point(96, 46);
            this.txtEdtPassword.Name = "txtEdtPassword";
            this.txtEdtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtEdtPassword.Properties.PasswordChar = '•';
            this.txtEdtPassword.Size = new System.Drawing.Size(352, 24);
            this.txtEdtPassword.TabIndex = 1;
            this.txtEdtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdtPassword_KeyDown);
            // 
            // cbbUsername
            // 
            this.cbbUsername.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbUsername.FormattingEnabled = true;
            this.cbbUsername.Location = new System.Drawing.Point(96, 9);
            this.cbbUsername.MaxDropDownItems = 10;
            this.cbbUsername.Name = "cbbUsername";
            this.cbbUsername.Size = new System.Drawing.Size(352, 24);
            this.cbbUsername.TabIndex = 0;
            this.cbbUsername.DropDown += new System.EventHandler(this.cbbUsername_DropDown);
            this.cbbUsername.SelectedIndexChanged += new System.EventHandler(this.cbbUsername_SelectedIndexChanged);
            this.cbbUsername.SelectionChangeCommitted += new System.EventHandler(this.cbbUsername_SelectionChangeCommitted);
            this.cbbUsername.DropDownClosed += new System.EventHandler(this.cbbUsername_DropDownClosed);
            this.cbbUsername.TextChanged += new System.EventHandler(this.cbbUsername_TextChanged);
            this.cbbUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbUsername_KeyDown);
            // 
            // chkBxRememberAccount
            // 
            this.chkBxRememberAccount.AutoSize = true;
            this.chkBxRememberAccount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBxRememberAccount.Location = new System.Drawing.Point(13, 125);
            this.chkBxRememberAccount.Name = "chkBxRememberAccount";
            this.chkBxRememberAccount.Size = new System.Drawing.Size(138, 20);
            this.chkBxRememberAccount.TabIndex = 4;
            this.chkBxRememberAccount.Text = "Remember account";
            this.chkBxRememberAccount.UseVisualStyleBackColor = true;
            this.chkBxRememberAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkBxRememberAccount_KeyDown);
            // 
            // btnChange
            // 
            this.btnChange.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Appearance.Options.UseFont = true;
            this.btnChange.Location = new System.Drawing.Point(461, 87);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(90, 25);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "Change";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(358, 121);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(258, 121);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Server IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Username";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::ProjectManagement.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(563, 181);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // formLogIn
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 335);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log In";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formLogIn_FormClosed);
            this.Load += new System.EventHandler(this.formLogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtServerIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtEdtServerIP;
        public System.Windows.Forms.CheckBox chkBxRememberAccount;
        private DevExpress.XtraEditors.SimpleButton btnChange;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public DevExpress.XtraEditors.TextEdit txtEdtPassword;
        public System.Windows.Forms.ComboBox cbbUsername;
        public DevExpress.XtraEditors.SimpleButton btnOK;
    }
}