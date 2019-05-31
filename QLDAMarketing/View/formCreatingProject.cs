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
    public partial class formCreatingProject : DevExpress.XtraEditors.XtraForm
    {
        public formCreatingProject()
        {
            InitializeComponent();
            lyoutControlProject.OptionsFocus.EnableAutoTabOrder = false;
            this.btnOke.Enabled = false;
        }

        #region Các cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectLeaderGlobal = false;

        bool b_IsSelectProjectTypeGlobal = false;

        bool b_IsSelectPOSMProjectGlobal = false;
        #endregion

        // Load tất cả các mã nhân viên trong công ty.
        private void loadLeader()
        {
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
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load các loại dự án.
        private void loadProjectType()
        {
            this.cbbProjectType.Items.Clear();
            this.cbbProjectType.Items.AddRange(new object[] {
            StaticVarClass.type_Normal,
            StaticVarClass.type_AdminApproval,
            });

            this.cbbProjectType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbProjectType.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbbProjectType.SelectedIndex = 0;
        }

        private void loadPOSMProject()
        {
            this.cbbPOSMProject.Items.Clear();
            this.cbbPOSMProject.Items.AddRange(new object[] {
            StaticVarClass.POSM_NotPOSMProject,
            StaticVarClass.POSM_POSMProject,
            });

            this.cbbPOSMProject.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbPOSMProject.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cbbPOSMProject.SelectedIndex = 0;
        }

        private void loadControl()
        {
            this.loadLeader();
            this.loadProjectType();
            this.loadPOSMProject();
            this.dtEdtStartDate.DateTime = DateTime.Now;
            this.dtEdtEndDate.DateTime = DateTime.Now.AddDays(1);
        }

        // Gán dữ liệu.
        private void setData(ProjectDTO projectDTO)
        {
            projectDTO.ProjectID = this.txtEdtProjectID.Text.Trim();
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

            projectDTO.Progress = "0";
            projectDTO.ProjectType = this.cbbProjectType.Text.Trim();
            projectDTO.POSMProject = this.cbbPOSMProject.Text.Trim();
            projectDTO.Status = StaticVarClass.status_NotComplete;
            projectDTO.DateRepeat = "0";
            projectDTO.AutoRepeat = "0";
            projectDTO.StartDateRepeat = null;
            projectDTO.EndDateRepeat = null;
        }

        private void formCreatingProject_Load(object sender, EventArgs e)
        {
            this.loadControl();
        }

        private void btnOke_Click(object sender, EventArgs e)
        {
            string str_ProjectLocal = this.txtEdtProjectID.Text.Trim();

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

            #region Kiểm tra end date.
            if (DateTime.Parse(projectDTOLocal.EndDate) <= DateTime.Parse(projectDTOLocal.StartDate))
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = this.dtEdtStartDate.DateTime.AddDays(1);
                return;
            }
            #endregion

            // Thêm mới.
            if (ProjectDAO.Instance.addData(projectDTOLocal))
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Add project " + projectDTOLocal.ProjectID;
                string status = "Successful";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Successfully added project " + str_ProjectLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);


                #region Chuyển qua creating stage.
                this.Hide();

                formProjectCreating frmProjectCreating = formProjectCreating.Instance;
                formCreatingStage frmCreatingStage = new formCreatingStage();
                frmCreatingStage.setInfo(str_ProjectLocal);
                frmCreatingStage.MdiParent = frmProjectCreating;
                frmCreatingStage.Show();
                #endregion
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

                XtraMessageBox.Show("Add project " + str_ProjectLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            #endregion
        }

        private void txtEdtProjectID_EditValueChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnOke.Enabled = true;
            }
            else if (str_ProjectIDLocal == string.Empty)
            {
                this.btnOke.Enabled = false;
            }

            this.txtEdtProjectID.Text = this.txtEdtProjectID.Text.Trim();
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

        private void cbbLeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnOke.Enabled = true;
            }
            else if (str_LeaderLocal == string.Empty)
            {
                this.btnOke.Enabled = false;
            }
        }

        private void cbbLeader_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectLeaderGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnOke.Enabled = true;
            }
            else if (str_LeaderLocal == string.Empty)
            {
                this.btnOke.Enabled = false;
            }
        }

        private void cbbLeader_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectLeaderGlobal == false)
                this.btnOke.Enabled = false;
            else
                this.b_IsSelectLeaderGlobal = false;
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

        private void cbbProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                XtraMessageBox.Show("Be careful when changing project type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.btnOke.Enabled = true;
            }
            else if (str_ProjectTypeLocal == string.Empty)
            {
                this.btnOke.Enabled = false;
            }
        }

        private void cbbProjectType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectProjectTypeGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                XtraMessageBox.Show("Be careful when changing project type!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.btnOke.Enabled = true;
            }
            else if (str_ProjectTypeLocal == string.Empty)
            {
                this.btnOke.Enabled = false;
            }
        }

        private void cbbProjectType_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectProjectTypeGlobal == false)
                this.btnOke.Enabled = false;
            else
                this.b_IsSelectProjectTypeGlobal = false;
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

        private void cbbPOSMProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnOke.Enabled = true;
            }
            else if (str_POSMProjectLocal == string.Empty)
            {
                this.btnOke.Enabled = false;
            }
        }

        private void cbbPOSMProject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectPOSMProjectGlobal = true;
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();
            string str_ProjectTypeLocal = this.cbbProjectType.GetItemText(this.cbbProjectType.SelectedItem).Trim();
            string str_POSMProjectLocal = this.cbbPOSMProject.GetItemText(this.cbbPOSMProject.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty && str_LeaderLocal != string.Empty
                && str_ProjectTypeLocal != string.Empty && str_POSMProjectLocal != string.Empty)
            {
                this.btnOke.Enabled = true;
            }
            else if (str_POSMProjectLocal == string.Empty)
            {
                this.btnOke.Enabled = false;
            }
        }

        private void cbbPOSMProject_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectPOSMProjectGlobal == false)
                this.btnOke.Enabled = false;
            else
                this.b_IsSelectPOSMProjectGlobal = false;
        }

        private void dtEdtStartDate_Leave(object sender, EventArgs e)
        {
            if (this.dtEdtStartDate.DateTime >= this.dtEdtEndDate.DateTime)
            {
                XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TimeSpan difference = new TimeSpan(1, 0, 0, 0);
                this.dtEdtStartDate.DateTime = this.dtEdtEndDate.DateTime.Subtract(difference);
            }
        }

        private void dtEdtEndDate_Leave(object sender, EventArgs e)
        {
            if (this.dtEdtEndDate.DateTime <= this.dtEdtStartDate.DateTime)
            {
                XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtEdtEndDate.DateTime = this.dtEdtStartDate.DateTime.AddDays(1);
            }
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

        private void cbbLeader_KeyDown(object sender, KeyEventArgs e)
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
                this.dtEdtStartDate.Select();
            }
        }

        private void dtEdtEndDate_KeyDown(object sender, KeyEventArgs e)
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
                if (this.btnOke.Enabled == true)
                    this.btnOke.PerformClick();
                else
                    this.txtEdtProjectID.Focus();
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