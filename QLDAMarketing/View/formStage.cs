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

namespace ProjectManagement.View
{
    public partial class formStage : DevExpress.XtraEditors.XtraForm
    {
        // Cờ đánh dấu Add hay Edit hay không làm gì cả.
        int i_FlagGlobal = 0;

        // Cờ xử lí sự kiện chọn value ô combobox Leader: phân biệt textchange.
        bool b_IsSelectProjectIDGlobal = false;

        // Cờ đánh dấu là Admin.
        bool b_IsAdminGlobal = false;

        // Cờ đánh dấu empty data.
        bool b_IsEmptyData = false;

        public formStage()
        {
            InitializeComponent();
            lyoutControlStage.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void loadData()
        {
            DataTable dtStage = new DataTable();
            dtStage = StageDAO.Instance.getData();

            if (dtStage != null)
            {
                grdCtrlStage.DataSource = dtStage;
                binding();

                if (dtStage.Rows.Count == 0)
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
                XtraMessageBox.Show("Empty data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            cbbProjectID.DataBindings.Clear();
            cbbProjectID.DataBindings.Add("Text", grdCtrlStage.DataSource, "PROJECTID");

            txtEdtStage.DataBindings.Clear();
            txtEdtStage.DataBindings.Add("Text", grdCtrlStage.DataSource, "STAGE");

            txtEdtStageSubject.DataBindings.Clear();
            txtEdtStageSubject.DataBindings.Add("Text", grdCtrlStage.DataSource, "STAGESUBJECT");

            txtEdtStatus.DataBindings.Clear();
            txtEdtStatus.DataBindings.Add("Text", grdCtrlStage.DataSource, "STATUS");
        }

        private void notBinding()
        {
            cbbProjectID.DataBindings.Clear();
            txtEdtStage.DataBindings.Clear();
            txtEdtStageSubject.DataBindings.Clear();
            txtEdtStatus.DataBindings.Clear();
        }

        private void disable(bool e)
        {
            if (this.i_FlagGlobal == 1)
            {
                cbbProjectID.Enabled = true;
                txtEdtStageSubject.ReadOnly = false;
            }
            else if (this.i_FlagGlobal == 2)
            {
                cbbProjectID.Enabled = false;
                txtEdtStageSubject.ReadOnly = true; // always
            }
            else
            {
                // Khóa các text, combobox.
                cbbProjectID.Enabled = false;
                txtEdtStageSubject.ReadOnly = true;
            }

            txtEdtStage.ReadOnly = true;
            txtEdtStatus.ReadOnly = true;

            // Khóa/ Mở khóa các nút.
            btnAdd.Enabled = !e;
            btnEdit.Enabled = !e;
            btnSave.Enabled = e;
            btnRemove.Enabled = !e;

            // Nếu ko có data.
            if (this.b_IsEmptyData == true)
            {
                this.btnEdit.Enabled = false;
                this.btnRemove.Enabled = false;
            }
        }

        // Khóa tất cả các phím.
        private void disableAll()
        {
            // Khóa các text, combobox.
            cbbProjectID.Enabled = false;
            txtEdtStage.ReadOnly = true;
            txtEdtStageSubject.ReadOnly = true;
            txtEdtStatus.ReadOnly = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void checkEnableEdit(string projectID, string stage)
        {
            string str_StatusLocal = StageDAO.Instance.getStringStatusFollowProjectIDAndStage(projectID, stage);

            if (str_StatusLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnSave.Enabled = false;
                return;
            }

            if (str_StatusLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSave.Enabled = false;
                return;
            }

            if (str_StatusLocal == StaticVarClass.status_Complete)
            {
                this.btnSave.Enabled = false;
                return;
            }

            if (str_StatusLocal != StaticVarClass.status_Complete)
            {
                // always
                this.txtEdtStageSubject.ReadOnly = false;
            }
        }

        // Xóa trước khi thêm.
        private void clearData()
        {
            cbbProjectID.Text = string.Empty;
            txtEdtStage.Text = string.Empty;
            txtEdtStageSubject.Text = string.Empty;
            txtEdtStatus.Text = StaticVarClass.status_NotComplete;
        }

        // Load các mã dự án.
        private void loadProjectID()
        {
            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();

            DataTable dtLocal = ProjectDAO.Instance.getDataProjectIDNotComplete();

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string projectID = row["PROJECTID"].ToString();
                    row["PROJECTID"] = projectID.Trim();
                }

                this.cbbProjectID.DataSource = dtLocal;
                this.cbbProjectID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbProjectID.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbProjectID.DisplayMember = "PROJECTID";

                if (this.i_FlagGlobal == 2 && str_ProjectIDLocal != string.Empty)
                    this.cbbProjectID.SelectedIndex = this.cbbProjectID.FindString(str_ProjectIDLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loadControl()
        {
            this.notBinding();
            this.loadProjectID();
        }

        // Gán dữ liệu.
        private void setData(StageDTO stageDTO)
        {
            stageDTO.ProjectID = cbbProjectID.Text.Trim();
            stageDTO.Stage = txtEdtStage.Text.Trim();
            stageDTO.StageSubject = txtEdtStageSubject.Text.Trim();
            stageDTO.Status = txtEdtStatus.Text.Trim();
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        private void formStage_Load(object sender, EventArgs e)
        {
            // Đặt lại cờ.
            this.i_FlagGlobal = 0;

            this.lyoutControlStage.Hide();

            this.loadData();

            // Phân quyền.
            this.Authorize();
        }

        private void formStage_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.i_FlagGlobal = 1;

            this.lyoutControlStage.Show();

            this.clearData();
            this.disable(true); // Điều khiển các nút.
            this.btnSave.Enabled = false;
            this.loadControl();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();
            string str_StageLocal = this.txtEdtStage.Text.Trim();

            this.i_FlagGlobal = 2;

            this.lyoutControlStage.Show();

            this.loadControl();
            this.disable(true); // Điều khiển các nút.
            this.btnSave.Enabled = true;
            this.checkEnableEdit(str_ProjectIDLocal, str_StageLocal);
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str_ProjectIDLocal = cbbProjectID.Text.Trim();
            string str_StageLocal = txtEdtStage.Text.Trim();

            StageDTO stageDTOLocal = new StageDTO();

            // Gán giá trị vào thuộc tính trong bảng.
            setData(stageDTOLocal);

            #region Thêm mới.
            if (i_FlagGlobal == 1)
            {
                // Thêm mới.
                if (StageDAO.Instance.addData(stageDTOLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully added project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Add project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            #region Sửa.
            else if (i_FlagGlobal == 2)
            {
                // Sửa.
                if (StageDAO.Instance.updateData(stageDTOLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully edited project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Edit project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            formStage_Load(sender, e);
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str_ProjectIDLocal = cbbProjectID.Text.Trim();
            string str_StageLocal = txtEdtStage.Text.Trim();

            #region Nếu project đã complete thì ko đc xóa stage.
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
                XtraMessageBox.Show("Cannot remove stage because project " + str_ProjectIDLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            #region Nếu project - stage đã complete thì ko đc xóa stage.
            string str_StatusLocal = StageDAO.Instance.getStringStatusFollowProjectIDAndStage(str_ProjectIDLocal, str_StageLocal);

            if (str_StatusLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (str_StatusLocal == string.Empty)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_StatusLocal == StaticVarClass.status_Complete)
            {
                XtraMessageBox.Show("Cannot remove stage because project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + " has been completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            int i_SumOfTaskLocal = TaskCreatingDAO.Instance.getIntQuantityInStageForFormProjectDiagram(str_ProjectIDLocal, str_StageLocal);

            if (i_SumOfTaskLocal == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region Lấy ra các chỉ số để xem xét việc xóa task.
            int i_RuleLocal = StageDAO.Instance.getIntWarningWhenRemovingStage(str_ProjectIDLocal, str_StageLocal);
            string str_Message = string.Empty;

            switch (i_RuleLocal)
            {
                case -1:
                    DialogResult dr = XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                case 1:
                    str_Message = "Warning: If you remove project - stage:" + str_ProjectIDLocal + " - " + str_StageLocal + ", you will not be able to add any stages in this project. \nThere are " + i_SumOfTaskLocal + " tasks in project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + ". \nAre you sure you want to remove?";
                    break;
                case 0:
                case 2:
                    str_Message = "Warning: There are " + i_SumOfTaskLocal + " tasks in project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + ". \nAre you sure you want to remove?";
                    break;
            }
            #endregion

            DialogResult drLocal = XtraMessageBox.Show(str_Message, "Comfirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (drLocal == DialogResult.Yes)
            {
                // Xóa.
                if (StageDAO.Instance.deleteData(str_ProjectIDLocal, str_StageLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully removed project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    #region update status and progress project.
                    StageDTO stageDTOTemp = StageDAO.Instance.getDataObjectForUpdateWhenRemovingStage(str_ProjectIDLocal);

                    if (stageDTOTemp.Empty() == false && stageDTOTemp != null)
                    {
                        if (!StageDAO.Instance.updateDataStatus(stageDTOTemp.ProjectID, stageDTOTemp.Stage, stageDTOTemp.Status))
                        {
                            XtraMessageBox.Show("Update status of project " + str_ProjectIDLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Remove project - stage: " + str_ProjectIDLocal + " - " + str_StageLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }

            formStage_Load(sender, e);
        }

        private void cbbProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = string.Empty;

            // Lấy giai đoạn có stt lớn nhất của dự án.
            int i_MaxStageLocal = StageDAO.Instance.getIntMaxStageFollowProjectID(str_ProjectIDLocal);

            if (i_MaxStageLocal == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.txtEdtStage.Text = (i_MaxStageLocal + 1).ToString();
            str_StageLocal = this.txtEdtStage.Text.Trim();

            if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty && str_StageLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal == 1 && str_ProjectIDLocal == string.Empty)
            {
                this.txtEdtStage.Text = string.Empty;
                this.btnSave.Enabled = false;
            }
        }

        private void cbbProjectID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectProjectIDGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            string str_StageLocal = string.Empty;

            // Lấy giai đoạn có stt lớn nhất của dự án.
            int i_MaxStageLocal = StageDAO.Instance.getIntMaxStageFollowProjectID(str_ProjectIDLocal);

            if (i_MaxStageLocal == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.txtEdtStage.Text = (i_MaxStageLocal + 1).ToString();
            str_StageLocal = this.txtEdtStage.Text.Trim();

            if (this.i_FlagGlobal == 1 && str_ProjectIDLocal != string.Empty && str_StageLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal == 1 && str_ProjectIDLocal == string.Empty)
            {
                this.txtEdtStage.Text = string.Empty;
                this.btnSave.Enabled = false;
            }
        }

        private void cbbProjectID_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectProjectIDGlobal == false)
            {
                if (this.i_FlagGlobal == 1)
                    this.txtEdtStage.Text = string.Empty;

                this.btnSave.Enabled = false;
            }
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

        private void cbbProjectID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtStageSubject.Focus();
            }
        }

        private void txtEdtStageSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbProjectID.Select();
            }
        }

        private void txtEdtStageSubject_EditValueChanged(object sender, EventArgs e)
        {
            this.txtEdtStageSubject.Text = this.txtEdtStageSubject.Text.Trim();
        }

        private void formStage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.b_IsAdminGlobal == true)
                {
                    if (btnAdd.Enabled == true)
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
                    if (btnRemove.Enabled == true)
                    {
                        if (e.KeyCode.Equals(Keys.R))
                        {
                            btnRemove_ItemClick(null, null);
                        }
                    }
                    if (btnSave.Enabled == true)
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
            formStage_Load(sender, e);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formStage = null;

            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formStage_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formStage = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}