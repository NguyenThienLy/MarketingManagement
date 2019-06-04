namespace ProjectManagement.View
{
    partial class formStage
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formStage));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRemove = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lyoutControlStage = new DevExpress.XtraLayout.LayoutControl();
            this.txtEdtStatus = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtStageSubject = new DevExpress.XtraEditors.TextEdit();
            this.txtEdtStage = new DevExpress.XtraEditors.TextEdit();
            this.cbbProjectID = new System.Windows.Forms.ComboBox();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdCtrlStage = new DevExpress.XtraGrid.GridControl();
            this.grvStage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlStage)).BeginInit();
            this.lyoutControlStage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStageSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlStage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStage)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnSave,
            this.btnRemove,
            this.btnRefresh,
            this.btnCancel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRemove, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnRefresh, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnCancel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnAdd
            // 
            this.btnAdd.Caption = "Add";
            this.btnAdd.Glyph = global::ProjectManagement.Properties.Resources.add_24;
            this.btnAdd.Id = 0;
            this.btnAdd.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAdd.Name = "btnAdd";
            toolTipItem1.Text = "Ctrl + (+) ";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnAdd.SuperTip = superToolTip1;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::ProjectManagement.Properties.Resources.edit_24;
            this.btnEdit.Id = 1;
            this.btnEdit.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnEdit.Name = "btnEdit";
            toolTipItem2.Text = "Ctrl + D";
            superToolTip2.Items.Add(toolTipItem2);
            this.btnEdit.SuperTip = superToolTip2;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = global::ProjectManagement.Properties.Resources.save_24;
            this.btnSave.Id = 2;
            this.btnSave.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave.Name = "btnSave";
            toolTipItem3.Text = "Ctrl + S";
            superToolTip3.Items.Add(toolTipItem3);
            this.btnSave.SuperTip = superToolTip3;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Caption = "Remove";
            this.btnRemove.Glyph = global::ProjectManagement.Properties.Resources.remove_24;
            this.btnRemove.Id = 3;
            this.btnRemove.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRemove.Name = "btnRemove";
            toolTipItem4.Text = "Ctrl + R";
            superToolTip4.Items.Add(toolTipItem4);
            this.btnRemove.SuperTip = superToolTip4;
            this.btnRemove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRemove_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = global::ProjectManagement.Properties.Resources.refresh_24;
            this.btnRefresh.Id = 4;
            this.btnRefresh.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.Name = "btnRefresh";
            toolTipItem5.Text = "F5";
            superToolTip5.Items.Add(toolTipItem5);
            this.btnRefresh.SuperTip = superToolTip5;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Glyph = global::ProjectManagement.Properties.Resources.cancel_24;
            this.btnCancel.Id = 5;
            this.btnCancel.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCancel.Name = "btnCancel";
            toolTipItem6.Text = "Esc";
            superToolTip6.Items.Add(toolTipItem6);
            this.btnCancel.SuperTip = superToolTip6;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1031, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 567);
            this.barDockControlBottom.Size = new System.Drawing.Size(1031, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 533);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1031, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 533);
            // 
            // lyoutControlStage
            // 
            this.lyoutControlStage.Controls.Add(this.txtEdtStatus);
            this.lyoutControlStage.Controls.Add(this.txtEdtStageSubject);
            this.lyoutControlStage.Controls.Add(this.txtEdtStage);
            this.lyoutControlStage.Controls.Add(this.cbbProjectID);
            this.lyoutControlStage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lyoutControlStage.Location = new System.Drawing.Point(0, 34);
            this.lyoutControlStage.Name = "lyoutControlStage";
            this.lyoutControlStage.Root = this.layoutControlGroup1;
            this.lyoutControlStage.Size = new System.Drawing.Size(1031, 69);
            this.lyoutControlStage.TabIndex = 0;
            this.lyoutControlStage.Text = "layoutControl1";
            // 
            // txtEdtStatus
            // 
            this.txtEdtStatus.Location = new System.Drawing.Point(587, 37);
            this.txtEdtStatus.MenuManager = this.barManager1;
            this.txtEdtStatus.Name = "txtEdtStatus";
            this.txtEdtStatus.Size = new System.Drawing.Size(432, 20);
            this.txtEdtStatus.StyleController = this.lyoutControlStage;
            this.txtEdtStatus.TabIndex = 3;
            this.txtEdtStatus.TabStop = false;
            // 
            // txtEdtStageSubject
            // 
            this.txtEdtStageSubject.Location = new System.Drawing.Point(81, 37);
            this.txtEdtStageSubject.MenuManager = this.barManager1;
            this.txtEdtStageSubject.Name = "txtEdtStageSubject";
            this.txtEdtStageSubject.Properties.MaxLength = 30;
            this.txtEdtStageSubject.Size = new System.Drawing.Size(433, 20);
            this.txtEdtStageSubject.StyleController = this.lyoutControlStage;
            this.txtEdtStageSubject.TabIndex = 2;
            this.txtEdtStageSubject.EditValueChanged += new System.EventHandler(this.txtEdtStageSubject_EditValueChanged);
            this.txtEdtStageSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdtStageSubject_KeyDown);
            // 
            // txtEdtStage
            // 
            this.txtEdtStage.Location = new System.Drawing.Point(587, 12);
            this.txtEdtStage.MenuManager = this.barManager1;
            this.txtEdtStage.Name = "txtEdtStage";
            this.txtEdtStage.Size = new System.Drawing.Size(432, 20);
            this.txtEdtStage.StyleController = this.lyoutControlStage;
            this.txtEdtStage.TabIndex = 1;
            this.txtEdtStage.TabStop = false;
            // 
            // cbbProjectID
            // 
            this.cbbProjectID.FormattingEnabled = true;
            this.cbbProjectID.Location = new System.Drawing.Point(81, 12);
            this.cbbProjectID.Name = "cbbProjectID";
            this.cbbProjectID.Size = new System.Drawing.Size(433, 21);
            this.cbbProjectID.TabIndex = 0;
            this.cbbProjectID.DropDown += new System.EventHandler(this.cbbProjectID_DropDown);
            this.cbbProjectID.SelectedIndexChanged += new System.EventHandler(this.cbbProjectID_SelectedIndexChanged);
            this.cbbProjectID.SelectionChangeCommitted += new System.EventHandler(this.cbbProjectID_SelectionChangeCommitted);
            this.cbbProjectID.DropDownClosed += new System.EventHandler(this.cbbProjectID_DropDownClosed);
            this.cbbProjectID.TextChanged += new System.EventHandler(this.cbbProjectID_TextChanged);
            this.cbbProjectID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbProjectID_KeyDown);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1031, 69);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtEdtStage;
            this.layoutControlItem2.Location = new System.Drawing.Point(506, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(505, 25);
            this.layoutControlItem2.Text = "Stage (*)";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(66, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtEdtStageSubject;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(506, 24);
            this.layoutControlItem3.Text = "Stage subject";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(66, 13);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cbbProjectID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(506, 25);
            this.layoutControlItem1.Text = "Project ID (*)";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(66, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtEdtStatus;
            this.layoutControlItem4.Location = new System.Drawing.Point(506, 25);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(505, 24);
            this.layoutControlItem4.Text = "Status";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(66, 13);
            // 
            // grdCtrlStage
            // 
            this.grdCtrlStage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlStage.Location = new System.Drawing.Point(0, 103);
            this.grdCtrlStage.MainView = this.grvStage;
            this.grdCtrlStage.MenuManager = this.barManager1;
            this.grdCtrlStage.Name = "grdCtrlStage";
            this.grdCtrlStage.Size = new System.Drawing.Size(1031, 464);
            this.grdCtrlStage.TabIndex = 1;
            this.grdCtrlStage.UseEmbeddedNavigator = true;
            this.grdCtrlStage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvStage});
            // 
            // grvStage
            // 
            this.grvStage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.grvStage.GridControl = this.grdCtrlStage;
            this.grvStage.Name = "grvStage";
            this.grvStage.OptionsFind.AlwaysVisible = true;
            this.grvStage.OptionsFind.FindDelay = 100;
            this.grvStage.OptionsView.ShowAutoFilterRow = true;
            this.grvStage.RowHeight = 35;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Project ID";
            this.gridColumn1.FieldName = "PROJECTID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn2.Caption = "Stage";
            this.gridColumn2.FieldName = "STAGE";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Stage subject";
            this.gridColumn3.FieldName = "STAGESUBJECT";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Status";
            this.gridColumn4.FieldName = "STATUS";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // formStage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 567);
            this.Controls.Add(this.grdCtrlStage);
            this.Controls.Add(this.lyoutControlStage);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "formStage";
            this.Text = "Stage";
            this.Activated += new System.EventHandler(this.formStage_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formStage_FormClosed);
            this.Load += new System.EventHandler(this.formStage_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formStage_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlStage)).EndInit();
            this.lyoutControlStage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStageSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtStage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlStage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvStage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnRemove;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl lyoutControlStage;
        private DevExpress.XtraEditors.TextEdit txtEdtStageSubject;
        private DevExpress.XtraEditors.TextEdit txtEdtStage;
        private System.Windows.Forms.ComboBox cbbProjectID;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.GridControl grdCtrlStage;
        private DevExpress.XtraGrid.Views.Grid.GridView grvStage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.TextEdit txtEdtStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}