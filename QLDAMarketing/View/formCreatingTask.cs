using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectManagement.DAO;
using ProjectManagement.CO;
using ProjectManagement.DTO;

namespace ProjectManagement.View
{
    public partial class formCreatingTask : DevExpress.XtraEditors.XtraForm
    {
        #region Các cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectProjectIDGlobal = false;

        bool b_IsSelectStageGlobal = false;

        bool b_IsSelectEmployeeGlobal = false;

        bool b_IsSelectTaskTypeGlobal = false;

        bool b_IsSelectApproverGlobal = false;

        bool b_IsSelectAttachFileGlobal = false;
        #endregion

        string str_ProjectIDGlobal = string.Empty;

        public formCreatingTask()
        {
            InitializeComponent();
            lyoutControlTaskCreating.OptionsFocus.EnableAutoTabOrder = false;
            this.btnDone.Enabled = false;
        }

        private void enableControl()
        {
            this.btnOK.Enabled = false;

            this.txtEdtProjectID.ReadOnly = true;
        }

        // Xóa trước khi thêm.
        private void clearData()
        {
            this.txtEdtProjectID.Text = string.Empty;
            this.cbbStage.Text = string.Empty;
            this.rchTxtBxTask.Text = string.Empty;
            this.cbbEmployee.Text = string.Empty;
            this.rchTxtBxTaskDescription.Text = string.Empty;
            this.dtEdtStartDate.DateTime = DateTime.Now;
            this.dtEdtEndDate.DateTime = DateTime.Now.AddDays(1);
            this.cbbTaskType.Text = string.Empty;
            this.cbbApprover.Text = string.Empty;
            this.cbbAttachFile.Text = string.Empty;
        }

        public void setInfo(string projectID)
        {
            this.str_ProjectIDGlobal = projectID;
        }

        // Load danh sách các mã dự án đang có.
        private void loadProjectID()
        {
            this.txtEdtProjectID.Text = str_ProjectIDGlobal;

        }

        // Load danh sách các giai đoạn trong một dự án.
        private void loadStage()
        {
            DataTable dtLocal = StageDAO.Instance.getDataStageFollowProjectIDForFormTaskCreating(str_ProjectIDGlobal);

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
                this.cbbEmployee.SelectedIndex = 0;
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load các loại task.
        private void loadTaskType(string employee)
        {
            // Lấy 
            string stringTypeProject = ProjectDAO.Instance.getStringTypeProjectFollowProjectID(this.str_ProjectIDGlobal);

            if (stringTypeProject == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.cbbTaskType.Items.Clear();
            this.cbbTaskType.Items.AddRange(new object[] {
            StaticVarClass.type_Normal,
            StaticVarClass.type_AdminApproval,
            });

            this.cbbTaskType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbTaskType.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (stringTypeProject == StaticVarClass.type_AdminApproval)
            {
                this.cbbTaskType.SelectedIndex = 1;
                this.cbbTaskType.Enabled = false;
                this.cbbApprover.Enabled = true;
                this.loadApprover(employee);
            }
            else if ((stringTypeProject == StaticVarClass.type_Normal || stringTypeProject == string.Empty))
            {
                this.cbbTaskType.SelectedIndex = 0;
                this.cbbTaskType.Enabled = true;
                this.cbbApprover.Enabled = false;
            }
        }

        // Load tất cả các mã nhân viên trong công ty.
        private void loadApprover(string employee)
        {
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
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load yes/ no.
        private void loadAttachFile()
        {
            this.cbbAttachFile.Items.Clear();
            this.cbbAttachFile.Items.AddRange(new object[] {
            StaticVarClass.attachFile_Yes,
            StaticVarClass.attachFile_No,
            });

            this.cbbAttachFile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbAttachFile.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbbAttachFile.SelectedIndex = 0;
        }

        private void loadDate()
        {
            string str_ProjectID = this.txtEdtProjectID.Text.Trim();
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectID);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectDTOLocal.Empty())
                return;

            this.dtEdtStartDate.DateTime = DateTime.Parse(projectDTOLocal.StartDate);
            this.dtEdtEndDate.DateTime = DateTime.Parse(projectDTOLocal.StartDate).AddDays(1);
        }

        // Load các combobox.
        private void loadControl()
        {
            this.loadProjectID();
            this.loadEmployee();
            this.loadStage();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            this.loadTaskType(str_EmployeeLocal);
            this.loadAttachFile();
            this.loadDate();
        }

        // Gán dữ liệu.
        private void setData(TaskCreatingDTO taskCreatingDTO)
        {
            taskCreatingDTO.ProjectID = this.txtEdtProjectID.Text.Trim();
            taskCreatingDTO.Stage = this.cbbStage.Text.Trim();
            taskCreatingDTO.Task = this.rchTxtBxTask.Text.Trim();

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

            if (this.cbbApprover.Text.Trim() == "Admin" || this.cbbApprover.Text.Trim() == string.Empty)
                taskCreatingDTO.Approver = null;
            else
                taskCreatingDTO.Approver = this.cbbApprover.Text.Trim();

            taskCreatingDTO.AttachFile = this.cbbAttachFile.Text.Trim();

            taskCreatingDTO.Progress = "0";
            taskCreatingDTO.Status = StaticVarClass.status_NotComplete;
            taskCreatingDTO.FinishDate = null;
            taskCreatingDTO.TimeDelay = "0";
            taskCreatingDTO.Note = string.Empty;
        }

        private void formCreatingTask_Load(object sender, EventArgs e)
        {
            this.clearData();
            this.loadControl();
            this.enableControl();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (this.btnDone.Enabled == true)
            {
                formProjectCreating frmProjectCreating = formProjectCreating.Instance;
                frmProjectCreating.Close();

                formProjectCreating.Instance = null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TaskCreatingDTO taskCreatingDTOLocal = new TaskCreatingDTO();

            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.Text.Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.Text.Trim();

            if (str_TaskLocal == string.Empty)
                str_TaskLocal = null;

            // Gán giá trị vào thuộc tính trong bảng.
            this.setData(taskCreatingDTOLocal);

            #region Kiểm tra start date.
            string str_ProjectID = this.txtEdtProjectID.Text.Trim();
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

            // Thêm mới.
            if (TaskCreatingDAO.Instance.addData(taskCreatingDTOLocal))
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Add project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal;
                string status = "Successful";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                this.btnDone.Enabled = true;

                XtraMessageBox.Show("Successfully added project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Add project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal;
                string status = "Failed";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Add project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            #endregion

            this.formCreatingTask_Load(null, null);
        }

        private void dtEdtStartDate_Leave(object sender, EventArgs e)
        {
            string str_ProjectID = this.txtEdtProjectID.Text.Trim();
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectID);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectDTOLocal.Empty())
                return;

            if ((this.dtEdtStartDate.DateTime < DateTime.Parse(projectDTOLocal.StartDate))
                || (this.dtEdtStartDate.DateTime >= this.dtEdtEndDate.DateTime))
            {
                XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtStartDate.DateTime = DateTime.Parse(projectDTOLocal.StartDate);
            }
        }

        private void dtEdtEndDate_Leave(object sender, EventArgs e)
        {
            string str_ProjectID = this.txtEdtProjectID.Text.Trim();
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectID);

            if (projectDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectDTOLocal.Empty())
                return;

            if ((this.dtEdtEndDate.DateTime > DateTime.Parse(projectDTOLocal.EndDate))
                || (this.dtEdtEndDate.DateTime <= this.dtEdtStartDate.DateTime))
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = DateTime.Parse(projectDTOLocal.EndDate);
            }
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

        private void cbbStage_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_StageLocal == string.Empty)
            {
                this.btnOK.Enabled = false;
            }
        }

        private void cbbStage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectStageGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_StageLocal == string.Empty)
            {
                this.btnOK.Enabled = false;
            }
        }

        private void cbbStage_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectStageGlobal == false)
                this.btnOK.Enabled = false;
            else
                this.b_IsSelectStageGlobal = false;
        }

        private void rchTxtBxTask_TextChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskLocal == string.Empty)
            {
                this.btnOK.Enabled = false;
            }
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

        private void cbbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
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

                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_EmployeeLocal == string.Empty)
            {
                if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
                {
                    this.loadApprover(str_EmployeeLocal);
                }
                this.btnOK.Enabled = false;
            }
        }

        private void cbbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectEmployeeGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
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

                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_ProjectIDLocal != string.Empty
                    && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                    && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_EmployeeLocal == string.Empty)
            {
                if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
                {
                    //this.cbbApprover.Text = string.Empty;
                    this.loadApprover(str_EmployeeLocal);
                }
                this.btnOK.Enabled = false;
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
                    this.loadApprover(str_EmployeeLocal);
                }
                this.btnOK.Enabled = false;
            }
            else
                this.b_IsSelectEmployeeGlobal = false;
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

        private void cbbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
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

                if (str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;

                if (str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == string.Empty)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;
                this.btnOK.Enabled = false;
            }
        }

        private void cbbTaskType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectTaskTypeGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
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

                if (str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;

                if (str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == string.Empty)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;
                this.btnOK.Enabled = false;
            }
        }

        private void cbbTaskType_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectTaskTypeGlobal == false)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;
                this.btnOK.Enabled = false;
            }
            else
                this.b_IsSelectTaskTypeGlobal = false;
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

        private void cbbApprover_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_TaskTypeLocal != string.Empty
                  && str_ApproverLocal != string.Empty && str_AttachFileLocal != string.Empty)
            {
                this.btnOK.Enabled = true;
            }
            else if (str_ApproverLocal == string.Empty)
            {
                this.btnOK.Enabled = false;
            }
        }

        private void cbbApprover_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectApproverGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty
                  && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                  && str_EmployeeLocal != string.Empty && str_TaskTypeLocal != string.Empty
                  && str_ApproverLocal != string.Empty && str_AttachFileLocal != string.Empty)
            {
                this.btnOK.Enabled = true;
            }
            else if (str_ApproverLocal == string.Empty)
            {
                this.btnOK.Enabled = false;
            }
        }

        private void cbbApprover_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectApproverGlobal == false)
            {
                this.btnOK.Enabled = false;
            }
            else
                this.b_IsSelectApproverGlobal = false;
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

        private void cbbAttachFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                   && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_AttachFileLocal == string.Empty)
            {
                this.btnOK.Enabled = false;
            }
        }

        private void cbbAttachFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectAttachFileGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.cbbStage.GetItemText(this.cbbStage.SelectedItem).Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                   && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_ProjectIDLocal != string.Empty
                   && str_StageLocal != string.Empty && str_TaskLocal != string.Empty
                   && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnOK.Enabled = true;
                }
            }

            if (str_AttachFileLocal == string.Empty)
            {
                this.btnOK.Enabled = false;
            }
        }

        private void cbbAttachFile_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectAttachFileGlobal == false)
                this.btnOK.Enabled = false;
            else
                this.b_IsSelectAttachFileGlobal = false;
        }

        private void cbbStage_KeyDown(object sender, KeyEventArgs e)
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
                this.rchTxtBxTask.Focus();
            }
        }

        private void rchTxtBxTask_KeyDown(object sender, KeyEventArgs e)
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
                this.cbbAttachFile.Select();
            }
        }

        private void cbbAttachFile_KeyDown(object sender, KeyEventArgs e)
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
                if (this.btnOK.Enabled == true)
                    this.btnOK.PerformClick();
                else
                    this.cbbStage.Select();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            formProjectCreating frmProjectCreating = formProjectCreating.Instance;
            formProjectCreating.Instance = null;
            frmProjectCreating.Close();
        }
    }
}