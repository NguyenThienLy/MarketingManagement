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

namespace ProjectManagement.View
{
    public partial class formTaskCreating : DevExpress.XtraEditors.XtraForm
    {
        int i_FlagGlobal = 0; // Add or Edit or do nothing.

        string str_OldTaskForUpdateGlobal = string.Empty;
        string str_OldEndDateGlobal = string.Empty;

        #region Các cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectProjectIDGlobal = false;

        bool b_IsSelectStageGlobal = false;

        bool b_IsSelectEmployeeGlobal = false;

        bool b_IsSelectTaskTypeGlobal = false;

        bool b_IsSelectApproverGlobal = false;

        bool b_IsSelectAttachFileGlobal = false;
        #endregion

        bool b_IsAdminGlobal = false;

        // Cờ đánh dấu empty data.
        bool b_IsEmptyData = false;

        public formTaskCreating()
        {
            InitializeComponent();
            lyoutControlTaskCreating.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void loadData()
        {
            DataTable dtTaskCreating = new DataTable();
            dtTaskCreating = TaskCreatingDAO.Instance.getData();

            if (dtTaskCreating != null)
            {
                this.grdCtrlTaskCreating.DataSource = dtTaskCreating;

                if (dtTaskCreating.Rows.Count == 0)
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
            System.Data.DataRow dtR_RowLocal = grvTaskCreating.GetDataRow(grvTaskCreating.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_RowLocal[0].ToString().Trim();
            string str_StageLocal = dtR_RowLocal[1].ToString().Trim();
            string str_TaskLocal = dtR_RowLocal[2].ToString().Trim();
            string str_EmployeeLocal = dtR_RowLocal[3].ToString().Trim();
            string str_TaskDescriptionLocal = dtR_RowLocal[4].ToString().Trim();
            string str_StartDateLocal = dtR_RowLocal[5].ToString().Trim();
            string str_EndDateLocal = dtR_RowLocal[6].ToString().Trim();
            string str_TaskTypeLocal = dtR_RowLocal[7].ToString().Trim();

            string str_ApproverLocal = dtR_RowLocal[8].ToString().Trim();
            if (str_ApproverLocal == string.Empty)
                str_ApproverLocal = "Admin";

            string str_AttachFileLocal = dtR_RowLocal[9].ToString().Trim();
            string str_ProgressLocal = dtR_RowLocal[10].ToString().Trim();
            string str_StatusLocal = dtR_RowLocal[11].ToString().Trim();

            string str_FinishDateLocal = string.Empty;
            if (dtR_RowLocal[12].ToString().Trim() != string.Empty)
                str_FinishDateLocal = DateTime.Parse(dtR_RowLocal[12].ToString().Trim()).ToString("dd/MM/yyyy");

            string str_TimeDelayLocal = dtR_RowLocal[13].ToString().Trim();
            string str_NoteLocal = dtR_RowLocal[15].ToString().Trim();

            // Gán giá trị cho các ô.
            this.cbbProjectID.Text = str_ProjectIDLocal;
            this.cbbStage.Text = str_StageLocal;
            this.txtEdtTask.Text = str_TaskLocal;
            this.cbbEmployee.Text = str_EmployeeLocal;
            this.rchTxtBxTaskDescription.Text = str_TaskDescriptionLocal;
            this.dtEdtStartDate.DateTime = DateTime.Parse(str_StartDateLocal);
            this.dtEdtEndDate.DateTime = DateTime.Parse(str_EndDateLocal);
            this.cbbTaskType.Text = str_TaskTypeLocal;
            this.cbbApprover.Text = str_ApproverLocal;
            this.cbbAttachFile.Text = str_AttachFileLocal;
            this.txtEdtProgress.Text = str_ProgressLocal;
            this.txtEdtStatus.Text = str_StatusLocal;
            this.txtEdtFinishDate.Text = str_FinishDateLocal;
            this.txtEdtTimeDelay.Text = str_TimeDelayLocal;
            this.txtEdtNote.Text = str_NoteLocal;

            //this.cbbProjectID.DataBindings.Clear();
            //this.cbbProjectID.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "PROJECTID");

            //this.cbbStage.DataBindings.Clear();
            //this.cbbStage.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "STAGE");

            //this.txtEdtTask.DataBindings.Clear();
            //this.txtEdtTask.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "TASK");

            //this.cbbEmployee.DataBindings.Clear();
            //this.cbbEmployee.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "EMPLOYEE");

            //this.rchTxtBxTaskDescription.DataBindings.Clear();
            //this.rchTxtBxTaskDescription.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "TASKDESCRIPTION");

            //Binding binding = new Binding(nameof(DateEdit.EditValue), grdCtrlTaskCreating.DataSource, "STARTDATE", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dtEdtStartDate.DataBindings.Clear();
            //this.dtEdtStartDate.DataBindings.Add(binding);

            //binding = new Binding(nameof(DateEdit.EditValue), grdCtrlTaskCreating.DataSource, "ENDDATE", false, DataSourceUpdateMode.OnPropertyChanged);
            //this.dtEdtEndDate.DataBindings.Clear();
            //this.dtEdtEndDate.DataBindings.Add(binding);

            //this.cbbTaskType.DataBindings.Clear();
            //this.cbbTaskType.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "TASKTYPE");

            //this.cbbApprover.DataBindings.Clear();
            //this.cbbApprover.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "APPROVER");

            //this.cbbAttachFile.DataBindings.Clear();
            //this.cbbAttachFile.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "ATTACHFILE");

            //this.txtEdtProgress.DataBindings.Clear();
            //this.txtEdtProgress.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "PROGRESS");

            //this.txtEdtStatus.DataBindings.Clear();
            //this.txtEdtStatus.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "STATUS");

            //this.txtEdtFinishDate.DataBindings.Clear();
            //this.txtEdtFinishDate.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "FINISHDATE");

            //this.txtEdtTimeDelay.DataBindings.Clear();
            //this.txtEdtTimeDelay.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "TIMEDELAY");

            //this.txtEdtNote.DataBindings.Clear();
            //this.txtEdtNote.DataBindings.Add("Text", grdCtrlTaskCreating.DataSource, "NOTE");
        }

        //private void notBinding()
        //{
        //    this.cbbProjectID.DataBindings.Clear();
        //    this.cbbStage.DataBindings.Clear();
        //    this.txtEdtTask.DataBindings.Clear();

        //    this.cbbEmployee.DataBindings.Clear();
        //    this.rchTxtBxTaskDescription.DataBindings.Clear();
        //    this.dtEdtStartDate.DataBindings.Clear();
        //    this.dtEdtEndDate.DataBindings.Clear();
        //    this.cbbTaskType.DataBindings.Clear();
        //    this.cbbApprover.DataBindings.Clear();
        //    this.cbbAttachFile.DataBindings.Clear();
        //    this.txtEdtProgress.DataBindings.Clear();
        //    this.txtEdtStatus.DataBindings.Clear();
        //    this.txtEdtFinishDate.DataBindings.Clear();
        //    this.txtEdtTimeDelay.DataBindings.Clear();
        //    this.txtEdtNote.DataBindings.Clear();
        //}

        // Khóa các phím.
        private void disable(bool e)
        {
            if (this.i_FlagGlobal == 1)
            {
                this.cbbProjectID.Enabled = true;
                this.cbbStage.Enabled = true;
                this.txtEdtTask.Enabled = true;
                this.cbbEmployee.Enabled = true;
                this.rchTxtBxTaskDescription.ReadOnly = false;
                this.dtEdtStartDate.ReadOnly = false;
                this.dtEdtEndDate.ReadOnly = false;
                this.cbbTaskType.Enabled = true;
                this.cbbApprover.Enabled = false;
                this.cbbAttachFile.Enabled = true;
            }
            else if (this.i_FlagGlobal == 2)
            {
                this.cbbProjectID.Enabled = false;
                this.cbbStage.Enabled = false;
                this.txtEdtTask.Enabled = false; // always
                this.cbbEmployee.Enabled = false; // 
                this.rchTxtBxTaskDescription.ReadOnly = true; // not complete
                this.dtEdtStartDate.ReadOnly = true; //
                this.dtEdtEndDate.ReadOnly = true; //
                this.cbbTaskType.Enabled = false; // not complete
                this.cbbApprover.Enabled = false; // always
                this.cbbAttachFile.Enabled = false; // not complete
            }
            else
            {
                this.cbbProjectID.Enabled = false;
                this.cbbStage.Enabled = false;
                this.txtEdtTask.Enabled = false;
                this.cbbEmployee.Enabled = false;
                this.rchTxtBxTaskDescription.ReadOnly = true;
                this.dtEdtStartDate.ReadOnly = true;
                this.dtEdtEndDate.ReadOnly = true;
                this.cbbTaskType.Enabled = false;
                this.cbbApprover.Enabled = false;
                this.cbbAttachFile.Enabled = false;
            }

            // Các ô mặc định khoá.
            this.txtEdtProgress.ReadOnly = true;
            this.txtEdtStatus.ReadOnly = true;
            this.txtEdtFinishDate.ReadOnly = true;
            this.txtEdtTimeDelay.ReadOnly = true;
            this.txtEdtNote.ReadOnly = true;

            // Mở/ khóa các nút.
            this.btnAdd.Enabled = !e;
            this.btnEdit.Enabled = !e;
            this.btnSave.Enabled = e;
            this.btnRemove.Enabled = !e;

            if (this.b_IsEmptyData == true)
            {
                this.btnEdit.Enabled = false;
                this.btnRemove.Enabled = false;
            }
        }

        // Khóa tất cả các phím.
        private void disableAll()
        {
            this.cbbProjectID.Enabled = false;
            this.cbbStage.Enabled = false;
            this.txtEdtTask.Enabled = false;
            this.cbbEmployee.Enabled = false;
            this.rchTxtBxTaskDescription.ReadOnly = true;
            this.dtEdtStartDate.ReadOnly = true;
            this.dtEdtEndDate.ReadOnly = true;
            this.cbbTaskType.Enabled = false;
            this.cbbApprover.Enabled = false;
            this.cbbAttachFile.Enabled = false;
            this.txtEdtProgress.ReadOnly = true;
            this.txtEdtStatus.ReadOnly = true;
            this.txtEdtFinishDate.ReadOnly = true;
            this.txtEdtTimeDelay.ReadOnly = true;
            this.txtEdtNote.ReadOnly = true;

            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnRemove.Enabled = false;
        }

        private void checkEnableEdit(string projectID, string stage, string task)
        {
            TaskCreatingDTO taskCreatingDTOLocal = TaskCreatingDAO.Instance.getDataObjectFollowProjectIDAndStageAndTask(projectID, stage, task);

            if (taskCreatingDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnSave.Enabled = false;
                return;
            }

            if (taskCreatingDTOLocal.Empty())
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSave.Enabled = false;
                return;
            }

            if (taskCreatingDTOLocal.Status == StaticVarClass.status_Complete)
            {
                this.btnSave.Enabled = false;
                return;
            }

            if (DateTime.Parse(taskCreatingDTOLocal.StartDate) > DateTime.Now)
            {
                //
                this.cbbEmployee.Enabled = true;
                this.dtEdtStartDate.ReadOnly = false;
                this.dtEdtEndDate.ReadOnly = false;
            }

            if (taskCreatingDTOLocal.Status == StaticVarClass.status_NotComplete)
            {
                this.dtEdtEndDate.ReadOnly = false; // gia hạn end date.
            }

            if (taskCreatingDTOLocal.Status == StaticVarClass.status_NotComplete || taskCreatingDTOLocal.Status == StaticVarClass.status_Overdue)
            {
                // not complete
                if (taskCreatingDTOLocal.TaskType == StaticVarClass.type_Normal)
                    this.cbbTaskType.Enabled = true;
                this.cbbAttachFile.Enabled = true;
                this.rchTxtBxTaskDescription.ReadOnly = false;
            }

            if (taskCreatingDTOLocal.Status != StaticVarClass.status_Complete)
            {
                // always
                this.txtEdtTask.Enabled = true;
                if (taskCreatingDTOLocal.TaskType == StaticVarClass.type_AdminApproval)
                    this.cbbApprover.Enabled = true;
            }
        }

        // Load danh sách các mã dự án đang có.
        private void loadProjectID()
        {
            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();

            DataTable dtLocal = ProjectDAO.Instance.getDataProjectIDForFormTaskCreating();

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string projectID = row["PROJECTID"].ToString();
                    row["PROJECTID"] = projectID.Trim();
                }

                this.cbbProjectID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbProjectID.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbProjectID.DataSource = dtLocal;

                this.cbbProjectID.DisplayMember = "PROJECTID";

                if (this.i_FlagGlobal == 2 && str_ProjectIDLocal != string.Empty)
                    this.cbbProjectID.SelectedIndex = this.cbbProjectID.FindString(str_ProjectIDLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load danh sách các giai đoạn trong một dự án.
        private void loadStage(string projectID)
        {
            string str_StageLocal = this.cbbStage.Text.Trim();

            DataTable dtLocal = StageDAO.Instance.getDataStageFollowProjectIDForFormTaskCreating(projectID);

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string stage = row["STAGE"].ToString();
                    row["STAGE"] = stage.Trim();
                }

                this.cbbStage.DataSource = dtLocal;
                this.cbbStage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbStage.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbStage.DisplayMember = "STAGE";

                if (this.i_FlagGlobal == 2 && str_StageLocal != string.Empty)
                    this.cbbStage.SelectedIndex = this.cbbStage.FindString(str_StageLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load tất cả các mã nhân viên trong công ty.
        private void loadEmployee()
        {
            string str_EmployeeLocal = this.cbbEmployee.Text.Trim();

            DataTable dtLocal = EmployeeDAO.Instance.getDataNotAllColumnsAndWorking();

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string name = row["NAME"].ToString();
                    row["NAME"] = name.Trim();
                }

                this.cbbEmployee.DataSource = dtLocal;
                this.cbbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbEmployee.DisplayMember = "NAME";

                if (this.i_FlagGlobal == 2 && str_EmployeeLocal != string.Empty)
                    this.cbbEmployee.SelectedIndex = this.cbbEmployee.FindString(str_EmployeeLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load các loại task.
        private void loadTaskType(string projectType, string employee)
        {
            //ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(projectID);

            //if (projectDTOLocal == null)
            //{
            //    XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            this.cbbTaskType.Items.Clear();
            this.cbbTaskType.Items.AddRange(new object[] {
            StaticVarClass.type_Normal,
            StaticVarClass.type_AdminApproval,
            });

            this.cbbTaskType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbTaskType.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.i_FlagGlobal != 0 && projectType == StaticVarClass.type_AdminApproval)
            {
                this.cbbTaskType.SelectedIndex = 1;
                this.cbbTaskType.Enabled = false;
                this.cbbApprover.Enabled = true;
                this.loadApprover(employee);
            }
            else if (this.i_FlagGlobal == 1 && (projectType == StaticVarClass.type_Normal || projectType == string.Empty))
            {
                this.cbbTaskType.SelectedIndex = 0;
                this.cbbTaskType.Enabled = true;
                this.cbbApprover.Enabled = false;
            }
        }

        // Load tất cả các mã nhân viên trong công ty.
        private void loadApprover(string employee)
        {
            string str_Approver = this.cbbApprover.Text.Trim();
            //string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();

            DataTable dtLocal = EmployeeDAO.Instance.getDataApprover(employee);

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string name = row["NAME"].ToString();
                    row["NAME"] = name.Trim();
                }

                DataRow rowTemp = dtLocal.NewRow();
                rowTemp["NAME"] = "Admin";
                dtLocal.Rows.Add(rowTemp);

                this.cbbApprover.DataSource = dtLocal;
                this.cbbApprover.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbApprover.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbApprover.DisplayMember = "NAME";

                if (this.i_FlagGlobal == 2 && str_Approver != string.Empty)
                    this.cbbApprover.SelectedIndex = this.cbbApprover.FindString(str_Approver);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load yes/ no.
        private void loadAttachFile()
        {
            string str_AttachFileLocal = this.cbbAttachFile.Text.Trim();

            this.cbbAttachFile.Items.Clear();
            this.cbbAttachFile.Items.AddRange(new object[] {
            StaticVarClass.attachFile_Yes,
            StaticVarClass.attachFile_No,
            });

            this.cbbAttachFile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbAttachFile.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.i_FlagGlobal == 1)
                this.cbbAttachFile.SelectedIndex = 0;

            if (this.i_FlagGlobal == 2 && str_AttachFileLocal != string.Empty)
                this.cbbAttachFile.SelectedIndex = this.cbbAttachFile.FindString(str_AttachFileLocal);
        }

        private void loadDate(string projectStartDate)
        {
            this.dtEdtStartDate.DateTime = DateTime.Parse(projectStartDate);
            this.dtEdtEndDate.DateTime = DateTime.Parse(projectStartDate).AddDays(1);
        }

        // Load các combobox.
        private void loadControl()
        {
            //this.notBinding();
            if (this.i_FlagGlobal == 2)
                this.binding();

            this.loadProjectID();
            this.loadEmployee();
            this.loadAttachFile();

            if (this.i_FlagGlobal == 2)
            {
                this.loadStage(this.cbbProjectID.Text.Trim());
                this.loadTaskType(this.cbbProjectID.Text.Trim(), this.cbbEmployee.Text.Trim());
            }
        }

        // Xóa trước khi thêm.
        private void clearData()
        {
            this.cbbProjectID.Text = string.Empty;
            this.cbbStage.Text = string.Empty;
            this.txtEdtTask.Text = string.Empty;
            this.cbbEmployee.Text = string.Empty;
            this.rchTxtBxTaskDescription.Text = string.Empty;
            this.dtEdtStartDate.DateTime = DateTime.Now;
            this.dtEdtEndDate.DateTime = DateTime.Now.AddDays(1);
            this.cbbTaskType.Text = string.Empty;
            this.cbbApprover.Text = string.Empty;
            this.cbbAttachFile.Text = string.Empty;
            this.txtEdtProgress.Text = "0";
            this.txtEdtStatus.Text = StaticVarClass.status_NotComplete;
            this.txtEdtFinishDate.Text = string.Empty;
            this.txtEdtTimeDelay.Text = "0";
            this.txtEdtNote.Text = string.Empty;
        }

        // Gán dữ liệu.
        private void setData(TaskCreatingDTO taskCreatingDTO)
        {
            taskCreatingDTO.ProjectID = this.cbbProjectID.Text.Trim();
            taskCreatingDTO.Stage = this.cbbStage.Text.Trim();

            if (this.i_FlagGlobal == 1)
                taskCreatingDTO.Task = this.txtEdtTask.Text.Trim();
            else if (this.i_FlagGlobal == 2)
                taskCreatingDTO.Task = this.str_OldTaskForUpdateGlobal;

            if (this.cbbEmployee.Text.Trim() == string.Empty)
                taskCreatingDTO.Employee = null;
            else
                taskCreatingDTO.Employee = this.cbbEmployee.Text.Trim();

            taskCreatingDTO.TaskDescription = this.rchTxtBxTaskDescription.Text.Trim();

            if (this.dtEdtStartDate.Text.Trim() == string.Empty)
                taskCreatingDTO.StartDate = null;
            else
                taskCreatingDTO.StartDate = this.dtEdtStartDate.Text.Trim();

            if (this.dtEdtEndDate.Text.Trim() == string.Empty)
                taskCreatingDTO.EndDate = null;
            else
                taskCreatingDTO.EndDate = this.dtEdtEndDate.Text.Trim();

            taskCreatingDTO.TaskType = this.cbbTaskType.Text.Trim();

            if (this.cbbApprover.Text.Trim() == "Admin")
                taskCreatingDTO.Approver = null;
            else
                taskCreatingDTO.Approver = this.cbbApprover.Text.Trim();

            taskCreatingDTO.AttachFile = this.cbbAttachFile.Text.Trim();
            taskCreatingDTO.Progress = this.txtEdtProgress.Text.Trim();
            taskCreatingDTO.Status = this.txtEdtStatus.Text.Trim();

            if (this.txtEdtFinishDate.Text.Trim() == string.Empty)
                taskCreatingDTO.FinishDate = null;
            else
                taskCreatingDTO.FinishDate = this.txtEdtFinishDate.Text.Trim();

            taskCreatingDTO.TimeDelay = this.txtEdtTimeDelay.Text.Trim();
            taskCreatingDTO.Note = this.txtEdtNote.Text.Trim();
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        private void formTaskCreating_Load(object sender, EventArgs e)
        {
            // Đặt lại cờ.
            this.i_FlagGlobal = 0;

            this.lyoutControlTaskCreating.Hide();

            this.loadData();

            // Phân quyền.
            this.Authorize();
        }

        private void formTaskCreating_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.i_FlagGlobal = 1;

            this.lyoutControlTaskCreating.Show();

            this.clearData();
            this.disable(true);  // Điều khiển các nút.
            this.loadControl();
            this.btnSave.Enabled = false;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Data.DataRow dtR_RowLocal = grvTaskCreating.GetDataRow(grvTaskCreating.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_RowLocal[0].ToString().Trim();
            string str_StageLocal = dtR_RowLocal[1].ToString().Trim();
            string str_TaskLocal = dtR_RowLocal[2].ToString().Trim();
            this.str_OldTaskForUpdateGlobal = str_TaskLocal;
            this.str_OldEndDateGlobal = dtR_RowLocal[6].ToString().Trim();

            this.lyoutControlTaskCreating.Show();

            this.i_FlagGlobal = 2;

            this.disable(true); // Điều khiển các nút.
            this.loadControl();
            this.btnSave.Enabled = true; // bật lên vì text change làm tắt.
            this.checkEnableEdit(str_ProjectIDLocal, str_StageLocal, str_TaskLocal);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaskCreatingDTO taskCreatingDTOLocal = new TaskCreatingDTO();

            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.Text.Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim(); // tên task mới (nếu có)
            string str_EmployeeLocal = this.cbbEmployee.Text.Trim();

            if (str_TaskLocal == string.Empty)
                str_TaskLocal = null;

            // Gán giá trị vào thuộc tính trong bảng.
            this.setData(taskCreatingDTOLocal);

            #region Kiểm tra start date.
            string str_ProjectID = this.cbbProjectID.Text.Trim();
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectID);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectDTOLocal.Empty())
                return;

            if ((DateTime.Parse(taskCreatingDTOLocal.StartDate) < DateTime.Parse(projectDTOLocal.StartDate))
                || (DateTime.Parse(taskCreatingDTOLocal.StartDate) >= (DateTime.Parse(taskCreatingDTOLocal.EndDate))))
            {
                XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtStartDate.DateTime = DateTime.Parse(projectDTOLocal.StartDate);
                return;
            }
            #endregion

            #region Kiểm tra end date.
            if ((DateTime.Parse(taskCreatingDTOLocal.EndDate) > DateTime.Parse(projectDTOLocal.EndDate))
                || (DateTime.Parse(taskCreatingDTOLocal.EndDate) <= (DateTime.Parse(taskCreatingDTOLocal.StartDate))))
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = DateTime.Parse(projectDTOLocal.EndDate);
                return;
            }
            #endregion

            #region Thêm.
            if (this.i_FlagGlobal == 1)
            {
                // Thêm mới.
                if (TaskCreatingDAO.Instance.addData(taskCreatingDTOLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task + " for employee " + str_EmployeeLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully added project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task + " for employee " + str_EmployeeLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task + " for employee " + str_EmployeeLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Add project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task + " for employee " + str_EmployeeLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            #region Sửa.
            else if (this.i_FlagGlobal == 2)
            {
                if (TaskCreatingDAO.Instance.updateData(taskCreatingDTOLocal, str_TaskLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully edited project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Edit project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + taskCreatingDTOLocal.Task + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            formTaskCreating_Load(sender, e);
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Data.DataRow dtR_RowLocal = grvTaskCreating.GetDataRow(grvTaskCreating.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_RowLocal[0].ToString().Trim();
            string str_StageLocal = dtR_RowLocal[1].ToString().Trim();
            string str_TaskLocal = dtR_RowLocal[2].ToString().Trim();

            #region Nếu project đã complete thì ko đc xóa task.
            string str_StatusProjectLocal = ProjectDAO.Instance.getStringStatusFollowProjectID(str_ProjectIDLocal);

            if (str_StatusProjectLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (str_StatusProjectLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_StatusProjectLocal == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot remove task because project " + str_ProjectIDLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Nếu project - stage đã complete thì ko được xóa task.
            string str_StatusStageLocal = StageDAO.Instance.getStringStatusFollowProjectIDAndStage(str_ProjectIDLocal, str_StageLocal);

            if (str_StatusStageLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (str_StatusStageLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_StatusStageLocal == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot remove task because project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Nếu project - stage - task đã complete thì ko đc xóa task.
            string str_StatusTaskLocal = TaskCreatingDAO.Instance.getStringStatusFollowAllPrimaryKeys(str_ProjectIDLocal, str_StageLocal, str_TaskLocal);

            if (str_StatusTaskLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (str_StatusTaskLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_StatusTaskLocal == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot remove task because project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            #region Lấy ra các chỉ số để xem xét việc xóa task.
            int i_RuleLocal = TaskCreatingDAO.Instance.getIntWarningWhenRemovingTask(str_ProjectIDLocal, str_StageLocal, str_TaskLocal);
            string str_Message = string.Empty;

            switch (i_RuleLocal)
            {
                case -1:
                    DialogResult dr = XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 1:
                    str_Message = "Warning: If you remove project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + ", you will not be able to add any tasks in this project - stage. \nAre you sure you want to remove?";
                    break;
                case 0:
                case 2:
                    str_Message = "Are you sure you want to remove project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + "?";
                    break;
            }
            #endregion

            DialogResult drLocal = XtraMessageBox.Show(str_Message, "Comfirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (drLocal == DialogResult.Yes)
            {
                // Xóa.
                if (TaskCreatingDAO.Instance.deleteData(str_ProjectIDLocal, str_StageLocal, str_TaskLocal))
                {

                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully removed project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region update status stage.
                    TaskCreatingDTO taskCreatingDTOTemp = TaskCreatingDAO.Instance.getDataObjectForUpdateWhenRemovingTask(str_ProjectIDLocal, str_StageLocal);

                    if (taskCreatingDTOTemp.Empty() == false && taskCreatingDTOTemp != null)
                    {
                        if (!TaskCreatingDAO.Instance.updateDataForStatusAndProgress(taskCreatingDTOTemp.ProjectID, taskCreatingDTOTemp.Stage, taskCreatingDTOTemp.Task, taskCreatingDTOTemp.Status, taskCreatingDTOTemp.Progress))
                        {
                            XtraMessageBox.Show("Update status of project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Remove project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }

            formTaskCreating_Load(sender, e);
        }

        private void dtEdtStartDate_Leave(object sender, EventArgs e)
        {
            string str_ProjectID = this.cbbProjectID.Text.Trim();
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectID);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectDTOLocal.Empty())
                return;

            if (this.i_FlagGlobal != 0 && ((this.dtEdtStartDate.DateTime < DateTime.Parse(projectDTOLocal.StartDate))
                || (this.dtEdtStartDate.DateTime >= this.dtEdtEndDate.DateTime)))
            {
                XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtStartDate.DateTime = DateTime.Parse(projectDTOLocal.StartDate);
            }
        }

        private void dtEdtEndDate_Leave(object sender, EventArgs e)
        {
            string str_ProjectID = this.cbbProjectID.Text.Trim();
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectID);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectDTOLocal.Empty())
                return;

            if (this.i_FlagGlobal != 0 && ((this.dtEdtEndDate.DateTime > DateTime.Parse(projectDTOLocal.EndDate))
                || (this.dtEdtEndDate.DateTime <= this.dtEdtStartDate.DateTime)))
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = DateTime.Parse(projectDTOLocal.EndDate);
            }
        }

        private void cbbProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = string.Empty;
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = string.Empty;
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty)
            {
                ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectIDLocal);

                if (projectDTOLocal == null)
                {
                    XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //if (this.cbbStage.Text.Trim() != string.Empty)
                //    this.cbbStage.Text = string.Empty;

                this.loadTaskType(projectDTOLocal.ProjectType, str_EmployeeLocal);
                this.loadStage(str_ProjectIDLocal);
                this.loadDate(projectDTOLocal.StartDate);

                str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
                str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();

                if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
                {
                    if (str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                        && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                        && str_AttachFileLocal != string.Empty)
                    {
                        this.btnSave.Enabled = true;
                    }
                }

                if (str_TaskTypeLocal == StaticVarClass.type_Normal)
                {
                    if (str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                        && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                    {
                        this.btnSave.Enabled = true;
                    }
                }
            }
            else if (this.i_FlagGlobal == 1 && str_ProjectIDLocal == string.Empty)
            {
                this.loadStage(str_ProjectIDLocal);
                this.loadTaskType(string.Empty, str_EmployeeLocal);
                this.btnSave.Enabled = false;
            }
        }

        private void cbbProjectID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectProjectIDGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = string.Empty;
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = string.Empty;
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty)
            {
                ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectIDLocal);

                if (projectDTOLocal == null)
                {
                    XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //if (this.cbbStage.Text.Trim() != string.Empty)
                //    this.cbbStage.Text = string.Empty;

                this.loadTaskType(projectDTOLocal.ProjectType, str_EmployeeLocal);
                this.loadStage(str_ProjectIDLocal);
                this.loadDate(projectDTOLocal.StartDate);

                str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
                str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();

                if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
                {
                    if (str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                        && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                        && str_AttachFileLocal != string.Empty)
                    {
                        this.btnSave.Enabled = true;
                    }
                }

                if (str_TaskTypeLocal == StaticVarClass.type_Normal)
                {
                    if (str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                        && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                    {
                        this.btnSave.Enabled = true;
                    }
                }
            }
            else if (this.i_FlagGlobal == 1 && str_ProjectIDLocal == string.Empty)
            {
                this.loadStage(str_ProjectIDLocal);
                this.loadTaskType(string.Empty, str_EmployeeLocal);
                this.btnSave.Enabled = false;
            }
        }

        private void cbbProjectID_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectProjectIDGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectProjectIDGlobal = false;
        }

        private void cbbProjectID_DropDown(object sender, EventArgs e)
        {
            this.cbbProjectID.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbProjectID.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbProjectID_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbProjectID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbProjectID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal == 1 && str_StageLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectStageGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal == 1 && str_StageLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbStage_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectStageGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectStageGlobal = false;
        }

        private void cbbStage_DropDown(object sender, EventArgs e)
        {
            this.cbbStage.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbStage.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbStage_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbStage.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbStage.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtEdtTask_EditValueChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal == 1 && str_TaskLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_EmployeeLocal != string.Empty)
                {
                    this.loadApprover(str_EmployeeLocal);
                    this.cbbApprover.Enabled = true;
                    str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
                }

                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal != 0 && str_EmployeeLocal == string.Empty)
            {
                if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
                {
                    //this.cbbApprover.Text = string.Empty;
                    this.loadApprover(str_EmployeeLocal);
                }
                this.btnSave.Enabled = false;
            }
        }

        private void cbbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectEmployeeGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_EmployeeLocal != string.Empty)
                {
                    this.loadApprover(str_EmployeeLocal); // phải lấy employee bằng getItemText..., lấy bằng .Text.Trim() sai.
                    this.cbbApprover.Enabled = true;
                    str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
                }

                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal != 0 && str_EmployeeLocal == string.Empty)
            {
                if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
                {
                    //this.cbbApprover.Text = string.Empty;
                    this.loadApprover(str_EmployeeLocal);
                }
                this.btnSave.Enabled = false;
            }
        }

        private void cbbEmployee_TextChanged(object sender, EventArgs e)
        {
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_EmployeeLocal = this.cbbEmployee.Text.Trim();

            if (this.b_IsSelectEmployeeGlobal == false)
            {
                if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
                {
                    //this.cbbApprover.Text = string.Empty;
                    this.loadApprover(str_EmployeeLocal);
                }
                this.btnSave.Enabled = false;
            }
            else
                this.b_IsSelectEmployeeGlobal = false;
        }

        private void cbbEmployee_DropDown(object sender, EventArgs e)
        {
            this.cbbEmployee.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbEmployee.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbEmployee_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = string.Empty;
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_EmployeeLocal != string.Empty)
                {
                    //if (this.cbbApprover.Text.Trim() != string.Empty)
                    //    this.cbbApprover.Text = string.Empty;

                    this.loadApprover(str_EmployeeLocal);
                    this.cbbApprover.Enabled = true;
                    str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
                }

                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;

                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal != 0 && str_TaskTypeLocal == string.Empty)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;
                this.btnSave.Enabled = false;
            }
        }

        private void cbbTaskType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectTaskTypeGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = string.Empty;
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_EmployeeLocal != string.Empty)
                {
                    //if (this.cbbApprover.Text.Trim() != string.Empty)
                    //    this.cbbApprover.Text = string.Empty;

                    this.loadApprover(str_EmployeeLocal);
                    this.cbbApprover.Enabled = true;
                    str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
                }

                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;

                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal != 0 && str_TaskTypeLocal == string.Empty)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;
                this.btnSave.Enabled = false;
            }
        }

        private void cbbTaskType_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectTaskTypeGlobal == false)
            {
                if (this.i_FlagGlobal != 0)
                {
                    this.cbbApprover.Text = string.Empty;
                    this.cbbApprover.Enabled = false;
                    this.btnSave.Enabled = false;
                }
            }
            else
                this.b_IsSelectTaskTypeGlobal = false;
        }

        private void cbbTaskType_DropDown(object sender, EventArgs e)
        {
            this.cbbTaskType.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbTaskType.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbTaskType_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbTaskType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbTaskType.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbApprover_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_TaskTypeLocal != string.Empty
                  && str_ApproverLocal != string.Empty && str_AttachFileLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_ApproverLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbApprover_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectApproverGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_TaskTypeLocal != string.Empty
                  && str_ApproverLocal != string.Empty && str_AttachFileLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_ApproverLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbApprover_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectApproverGlobal == false)
            {
                this.btnSave.Enabled = false;
            }
            else
                this.b_IsSelectApproverGlobal = false;
        }

        private void cbbApprover_DropDown(object sender, EventArgs e)
        {
            this.cbbApprover.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbApprover.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbApprover_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbApprover.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbApprover.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbAttachFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                   && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal != 0 && str_AttachFileLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbAttachFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectAttachFileGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.txtEdtTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                   && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (this.i_FlagGlobal != 0 && str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (this.i_FlagGlobal != 0 && str_AttachFileLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbAttachFile_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectAttachFileGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectAttachFileGlobal = false;
        }

        private void cbbAttachFile_DropDown(object sender, EventArgs e)
        {
            this.cbbAttachFile.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbAttachFile.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbAttachFile_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbAttachFile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbAttachFile.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbProjectID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbStage.Select();
            }
        }

        private void cbbStage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtTask.Focus();
            }
        }

        private void txtEdtTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbEmployee.Select();
            }
        }

        private void cbbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.rchTxtBxTaskDescription.Focus();
            }
        }

        private void rchTxtBxTaskDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEdtStartDate.Select();
            }
        }

        private void dtEdtStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEdtEndDate.Select();
            }
        }

        private void dtEdtEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbTaskType.Select();
            }
        }

        private void cbbTaskType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbApprover.Select();
            }
        }

        private void cbbApprover_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbAttachFile.Select();
            }
        }

        private void cbbAttachFile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.i_FlagGlobal == 1)
                    this.cbbProjectID.Select();
                if (this.i_FlagGlobal == 2)
                    this.txtEdtTask.Focus();
            }
        }

        private void formTaskCreating_KeyUp(object sender, KeyEventArgs e)
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
                    if (this.btnEdit.Enabled == true)
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
            this.formTaskCreating_Load(sender, e);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formTaskCreating = null;

            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formTaskCreating_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formTaskCreating = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}