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
using ProjectManagement.BUS;

namespace ProjectManagement.View
{
    public partial class formHistory : DevExpress.XtraEditors.XtraForm
    {
        // Cờ đánh dấu Admin.
        bool b_IsAdminGlobal = false;

        // Cờ đánh dấu empty data.
        bool b_IsEmptyData = false;

        public formHistory()
        {
            InitializeComponent();
        }

        private void loadData()
        {
            DataTable dtHistory = new DataTable();

            dtHistory = HistoryBUS.Instance.getData();

            if (dtHistory != null)
            {
                grdCtrlHistory.DataSource = dtHistory;

                if (dtHistory.Rows.Count == 0)
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

            if (str_RoleLocal == "Admin")
            {
                this.disable();
                this.b_IsAdminGlobal = true;
            }
            else if (str_RoleLocal == "Member")
            {
                this.disableAll();
                this.b_IsAdminGlobal = false;
            }
            else if (str_RoleLocal == "Staff")
            {
                this.disableAll();
                this.b_IsAdminGlobal = false;
            }
        }

        // Mở nút Remove All.
        private void disable()
        {
            btnRemoveAll.Enabled = true;
            this.grvHistory.Columns[4].Visible = true;

            // Nếu không có data.
            if (this.b_IsEmptyData == true)
            {
                btnRemoveAll.Enabled = false;
                this.grvHistory.Columns[4].Visible = false;
            }
        }

        // Khóa nút Remove All.
        private void disableAll()
        {
            btnRemoveAll.Enabled = false;
            this.grvHistory.Columns[4].Visible = false;
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = true;
        }

        private void formHistory_Load(object sender, EventArgs e)
        {
            this.loadData();

            // Phân quyền.
            this.Authorize();
        }

        private void formHistory_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();
        }

        private void btnRemoveAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Hộp thoại xác nhận khi nhấn nút xóa.
            DialogResult dr = XtraMessageBox.Show("Are you sure you want to remove all history?", "Confirm remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Xóa.
                if (HistoryBUS.Instance.deleteData())
                {
                    XtraMessageBox.Show("Successfully removed all history!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    XtraMessageBox.Show("Remove all history failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
            }

            formHistory_Load(sender, e);
        }

        private void btnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            System.Data.DataRow dtR_rowLocal = grvHistory.GetDataRow(grvHistory.FocusedRowHandle);

            string str_Name = dtR_rowLocal[0].ToString().Trim();
            string str_Time = dtR_rowLocal[1].ToString().Trim();

            if (!HistoryBUS.Instance.deleteDataFollowNameAndTime(str_Name, str_Time))
            {
                XtraMessageBox.Show("Remove history failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            formHistory_Load(sender, e);
        }

        private void formHistory_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (this.b_IsAdminGlobal == true)
                {
                    if (btnRemoveAll.Enabled == true)
                    {
                        if (e.KeyCode.Equals(Keys.R))
                        {
                            btnRemoveAll_ItemClick(null, null);
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
            this.formHistory_Load(sender, e);
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StaticVarClass.formHistory = null;

            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            StaticVarClass.formHistory = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}