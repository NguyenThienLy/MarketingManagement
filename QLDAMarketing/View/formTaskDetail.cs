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
using System.Net.Mail;
using System.IO;
using ProjectManagement.BUS;

namespace ProjectManagement.View
{
    public partial class formTaskDetail : DevExpress.XtraEditors.XtraForm
    {
        int i_FlagMailGlobal = 0;  // Cờ xác nhận đã gửi email thành công.
        //int i_FlagUploadGlobal = 0; // Cờ xác nhận đã đăng tải file thành công.

        // Cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectReceiveEmailAddressGlobal = false;
        // Cờ báo khóa tất cả các control.
        bool b_IsBlockAll = false;

        string str_ProjectIDGlobal = string.Empty;
        string str_StageGlobal = string.Empty;
        string str_TaskGlobal = string.Empty;
        string str_EmployeeGlobal = string.Empty;

        public formTaskDetail()
        {
            InitializeComponent();

            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
            layoutControl2.OptionsFocus.EnableAutoTabOrder = false;
            layoutControl3.OptionsFocus.EnableAutoTabOrder = false;
        }

        public void setInformation(string projectID, string stage, string task, string employee)
        {
            this.str_ProjectIDGlobal = projectID;
            this.str_StageGlobal = stage;
            this.str_TaskGlobal = task;
            this.str_EmployeeGlobal = employee;
        }

        // Xét quyền hạn của nhân viên.
        private void Authorize()
        {
            string str_StatusCurrProjectLocal = ProjectBUS.Instance.getStringStatusFollowProjectID(this.str_ProjectIDGlobal);
            string str_StatusCurrStageLocal = StageBUS.Instance.getStringStatusFollowProjectIDAndStage(this.str_ProjectIDGlobal, this.str_StageGlobal);
            string str_StatusBeforeStageLocal = StageBUS.Instance.getStringStatusFollowProjectIDAndStageBefore(this.str_ProjectIDGlobal, this.str_StageGlobal);
            string str_StatusCurrTaskLocal = TaskCreatingBUS.Instance.getStringStatusFollowAllPrimaryKeys(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);
            TaskCreatingDTO taskCreatingDTOLocal = TaskCreatingBUS.Instance.getDataObjectFollowProjectIDAndStageAndTask(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);

            if (str_StatusCurrStageLocal == null || str_StatusBeforeStageLocal == null || str_StatusCurrTaskLocal == null || str_StatusCurrProjectLocal == null || taskCreatingDTOLocal == null)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (str_StatusCurrStageLocal == string.Empty || str_StatusCurrTaskLocal == string.Empty || str_StatusCurrProjectLocal == string.Empty || taskCreatingDTOLocal.Empty() == true)
            {
                XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nếu project hiện tại đã hoàn thành.
            if (str_StatusCurrProjectLocal == StaticVarClass.status_Complete)
            {
                this.disableAll();
                b_IsBlockAll = true;
            }
            else
            {
                // Nếu stage của task đó hoàn thành rồi thì vào chỉ được xem.
                if (str_StatusCurrStageLocal == StaticVarClass.status_Complete)
                {
                    this.disableAll();
                    b_IsBlockAll = true;
                }
                else
                {
                    // Nếu status task hoàn thành thì chỉ được xem.
                    if (str_StatusCurrTaskLocal == StaticVarClass.status_Complete)
                    {
                        this.disableAll();
                        b_IsBlockAll = true;
                    }
                    else
                    {
                        // Nếu status stage trước đó không hoàn thành thì chỉ được xem.
                        if (str_StatusBeforeStageLocal == StaticVarClass.status_NotComplete)
                        {
                            this.disableAll();
                            b_IsBlockAll = true;
                        }

                        else
                        {
                            if (StaticVarClass.account_Username != this.str_EmployeeGlobal)
                            {
                                this.disableAll();
                                b_IsBlockAll = true;
                            }
                            else
                            {
                                string str_StartDateCurrTaskTemp = taskCreatingDTOLocal.StartDate;
                                if (DateTime.Now < DateTime.Parse(str_StartDateCurrTaskTemp))
                                {
                                    this.disableAll();
                                    b_IsBlockAll = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void disableAll()
        {
            this.nmrUpDwnProgress.Enabled = false;
            this.btnBrowseUpload.Enabled = false;
            this.btnUpload.Enabled = false;
            this.btnSend.Enabled = false;
            this.cbbReceiveEmailAddress.Enabled = false;
            this.txtedtSubject.ReadOnly = true;
            this.rchTxBxMessage.ReadOnly = true;
            this.txtEdtNoteUpload.ReadOnly = true;
            this.txtedtSendEmailAddress.ReadOnly = true;

            this.grvAttachment.Columns[3].Visible = false;
        }

        // Ẩn tabPage attachFile theo attach file.
        private void hideFollowAttachFile()
        {
            string str_AttachFileLocal = TaskCreatingBUS.Instance.getStringAttachFileFollowAllPrimaryKeys(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);

            if (str_AttachFileLocal == StaticVarClass.attachFile_No)
            {
                this.tbpgAttachment.Hide();
            }
            else if (str_AttachFileLocal == StaticVarClass.attachFile_Yes)
            {
                this.tbpgAttachment.Show();
            }
        }
        
        // Chạy tab page đang đc chọn.
        private void loadTabPageSelect()
        {
            int i_IndexPageTaskDetailLocal = this.tbpnTaskDetail.SelectedPageIndex;

            switch (i_IndexPageTaskDetailLocal)
            {
                case 0: // tp information.
                    this.loadInformation();

                    break;
                case 1: // tp email.
                    // Đóng các control.
                    this.disableEmail();

                    this.loadEmailRecieve();

                    this.txtedtSendEmailAddress.Text = EmployeeBUS.Instance.getStringEmailFollowName(this.str_EmployeeGlobal);

                    this.cbbReceiveEmailAddress.Enabled = true;

                    this.cbbReceiveEmailAddress.Focus();

                    break;
                case 2:  // tp attach file.
                    this.loadDataAttachFile();

                    this.hideFollowAttachFile();

                    int i_IndexPageUpDow = this.tbPnUploadDowload.SelectedPageIndex;

                    switch (i_IndexPageUpDow)
                    {
                        case 0: // tp upload.
                            this.disableAttachFileUpload(true);

                            //this.btnUpload.Enabled = true;
                            //this.btnUpload.PerformClick();
                            break;

                        case 1: // tp dowload.
                            this.disableAttachFileDownload(true);

                            //this.btnDownload.Enabled = true;
                            //this.btnDownload.PerformClick();
                            break;
                    }
                    break;
            }
        }

        private void formTaskDetail_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.LightGreen;
            this.hideFollowAttachFile();

            this.enabledFollowStatus();

            this.resetConfirm();

            this.loadTabPageSelect();

            // Phân quyền.
            this.Authorize();

        }

        private void tbpnTaskDetail_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            this.loadTabPageSelect();

            if (b_IsBlockAll == true)
                this.disableAll();
        }

        private void formTaskDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        #region tp thông tin.
        private void loadInformation()
        {
            if (this.str_ProjectIDGlobal == string.Empty || this.str_StageGlobal == string.Empty || this.str_TaskGlobal == string.Empty)
                return;

            // Chạy thông tin nhân viên được chọn.
            TaskCreatingDTO taskCreatingDTOLocal = TaskCreatingBUS.Instance.getDataObjectFollowProjectIDAndStageAndTask(this.str_ProjectIDGlobal, this.str_StageGlobal, str_TaskGlobal);

            this.txtEdtProjectID.Text = taskCreatingDTOLocal.ProjectID;

            this.txtEdtStage.Text = taskCreatingDTOLocal.Stage;

            this.rchTxtBxTask.Text = taskCreatingDTOLocal.Task;

            this.txtEdtEmployee.Text = taskCreatingDTOLocal.Employee;

            this.rchTxtBxTaskDescription.Text = taskCreatingDTOLocal.TaskDescription;

            this.txtEdtStartDate.Text = taskCreatingDTOLocal.StartDate;

            this.txtEdtEndDate.Text = taskCreatingDTOLocal.EndDate;

            this.txtEdtTaskType.Text = taskCreatingDTOLocal.TaskType;

            this.txtEdtApprover.Text = taskCreatingDTOLocal.Approver;

            this.txtEdtAttachFile.Text = taskCreatingDTOLocal.AttachFile;

            this.nmrUpDwnProgress.Text = taskCreatingDTOLocal.Progress;

            this.txtEdtStatus.Text = taskCreatingDTOLocal.Status;

            this.txtEdtFinishDate.Text = taskCreatingDTOLocal.FinishDate;

            this.txtEdtTimeDelay.Text = taskCreatingDTOLocal.TimeDelay;

            this.txtEdtNote.Text = taskCreatingDTOLocal.Note;
        }

        // Hàm check để xem nút confirm có thể đc chọn.
        private void checkConfirm()
        {
            string str_AttachFileLocal = TaskCreatingBUS.Instance.getStringAttachFileFollowAllPrimaryKeys(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);
            string str_ProgressLocal = this.nmrUpDwnProgress.Text.Trim();
            string str_Status = this.txtEdtStatus.Text.Trim();
            int i_FlagUploadLocal = AttachedFileDAO.Instance.getIntCheckHaveAttachedFile(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);

            if (str_AttachFileLocal == null || i_FlagUploadLocal == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xem để hiện nút progress.
            if (str_AttachFileLocal == StaticVarClass.attachFile_No)
            {
                if (this.i_FlagMailGlobal == 1 && str_ProgressLocal == StaticVarClass.completeProgress && str_Status != StaticVarClass.status_Complete && str_Status != StaticVarClass.status_WaitForApproval)
                {
                    // Mở khóa nút confirm.
                    this.btnConfirm.Enabled = true;
                }
            }
            else if (str_AttachFileLocal == StaticVarClass.attachFile_Yes)
            {
                if (this.i_FlagMailGlobal == 1 && i_FlagUploadLocal > 0 && str_ProgressLocal == StaticVarClass.completeProgress && str_Status != StaticVarClass.status_Complete && str_Status != StaticVarClass.status_WaitForApproval)
                {
                    // Mở khóa nút confirm.
                    this.btnConfirm.Enabled = true;
                }
            }
        }

        // Khởi tạo lại btn confirm.
        private void resetConfirm()
        {
            this.i_FlagMailGlobal = 0;
            //this.i_FlagUploadGlobal = 0;

            this.btnConfirm.Enabled = false;
            this.btnConfirm.LookAndFeel.UseDefaultLookAndFeel = true;

            this.enabledFollowStatus();
        }

        // Read only khi task đã hoàn thành.
        private void enabledFollowStatus()
        {
            string str_Status = TaskCreatingBUS.Instance.getStringStatusFollowAllPrimaryKeys(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);

            if (str_Status == StaticVarClass.status_Complete)
                this.nmrUpDwnProgress.Enabled = false;
        }

        private void nmrUpDwnProgress_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string str_ProjectIDLocal = this.str_ProjectIDGlobal;
                string str_StageLocal = this.str_StageGlobal;
                string str_TaskLocal = this.str_TaskGlobal;
                string str_ProgressLocal = this.nmrUpDwnProgress.Text.Trim();

                if (TaskCreatingBUS.Instance.updateDataForProgress(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_ProgressLocal))
                {
                    // Kiểm tra xem đc xác nhận chưa.
                    this.checkConfirm();

                    // Load lại tab thông tin.
                    this.loadInformation();

                
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully edited!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    tbpnTaskDetail.SelectedPageIndex = 1;
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Edit project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Edit failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Description_Click(object sender, EventArgs e)
        {
            formTaskDetail_Load(sender, e);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            TaskCreatingDTO taskCreatingDTOLocal = TaskCreatingBUS.Instance.getDataObjectFollowProjectIDAndStageAndTask(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);

            // Nếu nút comfirm đã đủ điều kiện.
            if (this.btnConfirm.Enabled == true)
            {
                // Biến lưu nếu không xác nhận thành công thì status mặc định lại ban đầu.
                string str_StatusTemp = this.txtEdtStatus.Text.Trim();

                if (taskCreatingDTOLocal.TaskType == StaticVarClass.type_Normal)
                {
                    this.txtEdtStatus.Text = StaticVarClass.status_Complete;
                }
                else if (taskCreatingDTOLocal.TaskType == StaticVarClass.type_AdminApproval)
                {
                    this.txtEdtStatus.Text = StaticVarClass.status_WaitForApproval;
                }

                // Cập nhật lại ngày hoàn thành và trạng thái của task.
                taskCreatingDTOLocal.FinishDate = DateTime.Now.Date.ToString();
                if (taskCreatingDTOLocal.FinishDate == string.Empty)
                    taskCreatingDTOLocal.FinishDate = null;

                taskCreatingDTOLocal.Status = this.txtEdtStatus.Text.Trim();

                // Cập nhật status của task.               
                if (TaskCreatingBUS.Instance.updateDataForFormTaskDetail(taskCreatingDTOLocal.ProjectID, taskCreatingDTOLocal.Stage,
                    taskCreatingDTOLocal.Task, taskCreatingDTOLocal.FinishDate, taskCreatingDTOLocal.Status))
                {
                    XtraMessageBox.Show("Successfully confirmed!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đặt lại mặc định của các nút liên quan đến confirm.
                    this.resetConfirm();
                }
                else
                {
                    this.txtEdtStatus.Text = str_StatusTemp;

                    XtraMessageBox.Show("Confirm failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion

        #region tp gửi email.
        private void disableEmail()
        {
            this.txtedtSendEmailAddress.ReadOnly = true;
            this.btnSend.Enabled = false;
        }

        private void loadEmailRecieve()
        {
            DataTable dtLocal = EmployeeBUS.Instance.getDataEmailFollowName(this.str_EmployeeGlobal);

            if (dtLocal != null)
            {
                foreach (DataRow row in dtLocal.Rows)
                {
                    string email = row["EMAIL"].ToString();
                    row["EMAIL"] = email.Trim();
                }

                this.cbbReceiveEmailAddress.DataSource = dtLocal;
                this.cbbReceiveEmailAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbReceiveEmailAddress.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbReceiveEmailAddress.DisplayMember = "EMAIL";
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool sendMail()
        {
            try // Its a good practice to write your code in a try catch block 
            {
                SmtpClient client = new SmtpClient(StaticVarClass.email_HostEmail, StaticVarClass.email_PortEmail);      //Connection Object.
                var message = new MailMessage(StaticVarClass.gmail_User, cbbReceiveEmailAddress.Text.Trim()); // Email Object.
                message.Body = this.rchTxBxMessage.Text.Trim() + Environment.NewLine + "Sent from " + this.txtedtSendEmailAddress.Text.Trim();
                string str_Subject = this.txtedtSubject.Text.Trim();
                if (str_Subject == string.Empty)
                    message.Subject = "Project - stage - task: " + this.str_ProjectIDGlobal + " - " + this.str_StageGlobal + " - " + this.str_TaskGlobal + " has been completed.";
                else
                    message.Subject = str_Subject;

                client.Credentials = new System.Net.NetworkCredential(StaticVarClass.gmail_User, StaticVarClass.gmail_Password); // Setting Credential of gmail account.
                client.EnableSsl = true;                // Enabling secured Connection.
                client.Send(message);
                message = null;                         // Free the memory
            }
            catch
            {
                return false;
            }

            return true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string str_ProjectIDLocal = this.str_ProjectIDGlobal;
            string str_StageLocal = this.str_StageGlobal;
            string str_TaskLocal = this.str_TaskGlobal;

            if (sendMail())
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Send a mail to confirm project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                string status = "Successful";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Successfully sent!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                i_FlagMailGlobal = 1;  // Báo hiệu đã gửi mail thành công.

                // Kiểm tra xác nhận đc chưa.
                this.checkConfirm();
            }
            else
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Send a mail to confirm project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                string status = "Failed";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Send failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbbReceiveEmailAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ReceiveEmailAddressLocal = this.cbbReceiveEmailAddress.GetItemText(this.cbbReceiveEmailAddress.SelectedItem).Trim();

            if (str_ReceiveEmailAddressLocal != string.Empty)
            {
                this.btnSend.Enabled = true;
            }
            else if (str_ReceiveEmailAddressLocal == string.Empty)
            {
                this.btnSend.Enabled = false;
            }
        }

        private void cbbReceiveEmailAddress_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectReceiveEmailAddressGlobal = true;
            string str_ReceivedEmailAddressLocal = this.cbbReceiveEmailAddress.GetItemText(this.cbbReceiveEmailAddress.SelectedItem).Trim();

            if (str_ReceivedEmailAddressLocal != string.Empty)
            {
                this.btnSend.Enabled = true;
            }
            else if (str_ReceivedEmailAddressLocal == string.Empty)
            {
                this.btnSend.Enabled = false;
            }
        }

        private void cbbReceiveEmailAddress_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectReceiveEmailAddressGlobal == false)
                this.btnSend.Enabled = false;
            else
                this.b_IsSelectReceiveEmailAddressGlobal = false;
        }

        private void cbbReceiveEmailAddress_DropDown(object sender, EventArgs e)
        {
            this.cbbReceiveEmailAddress.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbReceiveEmailAddress.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbReceiveEmailAddress_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbReceiveEmailAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbReceiveEmailAddress.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbReceiveEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtedtSubject.Focus();
            }
        }

        private void txtedtSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.rchTxBxMessage.Focus();
            }
        }

        private void rchTxBxMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnSend.Enabled == true)
                    this.btnSend.PerformClick();
                else
                    this.cbbReceiveEmailAddress.Select();
            }
        }
        #endregion

        #region tp dinh kem.
        struct FtpSetting
        {
            public string FileName { get; set; }
            public string FullName { get; set; }
        }

        FtpSetting ftpInfo;

        private void disableAttachFileUpload(bool e)
        {
            string str_linkUploadLocal = this.txtEdtLinkUpload.Text.Trim();

            // Chọn file mới cho btn tải file, chú thích.
            this.txtEdtLinkUpload.ReadOnly = true;
            this.txtEdtFileNameUpload.ReadOnly = true;

            if (str_linkUploadLocal == string.Empty)
            {
                this.btnUpload.Enabled = !e;
                this.txtEdtNoteUpload.ReadOnly = e;
            }
            else
            {
                this.btnUpload.Enabled = true;
                this.txtEdtNoteUpload.ReadOnly = false;
            }
        }

        private void clearUpload()
        {
            this.txtEdtLinkUpload.Text = string.Empty;
            this.txtEdtFileNameUpload.Text = string.Empty;
            this.txtEdtNoteUpload.Text = string.Empty;
        }

        private void disableAttachFileDownload(bool e)
        {
            string str_linkDowmloadLocal = this.txtEdtLinkDownload.Text.Trim();

            // Chọn đường dẫn lưu mới cho tải xuống, đường dẫn trống không cho tải xuống.
            this.txtEdtLinkDownload.ReadOnly = true;
            this.txtEdtFileNameDownload.ReadOnly = true;
            this.txtEdtNoteDownload.ReadOnly = true;

            if (str_linkDowmloadLocal == string.Empty)
            {
                this.btnDownload.Enabled = !e;
            }
            else
            {
                this.btnDownload.Enabled = true;
            }

        }

        private void clearDownload()
        {
            this.txtEdtLinkDownload.Text = string.Empty;
        }

        private void loadDataAttachFile()
        {
            // Chạy danh sách trong bảng 
            DataTable dtAttachedFile = new DataTable();
            dtAttachedFile = AttachedFileDAO.Instance.getData(this.str_ProjectIDGlobal, this.str_StageGlobal, this.str_TaskGlobal);

            if (dtAttachedFile != null)
            {
                if (dtAttachedFile.Rows.Count == 0)
                {
                    this.btnBrowseDownload.Enabled = false;
                    this.btnDownload.Enabled = false;
                }
                else
                {
                    this.btnBrowseDownload.Enabled = true;
                }

                this.grdCtrlAttachment.DataSource = dtAttachedFile;
                this.bindingAttachDownload();

            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bindingAttachDownload()
        {
            txtEdtFileNameDownload.DataBindings.Clear();
            txtEdtFileNameDownload.DataBindings.Add("Text", grdCtrlAttachment.DataSource, "FILENAME");

            txtEdtNoteDownload.DataBindings.Clear();
            txtEdtNoteDownload.DataBindings.Add("Text", grdCtrlAttachment.DataSource, "NOTE");
        }

        private void tbPnUploadDowload_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            this.loadTabPageSelect();
        }

        private void txtedtNoteUpload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnUpload.Enabled = true;
                this.btnUpload.PerformClick();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            string str_ProjectIDLocal = this.str_ProjectIDGlobal;
            string str_StageLocal = this.str_StageGlobal;
            string str_TaskLocal = this.str_TaskGlobal;
            string str_TimeLocal = DateTime.Now.ToString();
            string str_FileNameLocal = this.txtEdtFileNameUpload.Text.Trim();
            string str_NoteLocal = this.txtEdtNoteUpload.Text.Trim();

            ftp ftpClientLocal = new ftp(StaticVarClass.ftp_Server, StaticVarClass.ftp_Username, StaticVarClass.ftp_Password);

            if (ftpClientLocal.upload(StaticVarClass.account_Username, ftpInfo.FileName, ftpInfo.FullName))
            {
                AttachedFileDTO attachFileDTOTemp = new AttachedFileDTO(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_TimeLocal, str_FileNameLocal, str_NoteLocal);

                if (AttachedFileDAO.Instance.addData(attachFileDTOTemp))
                {
                    //this.i_FlagUploadGlobal = 1;  // Báo hiệu đã đăng file.

                    // Kiểm tra xác nhận được chưa.
                    this.checkConfirm();

                    // Load lại attachFile.
                    this.loadDataAttachFile();

                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Upload a file named " + str_FileNameLocal + " in project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                    string status = "Successful";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Successfully uploaded!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Làm sạch control.
                    this.clearUpload();
                    this.disableAttachFileUpload(true);
                }
                else
                {
                    #region Cập nhật lịch sử.
                    string name = StaticVarClass.account_Username;
                    string time = DateTime.Now.ToString();
                    string action = "Upload a file named " + str_FileNameLocal + " in project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                    string status = "Failed";

                    HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                    HistoryDAO.Instance.addData(hisDTO);
                    #endregion

                    XtraMessageBox.Show("Upload failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Upload a file named " + str_FileNameLocal + " in project - stage - task: " + str_ProjectIDLocal + " - " + str_StageLocal + " - " + str_TaskLocal;
                string status = "Failed";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Upload failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false, ValidateNames = true, Filter = "All files|*.*" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    // Đổi tên file để cho vào thư mục của mỗi nhân viên.
                    ftpInfo.FileName = str_ProjectIDGlobal + " - " + str_StageGlobal + " - " + str_TaskGlobal + " - " + DateTime.Now.ToString("dd.MM.yyy HH.mm.ss") + Path.GetExtension(ofd.FileName);
                    ftpInfo.FullName = fi.FullName;

                    this.txtEdtFileNameUpload.Text = ftpInfo.FileName;
                    this.txtEdtLinkUpload.Text = ftpInfo.FullName;

                    disableAttachFileUpload(false);
                }
            }
        }

        private void txtedtNoteDownload_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnDownload.Enabled = true;
                this.btnDownload.PerformClick();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            ftp ftpClientLocal = new ftp(StaticVarClass.ftp_Server, StaticVarClass.ftp_Username, StaticVarClass.ftp_Password);

            if (ftpClientLocal.download(str_EmployeeGlobal, ftpInfo.FileName, ftpInfo.FullName))
            {
                // Load lại attachFile.
                this.loadDataAttachFile();

                // Làm sạch control.
                this.clearDownload();
                this.disableAttachFileDownload(true);

                XtraMessageBox.Show("Successfully downloaded!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XtraMessageBox.Show("Download failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowseDownload_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fd = new FolderBrowserDialog())
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    ftpInfo.FileName = this.txtEdtFileNameDownload.Text.Trim();
                    ftpInfo.FullName = fd.SelectedPath + @"\" + txtEdtFileNameDownload.Text.Trim();

                    this.txtEdtLinkDownload.Text = ftpInfo.FullName;

                    this.btnDownload.Enabled = true;
                }
            }
        }

        private void btnDeleteFile_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            System.Data.DataRow dtR_rowLocal = grvAttachment.GetDataRow(grvAttachment.FocusedRowHandle);

            string str_ProjectIDLocal = this.str_ProjectIDGlobal; ;
            string str_StageLocal = this.str_StageGlobal;
            string str_TaskLocal = this.str_TaskGlobal;
            string str_DateTime = dtR_rowLocal[0].ToString().Trim();
            string str_FileName = dtR_rowLocal[1].ToString().Trim();

            DialogResult dr = XtraMessageBox.Show("Are you sure you want delete file " + str_FileName + "?", "Confirm delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.OK)
            {
                ftp ftpClientLocal = new ftp(StaticVarClass.ftp_Server, StaticVarClass.ftp_Username, StaticVarClass.ftp_Password);

                if (ftpClientLocal.delete(StaticVarClass.account_Username, str_FileName))
                {
                    if (AttachedFileDAO.Instance.deleteData(str_ProjectIDLocal, str_StageLocal, str_TaskLocal, str_DateTime))
                    {
                        this.loadDataAttachFile();

                        XtraMessageBox.Show("Successfully deleted file " + str_FileName + " !", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        XtraMessageBox.Show("Delete file " + str_FileName + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    XtraMessageBox.Show("Delete file " + str_FileName + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}