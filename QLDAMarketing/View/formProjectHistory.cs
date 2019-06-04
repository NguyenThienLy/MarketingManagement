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
using DevExpress.LookAndFeel;
using ProjectManagement.BUS;

namespace ProjectManagement.View
{
    public partial class formProjectHistory : DevExpress.XtraEditors.XtraForm
    {
        // Cờ đánh dấu là Admin.
        bool b_IsAdminGlobal = false;

        // Chạy lần đầu tiên.
        //bool b_IsFirstGlobal = true;
        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();

        public formProjectHistory()
        {
            InitializeComponent();

            this.addTabColor();
            this.loadColorDefault();
            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
        }

        // Xét quyền hạn của nhân viên.
        private void Authorize()
        {
            string str_RoleLocal = string.Empty;

            str_RoleLocal = EmployeeBUS.Instance.getStringRoleFollowName(StaticVarClass.account_Username);

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
                this.disable(true);
                this.b_IsAdminGlobal = false;
            }
            else if (str_RoleLocal == StaticVarClass.role_Staff)
            {
                this.disable(true);
                this.b_IsAdminGlobal = false;
            }
        }

        private void disable(bool e)
        {
            this.cbbEmployee.Enabled = !e;
        }

        // Chạy thông tin của user.
        private void loadMyUser()
        {
            this.cbbEmployee.Text = StaticVarClass.account_Username;
        }

        // Load thông tin đang search.
        private void loadSearchInfo()
        {
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();
            if (str_EmployeeLocal == "All")
                str_EmployeeLocal = string.Empty;

            string str_StartDateLocal = this.dtEdtStartDate.Text.Trim();
            string str_EndDateLocal = this.dtEdtEndDate.Text.Trim();
            string str_POSMProjectLocal = this.getPOSMProject();
            string str_StatusLocal = this.getStatus();

            DataTable dt_ProjectHistoryLocal = TaskCreatingBUS.Instance.getDataForFormProjectHistory(str_EmployeeLocal, str_StartDateLocal, str_EndDateLocal, str_POSMProjectLocal, str_StatusLocal);
            List<string> lst_QuanlityLocal = TaskCreatingBUS.Instance.getDataListQuantityForFormProjectHistory(str_EmployeeLocal, str_StartDateLocal, str_EndDateLocal, str_POSMProjectLocal);

            if (dt_ProjectHistoryLocal != null && lst_QuanlityLocal != null)
            {
                // Nếu lấy ra bảng không có phần tử nào, ko cho export.
                if (dt_ProjectHistoryLocal.Rows.Count == 0)
                    this.btnExport.Enabled = false;
                else
                    this.btnExport.Enabled = true;

                this.grdCtrlProjectHistory.DataSource = dt_ProjectHistoryLocal;

                this.loadQuanlityListTaskCreating(lst_QuanlityLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Xem người dùng có chọn dấu POSM không.
        private string getPOSMProject()
        {
            if (this.ChkBxPOSMProject.Checked == true)
            {
                return StaticVarClass.YN_Yes;
            }

            return StaticVarClass.YN_No;
        }

        // Xem người dùng đang chọn tab page nào.
        private string getStatus()
        {
            int i_PageIndex = this.tbCtrlProjectHistory.SelectedIndex;

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

        // Load danh sách các nhân viên.
        private void loadEmployee()
        {
            DataTable dtLocal = EmployeeBUS.Instance.getDataNotAllColumns();

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string name = row["NAME"].ToString();
                    row["NAME"] = name.Trim();
                }

                DataRow rowTemp = dtLocal.NewRow();
                rowTemp["NAME"] = "All";
                dtLocal.Rows.Add(rowTemp);

                this.cbbEmployee.DataSource = dtLocal;
                this.cbbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbEmployee.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbEmployee.DisplayMember = "NAME";
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        private void loadMainInfo()
        {
            this.Authorize();
            this.loadSearchInfo();
        }

        //private void SetTabHeader(TabPage page, Color color)
        //{
        //    this.TabColors[page] = color;
        //    tbCtrlProjectHistory.Invalidate();
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

        private void formProjectHistory_Load(object sender, EventArgs e)
        {
            this.tbCtrlProjectHistory.SelectedIndex = 1;

            this.loadEmployee();
            this.loadSearchInfo();
            this.loadMyUser();
            this.Authorize();
        }

        private void formProjectHistory_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Are you sure you want to export?", "Confirm export", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { ValidateNames = true, Filter = "Excel (*.xlsx) | *.xlsx;" })
                {
                    // Nếu người dùng đã chọn được file excel.
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        if (sfd.FileName != null)
                        {
                            Cursor.Current = Cursors.WaitCursor;

                            this.grdCtrlProjectHistory.ExportToXlsx(sfd.FileName);

                            XtraMessageBox.Show("Successfully exported!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Load xong.
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void btnTaskDetail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            System.Data.DataRow dtR_rowLocal = grvProjectHistory.GetDataRow(grvProjectHistory.FocusedRowHandle);
            string str_ProjectIDLocal = dtR_rowLocal[0].ToString().Trim();
            string str_StageLocal = dtR_rowLocal[1].ToString().Trim();
            string str_TaskLocal = dtR_rowLocal[2].ToString().Trim();
            string str_Employeelocal = dtR_rowLocal[3].ToString().Trim();

            formTaskDetail frmTaskDetailLocal = new formTaskDetail();
            frmTaskDetailLocal.setInformation(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_Employeelocal);
            frmTaskDetailLocal.ShowDialog();
        }

        private void tbCtrlProjectHistory_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            using (Brush br = new SolidBrush(TabColors[tbCtrlProjectHistory.TabPages[e.Index]]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
                SizeF sz = e.Graphics.MeasureString(tbCtrlProjectHistory.TabPages[e.Index].Text, this.tbCtrlProjectHistory.Font);

                var x = e.Bounds.Left + (e.Bounds.Width - e.Graphics.MeasureString(this.tbCtrlProjectHistory.TabPages[e.Index].Text, this.tbCtrlProjectHistory.Font).Width) / 2;
                var y = e.Bounds.Top + (e.Bounds.Height - e.Graphics.MeasureString(this.tbCtrlProjectHistory.TabPages[e.Index].Text, this.tbCtrlProjectHistory.Font).Height) / 2;
                e.Graphics.DrawString(this.tbCtrlProjectHistory.TabPages[e.Index].Text, this.tbCtrlProjectHistory.Font, Brushes.Black, x, y);

                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(0, 0);
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                e.DrawFocusRectangle();
            }
        }

        private void tbCtrlProjectHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadMainInfo();
        }

        private void ChkBxPOSMProject_CheckedChanged(object sender, EventArgs e)
        {
            this.loadMainInfo();
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
            this.loadMainInfo();
        }

        private void dtEdtStartDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loadMainInfo();
            }
        }

        private void dtEdtEndDate_EditValueChanged(object sender, EventArgs e)
        {
            this.loadMainInfo();
        }

        private void dtEdtEndDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.loadSearchInfo();
            }
        }

        private void cbbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();

            if (str_EmployeeLocal != string.Empty)
                this.loadMainInfo();
        }

        private void cbbEmployee_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string str_EmployeeLocal = this.cbbEmployee.GetItemText(this.cbbEmployee.SelectedItem).Trim();

            if (str_EmployeeLocal != string.Empty)
                this.loadMainInfo();
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

        private void formProjectHistory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.b_IsAdminGlobal == true)
                {
                    if (this.btnExport.Enabled == true)
                    {
                        if (e.KeyCode.Equals(Keys.E))
                        {
                            btnExport_ItemClick(null, null);
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
            formProjectHistory_Load(sender, e);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formProjectHistory = null;
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formProjectHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formProjectHistory = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}