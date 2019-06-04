using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectManagement.DTO;
using ProjectManagement.DAO;
using ProjectManagement.CO;
using DevExpress.XtraSplashScreen;
using ProjectManagement.BUS;

namespace ProjectManagement.View
{
    public partial class formProject : DevExpress.XtraEditors.XtraForm
    {
        formRepeatedProject frmRepeatedProject = new formRepeatedProject();

        int i_FlagGlobal = 0;   // Thêm = 1; Sửa = 2; không làm gì = 0.

        string str_OldProjectIDForUpdateGlobal = string.Empty;
        string str_OldEndDateGlobal = string.Empty;

        #region Các cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectLeaderGlobal = false;

        bool b_IsSelectProjectTypeGlobal = false;

        bool b_IsSelectPOSMProjectGlobal = false;
        #endregion

        // Cờ đánh dấu admin.
        bool b_IsAdminGlobal = false;

        // Cờ đánh dấu empty data.
        bool b_IsEmptyData = false;

        public formProject()
        {
            InitializeComponent();
            lyoutControlProject.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void loadData()
        {
            DataTable dtProject = new DataTable();

            dtProject = ProjectBUS.Instance.getData();

            if (dtProject != null)
            {
                this.grdCtrlProject.DataSource = dtProject;

                if (dtProject.Rows.Count == 0)
                {
                    this.b_IsEmptyData = true;
                    XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.b_IsEmptyData = false;
                }
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Xét quyền hạn của nhân viên.
        private void Authorize()
        {
            string str_RoleLocal = string.Empty;

            str_RoleLocal = EmployeeDAO.Instance.getStringRoleFollowName(StaticVarClass.account_Username);

            if (str_RoleLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (str_RoleLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_RoleLocal == StaticVarClass.role_Admin)
            {
                this.disable(false);
                this.b_IsAdminGlobal = true;
            }
            else if (str_RoleLocal == StaticVarClass.role_Member)
            {
                this.disableAll();
                this.b_IsAdminGlobal = false;
            }
            else if (str_RoleLocal == StaticVarClass.role_Staff)
            {
                this.disableAll();
                this.b_IsAdminGlobal = false;
            }
        }

        // Lấy tin tin từ bản xuất ra các text trên thông tin nhân viên.
        private void binding()
        {
            // Lấy theo thứ tự giống database.
            System.Data.DataRow dtR_RowLocal = grvProject.GetDataRow(grvProject.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_RowLocal[0].ToString().Trim();
            string str_ProjectNameLocal = dtR_RowLocal[1].ToString().Trim();
            string str_LeaderLocal = dtR_RowLocal[2].ToString().Trim();
            string str_StartDateLocal = dtR_RowLocal[3].ToString().Trim();
            string str_EndDateLocal = dtR_RowLocal[4].ToString().Trim();
            string str_ProgressLocal = dtR_RowLocal[5].ToString().Trim();
            string str_ProjectTypeLocal = dtR_RowLocal[6].ToString().Trim();
            string str_POSMProjectLocal = dtR_RowLocal[7].ToString().Trim();
            string str_DateRepeatLocal = dtR_RowLocal[8].ToString().Trim();
            string str_AutoRepeatLocal = dtR_RowLocal[9].ToString().Trim();

            string str_StartDateRepeatLocal = string.Empty;
            if (dtR_RowLocal[10].ToString().Trim() != string.Empty)
                str_StartDateRepeatLocal = DateTime.Parse(dtR_RowLocal[10].ToString().Trim()).ToString("dd/MM/yyyy");

            string str_EndDateRepeatLocal = string.Empty;
            if (dtR_RowLocal[11].ToString().Trim() != string.Empty)
                str_EndDateRepeatLocal = DateTime.Parse(dtR_RowLocal[11].ToString().Trim()).ToString("dd/MM/yyyy");

            string str_StatusLocal = dtR_RowLocal[12].ToString().Trim();

            // Gán giá trị cho các ô.
            this.txtEdtProjectID.Text = str_ProjectIDLocal;
            this.txtEdtProjectName.Text = str_ProjectNameLocal;
            this.cbbLeader.Text = str_LeaderLocal;
            this.dtEdtStartDate.DateTime = DateTime.Parse(str_StartDateLocal);
            this.dtEdtEndDate.DateTime = DateTime.Parse(str_EndDateLocal);
            this.txtEdtProgress.Text = str_ProgressLocal;
            this.cbbProjectType.Text = str_ProjectTypeLocal;
            this.cbbPOSMProject.Text = str_POSMProjectLocal;
            this.txtEdtStatus.Text = str_StatusLocal;
            this.txtEdtDateRepeat.Text = str_DateRepeatLocal;
            this.txtEdtAutoRepeat.Text = str_AutoRepeatLocal;
            this.txtEdtStartDateRepeat.Text = str_StartDateRepeatLocal;
            this.txtEdtEndDateRepeat.Text = str_EndDateRepeatLocal;

            //this.txtEdtProjectID.DataBindings.Clear();
            //this.txtEdtProjectID.DataBindings.Add("Text", grdCtrlProject.DataSource, "PROJECTID");

            //this.txtEdtProjectName.DataBindings.Clear();
            //this.txtEdtProjectName.DataBindings.Add("Text", grdCtrlProject.DataSource, "PROJECTNAME");

            //this.cbbLeader.DataBindings.Clear();
            //this.cbbLeader.DataBindings.Add("Text", grdCtrlProject.DataSource, "LEADER");

            //Binding binding = new Binding(nameof(DateEdit.EditValue), grdCtrlProject.DataSource, "STARTDATE", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dtEdtStartDate.DataBindings.Clear();
            //this.dtEdtStartDate.DataBindings.Add(binding);

            //binding = new Binding(nameof(DateEdit.EditValue), grdCtrlProject.DataSource, "ENDDATE", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dtEdtEndDate.DataBindings.Clear();
            //this.dtEdtEndDate.DataBindings.Add(binding);

            //this.txtEdtProgress.DataBindings.Clear();
            //this.txtEdtProgress.DataBindings.Add("Text", grdCtrlProject.DataSource, "PROGRESS");

            //this.cbbProjectType.DataBindings.Clear();
            //this.cbbProjectType.DataBindings.Add("Text", grdCtrlProject.DataSource, "PROJECTTYPE");

            //this.cbbPOSMProject.DataBindings.Clear();
            //this.cbbPOSMProject.DataBindings.Add("Text", grdCtrlProject.DataSource, "POSMPROJECT");

            //this.txtEdtStatus.DataBindings.Clear();
            //this.txtEdtStatus.DataBindings.Add("Text", grdCtrlProject.DataSource, "STATUS");

            //this.txtEdtDateRepeat.DataBindings.Clear();
            //this.txtEdtDateRepeat.DataBindings.Add("Text", grdCtrlProject.DataSource, "DATEREPEAT");

            //this.txtEdtAutoRepeat.DataBindings.Clear();
            //this.txtEdtAutoRepeat.DataBindings.Add("Text", grdCtrlProject.DataSource, "AUTOREPEAT");

            //this.txtEdtStartDateRepeat.DataBindings.Clear();
            //this.txtEdtStartDateRepeat.DataBindings.Add("Text", grdCtrlProject.DataSource, "STARTDATEREPEAT");

            //this.txtEdtEndDateRepeat.DataBindings.Clear();
            //this.txtEdtEndDateRepeat.DataBindings.Add("Text", grdCtrlProject.DataSource, "ENDDATEREPEAT");
        }

        //private void notBinding()
        //{
        //    this.txtEdtProjectID.DataBindings.Clear();
        //    this.txtEdtProjectName.DataBindings.Clear();
        //    this.cbbLeader.DataBindings.Clear();
        //    this.dtEdtStartDate.DataBindings.Clear();
        //    this.dtEdtEndDate.DataBindings.Clear();
        //    this.txtEdtProgress.DataBindings.Clear();
        //    this.cbbProjectType.DataBindings.Clear();
        //    this.cbbPOSMProject.DataBindings.Clear();
        //    this.txtEdtStatus.DataBindings.Clear();
        //    this.txtEdtDateRepeat.DataBindings.Clear();
        //    this.txtEdtAutoRepeat.DataBindings.Clear();
        //    this.txtEdtStartDateRepeat.DataBindings.Clear();
        //    this.txtEdtEndDateRepeat.DataBindings.Clear();
        //}

        private void disable(bool e)
        {
            if (this.i_FlagGlobal == 1)
            {
                this.txtEdtProjectID.ReadOnly = false;
                this.txtEdtProjectName.ReadOnly = false;
                this.cbbLeader.Enabled = true;
                this.dtEdtStartDate.ReadOnly = false;
                this.dtEdtEndDate.ReadOnly = false;
                this.cbbProjectType.Enabled = true;
                this.cbbPOSMProject.Enabled = true;
            }
            else if (this.i_FlagGlobal == 2)
            {
                this.txtEdtProjectID.ReadOnly = true; // always
                this.txtEdtProjectName.ReadOnly = true; // always
                this.cbbLeader.Enabled = false; // always
                this.dtEdtStartDate.ReadOnly = true; //
                this.dtEdtEndDate.ReadOnly = true; //
                this.cbbProjectType.Enabled = false; // not complete or overdue
                this.cbbPOSMProject.Enabled = false; // always
            }
            else
            {
                // Khóa các text, combobox.
                this.txtEdtProjectID.ReadOnly = true;
                this.txtEdtProjectName.ReadOnly = true;
                this.cbbLeader.Enabled = false;
                this.dtEdtStartDate.ReadOnly = true;
                this.dtEdtEndDate.ReadOnly = true;
                this.cbbProjectType.Enabled = false;
                this.cbbPOSMProject.Enabled = false;
            }

            // Các ô mặc định khoá.
            this.txtEdtProgress.ReadOnly = true;
            this.txtEdtStatus.ReadOnly = true;
            this.txtEdtDateRepeat.ReadOnly = true;
            this.txtEdtAutoRepeat.ReadOnly = true;
            this.txtEdtStartDateRepeat.ReadOnly = true;
            this.txtEdtEndDateRepeat.ReadOnly = true;

            // Các nút mặc định mở.
            this.btnStartRepeat.Enabled = true;
            this.btnStopRepeat.Enabled = true;

            // Khóa/ Mở khóa các nút.
            this.btnAdd.Enabled = !e;
            this.btnEdit.Enabled = !e;
            this.btnSave.Enabled = e;
            this.btnRemove.Enabled = !e;

            // Nếu ko có data.
            if (this.b_IsEmptyData == true)
            {
                this.btnStartRepeat.Enabled = false;
                this.btnStopRepeat.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnRemove.Enabled = false;
            }
        }

        // Khóa tất cả các phím.
        private void disableAll()
        {
            // Khóa các text, combobox.
            this.txtEdtProjectID.ReadOnly = true;
            this.txtEdtProjectName.ReadOnly = true;
            this.cbbLeader.Enabled = false;
            this.dtEdtStartDate.ReadOnly = true;
            this.dtEdtEndDate.ReadOnly = true;
            this.txtEdtProgress.ReadOnly = true;
            this.cbbProjectType.Enabled = false;
            this.cbbPOSMProject.Enabled = false;
            this.txtEdtStatus.ReadOnly = true;
            this.txtEdtDateRepeat.ReadOnly = true;
            this.txtEdtAutoRepeat.ReadOnly = true;
            this.txtEdtStartDateRepeat.ReadOnly = true;
            this.txtEdtEndDateRepeat.ReadOnly = true;

            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnRemove.Enabled = false;
            this.btnStartRepeat.Enabled = false;
            this.btnStopRepeat.Enabled = false;
        }

        private void checkEnableEdit(string projectID)
        {
            DataTable dtLocal = TaskCreatingDAO.Instance.getDataFollowProjectID(projectID);
            ProjectDTO projectDTOLocal = ProjectBUS.Instance.getDataObjectFollowProjectID(projectID);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnSave.Enabled = false;
                return;
            }

            if (projectDTOLocal.Empty())
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSave.Enabled = false;
                return;
            }

            if (projectDTOLocal.Status == StaticVarClass.status_Complete)
            {
                this.btnSave.Enabled = false;
                return;
            }

            if (DateTime.Parse(projectDTOLocal.StartDate) > DateTime.Now)
            {
                //
                this.dtEdtStartDate.ReadOnly = false;
                this.dtEdtEndDate.ReadOnly = false;
            }

            // not complete or overdue
            this.cbbProjectType.Enabled = true;
            foreach (DataRow dtR in dtLocal.Rows)
            {
                TaskCreatingDTO taskCreatingDTOTemp = new TaskCreatingDTO(dtR);
                if (taskCreatingDTOTemp.Status != StaticVarClass.status_NotComplete && taskCreatingDTOTemp.Status != StaticVarClass.status_Overdue)
                {
                    this.cbbProjectType.Enabled = false;
                    break;
                }
            }

            if (projectDTOLocal.Status != StaticVarClass.status_Complete)
            {
                // always
                this.txtEdtProjectID.ReadOnly = false;
                this.txtEdtProjectName.ReadOnly = false;
                this.cbbLeader.Enabled = true;
                this.cbbPOSMProject.Enabled = true;
                this.dtEdtEndDate.ReadOnly = false; // Mở end date để gia hạn.
            }
            
        }

        // Xóa sạch trước khi thêm.
        private void clearData()
        {
            this.txtEdtProjectID.Text = string.Empty;
            this.txtEdtProjectName.Text = string.Empty;
            this.cbbLeader.Text = string.Empty;
            this.dtEdtStartDate.DateTime = DateTime.Now;
            this.dtEdtEndDate.DateTime = DateTime.Now.AddDays(1);
            this.txtEdtProgress.Text = "0";
            this.cbbProjectType.Text = string.Empty;
            this.cbbPOSMProject.Text = string.Empty;
            this.txtEdtStatus.Text = StaticVarClass.status_NotComplete;
            this.txtEdtDateRepeat.Text = "0";
            this.txtEdtAutoRepeat.Text = "0";
            this.txtEdtStartDateRepeat.Text = string.Empty;
            this.txtEdtEndDateRepeat.Text = string.Empty;
        }

        // Load tất cả các mã nhân viên trong công ty.
        private void loadLeader()
        {
            string str_LeaderLocal = this.cbbLeader.Text.Trim();

            DataTable dtLocal = EmployeeDAO.Instance.getDataNotAllColumnsAndWorking();

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string name = row["NAME"].ToString();
                    row["NAME"] = name.Trim();
                }

                this.cbbLeader.DataSource = dtLocal;
                this.cbbLeader.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbLeader.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbLeader.DisplayMember = "NAME";

                if (this.i_FlagGlobal == 2 && str_LeaderLocal != string.Empty)
                    this.cbbLeader.SelectedIndex = this.cbbLeader.FindString(str_LeaderLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load các loại dự án.
        private void loadProjectType()
        {
            string str_ProjectTypeLocal = this.cbbProjectType.Text.Trim();

            this.cbbProjectType.Items.Clear();
            this.cbbProjectType.Items.AddRange(new object[] {
            StaticVarClass.type_Normal,
            StaticVarClass.type_AdminApproval,
            });

            this.cbbProjectType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbProjectType.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.i_FlagGlobal == 1)
                this.cbbProjectType.SelectedIndex = 0;

            if (this.i_FlagGlobal == 2 && str_ProjectTypeLocal != string.Empty)
                this.cbbProjectType.SelectedIndex = this.cbbProjectType.FindString(str_ProjectTypeLocal);
        }

        private void loadPOSMProject()
        {
            string str_POSMProjectLocal = this.cbbPOSMProject.Text.Trim();

            this.cbbPOSMProject.Items.Clear();
            this.cbbPOSMProject.Items.AddRange(new object[] {
            StaticVarClass.POSM_NotPOSMProject,
            StaticVarClass.POSM_POSMProject,
            });

            this.cbbPOSMProject.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbPOSMProject.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.i_FlagGlobal == 1)
                this.cbbPOSMProject.SelectedIndex = 0;

            if (this.i_FlagGlobal == 2 && str_POSMProjectLocal != string.Empty)
                this.cbbPOSMProject.SelectedIndex = this.cbbPOSMProject.FindString(str_POSMProjectLocal);
        }

        private void loadControl()
        {
            //this.notBinding();
            if (this.i_FlagGlobal == 2)
                this.binding();

            this.loadLeader();
            this.loadProjectType();
            this.loadPOSMProject();
        }

        // Gán dữ liệu.
        private void setData(ProjectDTO projectDTO)
        {
            if (this.i_FlagGlobal == 1)
                projectDTO.ProjectID = this.txtEdtProjectID.Text.Trim();
            else if (this.i_FlagGlobal == 2)
                projectDTO.ProjectID = this.str_OldProjectIDForUpdateGlobal;

            projectDTO.ProjectName = this.txtEdtProjectName.Text.Trim();

            if (this.cbbLeader.Text.Trim() == string.Empty)
                projectDTO.Leader = null;
            else
                projectDTO.Leader = this.cbbLeader.Text.Trim();

            if (this.dtEdtStartDate.Text.Trim() == string.Empty)
                projectDTO.StartDate = null;
            else projectDTO.StartDate = this.dtEdtStartDate.Text.Trim();

            if (this.dtEdtEndDate.Text.Trim() == string.Empty)
                projectDTO.EndDate = null;
            else projectDTO.EndDate = this.dtEdtEndDate.Text.Trim();

            projectDTO.Progress = this.txtEdtProgress.Text.Trim();
            projectDTO.ProjectType = this.cbbProjectType.Text.Trim();
            projectDTO.POSMProject = this.cbbPOSMProject.Text.Trim();
            projectDTO.Status = this.txtEdtStatus.Text.Trim();
            projectDTO.DateRepeat = this.txtEdtDateRepeat.Text.Trim();
            projectDTO.AutoRepeat = this.txtEdtAutoRepeat.Text.Trim();

            if (this.txtEdtStartDateRepeat.Text.Trim() == string.Empty)
                projectDTO.StartDateRepeat = null;
            else
                projectDTO.StartDateRepeat = this.txtEdtStartDateRepeat.Text.Trim();

            if (this.txtEdtEndDateRepeat.Text.Trim() == string.Empty)
                projectDTO.EndDateRepeat = null;
            else
                projectDTO.EndDateRepeat = this.txtEdtEndDateRepeat.Text.Trim();
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        private void formProject_Load(object sender, EventArgs e)
        {
            // Đặt lại cờ.
            this.i_FlagGlobal = 0;

            this.lyoutControlProject.Hide();

            this.loadData();

            // Phân quyền.
            this.Authorize();
        }

        private void formProject_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.i_FlagGlobal = 1;

            this.lyoutControlProject.Show();

            this.clearData();
            this.loadControl();
            this.disable(true); // Điều khiển các nút.
            this.btnSave.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Data.DataRow dtR_RowLocal = grvProject.GetDataRow(grvProject.FocusedRowHandle);
            this.str_OldProjectIDForUpdateGlobal = dtR_RowLocal[0].ToString().Trim();
            this.str_OldEndDateGlobal = dtR_RowLocal[4].ToString().Trim();

            this.i_FlagGlobal = 2;

            this.lyoutControlProject.Show();

            this.loadControl();
            this.disable(true);  // Điều khiển các nút.
            this.btnSave.Enabled = true;
            this.checkEnableEdit(str_OldProjectIDForUpdateGlobal);
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Data.DataRow dtR_RowLocal = grvProject.GetDataRow(grvProject.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_RowLocal[0].ToString().Trim();

            #region Nếu project đã hoàn thành thì ko xoá đc.
            ProjectDTO projectDTOLocal = ProjectBUS.Instance.getDataObjectFollowProjectID(str_ProjectIDLocal);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (projectDTOLocal.Empty())
            {
                return;
            }

            if (projectDTOLocal.Status == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot remove project because project " + str_ProjectIDLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            List<string> lst_ListQuatityLocal = ProjectBUS.Instance.getListQuantityRelatedToRemovingProject(str_ProjectIDLocal);

            if (lst_ListQuatityLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lst_ListQuatityLocal.Count == 0)
            {
                return;
            }

            // Hộp thoại xác nhận khi nhấn nút xóa.
            DialogResult dr = XtraMessageBox.Show("Warning: There are " + lst_ListQuatityLocal[0] + " stages, " + lst_ListQuatityLocal[1] + " tasks in project " + str_ProjectIDLocal + ". \nAre you sure you want to remove?", "Confirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Xóa.
                if (ProjectBUS.Instance.deleteData(str_ProjectIDLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove project " + str_ProjectIDLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully removed project " + str_ProjectIDLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove project " + str_ProjectIDLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Remove project " + str_ProjectIDLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            else
            {
                return;
            }

            formProject_Load(sender, e);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim(); // ProjectID mới (nếu có).

            if (str_ProjectIDLocal == string.Empty)
                str_ProjectIDLocal = null;

            ProjectDTO projectDTOLocal = new ProjectDTO();

            // Gán giá trị vào thuộc tính trong bảng.
            this.setData(projectDTOLocal);

            #region Kiểm tra start date.
            if (DateTime.Parse(projectDTOLocal.StartDate) >= DateTime.Parse(projectDTOLocal.EndDate))
            {
                XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TimeSpan difference = new TimeSpan(1, 0, 0, 0);
                this.dtEdtStartDate.DateTime = this.dtEdtEndDate.DateTime.Subtract(difference);
                return;
            }
            #endregion

            #region Thêm mới.
            if (this.i_FlagGlobal == 1)
            {
                #region Kiểm tra end date.
                if (DateTime.Parse(projectDTOLocal.EndDate) <= DateTime.Parse(projectDTOLocal.StartDate))
                {
                    XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtEdtEndDate.DateTime = this.dtEdtStartDate.DateTime.AddDays(1);
                    return;
                }
                #endregion

                // Thêm mới.
                if (ProjectBUS.Instance.addData(projectDTOLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add project " + projectDTOLocal.ProjectID;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully added project " + projectDTOLocal.ProjectID + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (this.frmRepeatedProject == null)
                        this.frmRepeatedProject = new formRepeatedProject();
                    this.frmRepeatedProject.getCreatedProject(projectDTOLocal.ProjectID); // Lưu lại projectID mới tạo cho form Repeated Project.
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add project " + projectDTOLocal.ProjectID;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Add project " + projectDTOLocal.ProjectID + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            #region Sửa.
            else if (this.i_FlagGlobal == 2)
            {
                #region Kiểm tra end date.
                if (DateTime.Parse(projectDTOLocal.EndDate) < DateTime.Parse(this.str_OldEndDateGlobal))
                {
                    XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtEdtEndDate.DateTime = DateTime.Parse(this.str_OldEndDateGlobal);
                    return;
                }
                #endregion

                // Sửa.
                if (ProjectBUS.Instance.updateData(projectDTOLocal, str_ProjectIDLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project " + projectDTOLocal.ProjectID;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully edited project " + projectDTOLocal.ProjectID + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project " + projectDTOLocal.ProjectID;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Edit project " + projectDTOLocal.ProjectID + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            formProject_Load(sender, e);
        }

        private void btnStartRepeat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.frmRepeatedProject == null)
                this.frmRepeatedProject = new formRepeatedProject();

            System.Data.DataRow dtR_RowLocal = grvProject.GetDataRow(grvProject.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_RowLocal[0].ToString().Trim();

            this.frmRepeatedProject.getCreatedProject(str_ProjectIDLocal);
            frmRepeatedProject.ShowDialog();
            this.frmRepeatedProject = null;

            this.formProject_Load(null, null);
        }

        private void btnStopRepeat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.frmRepeatedProject == null)
                this.frmRepeatedProject = new formRepeatedProject();

            System.Data.DataRow dtR_RowLocal = grvProject.GetDataRow(grvProject.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_RowLocal[0].ToString().Trim();

            this.frmRepeatedProject.getCreatedProject(str_ProjectIDLocal);
            frmRepeatedProject.ShowDialog();
            this.frmRepeatedProject = null;

            this.formProject_Load(null, null);
        }

        private void dtEdtStartDate_Leave(object sender, EventArgs e)
        {
            if (this.i_FlagGlobal != 0 && this.dtEdtStartDate.DateTime >= this.dtEdtEndDate.DateTime)
            {
                XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TimeSpan difference = new TimeSpan(1, 0, 0, 0);
                this.dtEdtStartDate.DateTime = this.dtEdtEndDate.DateTime.Subtract(difference);
            }
        }

        private void dtEdtEndDate_Leave(object sender, EventArgs e)
        {
            if (this.i_FlagGlobal == 1 && this.dtEdtEndDate.DateTime <= this.dtEdtStartDate.DateTime)
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = this.dtEdtStartDate.DateTime.AddDays(1);
            }

            if (this.i_FlagGlobal == 2 && (this.dtEdtEndDate.DateTime < DateTime.Parse(this.str_OldEndDateGlobal)))
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = DateTime.Parse(this.str_OldEndDateGlobal);
            }
        }

        private void txtEdtProjectID_EditValueChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_ProjectIDLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }

            this.txtEdtProjectID.Text = this.txtEdtProjectID.Text.Trim();
        }

        private void cbbLeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_LeaderLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbLeader_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectLeaderGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_LeaderLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbLeader_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectLeaderGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectLeaderGlobal = false;
        }

        private void cbbLeader_DropDown(object sender, EventArgs e)
        {
            this.cbbLeader.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbLeader.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbLeader_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbLeader.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbLeader.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                XtraMessageBox.Show("Be careful when changing project type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_ProjectTypeLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbProjectType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectProjectTypeGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                XtraMessageBox.Show("Be careful when changing project type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_ProjectTypeLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbProjectType_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectProjectTypeGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectProjectTypeGlobal = false;
        }

        private void cbbProjectType_DropDown(object sender, EventArgs e)
        {
            this.cbbProjectType.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbProjectType.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbProjectType_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbProjectType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbProjectType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbPOSMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_POSMProjectLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbPOSMProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectPOSMProjectGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_POSMProjectLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbPOSMProject_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectPOSMProjectGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectPOSMProjectGlobal = false;
        }

        private void cbbPOSMProject_DropDown(object sender, EventArgs e)
        {
            this.cbbPOSMProject.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbPOSMProject.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbPOSMProject_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbPOSMProject.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbPOSMProject.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtEdtProjectID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtProjectName.Focus();
            }
        }

        private void txtEdtProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbLeader.Select();
            }
        }

        private void txtEdtProjectName_EditValueChanged(object sender, EventArgs e)
        {
            this.txtEdtProjectName.Text = this.txtEdtProjectName.Text.Trim();
        }

        private void cbbLeader_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEdtStartDate.Focus();
            }
        }

        private void dtEdtStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEdtEndDate.Focus();
            }
        }

        private void dtEdtEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtProgress.Focus();
            }
        }

        private void nmrUpDwnProgress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbProjectType.Select();
            }
        }

        private void cbbProjectType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbPOSMProject.Select();
            }
        }

        private void cbbPOSMProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtProjectName.Focus();
            }

        }

        private void formProject_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.b_IsAdminGlobal == true)
                {
                    if (this.btnAdd.Enabled == true)
                    {
                        if (e.KeyCode.Equals(Keys.Oemplus) || e.KeyCode.Equals(Keys.Add))
                        {
                            btnAdd_ItemClick(null, null);
                        }
                    }
                    if (btnEdit.Enabled == true)
                    {
                        if (e.KeyCode.Equals(Keys.D))
                        {
                            btnEdit_ItemClick(null, null);
                        }
                    }
                    if (this.btnRemove.Enabled == true)
                    {
                        if (e.KeyCode.Equals(Keys.R))
                        {
                            btnRemove_ItemClick(null, null);
                        }
                    }
                    if (this.btnSave.Enabled == true)
                    {
                        if (e.KeyCode.Equals(Keys.S))
                        {
                            btnSave_ItemClick(null, null);
                        }
                    }
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
            formProject_Load(sender, e);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formProject = null;
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formProject = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}