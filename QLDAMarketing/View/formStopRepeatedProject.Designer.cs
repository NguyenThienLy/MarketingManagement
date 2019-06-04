namespace ProjectManagement.View
{
    partial class formStopRepeatedProject
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.cbbProjectID = new System.Windows.Forms.ComboBox();
            this.dtEdtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dtEdtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.chkBxAutoRepeat = new System.Windows.Forms.CheckBox();
            this.nmrUpDwnDateRepeat = new System.Windows.Forms.NumericUpDown();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUpDwnDateRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnOK);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 75);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(584, 37);
            this.panelControl2.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(492, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(391, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(584, 75);
            this.panelControl1.TabIndex = 13;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.cbbProjectID);
            this.layoutControl1.Controls.Add(this.dtEdtEndDate);
            this.layoutControl1.Controls.Add(this.dtEdtStartDate);
            this.layoutControl1.Controls.Add(this.chkBxAutoRepeat);
            this.layoutControl1.Controls.Add(this.nmrUpDwnDateRepeat);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(580, 71);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cbbProjectID
            // 
            this.cbbProjectID.FormattingEnabled = true;
            this.cbbProjectID.Location = new System.Drawing.Point(76, 12);
            this.cbbProjectID.Name = "cbbProjectID";
            this.cbbProjectID.Size = new System.Drawing.Size(211, 21);
            this.cbbProjectID.TabIndex = 6;
            // 
            // dtEdtEndDate
            // 
            this.dtEdtEndDate.EditValue = null;
            this.dtEdtEndDate.Location = new System.Drawing.Point(355, 37);
            this.dtEdtEndDate.Name = "dtEdtEndDate";
            this.dtEdtEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtEdtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Size = new System.Drawing.Size(213, 20);
            this.dtEdtEndDate.StyleController = this.layoutControl1;
            this.dtEdtEndDate.TabIndex = 5;
            // 
            // dtEdtStartDate
            // 
            this.dtEdtStartDate.EditValue = null;
            this.dtEdtStartDate.Location = new System.Drawing.Point(76, 37);
            this.dtEdtStartDate.Name = "dtEdtStartDate";
            this.dtEdtStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtEdtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Size = new System.Drawing.Size(211, 20);
            this.dtEdtStartDate.StyleController = this.layoutControl1;
            this.dtEdtStartDate.TabIndex = 4;
            // 
            // chkBxAutoRepeat
            // 
            this.chkBxAutoRepeat.Location = new System.Drawing.Point(474, 12);
            this.chkBxAutoRepeat.Name = "chkBxAutoRepeat";
            this.chkBxAutoRepeat.Size = new System.Drawing.Size(94, 20);
            this.chkBxAutoRepeat.TabIndex = 3;
            this.chkBxAutoRepeat.Text = "Auto Repeat";
            this.chkBxAutoRepeat.UseVisualStyleBackColor = true;
            // 
            // nmrUpDwnDateRepeat
            // 
            this.nmrUpDwnDateRepeat.Location = new System.Drawing.Point(355, 12);
            this.nmrUpDwnDateRepeat.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nmrUpDwnDateRepeat.Name = "nmrUpDwnDateRepeat";
            this.nmrUpDwnDateRepeat.Size = new System.Drawing.Size(115, 21);
            this.nmrUpDwnDateRepeat.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem2,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(580, 71);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.chkBxAutoRepeat;
            this.layoutControlItem1.Location = new System.Drawing.Point(462, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(98, 25);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtEdtStartDate;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(279, 26);
            this.layoutControlItem3.Text = "Start Date";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.nmrUpDwnDateRepeat;
            this.layoutControlItem2.Location = new System.Drawing.Point(279, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(183, 25);
            this.layoutControlItem2.Text = "Date Repeat";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtEdtEndDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(279, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(281, 26);
            this.layoutControlItem4.Text = "End Date";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(61, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cbbProjectID;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(279, 25);
            this.layoutControlItem5.Text = "Project ID";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(61, 13);
            // 
            // formStopRepeatedProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 114);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formStopRepeatedProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stop Repeated Project";
            this.Load += new System.EventHandler(this.formStopRepeatedProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrUpDwnDateRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.ComboBox cbbProjectID;
        private DevExpress.XtraEditors.DateEdit dtEdtEndDate;
        private DevExpress.XtraEditors.DateEdit dtEdtStartDate;
        private System.Windows.Forms.CheckBox chkBxAutoRepeat;
        private System.Windows.Forms.NumericUpDown nmrUpDwnDateRepeat;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}