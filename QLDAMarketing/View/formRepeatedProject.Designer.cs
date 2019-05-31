namespace ProjectManagement.View
{
    partial class formRepeatedProject
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
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnStop = new DevExpress.XtraEditors.SimpleButton();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
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
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // cbbProjectID
            // 
            this.cbbProjectID.FormattingEnabled = true;
            this.cbbProjectID.Location = new System.Drawing.Point(73, 12);
            this.cbbProjectID.Name = "cbbProjectID";
            this.cbbProjectID.Size = new System.Drawing.Size(214, 21);
            this.cbbProjectID.TabIndex = 0;
            this.cbbProjectID.DropDown += new System.EventHandler(this.cbbProjectID_DropDown);
            this.cbbProjectID.SelectedIndexChanged += new System.EventHandler(this.cbbProjectID_SelectedIndexChanged);
            this.cbbProjectID.SelectionChangeCommitted += new System.EventHandler(this.cbbProjectID_SelectionChangeCommitted);
            this.cbbProjectID.DropDownClosed += new System.EventHandler(this.cbbProjectID_DropDownClosed);
            this.cbbProjectID.TextChanged += new System.EventHandler(this.cbbProjectID_TextChanged);
            this.cbbProjectID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbProjectID_KeyDown);
            // 
            // dtEdtEndDate
            // 
            this.dtEdtEndDate.EditValue = null;
            this.dtEdtEndDate.Location = new System.Drawing.Point(352, 37);
            this.dtEdtEndDate.Name = "dtEdtEndDate";
            this.dtEdtEndDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtEdtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtEndDate.Size = new System.Drawing.Size(216, 20);
            this.dtEdtEndDate.StyleController = this.layoutControl1;
            this.dtEdtEndDate.TabIndex = 4;
            this.dtEdtEndDate.EditValueChanged += new System.EventHandler(this.dtEdtEndDate_EditValueChanged);
            this.dtEdtEndDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtEdtEndDate_KeyDown);
            // 
            // dtEdtStartDate
            // 
            this.dtEdtStartDate.EditValue = null;
            this.dtEdtStartDate.Location = new System.Drawing.Point(73, 37);
            this.dtEdtStartDate.Name = "dtEdtStartDate";
            this.dtEdtStartDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.dtEdtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdtStartDate.Size = new System.Drawing.Size(214, 20);
            this.dtEdtStartDate.StyleController = this.layoutControl1;
            this.dtEdtStartDate.TabIndex = 3;
            this.dtEdtStartDate.EditValueChanged += new System.EventHandler(this.dtEdtStartDate_EditValueChanged);
            this.dtEdtStartDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtEdtStartDate_KeyDown);
            // 
            // chkBxAutoRepeat
            // 
            this.chkBxAutoRepeat.Location = new System.Drawing.Point(474, 12);
            this.chkBxAutoRepeat.Name = "chkBxAutoRepeat";
            this.chkBxAutoRepeat.Size = new System.Drawing.Size(94, 20);
            this.chkBxAutoRepeat.TabIndex = 2;
            this.chkBxAutoRepeat.Text = "Auto repeat";
            this.chkBxAutoRepeat.UseVisualStyleBackColor = true;
            this.chkBxAutoRepeat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chkBxAutoRepeat_KeyDown);
            // 
            // nmrUpDwnDateRepeat
            // 
            this.nmrUpDwnDateRepeat.Location = new System.Drawing.Point(352, 12);
            this.nmrUpDwnDateRepeat.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nmrUpDwnDateRepeat.Name = "nmrUpDwnDateRepeat";
            this.nmrUpDwnDateRepeat.Size = new System.Drawing.Size(118, 21);
            this.nmrUpDwnDateRepeat.TabIndex = 1;
            this.nmrUpDwnDateRepeat.ValueChanged += new System.EventHandler(this.nmrUpDwnDateRepeat_ValueChanged);
            this.nmrUpDwnDateRepeat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nmrUpDwnDateRepeat_KeyDown);
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
            this.layoutControlItem3.Text = "Start date";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.nmrUpDwnDateRepeat;
            this.layoutControlItem2.Location = new System.Drawing.Point(279, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(183, 25);
            this.layoutControlItem2.Text = "Date repeat";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtEdtEndDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(279, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(281, 26);
            this.layoutControlItem4.Text = "End date";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(58, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cbbProjectID;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(279, 25);
            this.layoutControlItem5.Text = "Project ID";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(58, 13);
            // 
            // btnStart
            // 
            this.btnStart.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Appearance.Options.UseFont = true;
            this.btnStart.Location = new System.Drawing.Point(281, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 25);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(480, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(584, 75);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnStop);
            this.panelControl2.Controls.Add(this.btnCancel);
            this.panelControl2.Controls.Add(this.btnStart);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 75);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(584, 37);
            this.panelControl2.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.Appearance.Options.UseFont = true;
            this.btnStop.Location = new System.Drawing.Point(381, 6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 25);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // formRepeatedProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 114);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formRepeatedProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Repeated Project";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formRepeatedProject_FormClosed);
            this.Load += new System.EventHandler(this.formRepeatedProject_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.DateEdit dtEdtEndDate;
        private DevExpress.XtraEditors.DateEdit dtEdtStartDate;
        private System.Windows.Forms.CheckBox chkBxAutoRepeat;
        private System.Windows.Forms.NumericUpDown nmrUpDwnDateRepeat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private System.Windows.Forms.ComboBox cbbProjectID;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnStop;
    }
}