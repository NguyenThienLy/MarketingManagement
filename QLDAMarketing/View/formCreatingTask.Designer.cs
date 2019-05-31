namespace ProjectManagement.View
{
    partial class formCreatingTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCreatingTask));
            this.lyoutControlTaskCreating = new DevExpress.XtraLayout.LayoutControl();
            this.txtEdtProjectID = new DevExpress.XtraEditors.TextEdit();
            this.rchTxtBxTask = new System.Windows.Forms.RichTextBox();
            this.cbbAttachFile = new System.Windows.Forms.ComboBox();
            this.cbbApprover = new System.Windows.Forms.ComboBox();
            this.cbbTaskType = new System.Windows.Forms.ComboBox();
            this.dtEdtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dtEdtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.rchTxtBxTaskDescription = new System.Windows.Forms.RichTextBox();
            this.cbbStage = new System.Windows.Forms.ComboBox();
            this.cbbEmployee = new System.Windows.Forms.ComboBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lytCtrlStage = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytCtrlEmployees = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnDone = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlTaskCreating)).BeginInit();
            this.lyoutControlTaskCreating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlEmployees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // lyoutControlTaskCreating
            // 
            this.lyoutControlTaskCreating.Controls.Add(this.txtEdtProjectID);
            this.lyoutControlTaskCreating.Controls.Add(this.rchTxtBxTask);
            this.lyoutControlTaskCreating.Controls.Add(this.cbbAttachFile);
            this.lyoutControlTaskCreating.Controls.Add(this.cbbApprover);
            this.lyoutControlTaskCreating.Controls.Add(this.cbbTaskType);
            this.lyoutControlTaskCreating.Controls.Add(this.dtEdtEndDate);
            this.lyoutControlTaskCreating.Controls.Add(this.dtEdtStartDate);
            this.lyoutControlTaskCreating.Controls.Add(this.rchTxtBxTaskDescription);
            this.lyoutControlTaskCreating.Controls.Add(this.cbbStage);
            this.lyoutControlTaskCreating.Controls.Add(this.cbbEmployee);
            this.lyoutControlTaskCreating.Dock = System.Windows.Forms.DockStyle.Top;
            this.lyoutControlTaskCreating.Location = new System.Drawing.Point(0, 0);
            this.lyoutControlTaskCreating.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lyoutControlTaskCreating.Name = "lyoutControlTaskCreating";
            this.lyoutControlTaskCreating.Root = this.layoutControlGroup1;
            this.lyoutControlTaskCreating.Size = new System.Drawing.Size(584, 273);
            this.lyoutControlTaskCreating.TabIndex = 0;
            this.lyoutControlTaskCreating.Text = "layoutControl1";
            // 
            // txtEdtProjectID
            // 
            this.txtEdtProjectID.Location = new System.Drawing.Point(92, 12);
            this.txtEdtProjectID.Name = "txtEdtProjectID";
            this.txtEdtProjectID.Size = new System.Drawing.Size(189, 20);
            this.txtEdtProjectID.StyleController = this.lyoutControlTaskCreating;
            this.txtEdtProjectID.TabIndex = 0;
            this.txtEdtProjectID.TabStop = false;
            // 
            // rchTxtBxTask
            // 
            this.rchTxtBxTask.Location = new System.Drawing.Point(365, 12);
            this.rchTxtBxTask.Name = "rchTxtBxTask";
            this.rchTxtBxTask.Size = new System.Drawing.Size(207, 70);
            this.rchTxtBxTask.TabIndex = 3;
            this.rchTxtBxTask.Text = "";
            this.rchTxtBxTask.TextChanged += new System.EventHandler(this.rchTxtBxTask_TextChanged);
            this.rchTxtBxTask.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rchTxtBxTask_KeyDown);
            // 
            // cbbAttachFile
            // 
            this.cbbAttachFile.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbAttachFile.FormattingEnabled = true;
            this.cbbAttachFile.Location = new System.Drawing.Point(92, 240);
            this.cbbAttachFile.Name = "cbbAttachFile";
            this.cbbAttachFile.Size = new System.Drawing.Size(216, 21);
            this.cbbAttachFile.TabIndex = 7;
            this.cbbAttachFile.DropDown += new System.EventHandler(this.cbbAttachFile_DropDown);
            this.cbbAttachFile.SelectedIndexChanged += new System.EventHandler(this.cbbAttachFile_SelectedIndexChanged);
            this.cbbAttachFile.SelectionChangeCommitted += new System.EventHandler(this.cbbAttachFile_SelectionChangeCommitted);
            this.cbbAttachFile.DropDownClosed += new System.EventHandler(this.cbbAttachFile_DropDownClosed);
            this.cbbAttachFile.TextChanged += new System.EventHandler(this.cbbAttachFile_TextChanged);
            this.cbbAttachFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbAttachFile_KeyDown);
            // 
            // cbbApprover
            // 
            this.cbbApprover.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbApprover.FormattingEnabled = true;
            this.cbbApprover.Location = new System.Drawing.Point(392, 217);
            this.cbbApprover.Name = "cbbApprover";
            this.cbbApprover.Size = new System.Drawing.Size(180, 21);
            this.cbbApprover.TabIndex = 9;
            this.cbbApprover.DropDown += new System.EventHandler(this.cbbApprover_DropDown);
            this.cbbApprover.SelectedIndexChanged += new System.EventHandler(this.cbbApprover_SelectedIndexChanged);
            this.cbbApprover.SelectionChangeCommitted += new System.EventHandler(this.cbbApprover_SelectionChangeCommitted);
            this.cbbApprover.DropDownClosed += new System.EventHandler(this.cbbApprover_DropDownClosed);
            this.cbbApprover.TextChanged += new System.EventHandler(this.cbbApprover_TextChanged);
            this.cbbApprover.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbApprover_KeyDown);
            // 
            // cbbTaskType
            // 
            this.cbbTaskType.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbTaskType.FormattingEnabled = true;
            this.cbbTaskType.Location = new System.Drawing.Point(392, 192);
            this.cbbTaskType.Name = "cbbTaskType";
            this.cbbTaskType.Size = new System.Drawing.Size(180, 21);
            this.cbbTaskType.TabIndex = 8;
            this.cbbTaskType.DropDown += new System.EventHandler(this.cbbTaskType_DropDown);
            this.cbbTaskType.SelectedIndexChanged += new System.EventHandler(this.cbbTaskType_SelectedIndexChanged);
            this.cbbTaskType.SelectionChangeCommitted += new System.EventHandler(this.cbbTaskType_SelectionChangeCommitted);
            this.cbbTaskType.DropDownClosed += new System.EventHandler(this.cbbTaskType_DropDownClosed);
            this.cbbTaskType.TextChanged += new System.EventHandler(this.cbbTaskType_TextChanged);
            this.cbbTaskType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbTaskType_KeyDown);
            // 
            // dtEdtEndDate
            // 
            this.dtEdtEndDate.EditValue = null;
            this.dtEdtEndDate.Location = new System.Drawing.Point(92, 216);
            this.dtEdtEndDate.Name = "dtEdtEndDate";
            this.dtEdtEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtEdtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Size = new System.Drawing.Size(216, 20);
            this.dtEdtEndDate.StyleController = this.lyoutControlTaskCreating;
            this.dtEdtEndDate.TabIndex = 6;
            this.dtEdtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtEdtEndDate_KeyDown);
            this.dtEdtEndDate.Leave += new System.EventHandler(this.dtEdtEndDate_Leave);
            // 
            // dtEdtStartDate
            // 
            this.dtEdtStartDate.EditValue = null;
            this.dtEdtStartDate.Location = new System.Drawing.Point(92, 192);
            this.dtEdtStartDate.Name = "dtEdtStartDate";
            this.dtEdtStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtEdtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Size = new System.Drawing.Size(216, 20);
            this.dtEdtStartDate.StyleController = this.lyoutControlTaskCreating;
            this.dtEdtStartDate.TabIndex = 5;
            this.dtEdtStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtEdtStartDate_KeyDown);
            this.dtEdtStartDate.Leave += new System.EventHandler(this.dtEdtStartDate_Leave);
            // 
            // rchTxtBxTaskDescription
            // 
            this.rchTxtBxTaskDescription.Location = new System.Drawing.Point(92, 86);
            this.rchTxtBxTaskDescription.MaxLength = 300;
            this.rchTxtBxTaskDescription.Name = "rchTxtBxTaskDescription";
            this.rchTxtBxTaskDescription.Size = new System.Drawing.Size(480, 102);
            this.rchTxtBxTaskDescription.TabIndex = 4;
            this.rchTxtBxTaskDescription.Text = "";
            this.rchTxtBxTaskDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rchTxtBxTaskDescription_KeyDown);
            // 
            // cbbStage
            // 
            this.cbbStage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStage.FormattingEnabled = true;
            this.cbbStage.Location = new System.Drawing.Point(92, 36);
            this.cbbStage.Name = "cbbStage";
            this.cbbStage.Size = new System.Drawing.Size(189, 21);
            this.cbbStage.TabIndex = 1;
            this.cbbStage.DropDown += new System.EventHandler(this.cbbStage_DropDown);
            this.cbbStage.SelectedIndexChanged += new System.EventHandler(this.cbbStage_SelectedIndexChanged);
            this.cbbStage.SelectionChangeCommitted += new System.EventHandler(this.cbbStage_SelectionChangeCommitted);
            this.cbbStage.DropDownClosed += new System.EventHandler(this.cbbStage_DropDownClosed);
            this.cbbStage.TextChanged += new System.EventHandler(this.cbbStage_TextChanged);
            this.cbbStage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbStage_KeyDown);
            // 
            // cbbEmployee
            // 
            this.cbbEmployee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbEmployee.FormattingEnabled = true;
            this.cbbEmployee.Location = new System.Drawing.Point(92, 61);
            this.cbbEmployee.Name = "cbbEmployee";
            this.cbbEmployee.Size = new System.Drawing.Size(189, 21);
            this.cbbEmployee.TabIndex = 2;
            this.cbbEmployee.DropDown += new System.EventHandler(this.cbbEmployee_DropDown);
            this.cbbEmployee.SelectedIndexChanged += new System.EventHandler(this.cbbEmployee_SelectedIndexChanged);
            this.cbbEmployee.SelectionChangeCommitted += new System.EventHandler(this.cbbEmployee_SelectionChangeCommitted);
            this.cbbEmployee.DropDownClosed += new System.EventHandler(this.cbbEmployee_DropDownClosed);
            this.cbbEmployee.TextChanged += new System.EventHandler(this.cbbEmployee_TextChanged);
            this.cbbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbEmployee_KeyDown);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lytCtrlStage,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.lytCtrlEmployees,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(584, 273);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lytCtrlStage
            // 
            this.lytCtrlStage.Control = this.cbbStage;
            this.lytCtrlStage.Location = new System.Drawing.Point(0, 24);
            this.lytCtrlStage.Name = "lytCtrlStage";
            this.lytCtrlStage.Size = new System.Drawing.Size(273, 25);
            this.lytCtrlStage.Text = "Stage (*)";
            this.lytCtrlStage.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtEdtEndDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 204);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem5.Text = "End date";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.rchTxtBxTask;
            this.layoutControlItem2.Location = new System.Drawing.Point(273, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(291, 74);
            this.layoutControlItem2.Text = "Task (*)";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtEdtStartDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 180);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(300, 24);
            this.layoutControlItem4.Text = "Start date";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.rchTxtBxTaskDescription;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 74);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(564, 106);
            this.layoutControlItem1.Text = "Task description";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 13);
            // 
            // lytCtrlEmployees
            // 
            this.lytCtrlEmployees.Control = this.cbbEmployee;
            this.lytCtrlEmployees.Location = new System.Drawing.Point(0, 49);
            this.lytCtrlEmployees.Name = "lytCtrlEmployees";
            this.lytCtrlEmployees.Size = new System.Drawing.Size(273, 25);
            this.lytCtrlEmployees.Text = "Employee";
            this.lytCtrlEmployees.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cbbTaskType;
            this.layoutControlItem6.Location = new System.Drawing.Point(300, 180);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(264, 25);
            this.layoutControlItem6.Text = "Task type";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cbbApprover;
            this.layoutControlItem7.Location = new System.Drawing.Point(300, 205);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(264, 48);
            this.layoutControlItem7.Text = "Approver";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.cbbAttachFile;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 228);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(300, 25);
            this.layoutControlItem8.Text = "Attach file";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(77, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEdtProjectID;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(273, 24);
            this.layoutControlItem3.Text = "Project ID (*)";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(77, 13);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Appearance.Options.UseFont = true;
            this.btnDone.Location = new System.Drawing.Point(380, 287);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(90, 25);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(284, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(482, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // formCreatingTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 322);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.lyoutControlTaskCreating);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCreatingTask";
            this.Text = "Task creating";
            this.Load += new System.EventHandler(this.formCreatingTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlTaskCreating)).EndInit();
            this.lyoutControlTaskCreating.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtProjectID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlEmployees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lyoutControlTaskCreating;
        private System.Windows.Forms.ComboBox cbbAttachFile;
        private System.Windows.Forms.ComboBox cbbApprover;
        private System.Windows.Forms.ComboBox cbbTaskType;
        private DevExpress.XtraEditors.DateEdit dtEdtEndDate;
        private DevExpress.XtraEditors.DateEdit dtEdtStartDate;
        private System.Windows.Forms.RichTextBox rchTxtBxTaskDescription;
        private System.Windows.Forms.ComboBox cbbStage;
        private System.Windows.Forms.ComboBox cbbEmployee;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlStage;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlEmployees;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnDone;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private System.Windows.Forms.RichTextBox rchTxtBxTask;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.TextEdit txtEdtProjectID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}