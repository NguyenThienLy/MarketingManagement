namespace ProjectManagement.View
{
    partial class formLoading
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
            this.prgpnlloading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgpnlloading
            // 
            this.prgpnlloading.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.prgpnlloading.Appearance.Options.UseBackColor = true;
            this.prgpnlloading.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.prgpnlloading.AppearanceCaption.Options.UseFont = true;
            this.prgpnlloading.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.prgpnlloading.AppearanceDescription.Options.UseFont = true;
            this.prgpnlloading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prgpnlloading.ImageHorzOffset = 20;
            this.prgpnlloading.Location = new System.Drawing.Point(0, 21);
            this.prgpnlloading.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.prgpnlloading.Name = "prgpnlloading";
            this.prgpnlloading.Size = new System.Drawing.Size(328, 48);
            this.prgpnlloading.TabIndex = 0;
            this.prgpnlloading.Text = "progressPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.prgpnlloading, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 17, 0, 17);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(328, 90);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // formLoading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(328, 90);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "formLoading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel prgpnlloading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
