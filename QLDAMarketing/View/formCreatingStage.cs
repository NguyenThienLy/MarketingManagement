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

namespace ProjectManagement.View
{
    public partial class formCreatingStage : DevExpress.XtraEditors.XtraForm
    {
        string str_ProjectGlobal = string.Empty;
        int i_StageGlobal = 1;

        public formCreatingStage()
        {
            InitializeComponent();
            lyoutControlStage.OptionsFocus.EnableAutoTabOrder = false;
            this.btnNext.Enabled = false;
        }

        private void enableControl()
        {
            this.txtEdtStage.ReadOnly = true;
            this.txtEdtProjectID.ReadOnly = true;
        }

        // Load các mã dự án.
        private void loadProjectID()
        {
            this.txtEdtProjectID.Text = str_ProjectGlobal;
        }

        private void loadControl()
        {
            this.loadProjectID();
        }

        public void setInfo(string project)
        {
            this.str_ProjectGlobal = project;
        }

        // Xóa trước khi thêm.
        private void clearData()
        {
            this.txtEdtStage.Text = string.Empty;
            this.txtEdtStageSubject.Text = string.Empty;
            this.txtEdtStage.Text = this.i_StageGlobal.ToString();
        }

        // Gán dữ liệu.
        private void setData(StageDTO stageDTO)
        {
            stageDTO.ProjectID = this.txtEdtProjectID.Text.Trim();
            stageDTO.Stage = this.txtEdtStage.Text.Trim();
            stageDTO.StageSubject = this.txtEdtStageSubject.Text.Trim();
            stageDTO.Status = StaticVarClass.status_NotComplete;
        }

        private void formCreatingStage_Load(object sender, EventArgs e)
        {
            this.enableControl();
            this.clearData();
            this.loadControl();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.txtEdtProjectID.Text.Trim();
            string str_StageLocal = this.txtEdtStage.Text.Trim();

            StageDTO stageDTOLocal = new StageDTO();

            // Gán giá trị vào thuộc tính trong bảng.
            setData(stageDTOLocal);

            #region Thêm mới.
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

                this.btnNext.Enabled = true;

                // Tăng stage lên và kiểm tra có lớn hơn 20 stage không.
                i_StageGlobal++;
                if (i_StageGlobal > 20)
                    this.btnOK.Enabled = false;

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
            #endregion


            this.formCreatingStage_Load(null, null);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (btnNext.Enabled == true)
            {
                this.Hide();

                formProjectCreating frmProjectCreating = formProjectCreating.Instance;
                formCreatingTask frmCreatingTask = new formCreatingTask();
                frmCreatingTask.setInfo(this.str_ProjectGlobal);
                frmCreatingTask.MdiParent = frmProjectCreating;
                frmCreatingTask.Show();
            }
        }

        private void txtEdtStageSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnOK.Enabled == true)
                    this.btnOK.PerformClick();
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