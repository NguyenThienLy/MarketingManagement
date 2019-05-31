namespace ProjectManagement
{
    partial class formMain
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
            DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ProjectManagement.View.formFplashScreen), true, true);
            DevExpress.Utils.Animation.PushTransition pushTransition1 = new DevExpress.Utils.Animation.PushTransition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogOut = new DevExpress.XtraBars.BarButtonItem();
            this.btnShowMenu = new DevExpress.XtraBars.BarButtonItem();
            this.btnChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjectHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.btnProject = new DevExpress.XtraBars.BarButtonItem();
            this.btnTask = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.btntimkiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnlichsuduaninan = new DevExpress.XtraBars.BarButtonItem();
            this.btnStage = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjectCreating = new DevExpress.XtraBars.BarButtonItem();
            this.btnProjectsDiagram = new DevExpress.XtraBars.BarButtonItem();
            this.btnPersonalInformation = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.RbPgCtrlCreating = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbsstatus = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.mdimain = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
            this.workspaceManager1 = new DevExpress.Utils.WorkspaceManager();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdimain)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            splashScreenManager1.ClosingDelay = 500;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnLogIn,
            this.btnLogOut,
            this.btnShowMenu,
            this.btnChangePassword,
            this.btnProjectHistory,
            this.btnHistory,
            this.btnEmployee,
            this.btnDepartment,
            this.btnProject,
            this.btnTask,
            this.skinRibbonGalleryBarItem1,
            this.btntimkiem,
            this.btnlichsuduaninan,
            this.btnStage,
            this.btnProjectCreating,
            this.btnProjectsDiagram,
            this.btnPersonalInformation});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 27;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2,
            this.ribbonPage4,
            this.ribbonPage3});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1036, 147);
            this.ribbonControl1.StatusBar = this.rbsstatus;
            this.ribbonControl1.MinimizedChanged += new System.EventHandler(this.ribbonControl1_MinimizedChanged);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Caption = "Login";
            this.btnLogIn.Id = 1;
            this.btnLogIn.LargeGlyph = global::ProjectManagement.Properties.Resources.login_64;
            this.btnLogIn.LargeWidth = 80;
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogIn_ItemClick);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Caption = "Logout";
            this.btnLogOut.Id = 2;
            this.btnLogOut.LargeGlyph = global::ProjectManagement.Properties.Resources.logout_64;
            this.btnLogOut.LargeWidth = 80;
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogOut_ItemClick);
            // 
            // btnShowMenu
            // 
            this.btnShowMenu.Caption = "Show menu";
            this.btnShowMenu.Id = 3;
            this.btnShowMenu.LargeGlyph = global::ProjectManagement.Properties.Resources.menu_64;
            this.btnShowMenu.LargeWidth = 80;
            this.btnShowMenu.Name = "btnShowMenu";
            this.btnShowMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnShowMenu_ItemClick);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Caption = "Change password";
            this.btnChangePassword.Id = 4;
            this.btnChangePassword.LargeGlyph = global::ProjectManagement.Properties.Resources.changpassword_64;
            this.btnChangePassword.LargeWidth = 80;
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChangePassword_ItemClick);
            // 
            // btnProjectHistory
            // 
            this.btnProjectHistory.Caption = "KPI history";
            this.btnProjectHistory.Id = 6;
            this.btnProjectHistory.LargeGlyph = global::ProjectManagement.Properties.Resources.projecthistory_64;
            this.btnProjectHistory.LargeWidth = 80;
            this.btnProjectHistory.Name = "btnProjectHistory";
            this.btnProjectHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjectHistory_ItemClick);
            // 
            // btnHistory
            // 
            this.btnHistory.Caption = "History";
            this.btnHistory.Id = 7;
            this.btnHistory.LargeGlyph = global::ProjectManagement.Properties.Resources.history_64;
            this.btnHistory.LargeWidth = 80;
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistory_ItemClick);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Employee";
            this.btnEmployee.Id = 8;
            this.btnEmployee.LargeGlyph = global::ProjectManagement.Properties.Resources.employee_64;
            this.btnEmployee.LargeWidth = 80;
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployee_ItemClick);
            // 
            // btnDepartment
            // 
            this.btnDepartment.Caption = "Department";
            this.btnDepartment.Id = 9;
            this.btnDepartment.LargeGlyph = global::ProjectManagement.Properties.Resources.department_64;
            this.btnDepartment.LargeWidth = 80;
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDepartment_ItemClick);
            // 
            // btnProject
            // 
            this.btnProject.Caption = "Project";
            this.btnProject.Id = 10;
            this.btnProject.LargeGlyph = global::ProjectManagement.Properties.Resources.project_64;
            this.btnProject.LargeWidth = 80;
            this.btnProject.Name = "btnProject";
            this.btnProject.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProject_ItemClick);
            // 
            // btnTask
            // 
            this.btnTask.Caption = "Task";
            this.btnTask.Id = 11;
            this.btnTask.LargeGlyph = global::ProjectManagement.Properties.Resources.task_64;
            this.btnTask.LargeWidth = 80;
            this.btnTask.Name = "btnTask";
            this.btnTask.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaskCreating_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 14;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Id = 16;
            this.btntimkiem.Name = "btntimkiem";
            // 
            // btnlichsuduaninan
            // 
            this.btnlichsuduaninan.Caption = "Lịch Sử Dự Án In Ấn";
            this.btnlichsuduaninan.Id = 17;
            this.btnlichsuduaninan.LargeGlyph = global::ProjectManagement.Properties.Resources.lichsuduaninan48;
            this.btnlichsuduaninan.LargeWidth = 80;
            this.btnlichsuduaninan.Name = "btnlichsuduaninan";
            // 
            // btnStage
            // 
            this.btnStage.Caption = "Stage";
            this.btnStage.Id = 21;
            this.btnStage.LargeGlyph = global::ProjectManagement.Properties.Resources.stagemanagement_50_G;
            this.btnStage.LargeWidth = 80;
            this.btnStage.Name = "btnStage";
            this.btnStage.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnStage_ItemClick);
            // 
            // btnProjectCreating
            // 
            this.btnProjectCreating.Caption = "Project creating";
            this.btnProjectCreating.Id = 22;
            this.btnProjectCreating.LargeGlyph = global::ProjectManagement.Properties.Resources.creating_50_Bl;
            this.btnProjectCreating.LargeWidth = 80;
            this.btnProjectCreating.Name = "btnProjectCreating";
            this.btnProjectCreating.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjectCreating_ItemClick);
            // 
            // btnProjectsDiagram
            // 
            this.btnProjectsDiagram.Caption = "Project diagram";
            this.btnProjectsDiagram.Id = 23;
            this.btnProjectsDiagram.LargeGlyph = global::ProjectManagement.Properties.Resources.projectdiagram_64;
            this.btnProjectsDiagram.LargeWidth = 80;
            this.btnProjectsDiagram.Name = "btnProjectsDiagram";
            this.btnProjectsDiagram.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProjectsDiagram_ItemClick);
            // 
            // btnPersonalInformation
            // 
            this.btnPersonalInformation.Caption = "Personal\r\nInformation";
            this.btnPersonalInformation.Id = 26;
            this.btnPersonalInformation.LargeGlyph = global::ProjectManagement.Properties.Resources.User_64_Gr;
            this.btnPersonalInformation.Name = "btnPersonalInformation";
            this.btnPersonalInformation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPersonalInformation_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup10});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Home";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogIn);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogOut);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "System";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnShowMenu);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnChangePassword);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Function";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "Interface";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Personal";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPersonalInformation);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Information";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnProjectHistory);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnHistory);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "History";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.RbPgCtrlCreating,
            this.ribbonPageGroup12});
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "Function";
            // 
            // RbPgCtrlCreating
            // 
            this.RbPgCtrlCreating.ItemLinks.Add(this.btnProjectCreating);
            this.RbPgCtrlCreating.Name = "RbPgCtrlCreating";
            this.RbPgCtrlCreating.Text = "Project creating";
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.ItemLinks.Add(this.btnProjectsDiagram);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            this.ribbonPageGroup12.Text = "Project Diagram";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5,
            this.ribbonPageGroup6,
            this.ribbonPageGroup7,
            this.ribbonPageGroup11,
            this.ribbonPageGroup8});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Management";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnEmployee);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Employee";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnDepartment);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "Department";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnProject);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Project";
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.btnStage);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            this.ribbonPageGroup11.Text = "Stage";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btnTask);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            this.ribbonPageGroup8.Text = "Task ";
            // 
            // rbsstatus
            // 
            this.rbsstatus.Location = new System.Drawing.Point(1, 291);
            this.rbsstatus.Name = "rbsstatus";
            this.rbsstatus.Ribbon = this.ribbonControl1;
            this.rbsstatus.Size = new System.Drawing.Size(868, 28);
            // 
            // mdimain
            // 
            this.mdimain.AllowDragDrop = DevExpress.Utils.DefaultBoolean.True;
            this.mdimain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.mdimain.MdiParent = this;
            this.mdimain.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.True;
            this.mdimain.SelectedPageChanged += new System.EventHandler(this.mdimain_SelectedPageChanged);
            this.mdimain.PageAdded += new DevExpress.XtraTabbedMdi.MdiTabPageEventHandler(this.mdimain_PageAdded);
            // 
            // workspaceManager1
            // 
            this.workspaceManager1.TargetControl = this;
            this.workspaceManager1.TransitionType = pushTransition1;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            this.ribbonPageGroup9.Text = "Project diagram";
            // 
            // formMain
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 575);
            this.Controls.Add(this.ribbonControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "formMain";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.rbsstatus;
            this.Text = "Marketing Project Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formMain_FormClosing);
            this.Load += new System.EventHandler(this.formMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mdimain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnLogIn;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnLogOut;
        private DevExpress.XtraBars.BarButtonItem btnShowMenu;
        private DevExpress.XtraBars.BarButtonItem btnChangePassword;
        private DevExpress.XtraBars.BarButtonItem btnProjectHistory;
        private DevExpress.XtraBars.BarButtonItem btnHistory;
        private DevExpress.XtraBars.BarButtonItem btnEmployee;
        private DevExpress.XtraBars.BarButtonItem btnDepartment;
        private DevExpress.XtraBars.BarButtonItem btnProject;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btnTask;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar rbsstatus;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.BarButtonItem btntimkiem;
        private DevExpress.XtraBars.BarButtonItem btnlichsuduaninan;
        public DevExpress.XtraTabbedMdi.XtraTabbedMdiManager mdimain;
        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnStage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.Utils.WorkspaceManager workspaceManager1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup RbPgCtrlCreating;
        private DevExpress.XtraBars.BarButtonItem btnProjectCreating;
        private DevExpress.XtraBars.BarButtonItem btnProjectsDiagram;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem btnPersonalInformation;
    }
}

