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
    public partial class formDepartment : DevExpress.XtraEditors.XtraForm
    {
        // Cờ đánh dấu Add hay Edit hay không làm gì cả.
        int i_FlagGlobal = 0;

        string str_OldDepartmentForUpdateGlobal = string.Empty;

        // Cờ xử lí sự kiện chọn value ô combobox Leader: phân biệt textchange.
        bool b_IsSelectLeaderGlobal = false;

        // Cờ đánh dấu Admin.
        bool b_IsAdminGlobal = false;

        // Cờ đánh dấu empty data.
        bool b_IsEmptyData = false;

        public formDepartment()
        {
            InitializeComponent();
            lyoutControlDepartment.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void loadData()
        {
            DataTable dtDepartment = new DataTable();
            dtDepartment = DepartmentDAO.Instance.getData();

            if (dtDepartment != null)
            {
                this.grdCtrlDepartment.DataSource = dtDepartment;
                this.binding();

                if (dtDepartment.Rows.Count == 0)
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
            this.txtEdtDepartment.DataBindings.Clear();
            this.txtEdtDepartment.DataBindings.Add("Text", grdCtrlDepartment.DataSource, "DEPARTMENT");

            this.cbbLeader.DataBindings.Clear();
            this.cbbLeader.DataBindings.Add("Text", grdCtrlDepartment.DataSource, "LEADER");
        }

        private void notBinding()
        {
            this.txtEdtDepartment.DataBindings.Clear();
            this.cbbLeader.DataBindings.Clear();
        }

        // Khóa các phím.
        private void disable(bool e)
        {
            if (this.i_FlagGlobal == 1)
            {
                this.txtEdtDepartment.ReadOnly = false;
                this.cbbLeader.Enabled = false;
            }
            else if (this.i_FlagGlobal == 2)
            {
                this.txtEdtDepartment.ReadOnly = true;
                this.cbbLeader.Enabled = true;
            }
            else
            {
                this.txtEdtDepartment.ReadOnly = true;
                this.cbbLeader.Enabled = false;
            }

            // Mở khoá/ khóa các nút.
            this.btnAdd.Enabled = !e;
            this.btnEdit.Enabled = !e;
            this.btnSave.Enabled = e;

            // Nếu ko có data.
            if (this.b_IsEmptyData == true)
            {
                this.btnEdit.Enabled = false;
            }
        }

        // Khóa tất cả các phím.
        private void disableAll()
        {
            this.txtEdtDepartment.ReadOnly = true;
            this.cbbLeader.Enabled = false;

            this.btnAdd.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = false;

        }

        // Xóa sạch trước khi thêm.
        private void clearData()
        {
            this.txtEdtDepartment.Text = string.Empty;
            this.cbbLeader.Text = string.Empty;
        }

        // Hiện lên tất cả các nhân viên trong cty.
        private void loadLeader()
        {
            string str_DepartmentLocal = this.txtEdtDepartment.Text.Trim();
            string str_LeaderLocal = this.cbbLeader.Text.Trim();

            DataTable dtLocal = EmployeeDAO.Instance.getDataFollowDepartment(str_DepartmentLocal);

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

        private void loadControl()
        {
            this.notBinding();

            if (this.i_FlagGlobal == 2)
                this.loadLeader();
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        // Gán dữ liệu.
        private void setData(DepartmentDTO deptDTO)
        {
            if (this.i_FlagGlobal == 1)
                deptDTO.Department = this.txtEdtDepartment.Text.Trim();
            else if (this.i_FlagGlobal == 2)
                deptDTO.Department = this.str_OldDepartmentForUpdateGlobal;
            
            if (this.cbbLeader.Text.Trim() == string.Empty)
                deptDTO.Leader = null;
            else
                deptDTO.Leader = this.cbbLeader.Text.Trim();
        }

        private void formDepartment_Load(object sender, EventArgs e)
        {
            // Đặt lại cờ.
            this.i_FlagGlobal = 0;

            this.lyoutControlDepartment.Hide();

            this.loadData();

            // Phân quyền.
            this.Authorize();
        }

        private void formDepartment_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.i_FlagGlobal = 1;

            this.lyoutControlDepartment.Show();

            this.clearData();
            this.disable(true); // Điều khiển các nút.
            this.btnSave.Enabled = false;
            this.loadControl();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.str_OldDepartmentForUpdateGlobal = this.txtEdtDepartment.Text.Trim();

            this.i_FlagGlobal = 2;

            this.lyoutControlDepartment.Show();

            this.loadControl();
            this.disable(true); // Điều khiển các nút.
            this.btnSave.Enabled = true;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DepartmentDTO deptDTOLocal = new DepartmentDTO();

            string str_DepartmentLocal = this.txtEdtDepartment.Text.Trim(); // tên department mới (nếu có)

            if (str_DepartmentLocal == string.Empty)
                str_DepartmentLocal = null;

            // Gán giá trị vào thuộc tính trong bảng.
            setData(deptDTOLocal);

            #region Thêm mới.
            if (this.i_FlagGlobal == 1)
            {
                if (DepartmentDAO.Instance.addData(deptDTOLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add department " + deptDTOLocal.Department;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully added department " + deptDTOLocal.Department + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Add department " + deptDTOLocal.Department;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Add department " + deptDTOLocal.Department + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            #region Sửa
            else if (this.i_FlagGlobal == 2)
            {
                // Sửa.
                if (DepartmentDAO.Instance.updateData(deptDTOLocal, str_DepartmentLocal))
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit department " + deptDTOLocal.Department;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully edited department " + deptDTOLocal.Department + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit department " + deptDTOLocal.Department;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Edit department " + deptDTOLocal.Department + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }
            #endregion

            formDepartment_Load(sender, e);
        }

        private void txtEdtDepartment_EditValueChanged(object sender, EventArgs e)
        {
            string str_DepartmentLocal = this.txtEdtDepartment.Text.Trim();

            if (this.i_FlagGlobal == 1 && str_DepartmentLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal == 1 && str_DepartmentLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }

            this.txtEdtDepartment.Text = this.txtEdtDepartment.Text.Trim();
        }

        private void cbbLeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();

            if (this.i_FlagGlobal == 2 && str_LeaderLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal == 2 && str_LeaderLocal == string.Empty)
            {
                this.btnSave.Enabled = false;
            }
        }

        private void cbbLeader_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectLeaderGlobal = true;
            string str_LeaderLocal = this.cbbLeader.GetItemText(this.cbbLeader.SelectedItem).Trim();

            if (this.i_FlagGlobal == 2 && str_LeaderLocal != string.Empty)
            {
                this.btnSave.Enabled = true;
            }
            else if (this.i_FlagGlobal == 2 && str_LeaderLocal == string.Empty)
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

        private void txtEdtDepartment_KeyDown(object sender, KeyEventArgs e)
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
                this.txtEdtDepartment.Focus();
            }
        }

        private void formDepartment_KeyUp(object sender, KeyEventArgs e)
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
            formDepartment_Load(sender, e);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formDepartment = null;
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formDepartment_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formDepartment = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        //const float defaultFontSize = 11;

        //private void zoomTrackBarControl1_EditValueChanged(object sender, EventArgs e)
        //{
        //    float fontSize = defaultFontSize;
        //    fontSize += Convert.ToInt32(zoomTrackBarControl1.EditValue);
        //    Font fnt = new Font(grvDepartment.Appearance.Row.Font.Name, fontSize);
        //    grvDepartment.Appearance.HeaderPanel.Font = fnt;
        //    grvDepartment.Appearance.Row.Font = fnt;
        //}
    }
}