namespace ProjectManagement.View
{
    partial class formCreatingProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCreatingProject));
            this.lyoutControlProject = new DevExpress.XtraLayout.LayoutControl();
            this.cbbPOSMProject = new System.Windows.Forms.ComboBox();
            this.cbbProjectType = new System.Windows.Forms.ComboBox();
            this.cbbLeader = new System.Windows.Forms.ComboBox();
            this.dtEdtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dtEdtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.txtEdtProjectID = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lytCtrlProjectName = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytCtrlStartDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytCtrlProjectID = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytCtrlLeader = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytCtrlEndDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytCtrlProjectType = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnOke = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlProject)).BeginInit();
            this.lyoutControlProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlProjectName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlProjectID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlLeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlProjectType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // lyoutControlProject
            // 
            this.lyoutControlProject.Controls.Add(this.cbbPOSMProject);
            this.lyoutControlProject.Controls.Add(this.cbbProjectType);
            this.lyoutControlProject.Controls.Add(this.cbbLeader);
            this.lyoutControlProject.Controls.Add(this.dtEdtEndDate);
            this.lyoutControlProject.Controls.Add(this.dtEdtStartDate);
            this.lyoutControlProject.Controls.Add(this.txtEdtProjectID);
            this.lyoutControlProject.Controls.Add(this.txtEdtProjectName);
            this.lyoutControlProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.lyoutControlProject.Location = new System.Drawing.Point(0, 0);
            this.lyoutControlProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lyoutControlProject.Name = "lyoutControlProject";
            this.lyoutControlProject.Root = this.layoutControlGroup1;
            this.lyoutControlProject.Size = new System.Drawing.Size(584, 143);
            this.lyoutControlProject.TabIndex = 0;
            this.lyoutControlProject.Text = "layoutControl1";
            // 
            // cbbPOSMProject
            // 
            this.cbbPOSMProject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPOSMProject.FormattingEnabled = true;
            this.cbbPOSMProject.Location = new System.Drawing.Point(80, 110);
            this.cbbPOSMProject.Name = "cbbPOSMProject";
            this.cbbPOSMProject.Size = new System.Drawing.Size(492, 21);
            this.cbbPOSMProject.TabIndex = 6;
            this.cbbPOSMProject.DropDown += new System.EventHandler(this.cbbPOSMProject_DropDown);
            this.cbbPOSMProject.SelectedIndexChanged += new System.EventHandler(this.cbbPOSMProject_SelectedIndexChanged);
            this.cbbPOSMProject.SelectionChangeCommitted += new System.EventHandler(this.cbbPOSMProject_SelectionChangeCommitted);
            this.cbbPOSMProject.DropDownClosed += new System.EventHandler(this.cbbPOSMProject_DropDownClosed);
            this.cbbPOSMProject.TextChanged += new System.EventHandler(this.cbbPOSMProject_TextChanged);
            this.cbbPOSMProject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbPOSMProject_KeyDown);
            // 
            // cbbProjectType
            // 
            this.cbbProjectType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbProjectType.FormattingEnabled = true;
            this.cbbProjectType.Location = new System.Drawing.Point(80, 85);
            this.cbbProjectType.Name = "cbbProjectType";
            this.cbbProjectType.Size = new System.Drawing.Size(492, 21);
            this.cbbProjectType.TabIndex = 5;
            this.cbbProjectType.DropDown += new System.EventHandler(this.cbbProjectType_DropDown);
            this.cbbProjectType.SelectedIndexChanged += new System.EventHandler(this.cbbProjectType_SelectedIndexChanged);
            this.cbbProjectType.SelectionChangeCommitted += new System.EventHandler(this.cbbProjectType_SelectionChangeCommitted);
            this.cbbProjectType.DropDownClosed += new System.EventHandler(this.cbbProjectType_DropDownClosed);
            this.cbbProjectType.TextChanged += new System.EventHandler(this.cbbProjectType_TextChanged);
            this.cbbProjectType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbProjectType_KeyDown);
            // 
            // cbbLeader
            // 
            this.cbbLeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLeader.FormattingEnabled = true;
            this.cbbLeader.Location = new System.Drawing.Point(80, 60);
            this.cbbLeader.Name = "cbbLeader";
            this.cbbLeader.Size = new System.Drawing.Size(492, 21);
            this.cbbLeader.TabIndex = 2;
            this.cbbLeader.DropDown += new System.EventHandler(this.cbbLeader_DropDown);
            this.cbbLeader.SelectedIndexChanged += new System.EventHandler(this.cbbLeader_SelectedIndexChanged);
            this.cbbLeader.SelectionChangeCommitted += new System.EventHandler(this.cbbLeader_SelectionChangeCommitted);
            this.cbbLeader.DropDownClosed += new System.EventHandler(this.cbbLeader_DropDownClosed);
            this.cbbLeader.TextChanged += new System.EventHandler(this.cbbLeader_TextChanged);
            this.cbbLeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbLeader_KeyDown);
            // 
            // dtEdtEndDate
            // 
            this.dtEdtEndDate.EditValue = null;
            this.dtEdtEndDate.Location = new System.Drawing.Point(330, 36);
            this.dtEdtEndDate.Name = "dtEdtEndDate";
            this.dtEdtEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtEdtEndDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEdtEndDate.Properties.Appearance.Options.UseFont = true;
            this.dtEdtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Size = new System.Drawing.Size(242, 20);
            this.dtEdtEndDate.StyleController = this.lyoutControlProject;
            this.dtEdtEndDate.TabIndex = 4;
            this.dtEdtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtEdtEndDate_KeyDown);
            this.dtEdtEndDate.Leave += new System.EventHandler(this.dtEdtEndDate_Leave);
            // 
            // dtEdtStartDate
            // 
            this.dtEdtStartDate.EditValue = null;
            this.dtEdtStartDate.Location = new System.Drawing.Point(330, 12);
            this.dtEdtStartDate.Name = "dtEdtStartDate";
            this.dtEdtStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtEdtStartDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEdtStartDate.Properties.Appearance.Options.UseFont = true;
            this.dtEdtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Size = new System.Drawing.Size(242, 20);
            this.dtEdtStartDate.StyleController = this.lyoutControlProject;
            this.dtEdtStartDate.TabIndex = 3;
            this.dtEdtStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtEdtStartDate_KeyDown);
            this.dtEdtStartDate.Leave += new System.EventHandler(this.dtEdtStartDate_Leave);
            // 
            // txtEdtProjectID
            // 
            this.txtEdtProjectID.Location = new System.Drawing.Point(80, 12);
            this.txtEdtProjectID.Name = "txtEdtProjectID";
            this.txtEdtProjectID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdtProjectID.Properties.Appearance.Options.UseFont = true;
            this.txtEdtProjectID.Properties.MaxLength = 20;
            this.txtEdtProjectID.Size = new System.Drawing.Size(178, 20);
            this.txtEdtProjectID.StyleController = this.lyoutControlProject;
            this.txtEdtProjectID.TabIndex = 0;
            this.txtEdtProjectID.EditValueChanged += new System.EventHandler(this.txtEdtProjectID_EditValueChanged);
            this.txtEdtProjectID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdtProjectID_KeyDown);
            // 
            // txtEdtProjectName
            // 
            this.txtEdtProjectName.Location = new System.Drawing.Point(80, 36);
            this.txtEdtProjectName.Name = "txtEdtProjectName";
            this.txtEdtProjectName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdtProjectName.Properties.Appearance.Options.UseFont = true;
            this.txtEdtProjectName.Properties.MaxLength = 50;
            this.txtEdtProjectName.Size = new System.Drawing.Size(178, 20);
            this.txtEdtProjectName.StyleController = this.lyoutControlProject;
            this.txtEdtProjectName.TabIndex = 1;
            this.txtEdtProjectName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdtProjectName_KeyDown);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lytCtrlProjectName,
            this.lytCtrlStartDate,
            this.lytCtrlProjectID,
            this.lytCtrlLeader,
            this.lytCtrlEndDate,
            this.lytCtrlProjectType,
            this.layoutControlItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 143);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lytCtrlProjectName
            // 
            this.lytCtrlProjectName.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lytCtrlProjectName.AppearanceItemCaption.Options.UseFont = true;
            this.lytCtrlProjectName.Control = this.txtEdtProjectName;
            this.lytCtrlProjectName.Location = new System.Drawing.Point(0, 24);
            this.lytCtrlProjectName.Name = "lytCtrlProjectName";
            this.lytCtrlProjectName.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lytCtrlProjectName.Size = new System.Drawing.Size(250, 24);
            this.lytCtrlProjectName.Text = "Project name";
            this.lytCtrlProjectName.TextSize = new System.Drawing.Size(65, 13);
            // 
            // lytCtrlStartDate
            // 
            this.lytCtrlStartDate.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lytCtrlStartDate.AppearanceItemCaption.Options.UseFont = true;
            this.lytCtrlStartDate.Control = this.dtEdtStartDate;
            this.lytCtrlStartDate.Location = new System.Drawing.Point(250, 0);
            this.lytCtrlStartDate.Name = "lytCtrlStartDate";
            this.lytCtrlStartDate.OptionsTableLayoutItem.RowIndex = 1;
            this.lytCtrlStartDate.Size = new System.Drawing.Size(314, 24);
            this.lytCtrlStartDate.Text = "Start date";
            this.lytCtrlStartDate.TextSize = new System.Drawing.Size(65, 13);
            // 
            // lytCtrlProjectID
            // 
            this.lytCtrlProjectID.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lytCtrlProjectID.AppearanceItemCaption.Options.UseFont = true;
            this.lytCtrlProjectID.Control = this.txtEdtProjectID;
            this.lytCtrlProjectID.CustomizationFormText = "Project ID (*)";
            this.lytCtrlProjectID.Location = new System.Drawing.Point(0, 0);
            this.lytCtrlProjectID.Name = "lytCtrlProjectID";
            this.lytCtrlProjectID.Size = new System.Drawing.Size(250, 24);
            this.lytCtrlProjectID.Text = "Project ID (*)";
            this.lytCtrlProjectID.TextSize = new System.Drawing.Size(65, 13);
            // 
            // lytCtrlLeader
            // 
            this.lytCtrlLeader.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lytCtrlLeader.AppearanceItemCaption.Options.UseFont = true;
            this.lytCtrlLeader.Control = this.cbbLeader;
            this.lytCtrlLeader.Location = new System.Drawing.Point(0, 48);
            this.lytCtrlLeader.Name = "lytCtrlLeader";
            this.lytCtrlLeader.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lytCtrlLeader.OptionsTableLayoutItem.RowIndex = 5;
            this.lytCtrlLeader.Size = new System.Drawing.Size(564, 25);
            this.lytCtrlLeader.Text = "Leader";
            this.lytCtrlLeader.TextSize = new System.Drawing.Size(65, 13);
            // 
            // lytCtrlEndDate
            // 
            this.lytCtrlEndDate.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lytCtrlEndDate.AppearanceItemCaption.Options.UseFont = true;
            this.lytCtrlEndDate.Control = this.dtEdtEndDate;
            this.lytCtrlEndDate.Location = new System.Drawing.Point(250, 24);
            this.lytCtrlEndDate.Name = "lytCtrlEndDate";
            this.lytCtrlEndDate.OptionsTableLayoutItem.ColumnIndex = 1;
            this.lytCtrlEndDate.OptionsTableLayoutItem.RowIndex = 1;
            this.lytCtrlEndDate.Size = new System.Drawing.Size(314, 24);
            this.lytCtrlEndDate.Text = "End date";
            this.lytCtrlEndDate.TextSize = new System.Drawing.Size(65, 13);
            // 
            // lytCtrlProjectType
            // 
            this.lytCtrlProjectType.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lytCtrlProjectType.AppearanceItemCaption.Options.UseFont = true;
            this.lytCtrlProjectType.Control = this.cbbProjectType;
            this.lytCtrlProjectType.Location = new System.Drawing.Point(0, 73);
            this.lytCtrlProjectType.Name = "lytCtrlProjectType";
            this.lytCtrlProjectType.OptionsTableLayoutItem.RowIndex = 2;
            this.lytCtrlProjectType.Size = new System.Drawing.Size(564, 25);
            this.lytCtrlProjectType.Text = "Project type";
            this.lytCtrlProjectType.TextSize = new System.Drawing.Size(65, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.cbbPOSMProject;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.OptionsTableLayoutItem.ColumnIndex = 1;
            this.layoutControlItem1.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutControlItem1.Size = new System.Drawing.Size(564, 25);
            this.layoutControlItem1.Text = "POSM project";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(65, 13);
            // 
            // btnOke
            // 
            this.btnOke.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOke.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOke.Appearance.Options.UseFont = true;
            this.btnOke.Location = new System.Drawing.Point(386, 224);
            this.btnOke.Name = "btnOke";
            this.btnOke.Size = new System.Drawing.Size(90, 25);
            this.btnOke.TabIndex = 4;
            this.btnOke.Text = "OK";
            this.btnOke.Click += new System.EventHandler(this.btnOke_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(482, 224);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // formCreatingProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOke);
            this.Controls.Add(this.lyoutControlProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCreatingProject";
            this.Text = "Project creating";
            this.Load += new System.EventHandler(this.formCreatingProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlProject)).EndInit();
            this.lyoutControlProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlProjectName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlProjectID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlLeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlProjectType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl lyoutControlProject;
        private System.Windows.Forms.ComboBox cbbPOSMProject;
        private System.Windows.Forms.ComboBox cbbProjectType;
        private System.Windows.Forms.ComboBox cbbLeader;
        private DevExpress.XtraEditors.DateEdit dtEdtEndDate;
        private DevExpress.XtraEditors.DateEdit dtEdtStartDate;
        private DevExpress.XtraEditors.TextEdit txtEdtProjectID;
        private DevExpress.XtraEditors.TextEdit txtEdtProjectName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlProjectName;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlStartDate;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlProjectID;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlLeader;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlEndDate;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlProjectType;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnOke;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}