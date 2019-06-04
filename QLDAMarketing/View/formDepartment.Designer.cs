namespace ProjectManagement.View
{
    partial class formDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formDepartment));
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnEdit = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnCancel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.lyoutControlDepartment = new DevExpress.XtraLayout.LayoutControl();
            this.cbbLeader = new System.Windows.Forms.ComboBox();
            this.txtEdtDepartment = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lytCtrlDepartment = new DevExpress.XtraLayout.LayoutControlItem();
            this.lytCtrlLeader = new DevExpress.XtraLayout.LayoutControlItem();
            this.grdCtrlDepartment = new DevExpress.XtraGrid.GridControl();
            this.grvDepartment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlDepartment)).BeginInit();
            this.lyoutControlDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlLeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartment)).BeginInit();
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
            this.bar2.FloatLocation = new System.Drawing.Point(354, 118);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnEdit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            this.btnAdd.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnAdd.Caption = "Add";
            this.btnAdd.Glyph = global::ProjectManagement.Properties.Resources.add_24;
            this.btnAdd.Id = 0;
            this.btnAdd.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnAdd.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnAdd.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemAppearance.Normal.Options.UseFont = true;
            this.btnAdd.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnAdd.ItemInMenuAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemInMenuAppearance.Disabled.Options.UseFont = true;
            this.btnAdd.ItemInMenuAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemInMenuAppearance.Hovered.Options.UseFont = true;
            this.btnAdd.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.btnAdd.ItemInMenuAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ItemInMenuAppearance.Pressed.Options.UseFont = true;
            this.btnAdd.Name = "btnAdd";
            toolTipItem1.Text = "Ctrl + (+)";
            superToolTip1.Items.Add(toolTipItem1);
            this.btnAdd.SuperTip = superToolTip1;
            this.btnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdd_ItemClick);
            // 
            // btnEdit
            // 
            this.btnEdit.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnEdit.Caption = "Edit";
            this.btnEdit.Glyph = global::ProjectManagement.Properties.Resources.edit_24;
            this.btnEdit.Id = 1;
            this.btnEdit.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnEdit.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnEdit.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ItemAppearance.Normal.Options.UseFont = true;
            this.btnEdit.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnEdit.Name = "btnEdit";
            toolTipItem2.Text = "Ctrl + D";
            superToolTip2.Items.Add(toolTipItem2);
            this.btnEdit.SuperTip = superToolTip2;
            this.btnEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEdit_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnSave.Caption = "Save";
            this.btnSave.Glyph = global::ProjectManagement.Properties.Resources.save_24;
            this.btnSave.Id = 3;
            this.btnSave.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnSave.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnSave.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnSave.ItemInMenuAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemInMenuAppearance.Disabled.Options.UseFont = true;
            this.btnSave.ItemInMenuAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemInMenuAppearance.Hovered.Options.UseFont = true;
            this.btnSave.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.btnSave.ItemInMenuAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ItemInMenuAppearance.Pressed.Options.UseFont = true;
            this.btnSave.Name = "btnSave";
            toolTipItem3.Text = "Ctrl + S";
            superToolTip3.Items.Add(toolTipItem3);
            this.btnSave.SuperTip = superToolTip3;
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnRefresh.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Glyph = global::ProjectManagement.Properties.Resources.refresh_24;
            this.btnRefresh.Id = 4;
            this.btnRefresh.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnRefresh.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnRefresh.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnRefresh.ItemInMenuAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemInMenuAppearance.Disabled.Options.UseFont = true;
            this.btnRefresh.ItemInMenuAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemInMenuAppearance.Hovered.Options.UseFont = true;
            this.btnRefresh.ItemInMenuAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemInMenuAppearance.Normal.Options.UseFont = true;
            this.btnRefresh.ItemInMenuAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ItemInMenuAppearance.Pressed.Options.UseFont = true;
            this.btnRefresh.Name = "btnRefresh";
            toolTipItem4.Text = "F5";
            superToolTip4.Items.Add(toolTipItem4);
            this.btnRefresh.SuperTip = superToolTip4;
            this.btnRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRefresh_ItemClick);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnCancel.Border = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.btnCancel.Caption = "Cancel";
            this.btnCancel.Glyph = global::ProjectManagement.Properties.Resources.cancel_24;
            this.btnCancel.Id = 5;
            this.btnCancel.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ItemAppearance.Normal.Options.UseFont = true;
            this.btnCancel.Name = "btnCancel";
            toolTipItem5.Text = "Esc";
            superToolTip5.Items.Add(toolTipItem5);
            this.btnCancel.SuperTip = superToolTip5;
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCancel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(842, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 515);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(842, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 481);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(842, 34);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 481);
            // 
            // lyoutControlDepartment
            // 
            this.lyoutControlDepartment.Controls.Add(this.cbbLeader);
            this.lyoutControlDepartment.Controls.Add(this.txtEdtDepartment);
            this.lyoutControlDepartment.Dock = System.Windows.Forms.DockStyle.Top;
            this.lyoutControlDepartment.Location = new System.Drawing.Point(0, 34);
            this.lyoutControlDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lyoutControlDepartment.Name = "lyoutControlDepartment";
            this.lyoutControlDepartment.Root = this.layoutControlGroup1;
            this.lyoutControlDepartment.Size = new System.Drawing.Size(842, 45);
            this.lyoutControlDepartment.TabIndex = 0;
            this.lyoutControlDepartment.Text = "layoutControl1";
            // 
            // cbbLeader
            // 
            this.cbbLeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLeader.FormattingEnabled = true;
            this.cbbLeader.Location = new System.Drawing.Point(500, 12);
            this.cbbLeader.Name = "cbbLeader";
            this.cbbLeader.Size = new System.Drawing.Size(330, 21);
            this.cbbLeader.TabIndex = 1;
            this.cbbLeader.DropDown += new System.EventHandler(this.cbbLeader_DropDown);
            this.cbbLeader.SelectedIndexChanged += new System.EventHandler(this.cbbLeader_SelectedIndexChanged);
            this.cbbLeader.SelectionChangeCommitted += new System.EventHandler(this.cbbLeader_SelectionChangeCommitted);
            this.cbbLeader.DropDownClosed += new System.EventHandler(this.cbbLeader_DropDownClosed);
            this.cbbLeader.TextChanged += new System.EventHandler(this.cbbLeader_TextChanged);
            this.cbbLeader.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbLeader_KeyDown);
            // 
            // txtEdtDepartment
            // 
            this.txtEdtDepartment.Location = new System.Drawing.Point(89, 12);
            this.txtEdtDepartment.MenuManager = this.barManager1;
            this.txtEdtDepartment.Name = "txtEdtDepartment";
            this.txtEdtDepartment.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdtDepartment.Properties.Appearance.Options.UseFont = true;
            this.txtEdtDepartment.Properties.MaxLength = 30;
            this.txtEdtDepartment.Size = new System.Drawing.Size(330, 20);
            this.txtEdtDepartment.StyleController = this.lyoutControlDepartment;
            this.txtEdtDepartment.TabIndex = 0;
            this.txtEdtDepartment.EditValueChanged += new System.EventHandler(this.txtEdtDepartment_EditValueChanged);
            this.txtEdtDepartment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEdtDepartment_KeyDown);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lytCtrlDepartment,
            this.lytCtrlLeader});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(842, 45);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lytCtrlDepartment
            // 
            this.lytCtrlDepartment.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lytCtrlDepartment.AppearanceItemCaption.Options.UseFont = true;
            this.lytCtrlDepartment.Control = this.txtEdtDepartment;
            this.lytCtrlDepartment.Location = new System.Drawing.Point(0, 0);
            this.lytCtrlDepartment.Name = "lytCtrlDepartment";
            this.lytCtrlDepartment.Size = new System.Drawing.Size(411, 25);
            this.lytCtrlDepartment.Text = "Department (*)";
            this.lytCtrlDepartment.TextSize = new System.Drawing.Size(74, 13);
            // 
            // lytCtrlLeader
            // 
            this.lytCtrlLeader.Control = this.cbbLeader;
            this.lytCtrlLeader.Location = new System.Drawing.Point(411, 0);
            this.lytCtrlLeader.Name = "lytCtrlLeader";
            this.lytCtrlLeader.Size = new System.Drawing.Size(411, 25);
            this.lytCtrlLeader.Text = "Leader";
            this.lytCtrlLeader.TextSize = new System.Drawing.Size(74, 13);
            // 
            // grdCtrlDepartment
            // 
            this.grdCtrlDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCtrlDepartment.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grdCtrlDepartment.Location = new System.Drawing.Point(0, 79);
            this.grdCtrlDepartment.MainView = this.grvDepartment;
            this.grdCtrlDepartment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdCtrlDepartment.MenuManager = this.barManager1;
            this.grdCtrlDepartment.Name = "grdCtrlDepartment";
            this.grdCtrlDepartment.Size = new System.Drawing.Size(842, 436);
            this.grdCtrlDepartment.TabIndex = 1;
            this.grdCtrlDepartment.UseEmbeddedNavigator = true;
            this.grdCtrlDepartment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDepartment});
            // 
            // grvDepartment
            // 
            this.grvDepartment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3});
            this.grvDepartment.GridControl = this.grdCtrlDepartment;
            this.grvDepartment.Name = "grvDepartment";
            this.grvDepartment.OptionsDetail.AutoZoomDetail = true;
            this.grvDepartment.OptionsDetail.SmartDetailHeight = true;
            this.grvDepartment.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            this.grvDepartment.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.True;
            this.grvDepartment.OptionsFind.AlwaysVisible = true;
            this.grvDepartment.OptionsFind.FindDelay = 100;
            this.grvDepartment.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.grvDepartment.OptionsView.ShowAutoFilterRow = true;
            this.grvDepartment.OptionsView.ShowFooter = true;
            this.grvDepartment.RowHeight = 35;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Department";
            this.gridColumn1.FieldName = "DEPARTMENT";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Leader";
            this.gridColumn3.FieldName = "LEADER";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // formDepartment
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 515);
            this.Controls.Add(this.grdCtrlDepartment);
            this.Controls.Add(this.lyoutControlDepartment);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formDepartment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Department Management";
            this.Activated += new System.EventHandler(this.formDepartment_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formDepartment_FormClosed);
            this.Load += new System.EventHandler(this.formDepartment_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.formDepartment_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lyoutControlDepartment)).EndInit();
            this.lyoutControlDepartment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtEdtDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lytCtrlLeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCtrlDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnAdd;
        private DevExpress.XtraBars.BarButtonItem btnEdit;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnCancel;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl lyoutControlDepartment;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl grdCtrlDepartment;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.ComboBox cbbLeader;
        private DevExpress.XtraLayout.LayoutControlItem lytCtrlLeader;
        public DevExpress.XtraGrid.Views.Grid.GridView grvDepartment;
        public DevExpress.XtraEditors.TextEdit txtEdtDepartment;
    }
}