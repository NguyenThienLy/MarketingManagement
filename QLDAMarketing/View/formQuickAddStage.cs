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
    public partial class formQuickAddStage : DevExpress.XtraEditors.XtraForm
    {
        string str_ProjectIDGlobal = string.Empty;
        string str_StageGlobal = string.Empty;

        public formQuickAddStage()
        {
            InitializeComponent();
            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
        }

        // Hiển thị các thông tin có sẵn.
        private void loadInfo()
        {
            this.txtEdtProjectID.Text = this.str_ProjectIDGlobal;
            this.txtEdtStage.Text = this.str_StageGlobal;
            this.txtEdtProjectID.ReadOnly = true;
            this.txtEdtStage.ReadOnly = true;
        }

        public void setInfo(string projectID, string stage)
        {
            this.str_ProjectIDGlobal = projectID;
            this.str_StageGlobal = stage;
        }

        private void formAddStage_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.LightGreen;

            this.loadInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Lưu thông tin của stage mới vào bảng STAGE.
            string str_ProjectIDLocal= this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.txtEdtStage.Text.Trim();
            string str_StageSubjectLocal = this.txtEdtStageSubject.Text.Trim();
            string str_StatusLocal = StaticVarClass.status_NotComplete;

            StageDTO stageDTOTemp = new StageDTO(str_ProjectIDLocal, str_StageLocal, str_StageSubjectLocal, str_StatusLocal);

            if (StageDAO.Instance.addData(stageDTOTemp))
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
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void txtEdtStageSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnSave.Enabled == true)
                    this.btnSave.PerformClick();
                else
                    this.txtEdtStageSubject.Focus();
            }
        }

        private void txtEdtStageSubject_EditValueChanged(object sender, EventArgs e)
        {
            this.txtEdtStage.Text = this.txtEdtStage.Text.Trim();
        }

        private void formQuickAddStage_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}