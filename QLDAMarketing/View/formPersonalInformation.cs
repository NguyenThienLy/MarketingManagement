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
    public partial class formPersonalInformation : DevExpress.XtraEditors.XtraForm
    {
        bool b_IsAdminGlobal = false;

        #region Các cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectGenderGlobal = false;

        bool b_IsSelectYearOfBirthGlobal = false;

        bool b_IsSelectRoleGlobal = false;

        bool b_IsSelectDepartmentGlobal = false;
        #endregion

        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        public formPersonalInformation()
        {
            InitializeComponent();

            this.addTabColor();
            this.loadColorDefault();
            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            layoutControl2.OptionsFocus.EnableAutoTabOrder = false;
        }

        // Load thông tin đang search.
        private void loadSearchInfo()
        {
            string str_EmployeeLocal = StaticVarClass.account_Username;
            string str_StartDateLocal = this.dtEdtStartDate.Text.Trim();
            string str_EndDateLocal = this.dtEdtEndDate.Text.Trim();
            string str_POSMProjectLocal = this.getPOSMProject();
            string str_StatusLocal = this.getStatus();

            DataTable dt_PersonalInformationLocal = TaskCreatingDAO.Instance.getDataForFormMyTask(str_EmployeeLocal, str_StartDateLocal, str_EndDateLocal, str_POSMProjectLocal, str_StatusLocal);
            List<string> lst_QuanlityLocal = TaskCreatingDAO.Instance.getDataListQuantityForFormMyTask(str_EmployeeLocal, str_StartDateLocal, str_EndDateLocal, str_POSMProjectLocal);

            if (dt_PersonalInformationLocal != null && lst_QuanlityLocal != null)
            {
                //// Nếu lấy ra bảng không có phần tử nào.
                //if (dt_PersonalInformationLocal.Rows.Count == 0)
                //    dt_PersonalInformationLocal = null;

                this.grdCtrlPersonalInformation.DataSource = dt_PersonalInformationLocal;

                this.loadQuanlityListTaskCreating(lst_QuanlityLocal);

                this.hideApprover();
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
                this.disable(false);
                this.b_IsAdminGlobal = true;
            }
            else if (str_RoleLocal == StaticVarClass.role_Staff)
            {
                this.disableAll();
                this.b_IsAdminGlobal = false;
            }
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        private void formPersonalInformation_Load(object sender, EventArgs e)
        {
            this.tbCtrlMyTask.SelectedIndex = 1;
            // Gán dữ liệu cho các text edit và combobox.
            this.loadSearchInfo();

            // Phân quyền.
            this.Authorize();
        }

        private void formPersonalInformation_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void tbPnPersonalInfo_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            int i_IndexPage = this.tbPnPersonalInfo.SelectedPageIndex;

            switch (i_IndexPage)
            {
                case 0:
                    this.loadSearchInfo();
                    break;
                case 1:
                    this.setDataInformation();
                    break;
            }
        }

        #region tabpage My Task.
        // Check người dùng chọn project POSM.
        private string getPOSMProject()
        {
            if (this.chkBxPOSMProject.Checked == true)
            {
                return StaticVarClass.YN_Yes;
            }

            return StaticVarClass.YN_No;
        }

        // Xem người dùng đang chọn tab page nào.
        private string getStatus()
        {
            int i_PageIndex = this.tbCtrlMyTask.SelectedIndex;

            switch (i_PageIndex)
            {
                case 0:
                    return StaticVarClass.status_Complete;
                case 1:
                    return StaticVarClass.status_NotComplete;
                case 2:
                    return StaticVarClass.status_Overdue;
                case 3:
                    return StaticVarClass.status_AssignedTask;
                case 4:
                    return StaticVarClass.status_WaitForApproval;
            }

            return StaticVarClass.status_NeedApproving;
        }

        // Hiển thị các số lượng task creating trong từng status.
        private void loadQuanlityListTaskCreating(List<string> lst_QuanlityListTaskCreating)
        {
            this.tbPgComplete.Text = StaticVarClass.status_Complete + " (" + lst_QuanlityListTaskCreating[0] + ")";

            this.tbPgNotComplete.Text = StaticVarClass.status_NotComplete + " (" + lst_QuanlityListTaskCreating[1] + ")";

            this.tbPgOverdue.Text = StaticVarClass.status_Overdue + " (" + lst_QuanlityListTaskCreating[2] + ")";

            this.tbPgAssignedTask.Text = StaticVarClass.status_AssignedTask + " (" + lst_QuanlityListTaskCreating[3] + ")";

            this.tbPgWaitForApproval.Text = StaticVarClass.status_WaitForApproval + " (" + lst_QuanlityListTaskCreating[4] + ")";

            this.tbPgNeedApproving.Text = StaticVarClass.status_NeedApproving + " (" + lst_QuanlityListTaskCreating[5] + ")";
        }

        // Ẩn approver.
        private void hideApprover()
        {
            int i_PageIndex = this.tbCtrlMyTask.SelectedIndex;

            if (i_PageIndex < 5) // Nếu không phải là cột approver.
            {
                this.grvPersonalInformation.Columns[16].Visible = false;
            }
            else
            {
                this.grvPersonalInformation.Columns[16].Visible = true;
            }
        }

        //private void SetTabHeader(TabPage page, Color color)
        //{
        //    this.TabColors[page] = color;
        //    tbCtrlMyTask.Invalidate();
        //}

        private void addTabColor()
        {
            TabColors.Add(tbPgComplete, Color.ForestGreen);
            TabColors.Add(tbPgNotComplete, Color.LightSkyBlue);
            TabColors.Add(tbPgOverdue, Color.OrangeRed);
            TabColors.Add(tbPgAssignedTask, Color.LightYellow);
            TabColors.Add(tbPgWaitForApproval, Color.YellowGreen);
            TabColors.Add(tbPgNeedApproving, Color.LightGray);
        }

        // Màu mặc định của các btn.
        private void loadColorDefault()
        {
            this.tbPgComplete.BackColor = Color.ForestGreen;
            this.tbPgComplete.ForeColor = Color.ForestGreen;

            this.tbPgNotComplete.BackColor = Color.LightSkyBlue;
            this.tbPgNotComplete.ForeColor = Color.LightSkyBlue;

            this.tbPgOverdue.BackColor = Color.OrangeRed;
            this.tbPgOverdue.ForeColor = Color.OrangeRed;

            this.tbPgAssignedTask.BackColor = Color.LightYellow;
            this.tbPgAssignedTask.ForeColor = Color.LightYellow;

            this.tbPgWaitForApproval.BackColor = Color.YellowGreen;
            this.tbPgWaitForApproval.ForeColor = Color.YellowGreen;

            this.tbPgNeedApproving.BackColor = Color.LightGray;
            this.tbPgNeedApproving.ForeColor = Color.LightGray;
        }

        private void tbCtrlMyTask_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            using (Brush br = new SolidBrush(TabColors[tbCtrlMyTask.TabPages[e.Index]]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
                SizeF sz = e.Graphics.MeasureString(tbCtrlMyTask.TabPages[e.Index].Text, this.tbCtrlMyTask.Font);

                var x = e.Bounds.Left + (e.Bounds.Width - e.Graphics.MeasureString(this.tbCtrlMyTask.TabPages[e.Index].Text, this.tbCtrlMyTask.Font).Width) / 2;
                var y = e.Bounds.Top + (e.Bounds.Height - e.Graphics.MeasureString(this.tbCtrlMyTask.TabPages[e.Index].Text, this.tbCtrlMyTask.Font).Height) / 2;
                e.Graphics.DrawString(tbCtrlMyTask.TabPages[e.Index].Text, this.tbCtrlMyTask.Font, Brushes.Black, x, y);

                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(0, 0);
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                e.DrawFocusRectangle();
            }
        }
    
        private void tbCtrlMyTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadSearchInfo();
        }

        private void chkBxPOSMProject_CheckedChanged(object sender, EventArgs e)
        {
            this.loadSearchInfo();
        }

        private void dtEdtStartDate_Leave(object sender, EventArgs e)
        {
            DateTime value;
            if (DateTime.TryParse(this.dtEdtStartDate.Text.Trim(), out value) && DateTime.TryParse(this.dtEdtEndDate.Text.Trim(), out value))
            {
                if (this.dtEdtStartDate.DateTime >= this.dtEdtEndDate.DateTime)
                {
                    XtraMessageBox.Show("Invalid start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TimeSpan difference = new TimeSpan(1, 0, 0, 0);
                    this.dtEdtStartDate.DateTime = this.dtEdtEndDate.DateTime.Subtract(difference);
                }
            }
        }

        private void dtEdtEndDate_Leave(object sender, EventArgs e)
        {
            DateTime value;
            if (DateTime.TryParse(this.dtEdtEndDate.Text.Trim(), out value) && DateTime.TryParse(this.dtEdtStartDate.Text.Trim(), out value))
            {
                if (this.dtEdtEndDate.DateTime <= this.dtEdtStartDate.DateTime)
                {
                    XtraMessageBox.Show("Invalid end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.dtEdtEndDate.DateTime = this.dtEdtStartDate.DateTime.AddDays(1);
                }
            }
        }

        private void dtEdtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            this.loadSearchInfo();
        }

        private void dtEdtStartDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loadSearchInfo();
            }
        }

        private void dtEdtEndDate_EditValueChanged(object sender, EventArgs e)
        {
            this.loadSearchInfo();
        }

        private void dtEdtEndDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loadSearchInfo();
            }
        }

        private void btnTaskDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            System.Data.DataRow dtR_rowLocal = grvPersonalInformation.GetDataRow(grvPersonalInformation.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_rowLocal[0].ToString().Trim();
            string str_StageLocal = dtR_rowLocal[1].ToString().Trim();
            string str_TaskLocal = dtR_rowLocal[2].ToString().Trim();
            string str_EmployeeLocal = dtR_rowLocal[3].ToString().Trim();

            formTaskDetail frmTaskDetailLocal = new formTaskDetail();
            frmTaskDetailLocal.setInformation(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_EmployeeLocal);
            frmTaskDetailLocal.ShowDialog();
        }

        private void btnApprove_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            System.Data.DataRow dtR_rowLocal = grvPersonalInformation.GetDataRow(grvPersonalInformation.FocusedRowHandle);

            string str_ProjectIDLocal = dtR_rowLocal[0].ToString().Trim();
            string str_StageLocal = dtR_rowLocal[1].ToString().Trim();
            string str_TaskLocal = dtR_rowLocal[2].ToString().Trim();
            string str_EmployeeLocal = dtR_rowLocal[3].ToString().Trim();
            string str_Status = StaticVarClass.status_Complete;

            DialogResult dr = XtraMessageBox.Show("Are you sure you want to approve project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal + "!", "Confirm approve", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)
            {
                if (TaskCreatingDAO.Instance.updateDataForConfirmApprove(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_Status))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Approve project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully approved project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Approve project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Approve project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal + " for employee " + str_EmployeeLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            this.loadSearchInfo();
        }

        private void btnRefreshMyTask_Click(object sender, EventArgs e)
        {
            formPersonalInformation_Load(sender, e);
        }

        private void btnCancelMyTask_Click(object sender, EventArgs e)
        {
            StaticVarClass.formPersonalInformation = null;
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion

        #region tabpage Personal Info.
        // Gán dữ liệu cho các text edit, combobox.
        void setDataInformation()
        {
            EmployeeDTO employeeDTOLocal = EmployeeDAO.Instance.getDataObjectFollowName(StaticVarClass.account_Username);

            if (employeeDTOLocal != null)
            {
                if (employeeDTOLocal.Empty())
                {
                    XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.txtEdtName.Text = employeeDTOLocal.Name;
                    this.txtEdtFullName.Text = employeeDTOLocal.FullName;
                    this.cbbGender.Text = employeeDTOLocal.Gender;
                    this.cbbYearOfBirth.Text = employeeDTOLocal.YearOfBirth;
                    this.txtEdtPhone.Text = employeeDTOLocal.Phone;
                    this.txtEdtEmail.Text = employeeDTOLocal.Email;
                    this.txtEdtPosition.Text = employeeDTOLocal.Position;
                    this.cbbRole.Text = employeeDTOLocal.Role;
                    this.cbbDepartment.Text = employeeDTOLocal.Department;
                }
            }
            else
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Khóa/ mở khoá các phím.
        private void disable(bool e, string action = "")
        {
            if (action == "edit")
            {
                this.txtEdtName.ReadOnly = true;
                this.txtEdtFullName.ReadOnly = false;
                this.cbbGender.Enabled = true;
                this.cbbYearOfBirth.Enabled = true;
                this.txtEdtPhone.ReadOnly = false;
                this.txtEdtEmail.ReadOnly = false;
            }
            else
            {
                this.txtEdtName.ReadOnly = true;
                this.txtEdtFullName.ReadOnly = true;
                this.cbbGender.Enabled = false;
                this.cbbYearOfBirth.Enabled = false;
                this.txtEdtPhone.ReadOnly = true;
                this.txtEdtEmail.ReadOnly = true;
            }

            // Mặc định khóa các ô.
            this.txtEdtPosition.ReadOnly = true;
            this.cbbRole.Enabled = false;
            this.cbbDepartment.Enabled = false;

            // Mở khoá/ khóa các nút.
            btnEdit.Enabled = !e;
            btnSave.Enabled = e;
        }

        // Khóa tất cả các phím.
        private void disableAll()
        {
            this.txtEdtName.ReadOnly = true;
            this.txtEdtFullName.ReadOnly = true;
            this.cbbGender.Enabled = false;
            this.cbbYearOfBirth.Enabled = false;
            this.txtEdtPhone.ReadOnly = true;
            this.txtEdtEmail.ReadOnly = true;
            this.txtEdtPosition.ReadOnly = true;
            this.cbbRole.Enabled = false;
            this.cbbDepartment.Enabled = false;

            btnEdit.Enabled = false;
            btnSave.Enabled = false;
        }

        // Load giới tính.
        private void loadGender()
        {
            string str_GenderLocal = this.cbbGender.Text.Trim();

            this.cbbGender.Items.Clear();
            this.cbbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            });

            this.cbbGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbGender.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (str_GenderLocal != string.Empty)
                this.cbbGender.SelectedIndex = this.cbbGender.FindString(str_GenderLocal);
        }

        // Load năm sinh.
        private void loadYearOfBirth()
        {
            string str_YearOfBirthLocal = this.cbbYearOfBirth.Text.Trim();

            int i_EighteenYearLocal = DateTime.Now.Year - 2018 + 2000;

            for (int i = i_EighteenYearLocal; i >= i_EighteenYearLocal - (42 + DateTime.Now.Year - 2018); i--)
            {
                this.cbbYearOfBirth.Items.Add(i);
            }
            //this.cbbYearOfBirth.DataSource = Enumerable.Range(DateTime.Now.Year - 2018 + 2000, -(43 + DateTime.Now.Year - 2018)).ToList();

            this.cbbYearOfBirth.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbYearOfBirth.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (str_YearOfBirthLocal != string.Empty)
                this.cbbYearOfBirth.SelectedIndex = this.cbbYearOfBirth.FindString(str_YearOfBirthLocal);
        }

        // Load role.
        private void loadRole()
        {
            string str_RoleLocal = this.cbbRole.Text.Trim();

            this.cbbRole.Items.Clear();
            this.cbbRole.Items.AddRange(new object[] {
            StaticVarClass.role_Member,
            StaticVarClass.role_Staff,
            StaticVarClass.role_Admin
            });

            this.cbbRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbRole.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (str_RoleLocal != string.Empty)
                this.cbbRole.SelectedIndex = this.cbbRole.FindString(str_RoleLocal);
        }

        // Đưa lên danh sách các phòng ban đang có trong công ty.
        private void loadDepartment()
        {
            string str_DepartmentLocal = this.cbbDepartment.Text.Trim();

            DataTable dtLocal = DepartmentDAO.Instance.getData();

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string department = row["DEPARTMENT"].ToString();
                    row["DEPARTMENT"] = department.Trim();
                }

                this.cbbDepartment.DataSource = dtLocal;
                this.cbbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbDepartment.DisplayMember = "DEPARTMENT";

                if (str_DepartmentLocal != string.Empty)
                    this.cbbDepartment.SelectedIndex = this.cbbDepartment.FindString(str_DepartmentLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Load các combobox.
        private void loadControl()
        {
            this.loadGender();
            this.loadYearOfBirth();
            this.loadRole();
            this.loadDepartment();
        }

        // Gán dữ liệu cho tp thông tin.
        void setData(EmployeeDTO employeeDTO)
        {
            employeeDTO.Name = this.txtEdtName.Text.Trim();
            employeeDTO.FullName = this.txtEdtFullName.Text.Trim();
            employeeDTO.Gender = this.cbbGender.Text.Trim();
            employeeDTO.YearOfBirth = this.cbbYearOfBirth.Text.Trim();
            employeeDTO.Phone = this.txtEdtPhone.Text.Trim();
            employeeDTO.Email = this.txtEdtEmail.Text.Trim();
            employeeDTO.Position = this.txtEdtPosition.Text.Trim();

            if (this.cbbRole.Text.Trim() == string.Empty)
                employeeDTO.Role = null;
            else
                employeeDTO.Role = this.cbbRole.Text.Trim();

            if (this.cbbDepartment.Text.Trim() == string.Empty)
                employeeDTO.Department = null;
            else
                employeeDTO.Department = this.cbbDepartment.Text.Trim();

            employeeDTO.Status = StaticVarClass.status_Working;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            loadControl();
            disable(true, "edit"); // Điều khiển các nút.
            this.btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str_NameLocal = this.txtEdtName.Text.Trim();

            EmployeeDTO employeeDTOLocal = new EmployeeDTO();

            // Gán giá trị vào đối tượng employeeDTOLocal
            setData(employeeDTOLocal);

            // Sửa.
            if (EmployeeDAO.Instance.updateDataNotAllColumns(employeeDTOLocal))
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Edit personal information";
                string status = "Successful";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Successfully edited personal information of " + str_NameLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Edit personal information";
                string status = "Failed";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Edit personal information of " + str_NameLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            formPersonalInformation_Load(sender, e);
        }

        private void cbbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_GenderLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbGender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectGenderGlobal = true;
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_GenderLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbGender_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectGenderGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectGenderGlobal = false;
        }

        private void cbbGender_DropDown(object sender, EventArgs e)
        {
            this.cbbGender.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbGender.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbGender_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbGender.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbGender.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbYearOfBirth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_YearOfBirthLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbYearOfBirth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectYearOfBirthGlobal = true;
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_YearOfBirthLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbYearOfBirth_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectYearOfBirthGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectYearOfBirthGlobal = false;
        }

        private void cbbYearOfBirth_DropDown(object sender, EventArgs e)
        {
            this.cbbYearOfBirth.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbYearOfBirth.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbYearOfBirth_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbYearOfBirth.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbYearOfBirth.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtEdtEmail_EditValueChanged(object sender, EventArgs e)
        {
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_EmailLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_RoleLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectRoleGlobal = true;
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_RoleLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbRole_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectRoleGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectRoleGlobal = false;
        }

        private void cbbRole_DropDown(object sender, EventArgs e)
        {
            this.cbbRole.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbRole.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbRole_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbRole.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbRole.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_DepartmentLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectDepartmentGlobal = true;
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();

            if (str_GenderLocal != string.Empty && str_YearOfBirthLocal != string.Empty
                && str_EmailLocal != string.Empty && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (str_DepartmentLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbDepartment_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectDepartmentGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectDepartmentGlobal = false;
        }

        private void cbbDepartment_DropDown(object sender, EventArgs e)
        {
            this.cbbDepartment.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbDepartment.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbDepartment_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbDepartment.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbDepartment.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtEdtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbGender.Select();
            }
        }

        private void cbbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbYearOfBirth.Select();
            }
        }

        private void cbbYearOfBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtPhone.Focus();
            }
        }

        private void txtEdtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtEmail.Focus();
            }
        }

        private void txtEdtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtPosition.Focus();
            }
        }

        private void txtEdtPosition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbRole.Select();
            }
        }

        private void cbbRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbbDepartment.Select();
            }
        }

        private void cbbDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnSave.Enabled == true)
                    this.btnSave.PerformClick();
                else
                    this.txtEdtName.Focus();
            }
        }

        private void btnRefreshInfo_Click(object sender, EventArgs e)
        {

            formPersonalInformation_Load(sender, e);
        }

        private void btnCancelInfo_Click(object sender, EventArgs e)
        {
            StaticVarClass.formPersonalInformation = null;
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion

        private void formPersonalInformation_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.b_IsAdminGlobal == true)
                {
                    if (this.tbPnPersonalInfo.SelectedPageIndex == 0)
                    {
                        if (btnEdit.Enabled == true)
                        {
                            if (e.KeyCode.Equals(Keys.D))
                            {
                                btnEdit_Click(null, null);
                            }
                        }
                        if (btnSave.Enabled == true)
                        {
                            if (e.KeyCode.Equals(Keys.S))
                            {
                                btnSave_Click(null, null);
                            }
                        }
                    }
                }
            }
            else
            {
                if (e.KeyCode.Equals(Keys.F5))
                {
                    btnRefreshMyTask_Click(null, null);
                    btnRefreshInfo_Click(null, null);
                }
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    btnCancelMyTask_Click(null, null);
                }
            }
        }

        private void formPersonalInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formPersonalInformation = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

    }
}