using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectManagement.DTO;
using ProjectManagement.DAO;
using ProjectManagement.CO;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;

namespace ProjectManagement.View
{
    public partial class formAssignTask : DevExpress.XtraEditors.XtraForm
    {
        string str_EmployeeAssignGlobal = string.Empty;
        string str_EmployeeRecieveGlobal = string.Empty;
        string str_ProjectIDGlobal = string.Empty;
        string str_StageGlobal = string.Empty;
        string str_TaskGlobal = string.Empty;
        string str_StartDateGlobal = string.Empty;
        string str_EndDateGlobal = string.Empty;
        string str_StatusGlobal = string.Empty;

        // Cờ xử lí sự kiện chọn value ô combobox Employee: phân biệt textchange.
        bool b_IsSelectEmployeeGlobal = false;

        public formAssignTask()
        {
            InitializeComponent();
            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
        }

        // Load danh sách những người có thể đẩy công việc.
        private void loadEmployee()
        {
            // Lấy danh sách các nhân viên trong các phòng ban của người đó.
            DataTable dtLocal = EmployeeDAO.Instance.getDataForAssigningTask(this.str_EmployeeAssignGlobal);

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
                
                // Kiểm tra có sẵn nhân viên trong combobox không.
                this.str_EmployeeRecieveGlobal = this.cbbEmployee.Text.Trim();
                if (this.str_EmployeeRecieveGlobal == string.Empty)
                {
                    this.btnAssignTask.Enabled = false;
                }
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Hiện thi các thông tin đã có sẵn.
        private void loadInfo()
        {
            this.txtEdtProjectID.Text = this.str_ProjectIDGlobal;
            this.txtEdtStage.Text = this.str_StageGlobal;
            this.rchTxtBxTask.Text = this.str_TaskGlobal;
            this.dtEdtStartDate.DateTime = DateTime.Now.Date;
            this.dtEdtEndDate.DateTime = DateTime.Parse(this.str_EndDateGlobal);

            this.txtEdtProjectID.ReadOnly = true;
            this.txtEdtStage.ReadOnly = true;
            this.rchTxtBxTask.ReadOnly = true;
            this.dtEdtStartDate.ReadOnly = true;
            this.dtEdtEndDate.ReadOnly = true;
        }

        // Kiểm tra status.
        private void checkStatus()
        {
            if (this.str_StatusGlobal == StaticVarClass.status_Overdue)
            {
                this.chkbRenewDuration.Checked = true;
                this.chkbRenewDuration.Enabled = false;
            }
        }

        public void setInformation(string projectID, string stage, string task, string employeeAssign, string startDate, string endDate, string status)
        {
            this.str_ProjectIDGlobal = projectID;
            this.str_StageGlobal = stage;
            this.str_TaskGlobal = task;
            this.str_EmployeeAssignGlobal = employeeAssign;
            this.str_StartDateGlobal = startDate;
            this.str_EndDateGlobal = endDate;
            this.str_StatusGlobal = status;
        }

        // Hiển thị các thông tin đã có sẵn
        private void formAssignTask_Load(object sender, EventArgs e)
        {
            this.loadEmployee();
            this.loadInfo();
            this.checkStatus();
        }

        private void chkbRenewDuration_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkbRenewDuration.Checked == true)
            {
                this.dtEdtStartDate.DateTime = DateTime.Now.Date;
                this.dtEdtEndDate.DateTime = DateTime.Now.Date + DateTime.Parse(this.str_EndDateGlobal).Subtract(DateTime.Parse(this.str_StartDateGlobal));
            }
            else
            {
                this.dtEdtStartDate.DateTime = DateTime.Now.Date;
                this.dtEdtEndDate.DateTime = DateTime.Parse(this.str_EndDateGlobal);
            }
        }

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            this.str_EmployeeRecieveGlobal = this.cbbEmployee.Text.Trim();

            // Lấy ra một task creating.
            TaskCreatingDTO taskCreatingAssignDTOLocal = TaskCreatingDAO.Instance.getDataObjectFollowProjectIDAndStageAndTask(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);

            if (taskCreatingAssignDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (taskCreatingAssignDTOLocal.Empty())
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string str_ProjectIDLocal = this.str_ProjectIDGlobal;
            string str_StageLocal = this.str_StageGlobal;
            string str_TaskLocal = this.str_TaskGlobal;

            // Lấy ra một task assign.
            // Giờ đưa nhiệm vụ này vào bảng nhiệm vụ đã đẩy.
            TaskAssignDTO taskAssignDTO = new TaskAssignDTO(taskCreatingAssignDTOLocal);

            taskAssignDTO.Note += this.str_EmployeeAssignGlobal + " assigned task to " + this.str_EmployeeRecieveGlobal + "; ";

            if (TaskAssignDAO.Instance.addData(taskAssignDTO))
            {
                // Cập nhật thông tin cho người mới được nhận công việc của người cũ.
                if (taskCreatingAssignDTOLocal.Approver == string.Empty)
                    taskCreatingAssignDTOLocal.Approver = null;

                if (this.str_EmployeeRecieveGlobal == string.Empty)
                    taskCreatingAssignDTOLocal.Employee = null;
                else
                    taskCreatingAssignDTOLocal.Employee = this.str_EmployeeRecieveGlobal;

                if (this.dtEdtStartDate.Text.Trim() == string.Empty)
                    taskCreatingAssignDTOLocal.StartDate = null;
                else
                    taskCreatingAssignDTOLocal.StartDate = this.dtEdtStartDate.Text.Trim();

                if (this.dtEdtEndDate.Text.Trim() == string.Empty)
                    taskCreatingAssignDTOLocal.EndDate = null;
                else
                    taskCreatingAssignDTOLocal.EndDate = this.dtEdtEndDate.Text.Trim();

                taskCreatingAssignDTOLocal.Progress = "0";
                taskCreatingAssignDTOLocal.Status = StaticVarClass.status_NotComplete;
                taskCreatingAssignDTOLocal.FinishDate = null;
                taskCreatingAssignDTOLocal.TimeDelay = "0";
                taskCreatingAssignDTOLocal.Note += this.str_EmployeeRecieveGlobal + " recieved task from " + this.str_EmployeeAssignGlobal + "; ";

                if (TaskCreatingDAO.Instance.updateDataForTaskAssign(taskCreatingAssignDTOLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Assign project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " to employee " + str_EmployeeRecieveGlobal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully assigned project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " to employee " + str_EmployeeRecieveGlobal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Assign project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " to employee " + str_EmployeeRecieveGlobal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Assign project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " to employee " + str_EmployeeRecieveGlobal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Assign project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " to employee " + str_EmployeeRecieveGlobal;
                string status = "Failed";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Assign project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " to employee " + str_EmployeeRecieveGlobal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void cbbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_EmployeeLocal = string.Empty;

            str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();

            if (str_EmployeeLocal != string.Empty)
                btnAssignTask.Enabled = true;
            else
                btnAssignTask.Enabled = false;
        }

        private void cbbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectEmployeeGlobal = true;
            string str_EmployeeLocal = string.Empty;

            str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();

            if (str_EmployeeLocal != string.Empty)
                btnAssignTask.Enabled = true;
            else
                btnAssignTask.Enabled = false;
        }

        private void cbbEmployee_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectEmployeeGlobal == false)
                btnAssignTask.Enabled = false;
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

        private void cbbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chkbRenewDuration.Focus();
            }
        }

        private void chkbRenewDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnAssignTask.Enabled == true)
                    this.btnAssignTask.PerformClick();
                else
                    this.cbbEmployee.Select();
            }
        }

        private void formAssignTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
