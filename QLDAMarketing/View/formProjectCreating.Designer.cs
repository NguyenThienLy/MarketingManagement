namespace ProjectManagement.View
{
    partial class formProjectCreating
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
            this.components = new System.ComponentModel.Container();
            this.mdiProjectCreating = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mdiProjectCreating)).BeginInit();
            this.SuspendLayout();
            // 
            // mdiProjectCreating
            // 
            this.mdiProjectCreating.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.mdiProjectCreating.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.mdiProjectCreating.CloseTabOnMiddleClick = DevExpress.XtraTabbedMdi.CloseTabOnMiddleClick.Never;
            this.mdiProjectCreating.MdiParent = this;
            this.mdiProjectCreating.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.True;
            this.mdiProjectCreating.PageRemoved += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.mdiProjectCreating_PageRemoved);
            // 
            // formProjectCreating
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 359);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formProjectCreating";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project creating";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formProjectCreating_FormClosed);
            this.Load += new System.EventHandler(this.formProjectCreating_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mdiProjectCreating)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdiProjectCreating;
    }
}