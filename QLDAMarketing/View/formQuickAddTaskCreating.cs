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
using ProjectManagement.DTO;
using ProjectManagement.CO;

namespace ProjectManagement.View
{
    public partial class formQuickAddTaskCreating : DevExpress.XtraEditors.XtraForm
    {
        string str_ProjectIDGlobal = string.Empty;
        string str_StageGlobal = string.Empty;
        string str_StartDateProjectGlobal = string.Empty;
        string str_EndDateProjectGlobal = string.Empty;
        string str_ProjectTypeGlobal = string.Empty;

        #region Các cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectEmployeeGlobal = false;

        bool b_IsSelectTaskTypeGlobal = false;

        bool b_IsSelectApproverGlobal = false;

        bool b_IsSelectAttachFileGlobal = false;
        #endregion

        public formQuickAddTaskCreating()
        {
            InitializeComponent();
            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
        }

        // Hiện thị các thông tin có sẵn.
        private void loadInfo()
        {
            this.txtEdtProjectID.Text = this.str_ProjectIDGlobal;
            this.txtEdtStage.Text = this.str_StageGlobal;
            this.dtEdtStartDate.DateTime = DateTime.Parse(this.str_StartDateProjectGlobal);
            this.dtEdtEndDate.DateTime = DateTime.Parse(this.str_EndDateProjectGlobal);

            this.loadEmployee();
            this.loadTaskType(this.cbbEmployee.Text.Trim());
            this.loadAttachFile();

            this.txtEdtProjectID.ReadOnly = true;
            this.txtEdtStage.ReadOnly = true;
        }

        public void setInfo(string projectID, string stage, string startDate, string endDate, string projectype)
        {
            this.str_ProjectIDGlobal = projectID;
            this.str_StageGlobal = stage;
            this.str_StartDateProjectGlobal = startDate;
            this.str_EndDateProjectGlobal = endDate;
            this.str_ProjectTypeGlobal = projectype;
        }

        // Load tất cả các mã nhân viên trong công ty.
        private void loadEmployee()
        {
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
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load các loại task.
        private void loadTaskType(string employee)
        {
            this.cbbTaskType.Items.Clear();
            this.cbbTaskType.Items.AddRange(new object[] {
            StaticVarClass.type_Normal,
            StaticVarClass.type_AdminApproval,
            });

            this.cbbTaskType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbTaskType.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.str_ProjectTypeGlobal == StaticVarClass.type_AdminApproval)
            {
                this.cbbTaskType.SelectedIndex = 1;
                this.cbbTaskType.Enabled = false;
                this.cbbApprover.Enabled = true;
                this.loadApprover(employee);
            }
            else if (this.str_ProjectTypeGlobal == StaticVarClass.type_Normal)
            {
                this.cbbTaskType.SelectedIndex = 0;
                this.cbbTaskType.Enabled = true;
                this.cbbApprover.Enabled = false;
            }
        }

        // load các nhân viên có quyền xác nhận.
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

                this.cbbApprover.DataSource = dtLocal;
                this.cbbApprover.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbApprover.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbApprover.DisplayMember = "NAME";
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load các loại task.
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

        private void formQuickAddTask_Load(object sender, EventArgs e)
        {
            this.loadInfo();
        }

        private void dtEdtStartDate_Leave(object sender, EventArgs e)
        {
            if ((this.dtEdtStartDate.DateTime < DateTime.Parse(this.str_StartDateProjectGlobal))
                || (this.dtEdtStartDate.DateTime >= this.dtEdtEndDate.DateTime))
            {
                XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtStartDate.DateTime = DateTime.Parse(this.str_StartDateProjectGlobal);
            }
        }

        private void dtEdtEndDate_Leave(object sender, EventArgs e)
        {
            if ((this.dtEdtEndDate.DateTime > DateTime.Parse(this.str_EndDateProjectGlobal))
                || (this.dtEdtEndDate.DateTime <= this.dtEdtStartDate.DateTime))
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = DateTime.Parse(this.str_EndDateProjectGlobal);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lưu thông tin của task mới vào bảng TASK.
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.txtEdtStage.Text.Trim();
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();

            string str_EmployeeLocal = string.Empty;
            if (this.cbbEmployee.Text.Trim() == string.Empty)
                str_EmployeeLocal = null;
            else
                str_EmployeeLocal = this.cbbEmployee.Text.Trim();

            string str_TaskDescriptionLocal = this.rchTxtBxTaskDescription.Text.Trim();

            string str_StartDateLocal = string.Empty;
            if (this.dtEdtStartDate.Text.Trim() == string.Empty)
                str_StartDateLocal = null;
            else
                str_StartDateLocal = this.dtEdtStartDate.Text.Trim();

            string str_EndDateLocal = string.Empty;
            if (this.dtEdtEndDate.Text.Trim() == string.Empty)
                str_EndDateLocal = null;
            else
                str_EndDateLocal = this.dtEdtEndDate.Text.Trim();

            string str_TaskTypeLocal = this.cbbTaskType.Text.Trim();

            string str_ApproverLocal = string.Empty;
            if (this.cbbApprover.Text.Trim() == string.Empty)
                str_ApproverLocal = null;
            else
                str_ApproverLocal = this.cbbApprover.Text.Trim();

            string str_AttachFileLocal = this.cbbAttachFile.Text.Trim();
            string str_ProgressLocal = "0";
            string str_StatusLocal = StaticVarClass.status_NotComplete;
            string str_FinishDateLocal = null;
            string str_TimeDelayLocal = "0";
            string str_ColorLocal = "Gray";
            string str_NoteLocal = string.Empty;

            TaskCreatingDTO taskCreatingDTOTemp = new TaskCreatingDTO(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_EmployeeLocal,
                str_TaskDescriptionLocal, str_StartDateLocal, str_EndDateLocal, str_TaskTypeLocal, str_ApproverLocal, str_AttachFileLocal, str_ProgressLocal,
                str_StatusLocal, str_FinishDateLocal, str_TimeDelayLocal, str_ColorLocal, str_NoteLocal);

            if (TaskCreatingDAO.Instance.addData(taskCreatingDTOTemp))
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Add project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal;
                string status = "Successful";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

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
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void rchTxtBxTask_TextChanged(object sender, EventArgs e)
        {
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty && (str_ApproverLocal != string.Empty || this.cbbApprover.Text.Trim() == string.Empty)
                    && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_EmployeeLocal != string.Empty)
                {
                    this.loadApprover(str_EmployeeLocal);
                    this.cbbApprover.Enabled = true;
                    str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
                }

                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_EmployeeLocal == string.Empty)
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
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_EmployeeLocal != string.Empty)
                {
                    this.loadApprover(str_EmployeeLocal);
                    this.cbbApprover.Enabled = true;
                    str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
                }

                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty && str_ApproverLocal != string.Empty
                && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_EmployeeLocal == string.Empty)
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
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = string.Empty;
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

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

                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }
            else if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;

                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == string.Empty)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;
                this.btnSave.Enabled = false;
            }
        }

        private void cbbTaskType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectTaskTypeGlobal = true;
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = string.Empty;
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

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

                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }
            else if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;

                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == string.Empty)
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
                this.cbbApprover.Text = string.Empty;
                this.cbbApprover.Enabled = false;
                this.btnSave.Enabled = false;
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
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
              && str_TaskTypeLocal != string.Empty && str_ApproverLocal != string.Empty
              && str_AttachFileLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_ApproverLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbApprover_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectApproverGlobal = true;
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                && str_TaskTypeLocal != string.Empty && str_ApproverLocal != string.Empty
                && str_AttachFileLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_ApproverLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbApprover_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectApproverGlobal == false)
            {
                if (this.cbbApprover.Text.Trim() == string.Empty)
                    this.btnSave.Enabled = true;
                else
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
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_AttachFileLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbAttachFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectAttachFileGlobal = true;
            string str_TaskLocal = this.rchTxtBxTask.Text.Trim();
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            string str_TaskTypeLocal = this.cbbTaskType.GetItemText(this.cbbTaskType.SelectedItem).Trim();
            string str_ApproverLocal = this.cbbApprover.GetItemText(this.cbbApprover.SelectedItem).Trim();
            string str_AttachFileLocal = this.cbbAttachFile.GetItemText(this.cbbAttachFile.SelectedItem).Trim();

            if (str_TaskTypeLocal == StaticVarClass.type_AdminApproval)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_ApproverLocal != string.Empty
                  && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_TaskTypeLocal == StaticVarClass.type_Normal)
            {
                if (str_TaskLocal != string.Empty && str_EmployeeLocal != string.Empty
                  && str_TaskTypeLocal != string.Empty && str_AttachFileLocal != string.Empty)
                {
                    this.btnSave.Enabled = true;
                }
            }

            if (str_AttachFileLocal == string.Empty)
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

        private void rchTxtBxTask_KeyDown(object sender, KeyEventArgs e)
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
                if (this.btnSave.Enabled == true)
                    this.btnSave.PerformClick();
                else
                    this.rchTxtBxTask.Focus();
            }
        }

        private void formQuickAddTaskCreating_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}