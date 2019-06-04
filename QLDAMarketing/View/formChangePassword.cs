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
using ProjectManagement.BUS;

namespace ProjectManagement.View
{
    public partial class formChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public formChangePassword()
        {
            InitializeComponent();

            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;

            btnSave.Enabled = false;
            txtEdtNewPassword.ReadOnly = true;
            txtEdtConfirmNewPassword.ReadOnly = true;
        }

        private void txtEdtCurrentPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (txtEdtCurrentPassword.Text.Trim() != string.Empty)
            {
                txtEdtNewPassword.ReadOnly = false;
                txtEdtConfirmNewPassword.ReadOnly = false;

                if (txtEdtConfirmNewPassword.Text.Trim() != string.Empty)
                {
                    btnSave.Enabled = true;
                }
            }
            else
            {
                txtEdtNewPassword.ReadOnly = true;
                txtEdtConfirmNewPassword.ReadOnly = true;
                btnSave.Enabled = false;
            }

        }

        private void txtEdtNewPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (txtEdtNewPassword.Text.Trim() != string.Empty)
            {
                txtEdtConfirmNewPassword.ReadOnly = false;
            }
            else
            {
                txtEdtConfirmNewPassword.Text = string.Empty;
                txtEdtConfirmNewPassword.ReadOnly = true;
                btnSave.Enabled = false;
            }
        }

        private void txtEdtConfirmNewPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (txtEdtConfirmNewPassword.Text.Trim() != string.Empty)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string str_CurrentPasswordLocal = txtEdtCurrentPassword.Text.Trim();
            string str_NewPasswordLocal = txtEdtNewPassword.Text.Trim();
            string str_ConfirmNewPasswordLocal = txtEdtConfirmNewPassword.Text.Trim();
            int i_CompareLocal = 0;

            if (StaticVarClass.account_Password != str_CurrentPasswordLocal)
            {
                XtraMessageBox.Show("Current password does not match. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                i_CompareLocal = String.Compare(str_NewPasswordLocal, str_ConfirmNewPasswordLocal, false);

                if (i_CompareLocal == 0)
                {
                    if (EmployeeBUS.Instance.updateDataPassword(StaticVarClass.account_Username, str_ConfirmNewPasswordLocal))
                    {
                        StaticVarClass.account_Password = str_ConfirmNewPasswordLocal;

                        #region Cập nhật lịch sử.
                        string name = StaticVarClass.account_Username;
                        string time = DateTime.Now.ToString();
                        string action = "Change password";
                        string status = "Successful";

                        HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                        HistoryDAO.Instance.addData(hisDTO);
                        #endregion

                        XtraMessageBox.Show("Successfully changed password", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        #region Cập nhật lịch sử.
                        string name = StaticVarClass.account_Username;
                        string time = DateTime.Now.ToString();
                        string action = "Change password";
                        string status = "Failed";

                        HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                        HistoryDAO.Instance.addData(hisDTO);
                        #endregion

                        XtraMessageBox.Show("Change password failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("New passwords do not match. Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtEdtCurrentPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEdtNewPassword.Focus();
            }
        }

        private void txtEdtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEdtConfirmNewPassword.Focus();
            }
        }

        private void txtEdtConfirmNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEdtConfirmNewPassword.Text.Trim() != string.Empty)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Enabled = true;
                    btnSave.PerformClick();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnCancel.PerformClick();
                }
            }
        }

        private void formChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}