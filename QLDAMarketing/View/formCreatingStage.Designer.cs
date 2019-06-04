namespace ProjectManagement.View
{
    partial class formCreatingStage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCreatingStage));
            this.lyoutControlStage = new DevExpress.XtraLayout.LayoutControl();
            this.txtEdtProjectID = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtStageSubject = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtStage = new DevExpress.XtraEditors.TextEdit();
            this.lyItemCreatingStage = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlStage)).BeginInit();
            this.lyoutControlStage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStageSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyItemCreatingStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lyoutControlStage
            // 
            this.lyoutControlStage.Controls.Add(this.txtEdtProjectID);
            this.lyoutControlStage.Controls.Add(this.txtEdtStageSubject);
            this.lyoutControlStage.Controls.Add(this.txtEdtStage);
            this.lyoutControlStage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lyoutControlStage.Location = new System.Drawing.Point(0, 0);
            this.lyoutControlStage.Name = "lyoutControlStage";
            this.lyoutControlStage.Root = this.lyItemCreatingStage;
            this.lyoutControlStage.Size = new System.Drawing.Size(584, 69);
            this.lyoutControlStage.TabIndex = 0;
            this.lyoutControlStage.Text = "layoutControl1";
            // 
            // txtEdtProjectID
            // 
            this.txtEdtProjectID.Location = new System.Drawing.Point(81, 12);
            this.txtEdtProjectID.Name = "txtEdtProjectID";
            this.txtEdtProjectID.Size = new System.Drawing.Size(208, 20);
            this.txtEdtProjectID.StyleController = this.lyoutControlStage;
            this.txtEdtProjectID.TabIndex = 0;
            this.txtEdtProjectID.TabStop = false;
            // 
            // txtEdtStageSubject
            // 
            this.txtEdtStageSubject.Location = new System.Drawing.Point(81, 36);
            this.txtEdtStageSubject.Name = "txtEdtStageSubject";
            this.txtEdtStageSubject.Properties.MaxLength = 30;
            this.txtEdtStageSubject.Size = new System.Drawing.Size(491, 20);
            this.txtEdtStageSubject.StyleController = this.lyoutControlStage;
            this.txtEdtStageSubject.TabIndex = 2;
            this.txtEdtStageSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdtStageSubject_KeyDown);
            // 
            // txtEdtStage
            // 
            this.txtEdtStage.Location = new System.Drawing.Point(362, 12);
            this.txtEdtStage.Name = "txtEdtStage";
            this.txtEdtStage.Size = new System.Drawing.Size(210, 20);
            this.txtEdtStage.StyleController = this.lyoutControlStage;
            this.txtEdtStage.TabIndex = 1;
            this.txtEdtStage.TabStop = false;
            // 
            // lyItemCreatingStage
            // 
            this.lyItemCreatingStage.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lyItemCreatingStage.GroupBordersVisible = false;
            this.lyItemCreatingStage.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1});
            this.lyItemCreatingStage.Location = new System.Drawing.Point(0, 0);
            this.lyItemCreatingStage.Name = "lyItemCreatingStage";
            this.lyItemCreatingStage.Size = new System.Drawing.Size(584, 69);
            this.lyItemCreatingStage.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEdtStage;
            this.layoutControlItem2.Location = new System.Drawing.Point(281, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(283, 24);
            this.layoutControlItem2.Text = "Stage (*)";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEdtStageSubject;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(564, 25);
            this.layoutControlItem3.Text = "Stage subject";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(66, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtEdtProjectID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(281, 24);
            this.layoutControlItem1.Text = "Project ID (*)";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 13);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Location = new System.Drawing.Point(376, 224);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(90, 25);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(280, 224);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(482, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // formCreatingStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lyoutControlStage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCreatingStage";
            this.Text = "Stage creating";
            this.Load += new System.EventHandler(this.formCreatingStage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlStage)).EndInit();
            this.lyoutControlStage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStageSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyItemCreatingStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lyoutControlStage;
        private DevExpress.XtraEditors.TextEdit txtEdtStageSubject;
        private DevExpress.XtraEditors.TextEdit txtEdtStage;
        private DevExpress.XtraLayout.LayoutControlGroup lyItemCreatingStage;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit txtEdtProjectID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}