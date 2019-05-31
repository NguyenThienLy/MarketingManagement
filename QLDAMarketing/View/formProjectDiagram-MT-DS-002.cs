using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using ProjectManagement.DTO;
using ProjectManagement.DAO;
using ProjectManagement.CO;

namespace ProjectManagement.View
{
    public partial class formProjectDiagram : DevExpress.XtraEditors.XtraForm
    {
        bool b_IsAdminGlobal = false; // cờ đánh dấu là Admin.

        string str_ProjectIDGlobal = string.Empty;

        int i_WidthGlobal = 0;
        int i_HeightGlobal = 0;

        List<System.Windows.Forms.TabPage> lst_TbPgStageListGlobal = new List<System.Windows.Forms.TabPage>();

        List<System.Windows.Forms.TabPage> lst_TbPgDeptListGlobal = new List<System.Windows.Forms.TabPage>();

        List<string> lst_NameDeptGlobal = new List<string>();

        public formProjectDiagram()
        {
            this.i_WidthGlobal = GetScreen().Width;
            this.i_HeightGlobal = GetScreen().Height;

            InitializeComponent();

            this.addTbPgStageList();

            this.addTbPgDeptList();

            this.addNameDeptList();

            this.setLocationBtnSeclect();

            this.hideButtonAndPanel(true);
        }

        // Lấy tin tin từ bản xuất ra các text trên thông tin nhân viên.
        private void loadData()
        {
            // Nếu chưa chọn dự án.
            if (this.str_ProjectIDGlobal == string.Empty)
                return;

            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(this.str_ProjectIDGlobal);

            if (projectDTOLocal != null)
            {
                if (!projectDTOLocal.Empty())
                {
                    this.txtEdtProjectID.Text = projectDTOLocal.ProjectID;

                    this.txtEdtProjectName.Text = projectDTOLocal.ProjectName;

                    this.txtEdtLeader.Text = projectDTOLocal.Leader;

                    this.txtEdtStartDate.Text = projectDTOLocal.StartDate;

                    this.txtEdtEndDate.Text = projectDTOLocal.EndDate;

                    this.txtEdtProgress.Text = projectDTOLocal.Progress;

                    this.txtEdtProjectType.Text = projectDTOLocal.ProjectType;

                    this.txtEdtPOSMProject.Text = projectDTOLocal.POSMProject;

                    this.txtEdtStatus.Text = projectDTOLocal.Status;

                    this.txtEdtDateRepeat.Text = projectDTOLocal.DateRepeat;

                    this.txtEdtAutoRepeat.Text = projectDTOLocal.AutoRepeat;

                    this.txtEdtStartDateRepeat.Text = projectDTOLocal.StartDateRepeat;

                    this.txtEdtEndDateRepeat.Text = projectDTOLocal.EndDateRepeat;
                }
                else
                {
                    XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.hideButtonAndPanel(true);
                    this.lblSelect.Show();
                    this.btnSelect.Show();
                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }
        }

        // Xét quyền hạn của nhân viên.
        private void Authorize()
        {
            string str_RoleLocal = string.Empty;

            str_RoleLocal = EmployeeDAO.Instance.getStringRoleFollowName(StaticVarClass.account_Username);

            if (str_RoleLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnCancel_ItemClick(null, null);
            }

            if (str_RoleLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnCancel_ItemClick(null, null);
            }

            if (str_RoleLocal == StaticVarClass.role_Admin)
            {
                this.disable(true);
                this.b_IsAdminGlobal = true;
            }
            else if (str_RoleLocal == StaticVarClass.role_Member)
            {
                this.disable(false);
                this.b_IsAdminGlobal = false;
            }
            else if (str_RoleLocal == StaticVarClass.role_Staff)
            {
                this.disable(false);
                this.b_IsAdminGlobal = false;
            }
        }

        private Rectangle GetScreen()
        {
            formMain frmMain = formMain.Instance;
            return Screen.FromControl(frmMain).Bounds;
        }

        // Cho nút btnSelect đứng giữa màn hình.
        private void setLocationBtnSeclect()
        {
            //i_WidthGlobal = Screen.PrimaryScreen.Bounds.Width;
            //i_HeightGlobal = Screen.PrimaryScreen.Bounds.Height;
            //Screen.PrimaryScreen.Bounds.Size;

            this.lblSelect.Location = new Point((i_WidthGlobal - lblSelect.Size.Width) / 2, (i_HeightGlobal - lblSelect.Size.Height) / 2 - 300);
            this.btnSelect.Location = new Point((i_WidthGlobal - btnSelect.Size.Width) / 2, (i_HeightGlobal - btnSelect.Size.Height) / 2 - 200);
        }

        // Khóa/ mở tùy thuộc vào admin.
        private void disable(bool e)
        {
            this.btnQuickAddStage.Enabled = e;
            this.btnQuickRemoveStage.Enabled = e;
            this.btnQuickAddTaskCreating.Enabled = e;
            this.btnQuickAccessTaskWorking.Enabled = true;
        }

        // Check xem username có tham gia vào project này không.
        private void checkIfJoinProject()
        {
            int i_CheckIfJoinProject = TaskCreatingDAO.Instance.checkIfJoinProject(this.str_ProjectIDGlobal, StaticVarClass.account_Username);

            if (i_CheckIfJoinProject == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

            if (i_CheckIfJoinProject == 0)
            {
                this.btnQuickAccessTaskWorking.Enabled = false;
            }
        }

        // Ẩn các nút và panel control 1 cho đến khi chọn dự án.
        private void hideButtonAndPanel(bool e)
        {
            if (e == true)
            {
                this.btnProjectSelection.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnQuickAddStage.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnQuickAddTaskCreating.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnQuickRemoveStage.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnQuickAccessTaskWorking.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.panelControl1.Visible = false;
                this.tbCtrlStage.Visible = false;
                this.tbCtrlDept.Visible = false;
                this.flPnHaveTaskCreating.Visible = false;
            }
            else
            {
                this.btnProjectSelection.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.btnQuickAddStage.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.btnQuickAddTaskCreating.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.btnQuickRemoveStage.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.btnQuickAccessTaskWorking.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.btnRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                this.panelControl1.Visible = true;
                this.flPnHaveTaskCreating.Visible = true;

                this.checkIfJoinProject();

                // Khi nào các stage lớn hớn hiện thanh tb của stage và dept.
                int i_MaxStageTemp = StageDAO.Instance.getIntMaxStageFollowProjectID(this.str_ProjectIDGlobal);

                if (i_MaxStageTemp == -1)
                {
                    XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.hideButtonAndPanel(true);
                    this.lblSelect.Show();
                    this.btnSelect.Show();
                    return;
                }

                if (i_MaxStageTemp != 0)
                {
                    this.tbCtrlStage.Visible = true;
                    this.tbCtrlDept.Visible = true;

                    //if (this.b_IsAdminGlobal == true)
                    //{
                    //    this.btnQuickAddTaskCreating.Enabled = true;
                    //    this.btnQuickRemoveStage.Enabled = true;
                    //    this.btnQuickAccessTaskWorking.Enabled = true;
                    //}
                }
                else
                {
                    this.tbCtrlStage.Visible = false;
                    this.tbCtrlDept.Visible = false;
                    this.flPnHaveTaskCreating.Controls.Clear(); // làm sạch bảng chứa task.
                    this.btnQuickAddTaskCreating.Enabled = false;
                    this.btnQuickRemoveStage.Enabled = false;
                    this.btnQuickAccessTaskWorking.Enabled = false;
                }

                ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(this.str_ProjectIDGlobal);

                if (projectDTOLocal == null)
                {
                    XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.hideButtonAndPanel(true);
                    this.lblSelect.Show();
                    this.btnSelect.Show();
                    return;
                }
                else if (projectDTOLocal.Empty())
                {
                    this.hideButtonAndPanel(true);
                    this.lblSelect.Show();
                    this.btnSelect.Show();
                    return;
                }
                else if (projectDTOLocal.Status == StaticVarClass.status_Complete)
                {
                    this.btnQuickAddStage.Enabled = false;
                    this.btnQuickRemoveStage.Enabled = false;
                    this.btnQuickAddTaskCreating.Enabled = false;
                    this.btnQuickAccessTaskWorking.Enabled = false;
                }
            }
        }

        // Nạp các System.Windows.Forms.TabPage vào tpList.
        private void addTbPgStageList()
        {
            this.lst_TbPgStageListGlobal.Add(tbPgStage1);
            this.lst_TbPgStageListGlobal.Add(tbPgStage2);
            this.lst_TbPgStageListGlobal.Add(tbPgStage3);
            this.lst_TbPgStageListGlobal.Add(tbPgStage4);
            this.lst_TbPgStageListGlobal.Add(tbPgStage5);
            this.lst_TbPgStageListGlobal.Add(tbPgStage6);
            this.lst_TbPgStageListGlobal.Add(tbPgStage7);
            this.lst_TbPgStageListGlobal.Add(tbPgStage8);
            this.lst_TbPgStageListGlobal.Add(tbPgStage9);
            this.lst_TbPgStageListGlobal.Add(tbPgStage10);
            this.lst_TbPgStageListGlobal.Add(tbPgStage11);
            this.lst_TbPgStageListGlobal.Add(tbPgStage12);
            this.lst_TbPgStageListGlobal.Add(tbPgStage13);
            this.lst_TbPgStageListGlobal.Add(tbPgStage14);
            this.lst_TbPgStageListGlobal.Add(tbPgStage15);
            this.lst_TbPgStageListGlobal.Add(tbPgStage16);
            this.lst_TbPgStageListGlobal.Add(tbPgStage17);
            this.lst_TbPgStageListGlobal.Add(tbPgStage18);
            this.lst_TbPgStageListGlobal.Add(tbPgStage19);
            this.lst_TbPgStageListGlobal.Add(tbPgStage20);
        }

        // Nạp các System.Windows.Forms.TabPage vào tpList.
        private void addTbPgDeptList()
        {
            this.lst_TbPgDeptListGlobal.Add(tbPgCustomerService);
            this.lst_TbPgDeptListGlobal.Add(tbPgDesign);
            this.lst_TbPgDeptListGlobal.Add(tbPgHR);
            this.lst_TbPgDeptListGlobal.Add(tbPgMarketing);
            this.lst_TbPgDeptListGlobal.Add(tbPgPurchase);
            this.lst_TbPgDeptListGlobal.Add(tbPgRSD);
            this.lst_TbPgDeptListGlobal.Add(tbPgShopStaff);
            this.lst_TbPgDeptListGlobal.Add(tbPgWareHouse);
        }

        // Nạp tên các phòng vào list.
        private void addNameDeptList()
        {
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_CustomerService);
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_Design);
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_HR);
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_Marketing);
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_Purchase);
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_RSD);
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_ShopStaff);
            this.lst_NameDeptGlobal.Add(StaticVarClass.dept_WareHouse);
        }

        // Hiển thị tên và số lượng của Task creating trong tabControl.
        private void loadStageSubjectAndQuantity(List<string> lst_StageSubject, List<string> lst_QuantityStage, List<string> lst_QuantityDept)
        {
            int i = 0;
            int i_MaxStageLocal = StageDAO.Instance.getIntSumStageFollowProjectID(this.str_ProjectIDGlobal);

            if (i_MaxStageLocal != -1)
            {
                for (i = 0; i < i_MaxStageLocal; i++)
                {
                    this.lst_TbPgStageListGlobal[i].Text = lst_StageSubject[i] + " - (" + lst_QuantityStage[i] + ")";
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

            for (i = 0; i < StaticVarClass.dept_Quantity; i++)
            {
                this.lst_TbPgDeptListGlobal[i].Text = lst_NameDeptGlobal[i] + " - (" + lst_QuantityDept[i] + ")";
            }
        }

        // Lấy ra Giai đoạn đang chọn hiện tại.
        private string getCurrStage()
        {
            // Lấy vị trí hiện tại đang chọn.
            int i_Index = tbCtrlStage.SelectedIndex;

            string str_StageLocal = StageDAO.Instance.getDataStringStageFollowProjectIDAndIndex(this.str_ProjectIDGlobal, i_Index);

            if (str_StageLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return string.Empty;
            }

            if (str_StageLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return str_StageLocal;
        }

        // Lấy ra phòng đang chọn chọn hiện tại.
        private string getCurrDept()
        {
            int i_IndexTabLocal = this.tbCtrlDept.SelectedIndex;

            return this.lst_NameDeptGlobal[i_IndexTabLocal];
        }

        // Hiện thị các task theo màu qui định.
        // Đỏ là trễ ngày.
        // Xanh lá cây là làm xong.
        // Vàng đang chờ duyệt.
        // Xám chưa bắt đầu.
        // Xanh nước biển đang làm.
        // Cam là làm xong trễ.
        private void loadStage()
        {
            // Nếu hai thanh này đang bị ẩn thì không load stage.
            if (this.tbCtrlStage.Visible == false || this.tbCtrlDept.Visible == false)
                return;

            string str_ProjectIDLocal = this.str_ProjectIDGlobal;
            string str_StageLocal = this.getCurrStage();
            string str_DeptLocal = this.getCurrDept();

            // Lấy ra các dự án theo mã dự án đã chọn.
            List<TaskCreatingDTO> taskCreatingListLocal = TaskCreatingDAO.Instance.getDataListFollowProjectIDAndStageAndDept(str_ProjectIDLocal, str_StageLocal, str_DeptLocal);
            // Lấy ra các tên của stage.
            List<string> lst_NameSubjectLocal = StageDAO.Instance.getDataListFollowProjectID(str_ProjectIDLocal);
            // Lấy ra số lượng các taskcreating có trong stage.
            List<string> lst_QuantityStageLocal = TaskCreatingDAO.Instance.getDataListQuantityInStageForFormProjectDiagram(str_ProjectIDLocal);
            // Lấy ra số lượng các taskcreating có trong dept.
            List<string> lst_QuantityDeptLocal = TaskCreatingDAO.Instance.getDataListQuantityInDeptForFormProjectDiagram(str_ProjectIDLocal, str_StageLocal);

            if (taskCreatingListLocal != null && lst_NameSubjectLocal != null && lst_QuantityStageLocal != null && lst_QuantityDeptLocal != null)
            {
                // Làm sạch bảng giai đoạn.
                this.flPnHaveTaskCreating.Controls.Clear();

                // Hiển thị quantity và stage subject.
                this.loadStageSubjectAndQuantity(lst_NameSubjectLocal, lst_QuantityStageLocal, lst_QuantityDeptLocal);

                foreach (TaskCreatingDTO taskCreatingDTOTemp in taskCreatingListLocal)
                {
                    // Chỉ hiện thị những task hiện có của người đó.
                    // Task từ trước của người đó   (0).
                    // Task được nhận từ người khác (1).

                    #region Khởi tạo button.
                    //this.btnPersonalInformation = new Bunifu.Framework.UI.BunifuFlatButton();
                    var btn = new Bunifu.Framework.UI.BunifuFlatButton();
                    {
                        btn.Width = StaticVarClass.btn_TaskCreatingWidth;
                        btn.Height = StaticVarClass.btn_TaskCreatingHeight;
                    }

                    int i_LengthEmloyee = ("Employee: " + taskCreatingDTOTemp.Employee).Length;
                    int i_LengthTask = ("Task: " + taskCreatingDTOTemp.Task).Length;
                    int i_LengthProgress = ("Progress: " + taskCreatingDTOTemp.Progress).Length;
                    int i_LengthStatus = ("Status: " + taskCreatingDTOTemp.Status).Length;

                    btn.ButtonText = "Employee: " + taskCreatingDTOTemp.Employee;
                    btn.ButtonText += Environment.NewLine + "Task: " + taskCreatingDTOTemp.Task;
                    btn.ButtonText += Environment.NewLine + "Progress: " + taskCreatingDTOTemp.Progress;
                    btn.ButtonText += Environment.NewLine + "Status: " + taskCreatingDTOTemp.Status;

                    btn.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn.Iconimage = null;
                    btn.Iconimage_right = null;
                    btn.Iconimage_right_Selected = null;
                    btn.Iconimage_Selected = null;
                    btn.Cursor = System.Windows.Forms.Cursors.Hand;
                    btn.BorderRadius = 7;

                    btn.Click += Btn_Click;

                    btn.Tag = taskCreatingDTOTemp;
                    #endregion

                    #region Nhận diện màu của từng task.
                    switch (taskCreatingDTOTemp.Color)
                    {
                        case "Orange red":
                            btn.Normalcolor = Color.OrangeRed;
                            btn.Textcolor = Color.White;
                            btn.OnHovercolor = Color.Black;
                            btn.OnHoverTextColor = Color.White;                    
                            break;
                        case "Forest green":
                            btn.Normalcolor = Color.ForestGreen;
                            btn.Textcolor = Color.White;
                            btn.OnHovercolor = Color.Black;
                            btn.OnHoverTextColor = Color.White;
                            break;
                        case "Gray":
                            btn.Normalcolor = Color.LightGray;
                            btn.Textcolor = Color.Black;
                            btn.OnHovercolor = Color.Black;
                            btn.OnHoverTextColor = Color.White;
                            break;
                        case "Orange":
                            btn.Normalcolor = Color.Orange;
                            btn.Textcolor = Color.White;
                            btn.OnHovercolor = Color.Black;
                            btn.OnHoverTextColor = Color.White;
                            break;
                        case "Light sky blue":
                            btn.Normalcolor = Color.LightSkyBlue;
                            btn.Textcolor = Color.Black;
                            btn.OnHovercolor = Color.Black;
                            btn.OnHoverTextColor = Color.White;
                            break;
                        case "Yellow green":
                            btn.Normalcolor = Color.YellowGreen;
                            btn.Textcolor = Color.Black;
                            btn.OnHovercolor = Color.Black;
                            btn.OnHoverTextColor = Color.White;
                            break;
                    }
                    #endregion

                    #region Đưa từng task vào từng flowPannel Control.
                    this.flPnHaveTaskCreating.Controls.Add(btn);
                    #endregion
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Cursor.Current = Cursors.WaitCursor;

            string str_ProjectIDLocal = ((sender as Bunifu.Framework.UI.BunifuThinButton2).Tag as TaskCreatingDTO).ProjectID;
            string str_StageLocal = ((sender as Bunifu.Framework.UI.BunifuThinButton2).Tag as TaskCreatingDTO).Stage;
            string str_TaskLocal = ((sender as Bunifu.Framework.UI.BunifuThinButton2).Tag as TaskCreatingDTO).Task;
            string str_EmployeeLocal = ((sender as Bunifu.Framework.UI.BunifuThinButton2).Tag as TaskCreatingDTO).Employee;
            string str_StartDateLocal = ((sender as Bunifu.Framework.UI.BunifuThinButton2).Tag as TaskCreatingDTO).StartDate;
            string str_EndDateLocal = ((sender as Bunifu.Framework.UI.BunifuThinButton2).Tag as TaskCreatingDTO).EndDate;
            string str_StatusLocal = ((sender as Bunifu.Framework.UI.BunifuThinButton2).Tag as TaskCreatingDTO).Status;

            switch (me.Button)
            {
                case MouseButtons.Left:
                    this.showFormTaskDetail(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_EmployeeLocal);
                    break;
                case MouseButtons.Right:
                    // Khi công việc đã hoàn thành || không phải admin thì không được đẩy.
                    if (str_StatusLocal != StaticVarClass.status_Complete && str_StatusLocal != StaticVarClass.status_WaitForApproval && b_IsAdminGlobal == true)
                        this.showFormAssignTask(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_EmployeeLocal, str_StartDateLocal, str_EndDateLocal, str_StatusLocal);
                    break;
            }
        }

        private void showFormAssignTask(string projectID, string stage, string task, string employee, string startDate, string endDate, string status)
        {
            formAssignTask frmAssignTaskLocal = null;

            frmAssignTaskLocal = new formAssignTask();
            frmAssignTaskLocal.setInformation(projectID, stage, task, employee, startDate, endDate, status);
            frmAssignTaskLocal.ShowDialog();

            this.loadStage();
        }

        private void showFormTaskDetail(string projectID, string stage, string task, string employee)
        {
            formTaskDetail frmTaskDetailLocal = null;

            frmTaskDetailLocal = new formTaskDetail();
            frmTaskDetailLocal.setInformation(projectID, stage, task, employee);
            frmTaskDetailLocal.ShowDialog();

            this.loadStage();
        }

        // Ẩn các tabpage không cần dùng.
        private void hideTabPage(int indexStage)
        {
            int i_MaxStageLocal = StageDAO.Instance.getIntSumStageFollowProjectID(this.str_ProjectIDGlobal);
            int i = 0;

            tbCtrlStage.SelectedIndexChanged -= tbCtrlStage_SelectedIndexChanged;
            tbCtrlDept.SelectedIndexChanged -= tbCtrlDept_SelectedIndexChanged;

            // Xóa các giai đoạn hết các giai đoạn trước đó.
            for (i = 0; i < StaticVarClass.maxStage; i++)
            {
                tbCtrlStage.TabPages.Remove(this.lst_TbPgStageListGlobal[i]);
            }

            if (i_MaxStageLocal != -1)
            {
                // Thêm vào các giai đoạn sẵn có của dự án.
                for (i = 0; i < i_MaxStageLocal; i++)
                {
                    tbCtrlStage.TabPages.Add(this.lst_TbPgStageListGlobal[i]);
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

            // Lúc remove các page thì vị trí chọn page phải đc gán lai.
            this.tbCtrlStage.SelectedIndex = indexStage;

            tbCtrlStage.SelectedIndexChanged += tbCtrlStage_SelectedIndexChanged;
            tbCtrlDept.SelectedIndexChanged += tbCtrlDept_SelectedIndexChanged;
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        // Hàm đưa giúp focuss đúng stage.
        private void setFocusStage(int maxBefore, int maxAfter, int currStage, int currDept)
        {
            if (maxBefore == maxAfter)
            {
                this.tbCtrlStage.SelectedIndex = currStage;
                this.tbCtrlDept.SelectedIndex = currDept;
            }
            else if (maxBefore < maxAfter)
            {
                this.tbCtrlStage.SelectedIndex = maxAfter;
                this.tbCtrlDept.SelectedIndex = 0;
            }
        }

        private void formProjectDiagram_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void formProjectDiagram_Load(object sender, EventArgs e)
        {
            this.loadData();
            this.Authorize(); // Phân quyền.
        }

        private void btnProjectSelection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.lblSelect.Hide();
            this.btnSelect.Hide();

            formProjectSelection frmProjectSelectionLocal = new formProjectSelection();

            if (frmProjectSelectionLocal.ShowDialog() == DialogResult.OK)
            {
                this.str_ProjectIDGlobal = frmProjectSelectionLocal.cbbProjectID.Text.Trim();

                if (this.str_ProjectIDGlobal != string.Empty)
                {
                    // Lúc chọn dự án thì bắt đầu điều khiển được giai đoạn.
                    this.hideTabPage(0);
                    this.formProjectDiagram_Load(null, null);
                    this.hideButtonAndPanel(false);
                    this.loadStage();

                }
                else if (this.str_ProjectIDGlobal == string.Empty)
                {
                    this.lblSelect.Show();
                    this.btnSelect.Show();
                    XtraMessageBox.Show("You have not selected any projects yet!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (this.str_ProjectIDGlobal == string.Empty)
            {
                this.lblSelect.Show();
                this.btnSelect.Show();
                XtraMessageBox.Show("You have not selected any projects yet!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            btnProjectSelection_ItemClick(null, null);
        }

        private void btnAddStage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            int i_IndexCurrDeptLocal = this.tbCtrlDept.SelectedIndex;
            int i_IndexCurrStageLocal = this.tbCtrlStage.SelectedIndex;

            #region Nếu project đã complete thì ko đc add stage.
            string str_ProjectIDLocal = this.str_ProjectIDGlobal;
            string str_StatusProjectLocal = ProjectDAO.Instance.getStringStatusFollowProjectID(str_ProjectIDLocal);

            if (str_StatusProjectLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

            if (str_StatusProjectLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_StatusProjectLocal == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot add stage because project " + str_ProjectIDLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            // Lấy giai đoạn có stt lớn nhất của dự án.
            int i_MaxStageLocal = StageDAO.Instance.getIntMaxStageFollowProjectID(this.str_ProjectIDGlobal);

            if (i_MaxStageLocal != -1)
            {
                string str_ProjectIDTemp = this.str_ProjectIDGlobal;
                string str_StageTemp = (i_MaxStageLocal + 1).ToString();

                // Nếu stage < 20 thì lúc thêm thì stage=stage + 1; và thực hiện thêm tb vào trong tbCtrlStage.
                if (i_MaxStageLocal < StaticVarClass.maxStage)
                {
                    // Lấy thông tin hiện có truyền vào form add Stage.
                    formQuickAddStage frmQuickAddStageTemp = null;

                    frmQuickAddStageTemp = new formQuickAddStage();
                    frmQuickAddStageTemp.setInfo(str_ProjectIDTemp, str_StageTemp);
                    frmQuickAddStageTemp.ShowDialog();

                    // Cập nhật lại các stage mới.
                    this.hideTabPage(0);
                    this.formProjectDiagram_Load(null, null);
                    this.hideButtonAndPanel(false);
                    this.loadStage();

                    // Số stage lúc đã thêm mới.
                    int i_MaxStageTemp = StageDAO.Instance.getIntMaxStageFollowProjectID(this.str_ProjectIDGlobal);

                    this.setFocusStage(i_MaxStageLocal - 1, i_MaxStageTemp - 1, i_IndexCurrStageLocal, i_IndexCurrDeptLocal);
                }
                else
                {
                    XtraMessageBox.Show("Add project - stage: " + str_ProjectIDTemp + " - " + str_StageTemp + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }
        }

        private void btnRemoveStage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str_ProjectIDLocal = this.str_ProjectIDGlobal;
            int i_MaxStageLocal = StageDAO.Instance.getIntMaxStageFollowProjectID(str_ProjectIDLocal);
            string str_MaxStageLocal = i_MaxStageLocal.ToString().Trim();
            int i_SumOfTaskLocal = 0; // Số lượng của các task hiện có trong giai đoạn đó. 

            int i_IndexCurrDeptLocal = this.tbCtrlDept.SelectedIndex;
            int i_IndexCurrStageLocal = this.tbCtrlStage.SelectedIndex;

            #region Nếu project đã complete thì ko đc xóa stage.
            string str_StatusProjectLocal = ProjectDAO.Instance.getStringStatusFollowProjectID(str_ProjectIDLocal);

            if (str_StatusProjectLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

            if (str_StatusProjectLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_StatusProjectLocal == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot remove stage because project " + str_ProjectIDLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Nếu project - stage đã complete thì ko được xóa stage.
            string str_StatusStageLocal = StageDAO.Instance.getStringStatusFollowProjectIDAndStage(str_ProjectIDLocal, str_MaxStageLocal);

            if (str_StatusStageLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

            if (str_StatusStageLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_StatusStageLocal == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot remove stage because project " + str_ProjectIDLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            if (i_MaxStageLocal != -1)
            {
                if (1 <= i_MaxStageLocal && i_MaxStageLocal <= StaticVarClass.maxStage)
                {
                    i_SumOfTaskLocal = TaskCreatingDAO.Instance.getIntQuantityInStageForFormProjectDiagram(str_ProjectIDLocal, str_MaxStageLocal);

                    if (i_SumOfTaskLocal != -1)
                    {
                        #region Lấy ra các chỉ số để xem xét việc xóa task.
                        int i_RuleLocal = StageDAO.Instance.getIntWarningWhenRemovingStage(str_ProjectIDLocal, str_MaxStageLocal);
                        string str_Message = string.Empty;

                        switch (i_RuleLocal)
                        {
                            case -1:
                                DialogResult dr = XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.hideButtonAndPanel(true);
                                this.lblSelect.Show();
                                this.btnSelect.Show();
                                return;
                            case 1:
                                str_Message = "Warning: If you remove project - stage: " + str_ProjectIDLocal + " - " + str_MaxStageLocal + ", you will not be able to add any stages in this project. \nThere are " + i_SumOfTaskLocal + " tasks in project - stage: " + str_ProjectIDLocal + " - " + str_MaxStageLocal + ". \nAre you sure you want to remove?";
                                break;
                            case 0:
                            case 2:
                                str_Message = "Warning: There are " + i_SumOfTaskLocal + " tasks in project - stage: " + str_ProjectIDLocal + " - " + str_MaxStageLocal + ". \nAre you sure you want to remove?";
                                break;
                        }
                        #endregion

                        DialogResult drLocal = XtraMessageBox.Show(str_Message, "Comfirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (drLocal == DialogResult.Yes)
                        {
                            if (StageDAO.Instance.deleteData(str_ProjectIDLocal, str_MaxStageLocal))
                            {
                                #region Cập nhật lịch sử.
                                string name = StaticVarClass.account_Username;
                                string time = DateTime.Now.ToString();
                                string action = "Remove project - stage: " + str_ProjectIDLocal + " - " + str_MaxStageLocal;
                                string status = "Successful";

                                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                                HistoryDAO.Instance.addData(hisDTO);
                                #endregion

                                XtraMessageBox.Show("Successfully removed project - stage: " + str_ProjectIDLocal + " - " + str_MaxStageLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                #region update satus project.
                                StageDTO stageDTOTemp = StageDAO.Instance.getDataObjectForUpdateWhenRemovingStage(str_ProjectIDLocal);

                                if (stageDTOTemp.Empty() == false && stageDTOTemp != null)
                                {
                                    if (!StageDAO.Instance.updateDataStatus(stageDTOTemp.ProjectID, stageDTOTemp.Stage, stageDTOTemp.Status))
                                    {
                                        XtraMessageBox.Show("Update status project " + str_ProjectIDLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion

                                //this.tbCtrlStage.TabPages.Remove(this.lst_TbPgStageListGlobal[i_MaxStageLocal - 1]);
                                this.hideTabPage(0);
                                this.formProjectDiagram_Load(null, null);
                                this.hideButtonAndPanel(false);
                                this.loadStage();
                            }
                            else
                            {
                                #region Cập nhật lịch sử.
                                string name = StaticVarClass.account_Username;
                                string time = DateTime.Now.ToString();
                                string action = "Remove project - stage: " + str_ProjectIDLocal + " - " + str_MaxStageLocal;
                                string status = "Failed";

                                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                                HistoryDAO.Instance.addData(hisDTO);
                                #endregion

                                XtraMessageBox.Show("Remove project - stage: " + str_ProjectIDLocal + " - " + str_MaxStageLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.hideButtonAndPanel(true);
                        this.lblSelect.Show();
                        this.btnSelect.Show();
                        return;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

        }

        private void btnQuickAccessTaskWorking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnRefresh_ItemClick(null, null); // refresh trước khi gán this.tbCtrlStage.SelectedTab

            List<int> lst_StageAndStageOrdinalNumber = StageDAO.Instance.getDataListStageAndStageOrdinalNumberFollowProjectIDForQuickAccessTaskWorking(this.str_ProjectIDGlobal);

            if (lst_StageAndStageOrdinalNumber == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }

            if (lst_StageAndStageOrdinalNumber.Count == 2)
            {
                string str_ProjectIDTemp = this.str_ProjectIDGlobal;
                string str_StageTemp = lst_StageAndStageOrdinalNumber[0].ToString();
                string str_EmployeeTemp = StaticVarClass.account_Username;

                TaskCreatingDTO taskCreatingDTOTemp = TaskCreatingDAO.Instance.getDataObjectForQuickAccessTaskWorking(str_ProjectIDTemp, str_StageTemp, str_EmployeeTemp);

                if (taskCreatingDTOTemp == null)
                {
                    XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.hideButtonAndPanel(true);
                    this.lblSelect.Show();
                    this.btnSelect.Show();
                    return;
                }

                if (taskCreatingDTOTemp.Empty()) // Trong project - stage not complete này không có task nào của employee này.
                {
                    this.tbCtrlStage.SelectedTab = this.lst_TbPgStageListGlobal[lst_StageAndStageOrdinalNumber[1]];
                }
                else // Có task của employee.
                {
                    if (taskCreatingDTOTemp.Status == StaticVarClass.status_Complete) // Nếu employee đã complete hết các task thì show stage not complete hiện tại.
                    {
                        this.tbCtrlStage.SelectedTab = this.lst_TbPgStageListGlobal[lst_StageAndStageOrdinalNumber[1]];
                    }
                    else // Nếu employee chưa complete task thì show task detail.
                    {
                        this.tbCtrlStage.SelectedTab = this.lst_TbPgStageListGlobal[lst_StageAndStageOrdinalNumber[1]];
                        this.showFormTaskDetail(taskCreatingDTOTemp.ProjectID, taskCreatingDTOTemp.Stage, taskCreatingDTOTemp.Task, taskCreatingDTOTemp.Employee);
                    }
                }
            }
        }

        private void btnAddTaskCreating_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            formQuickAddTaskCreating frmQuickAddTaskTemp = null;
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(this.str_ProjectIDGlobal);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.hideButtonAndPanel(true);
                this.lblSelect.Show();
                this.btnSelect.Show();
                return;
            }
            else
            {
                if (!projectDTOLocal.Empty())
                {
                    // Lấy vị trí stage hiện tại đang chọn.
                    string str_StageLocal = getCurrStage();

                    #region Nếu project đã complete thì ko đc add task.
                    string str_ProjectIDLocal = this.str_ProjectIDGlobal;
                    string str_StatusProjectLocal = ProjectDAO.Instance.getStringStatusFollowProjectID(str_ProjectIDLocal);

                    if (str_StatusProjectLocal == null)
                    {
                        XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.hideButtonAndPanel(true);
                        this.lblSelect.Show();
                        this.btnSelect.Show();
                        return;
                    }

                    if (str_StatusProjectLocal == string.Empty)
                    {
                        XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (str_StatusProjectLocal == StaticVarClass.status_Complete)
                    {
                        XtraMessageBox.Show("Cannot add task because project " + str_ProjectIDLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    #endregion

                    #region Nếu project - stage đã complete thì ko được add task.
                    string statusStageTemp = StageDAO.Instance.getStringStatusFollowProjectIDAndStage(this.str_ProjectIDGlobal, str_StageLocal);

                    if (statusStageTemp == StaticVarClass.status_Complete)
                    {
                        XtraMessageBox.Show("Cannot add task because project - stage: " + this.str_ProjectIDGlobal + " - " + str_StageLocal + " has been completed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    #endregion

                    string str_ProjectIDTemp = projectDTOLocal.ProjectID;
                    string str_StageTemp = str_StageLocal;
                    string str_StartDateTemp = projectDTOLocal.StartDate;
                    string str_EndDateTemp = projectDTOLocal.EndDate;
                    string str_ProjectTypeTemp = projectDTOLocal.ProjectType;

                    // Lấy thông tin hiện có truyền vào form add Stage.
                    frmQuickAddTaskTemp = new formQuickAddTaskCreating();
                    frmQuickAddTaskTemp.setInfo(str_ProjectIDTemp, str_StageTemp, str_StartDateTemp, str_EndDateTemp, str_ProjectTypeTemp);
                    frmQuickAddTaskTemp.ShowDialog();

                    int i_CurrIndexStageTemp = int.Parse(frmQuickAddTaskTemp.txtEdtStage.Text.Trim()) - 1;
                    int i_CurrIndexDepatmentTemp = EmployeeDAO.Instance.getDataIntOrdinalNumberDepartmentFollowEmployee(frmQuickAddTaskTemp.cbbEmployee.Text.Trim());

                    if (i_CurrIndexDepatmentTemp == -1) 
                    {
                        XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.hideButtonAndPanel(true);
                        this.lblSelect.Show();
                        this.btnSelect.Show();
                        return;
                    }

                    this.hideTabPage(0);
                    this.formProjectDiagram_Load(null, null);
                    this.hideButtonAndPanel(false);
                    this.loadStage();

                    this.tbCtrlDept.SelectedIndex = i_CurrIndexDepatmentTemp;
                    this.tbCtrlStage.SelectedIndex = i_CurrIndexStageTemp;
                }
                else
                {
                    XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.hideButtonAndPanel(true);
                    this.lblSelect.Show();
                    this.btnSelect.Show();
                }
            }
        }

        private void tbCtrlStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i_CurrIndex = tbCtrlStage.SelectedIndex;
            this.hideTabPage(i_CurrIndex);

            this.formProjectDiagram_Load(null, null);
            this.hideButtonAndPanel(false);
            this.loadStage();

        }

        private void tbCtrlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i_CurrIndex = tbCtrlStage.SelectedIndex;
            this.hideTabPage(i_CurrIndex);

            this.formProjectDiagram_Load(null, null);
            this.hideButtonAndPanel(false);
            this.loadStage();
        }

        private void tbCtrlStage_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == tbCtrlStage.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.ForestGreen, e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.OrangeRed, e.Bounds);
            }
        }

        private void formProjectDiagram_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.b_IsAdminGlobal == true)
                {

                }
            }
            else
            {
                if (e.KeyCode.Equals(Keys.F5))
                {
                    btnRefresh_ItemClick(null, null);
                }
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    btnCancel_ItemClick(null, null);
                }
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.hideTabPage(0);

            this.formProjectDiagram_Load(null, null);
            this.hideButtonAndPanel(false);
            this.loadStage();
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formProjectDiagram = null;
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formProjectDiagram_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formProjectDiagram = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}