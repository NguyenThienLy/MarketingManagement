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
    public partial class formEmployee : DevExpress.XtraEditors.XtraForm
    {
        // Cờ đánh dấu Add hay Edit hay không làm gì cả.
        int i_FlagGlobal = 0;

        #region Các cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange.
        bool b_IsSelectGenderGlobal = false;

        bool b_IsSelectYearOfBirthGlobal = false;

        bool b_IsSelectRoleGlobal = false;

        bool b_IsSelectDepartmentGlobal = false;

        bool b_IsSelectStatusGlobal = false;
        #endregion

        // Cờ đánh dấu là Admin.
        bool b_IsAdminGlobal = false;

        // Cờ đánh dấu empty data.
        bool b_IsEmptyData = false;

        public formEmployee()
        {
            InitializeComponent();
            lyoutControlEmployee.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        private void loadData()
        {
            DataTable dtEmployee = new DataTable();
            dtEmployee = EmployeeDAO.Instance.getDataNotAllColumns();

            if (dtEmployee != null)
            {
                this.grdCtrlEmployeeManagement.DataSource = dtEmployee;
                this.binding();

                if (dtEmployee.Rows.Count == 0)
                {
                    this.b_IsEmptyData = true;
                    XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.b_IsEmptyData = false;
                }
            }
            else
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.txtEdtName.DataBindings.Clear();
            this.txtEdtName.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "NAME");

            this.txtEdtFullName.DataBindings.Clear();
            this.txtEdtFullName.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "FULLNAME");

            this.cbbGender.DataBindings.Clear();
            this.cbbGender.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "GENDER");

            this.cbbYearOfBirth.DataBindings.Clear();
            this.cbbYearOfBirth.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "YEAROFBIRTH");

            this.txtEdtPhone.DataBindings.Clear();
            this.txtEdtPhone.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "PHONE");

            this.txtEdtEmail.DataBindings.Clear();
            this.txtEdtEmail.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "EMAIL");

            this.txtEdtPosition.DataBindings.Clear();
            this.txtEdtPosition.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "POSITION");

            this.cbbRole.DataBindings.Clear();
            this.cbbRole.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "ROLE");

            this.cbbDepartment.DataBindings.Clear();
            this.cbbDepartment.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "DEPARTMENT");

            this.cbbStatus.DataBindings.Clear();
            this.cbbStatus.DataBindings.Add("Text", grdCtrlEmployeeManagement.DataSource, "STATUS");
        }

        private void notBinding()
        {
            this.txtEdtName.DataBindings.Clear();
            this.txtEdtFullName.DataBindings.Clear();
            this.cbbGender.DataBindings.Clear();
            this.cbbYearOfBirth.DataBindings.Clear();
            this.txtEdtPhone.DataBindings.Clear();
            this.txtEdtEmail.DataBindings.Clear();
            this.txtEdtPosition.DataBindings.Clear();
            this.cbbRole.DataBindings.Clear();
            this.cbbDepartment.DataBindings.Clear();
            this.cbbStatus.DataBindings.Clear();
        }

        // Khóa/ mở khoá các phím.
        private void disable(bool e)
        {
            if (this.i_FlagGlobal == 1)
            {
                this.txtEdtName.ReadOnly = false;
                this.txtEdtFullName.ReadOnly = false;
                this.cbbGender.Enabled = true;
                this.cbbYearOfBirth.Enabled = true;
                this.txtEdtPhone.ReadOnly = false;
                this.txtEdtEmail.ReadOnly = false;
                this.txtEdtPosition.ReadOnly = false;
                this.cbbRole.Enabled = true;
                this.cbbDepartment.Enabled = true;
                this.cbbStatus.Enabled = false; // Khóa status.
            }
            else if (this.i_FlagGlobal == 2)
            {
                // Chỉ khóa text edit Name.
                this.txtEdtName.ReadOnly = true;
                this.txtEdtFullName.ReadOnly = false;
                this.cbbGender.Enabled = true;
                this.cbbYearOfBirth.Enabled = true;
                this.txtEdtPhone.ReadOnly = false;
                this.txtEdtEmail.ReadOnly = false;
                this.txtEdtPosition.ReadOnly = false;
                this.cbbRole.Enabled = true;
                this.cbbDepartment.Enabled = true;
                this.cbbStatus.Enabled = true; 
            }
            else
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
                this.cbbStatus.Enabled = false;
            }

            // Mở khoá/ khóa các nút.
            this.btnAdd.Enabled = !e;
            this.btnEdit.Enabled = !e;
            this.btnSave.Enabled = e;
            this.btnRemove.Enabled = !e;

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
            this.txtEdtName.ReadOnly = true;
            this.txtEdtFullName.ReadOnly = true;
            this.cbbGender.Enabled = false;
            this.cbbYearOfBirth.Enabled = false;
            this.txtEdtPhone.ReadOnly = true;
            this.txtEdtEmail.ReadOnly = true;
            this.txtEdtPosition.ReadOnly = true;
            this.cbbRole.Enabled = false;
            this.cbbDepartment.Enabled = false;
            this.cbbStatus.Enabled = false;

            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnRemove.Enabled = false;
        }

        // Xóa sạch trước khi thêm.
        private void clearData()
        {
            this.txtEdtName.Text = string.Empty;
            this.txtEdtFullName.Text = string.Empty;
            this.cbbGender.Text = string.Empty;
            this.cbbYearOfBirth.Text = string.Empty;
            this.txtEdtPhone.Text = string.Empty;
            this.txtEdtEmail.Text = string.Empty;
            this.txtEdtPosition.Text = string.Empty;
            this.cbbRole.Text = string.Empty;
            this.cbbDepartment.Text = string.Empty;
            this.cbbStatus.Text = string.Empty;
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

            if (this.i_FlagGlobal == 1)
                this.cbbGender.SelectedIndex = 0;

            if (this.i_FlagGlobal == 2 && str_GenderLocal != string.Empty)
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

            if (this.i_FlagGlobal == 1)
                this.cbbYearOfBirth.SelectedIndex = 0;

            if (this.i_FlagGlobal == 2 && str_YearOfBirthLocal != string.Empty)
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

            if (this.i_FlagGlobal == 1)
                this.cbbRole.SelectedIndex = 0;

            if (this.i_FlagGlobal == 2 && str_RoleLocal != string.Empty)
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

                if (this.i_FlagGlobal == 2 && str_DepartmentLocal != string.Empty)
                    this.cbbDepartment.SelectedIndex = this.cbbDepartment.FindString(str_DepartmentLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loadStatus()
        {
            string str_StatusLocal = this.cbbStatus.Text.Trim();

            this.cbbStatus.Items.Clear();
            this.cbbStatus.Items.AddRange(new object[] {
            StaticVarClass.status_Working,
            StaticVarClass.status_NotWorking
            });

            this.cbbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;

            if (this.i_FlagGlobal == 1)
                this.cbbStatus.SelectedIndex = 0;

            if (this.i_FlagGlobal == 2 && str_StatusLocal != string.Empty)
                this.cbbStatus.SelectedIndex = this.cbbStatus.FindString(str_StatusLocal);
        }

        // Load các combobox.
        private void loadControl()
        {
            this.notBinding();

            this.loadGender();
            this.loadYearOfBirth();
            this.loadStatus();
            this.loadRole();
            this.loadDepartment();
        }

        // Kiểm tra xem người đó có phải là leader của một phòng hay người duyệt nhiệm vụ nào đó không.
        private bool isHaveRelation(string status, string name)
        {
            if (status == StaticVarClass.status_NotWorking)
            {
                if (DepartmentDAO.Instance.checkLeader(name) == true)
                {
                    XtraMessageBox.Show(name + " is a leader of a department!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (StaticVarClass.formDepartment != null)
                    {
                        // Đóng form đang mở.
                        StaticVarClass.formEmployee.Close();

                        formMain frmmain = formMain.Instance;

                        formDepartment frmDept = new formDepartment();

                        StaticVarClass.formDepartment = frmDept;

                        StaticVarClass.formDepartment.MdiParent = frmmain;

                        frmDept.grvDepartment.FindFilterText = name;

                        StaticVarClass.formDepartment.Activate();
                    }
                    else if (StaticVarClass.formDepartment == null)
                    {
                        formMain frmmain = formMain.Instance;

                        formDepartment frmDept = new formDepartment();

                        StaticVarClass.formDepartment = frmDept;

                        frmDept.MdiParent = frmmain;

                        frmDept.grvDepartment.FindFilterText = name;

                        frmDept.Show();
                    }

                    return true;
                }

                if (ProjectDAO.Instance.checkLeader(name) == true)
                {
                    XtraMessageBox.Show(name + " is a leader of a project!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (StaticVarClass.formProject != null)
                    {
                        // Đóng form đang mở.
                        StaticVarClass.formProject.Close();

                        formMain frmmain = formMain.Instance;

                        formProject frmProject = new formProject();

                        StaticVarClass.formProject = frmProject;

                        StaticVarClass.formProject.MdiParent = frmmain;

                        frmProject.grvProject.FindFilterText = name;

                        StaticVarClass.formProject.Activate();
                    }
                    else if (StaticVarClass.formProject == null)
                    {
                        formMain frmmain = formMain.Instance;

                        formProject frmProject = new formProject();

                        StaticVarClass.formProject = frmProject;

                        frmProject.MdiParent = frmmain;

                        frmProject.grvProject.FindFilterText = name;

                        frmProject.Show();
                    }

                    return true;
                }
                if (TaskCreatingDAO.Instance.checkApprover(name) == true)
                {
                    XtraMessageBox.Show(name + " is an approver of a task!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (StaticVarClass.formTaskCreating != null)
                    {
                        // Đóng form đang mở.
                        StaticVarClass.formProject.Close();

                        formMain frmmain = formMain.Instance;

                        formTaskCreating frmTaskCreating = new formTaskCreating();

                        StaticVarClass.formTaskCreating = frmTaskCreating;

                        StaticVarClass.formTaskCreating.MdiParent = frmmain;

                        frmTaskCreating.grvTaskCreating.FindFilterText = name;

                        StaticVarClass.formTaskCreating.Activate();
                    }
                    else if (StaticVarClass.formTaskCreating == null)
                    {
                        formMain frmmain = formMain.Instance;

                        formTaskCreating frmTaskCreating = new formTaskCreating();

                        StaticVarClass.formTaskCreating = frmTaskCreating;

                        frmTaskCreating.MdiParent = frmmain;

                        frmTaskCreating.grvTaskCreating.FindFilterText = name;

                        frmTaskCreating.Show();
                    }
                    return true;
                }
            }
            return false;
        }

        // Gán dữ liệu.
        private void setData(EmployeeDTO employeeDTO)
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

            employeeDTO.Status = this.cbbStatus.Text.Trim();

            // Khi add người mới, mật khẩu ban đầu mặc định là 123.
            if (this.i_FlagGlobal == 1)
            {
                employeeDTO.Password = "123456";
            }
        }

        private void formEmployee_Load(object sender, EventArgs e)
        {
            // Đặt lại cờ.
            this.i_FlagGlobal = 0;

            this.lyoutControlEmployee.Hide();

            this.loadData();

            // Phân quyền.
            this.Authorize();
        }

        private void formEmployee_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.i_FlagGlobal = 1;

            // Hiện thanh cho phép người dùng chỉnh sửa.
            this.lyoutControlEmployee.Show();

            this.clearData();
            this.disable(true);   // Điều khiển các nút.
            this.btnSave.Enabled = false;

            this.loadControl();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.i_FlagGlobal = 2;

            // Hiện thanh cho phép người dùng chỉnh sửa.
            this.lyoutControlEmployee.Show();

            this.loadControl();
            this.disable(true); // Điều khiển các nút.
            this.btnSave.Enabled = true;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EmployeeDTO employeeDTOLocal = new EmployeeDTO();

            string str_NameLocal = this.txtEdtName.Text.Trim();

            // Gán giá trị vào thuộc tính trong bảng.
            this.setData(employeeDTOLocal);

            #region Thêm mới.
            if (this.i_FlagGlobal == 1)
            {
                if (EmployeeDAO.Instance.addData(employeeDTOLocal))
                {
                    ftp ftpClientLocal = new ftp(StaticVarClass.ftp_Server, StaticVarClass.ftp_Username, StaticVarClass.ftp_Password);

                    ftpClientLocal.createDirectory(employeeDTOLocal.Name);
          
                        #region Cập nhật lịch sử.
                        string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add employee " + str_NameLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully added employee " + str_NameLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove employee " + str_NameLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Add employee " + str_NameLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            #region Sửa.
            else if (this.i_FlagGlobal == 2)
            {
                // Sửa.
                if (EmployeeDAO.Instance.updateDataNotAllColumns(employeeDTOLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit employee " + str_NameLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully edited employee " + str_NameLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit employee " + str_NameLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Edit employee " + str_NameLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            formEmployee_Load(sender, e);
        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str_NameLocal = this.txtEdtName.Text.Trim();

            // Hộp thoại xác nhận khi nhấn nút xóa.
            DialogResult dr = XtraMessageBox.Show("Are you sure you want to remove employee " + str_NameLocal + "?", "Confirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Xóa.
                if (EmployeeDAO.Instance.deleteData(str_NameLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove employee " + str_NameLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully removed employee " + str_NameLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Remove employee " + str_NameLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Remove employee " + str_NameLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            else
            {
                return;
            }

            formEmployee_Load(sender, e);
        }

        private void txtEdtName_EditValueChanged(object sender, EventArgs e)
        {
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal == 1 && str_NameLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
            else if (this.i_FlagGlobal == 1 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty 
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
        }

        private void cbbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_GenderLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbGender_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectGenderGlobal = true;
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_GenderLocal == string.Empty)
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
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_YearOfBirthLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbYearOfBirth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectYearOfBirthGlobal = true;
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_YearOfBirthLocal == string.Empty)
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
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_EmailLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }

            // 
            this.txtEdtEmail.Text = this.txtEdtEmail.Text.Trim();
        }

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_RoleLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbRole_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectRoleGlobal = true;
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_RoleLocal == string.Empty)
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
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_DepartmentLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectDepartmentGlobal = true;
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal != 0 && str_DepartmentLocal == string.Empty)
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

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                if (this.isHaveRelation(str_StatusLocal, str_NameLocal) == true)
                {
                    this.btnRefresh_ItemClick(null, null);
                }
                else
                {
                    this.btnSave.Enabled = true;
                }
            }
            else if (this.i_FlagGlobal != 0 && str_StatusLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectStatusGlobal = true;
            string str_NameLocal = this.txtEdtName.Text.Trim();
            string str_GenderLocal = this.cbbGender.GetItemText(this.cbbGender.SelectedItem).Trim();
            string str_YearOfBirthLocal = this.cbbYearOfBirth.GetItemText(this.cbbYearOfBirth.SelectedItem).Trim();
            string str_EmailLocal = this.txtEdtEmail.Text.Trim();
            string str_RoleLocal = this.cbbRole.GetItemText(this.cbbRole.SelectedItem).Trim();
            string str_DepartmentLocal = this.cbbDepartment.GetItemText(this.cbbDepartment.SelectedItem).Trim();
            string str_StatusLocal = this.cbbStatus.GetItemText(this.cbbStatus.SelectedItem).Trim();

            if (this.i_FlagGlobal != 0 && str_NameLocal != string.Empty && str_GenderLocal != string.Empty
                && str_YearOfBirthLocal != string.Empty && str_EmailLocal != string.Empty
                && str_RoleLocal != string.Empty && str_DepartmentLocal != string.Empty
                && str_StatusLocal != string.Empty)
            {
                if (this.isHaveRelation(str_StatusLocal, str_NameLocal) == true)
                {
                    this.btnRefresh_ItemClick(null, null);
                }
                else
                {
                    this.btnSave.Enabled = true;
                }
            }
            else if (this.i_FlagGlobal != 0 && str_StatusLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbStatus_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectStatusGlobal == false)
                this.btnSave.Enabled = false;
            else
                this.b_IsSelectStatusGlobal = false;
        }

        private void cbbStatus_DropDown(object sender, EventArgs e)
        {
            this.cbbStatus.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbStatus.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbStatus_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbStatus.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbStatus.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txtEdtFullName_EditValueChanged(object sender, EventArgs e)
        {
            this.txtEdtFullName.Text = this.txtEdtFullName.Text.Trim();
        }

        private void txtEdtPhone_EditValueChanged(object sender, EventArgs e)
        {
            this.txtEdtPhone.Text = this.txtEdtPhone.Text.Trim();
        }

        private void txtEdtPosition_EditValueChanged(object sender, EventArgs e)
        {
            this.txtEdtPosition.Text = this.txtEdtPosition.Text.Trim();
        }

        private void txtEdtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtFullName.Focus();
            }
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
                this.cbbStatus.Select();
            }
        }

        private void cbbStatus_KeyDown(object sender, KeyEventArgs e)
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
                this.txtEdtName.Focus();
            }
        }

        private void formEmployee_KeyUp(object sender, KeyEventArgs e)
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
            this.formEmployee_Load(sender, e);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formEmployee = null;

            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formEmployee = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}