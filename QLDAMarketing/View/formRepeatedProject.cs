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
    public partial class formRepeatedProject : DevExpress.XtraEditors.XtraForm
    {
        string str_CreatedProjectGlobal = string.Empty;

        // Cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange.
        bool b_IsSelectProjectIDGlobal = false;

        public formRepeatedProject()
        {
            InitializeComponent();
            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void formRepeatedProject_Load(object sender, EventArgs e)
        {
            this.loadProjectID();

            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();
            this.setValue(str_ProjectIDLocal);
        }

        public void getCreatedProject(string projectID)
        {
            if (this.str_CreatedProjectGlobal == string.Empty)
                this.str_CreatedProjectGlobal = projectID;
        }

        // Load các dự án.
        private void loadProjectID()
        {
            DataTable dtLocal = ProjectDAO.Instance.getData();

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

                // Show project vừa mới tạo.
                if (this.str_CreatedProjectGlobal != string.Empty)
                    this.cbbProjectID.SelectedIndex = this.cbbProjectID.FindStringExact(this.str_CreatedProjectGlobal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void setValue(string projectID)
        {
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(projectID);
            int i_Number1Local = ProjectDAO.Instance.getIntNumberOfProjectType1FollowProjectID(projectID);
            int i_Number2Local = ProjectDAO.Instance.getIntNumberOfProjectType2FollowProjectID(projectID);
            int i_Number5Local = 0;
            int i_Number345Local = ProjectDAO.Instance.getIntNumberOfProjectType345FollowProjectID(projectID);

            if (projectDTOLocal == null || i_Number1Local == -1 || i_Number2Local == -1 || i_Number345Local == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btnCancel_Click(null, null);
            }

            if (projectDTOLocal.Empty())
            {
                return;
            }

            

            #region Set value các ô.
            //this.cbbProjectID.Text = projectDTOLocal.ProjectID;
            this.nmrUpDwnDateRepeat.Value = Decimal.Parse(projectDTOLocal.DateRepeat);

            if (projectDTOLocal.AutoRepeat == "0")
                this.chkBxAutoRepeat.CheckState = CheckState.Unchecked;
            else
                this.chkBxAutoRepeat.CheckState = CheckState.Checked;

            if (projectDTOLocal.StartDateRepeat != string.Empty && projectDTOLocal.EndDateRepeat != string.Empty)
            {
                this.dtEdtStartDate.DateTime = DateTime.Parse(projectDTOLocal.StartDateRepeat);
                this.dtEdtEndDate.DateTime = DateTime.Parse(projectDTOLocal.EndDateRepeat);
            }
            else if (projectDTOLocal.StartDateRepeat == string.Empty && projectDTOLocal.EndDateRepeat == string.Empty)
            {
                this.dtEdtStartDate.EditValue = null;
                this.dtEdtEndDate.EditValue = null;
            }
            #endregion

            #region Nếu 4 thuộc tính ở giá trị mặc định.
            if (projectDTOLocal.DateRepeat == "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat == string.Empty
                && projectDTOLocal.EndDateRepeat == string.Empty)
            {
                this.nmrUpDwnDateRepeat.Enabled = true;
                this.chkBxAutoRepeat.Enabled = false;

                if (i_Number1Local == 1 || i_Number2Local > 0) // Nếu đã tạo dự án 1 hay 2 thì khóa Date Repeat và AutoRepeat.
                {
                    this.chkBxAutoRepeat.Enabled = false;
                    this.nmrUpDwnDateRepeat.Enabled = false;
                }
                else if (i_Number345Local > 0) // Nếu đã tạo dự án 3 hay 4 hay 5 thì khóa Date Repeat và AutoRepeat.
                {
                    this.chkBxAutoRepeat.Enabled = false;
                    this.nmrUpDwnDateRepeat.Enabled = false;
                }
            }
            #endregion

            #region Nếu chưa tạo dự án 1 thì chỉnh sửa tùy ý Date Repeat + Auto Repeat + Start Date Repeat + End Date Repeat.
            if (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat == string.Empty
                && projectDTOLocal.EndDateRepeat == string.Empty)
            {
                this.nmrUpDwnDateRepeat.Enabled = true;
                this.chkBxAutoRepeat.Enabled = true;
            }
            #endregion

            #region Nếu đang tạo dự án 2.
            if (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "1" && projectDTOLocal.StartDateRepeat == string.Empty
                && projectDTOLocal.EndDateRepeat == string.Empty)
            {
                if (i_Number2Local > 0)
                {
                    this.chkBxAutoRepeat.Enabled = false;
                }
                else if (i_Number2Local == 0)
                {
                    this.chkBxAutoRepeat.Enabled = true;
                }

                this.nmrUpDwnDateRepeat.Enabled = true;
            }
            #endregion

            #region Nếu chưa tạo dự án 3.
            if (projectDTOLocal.DateRepeat == "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat != string.Empty
                && projectDTOLocal.EndDateRepeat != string.Empty)
            {
                this.nmrUpDwnDateRepeat.Enabled = true;
                this.chkBxAutoRepeat.Enabled = false;
            }
            #endregion

            #region Nếu chưa tạo dự án 4 HAY đã tạo 1 dự án 4 và đang chờ tạo 1 dự án 4 nữa.
            if (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat != string.Empty
                && projectDTOLocal.EndDateRepeat != string.Empty)
            {
                this.nmrUpDwnDateRepeat.Enabled = true;
                this.chkBxAutoRepeat.Enabled = true;
            }
            #endregion

            #region Nếu chưa tạo dự án 5.
            if (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "1" && projectDTOLocal.StartDateRepeat != string.Empty
                && projectDTOLocal.EndDateRepeat != string.Empty)
            {
                i_Number5Local = ProjectDAO.Instance.getIntNumberOfProjectType5FollowProjectIDAndStartDate(projectDTOLocal.ProjectID,
                    projectDTOLocal.StartDateRepeat);

                if (i_Number5Local <= 1)
                {
                    this.chkBxAutoRepeat.Enabled = true;
                }
                else if (i_Number5Local > 1)
                {
                    this.chkBxAutoRepeat.Enabled = false;
                }

                this.nmrUpDwnDateRepeat.Enabled = true;
            }
            #endregion

            #region Xử lí đây có phải là dự án lặp lại ko.
            int i_IsRepeatedProjectLocal = ProjectDAO.Instance.getIntConfirmRepeatedProject(projectID);

            if (i_IsRepeatedProjectLocal == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.nmrUpDwnDateRepeat.Enabled = false;
                this.chkBxAutoRepeat.Enabled = false;
                this.dtEdtStartDate.ReadOnly = true;
                this.dtEdtEndDate.ReadOnly = true;

                this.btnStop.Enabled = false;
                this.btnStart.Enabled = false;
                return;
            }

            if (i_IsRepeatedProjectLocal == 1)
            {
                this.nmrUpDwnDateRepeat.Enabled = false;
                this.chkBxAutoRepeat.Enabled = false;
                this.dtEdtStartDate.ReadOnly = true;
                this.dtEdtEndDate.ReadOnly = true;

                this.btnStop.Enabled = true;
                this.btnStart.Enabled = false;
            }
            else
            {
                this.dtEdtStartDate.ReadOnly = false;
                this.dtEdtEndDate.ReadOnly = false;
                this.btnStop.Enabled = false;
                this.btnStart.Enabled = true;
            }
            #endregion

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();
            string str_DateRepeatLocal = this.nmrUpDwnDateRepeat.Value.ToString().Trim();
            string str_AutoRepeatLocal = string.Empty;

            string str_StartDateRepeatLocal = string.Empty;
            if (this.dtEdtStartDate.Text.Trim() == string.Empty)
                str_StartDateRepeatLocal = null;
            else
                str_StartDateRepeatLocal = this.dtEdtStartDate.Text.Trim();

            string str_EndDateRepeatLocal = string.Empty;
            if (this.dtEdtEndDate.Text.Trim() == string.Empty)
                str_EndDateRepeatLocal = null;
            else
                str_EndDateRepeatLocal = this.dtEdtEndDate.Text.Trim();

            if (this.chkBxAutoRepeat.Checked == true)
                str_AutoRepeatLocal = "1";
            else
                str_AutoRepeatLocal = "0";

            // Kiểm tra các ô có trống không.
            if (str_DateRepeatLocal == "0" && (str_StartDateRepeatLocal == null || str_EndDateRepeatLocal == null))
            {
                XtraMessageBox.Show("Please enter values to start repeating!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region Sửa.
            // Sửa.
            if (ProjectDAO.Instance.updateDataRepeatedProject(str_ProjectIDLocal, str_DateRepeatLocal, str_AutoRepeatLocal, str_StartDateRepeatLocal, str_EndDateRepeatLocal))
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Start repeating project: " + str_ProjectIDLocal;
                string status = "Successful";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Successfully started repeating project " + str_ProjectIDLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Start repeating project: " + str_ProjectIDLocal;
                string status = "Failed";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Start repeating project " + str_ProjectIDLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            #endregion

            formRepeatedProject_Load(sender, e);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();
            string str_DateRepeatLocal = "0";
            string str_AutoRepeatLocal = "0";
            string str_StartDateRepeatLocal = null;
            string str_EndDateRepeatLocal = null;

            #region Sửa.
            // Sửa.
            if (ProjectDAO.Instance.updateDataRepeatedProject(str_ProjectIDLocal, str_DateRepeatLocal, str_AutoRepeatLocal, str_StartDateRepeatLocal, str_EndDateRepeatLocal))
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Stop repeating project: " + str_ProjectIDLocal;
                string status = "Successful";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Successfully stopped repeating project " + str_ProjectIDLocal + "!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                #region Cập nhật lịch sử.
                string name = StaticVarClass.account_Username;
                string time = DateTime.Now.ToString();
                string action = "Stop repeating project: " + str_ProjectIDLocal;
                string status = "Failed";

                HistoryDTO hisDTO = new HistoryDTO(name, time, action, status);
                HistoryDAO.Instance.addData(hisDTO);
                #endregion

                XtraMessageBox.Show("Stop repeating project " + str_ProjectIDLocal + " failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            #endregion

            formRepeatedProject_Load(sender, e);
        }

        private void nmrUpDwnDateRepeat_ValueChanged(object sender, EventArgs e)
        {
            //string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();

            //int i_Number2Local = ProjectDAO.Instance.getIntNumberOfProjectType2FollowProjectID(str_ProjectIDLocal);
            //int i_Number5Local = 0;
            //int i_Number4Local = 0;

            //ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectIDLocal);

            //// Nếu đã tạo dự án 2 và muốn dừng auto repeat.
            //if (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "1" && projectDTOLocal.StartDateRepeat == string.Empty
            //    && projectDTOLocal.EndDateRepeat == string.Empty)
            //{
            //    if (i_Number2Local > 0)
            //    {
            //        if (Convert.ToInt32(projectDTOLocal.DateRepeat) == Convert.ToInt32(Math.Round(this.nmrUpDwnDateRepeat.Value, 0)) &&
            //            this.dtEdtStartDate.Text == string.Empty && this.dtEdtStartDate.Text == string.Empty)
            //        {
            //            this.nmrUpDwnDateRepeat.Value = decimal.Parse(projectDTOLocal.DateRepeat);
            //        }
            //        else if (Convert.ToInt32(projectDTOLocal.DateRepeat) != Convert.ToInt32(Math.Round(this.nmrUpDwnDateRepeat.Value, 0)) &&
            //            this.dtEdtStartDate.Text == string.Empty && this.dtEdtEndDate.Text == string.Empty)
            //        {
            //            this.nmrUpDwnDateRepeat.Value = 0;
            //        }
            //    }
            //}

            //// Nếu đang tạo dự án 4.
            //if (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat != string.Empty
            //    && projectDTOLocal.EndDateRepeat != string.Empty)
            //{
            //    i_Number4Local = ProjectDAO.Instance.getIntNumberOfProjectType4FollowProjectIDAndStartDate(str_ProjectIDLocal,
            //        projectDTOLocal.StartDateRepeat);

            //    if (i_Number4Local == 1) // Đã tạo 1 dự án 4 vào đúng Start Date Repeat.
            //    {
            //        if (Convert.ToInt32(Math.Round(this.nmrUpDwnDateRepeat.Value, 0)) == 0 && this.dtEdtStartDate.Text != string.Empty
            //            && this.dtEdtEndDate.Text != string.Empty)
            //        {
            //            this.dtEdtStartDate.EditValue = null;
            //            this.dtEdtEndDate.EditValue = null;

            //            this.nmrUpDwnDateRepeat.Enabled = false;
            //            this.chkBxAutoRepeat.Enabled = false;
            //        }
            //    }
            //}

            //// Nếu đang tạo dự án 5.
            //if (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "1" && projectDTOLocal.StartDateRepeat != string.Empty
            //    && projectDTOLocal.EndDateRepeat != string.Empty)
            //{
            //    i_Number5Local = ProjectDAO.Instance.getIntNumberOfProjectType5FollowProjectIDAndStartDate(str_ProjectIDLocal,
            //        projectDTOLocal.StartDateRepeat);

            //    if (i_Number5Local > 1)
            //    {
            //        if (Convert.ToInt32(projectDTOLocal.DateRepeat) == Convert.ToInt32(Math.Round(this.nmrUpDwnDateRepeat.Value, 0)) && this.dtEdtStartDate.Text != string.Empty
            //            && this.dtEdtEndDate.Text != string.Empty)
            //        {
            //            this.nmrUpDwnDateRepeat.Value = decimal.Parse(projectDTOLocal.DateRepeat);
            //        }
            //        else if (Convert.ToInt32(projectDTOLocal.DateRepeat) != Convert.ToInt32(Math.Round(this.nmrUpDwnDateRepeat.Value, 0)) && this.dtEdtStartDate.Text != string.Empty
            //            && this.dtEdtEndDate.Text != string.Empty)
            //        {
            //            this.nmrUpDwnDateRepeat.Value = 0;
            //            this.dtEdtStartDate.EditValue = null;
            //            this.dtEdtEndDate.EditValue = null;

            //            this.nmrUpDwnDateRepeat.Enabled = false;
            //            this.chkBxAutoRepeat.Enabled = false;
            //        }
            //    }
            //    else if (i_Number5Local <= 1)
            //    {
            //        if (Convert.ToInt32(Math.Round(this.nmrUpDwnDateRepeat.Value, 0)) == 0 && this.dtEdtStartDate.Text != string.Empty
            //            && this.dtEdtEndDate.Text != string.Empty)
            //        {
            //            this.dtEdtStartDate.EditValue = null;
            //            this.dtEdtEndDate.EditValue = null;

            //            this.nmrUpDwnDateRepeat.Enabled = false;
            //            this.chkBxAutoRepeat.Enabled = false;
            //        }
            //    }
            //}


            if (Convert.ToInt32(Math.Round(this.nmrUpDwnDateRepeat.Value, 0)) == 0)
            {
                chkBxAutoRepeat.Checked = false;
                chkBxAutoRepeat.Enabled = false;
            }
            else
            {
                chkBxAutoRepeat.Checked = false;
                chkBxAutoRepeat.Enabled = true;
            }
        }

        private void dtEdtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();

            int i_Number1Local = ProjectDAO.Instance.getIntNumberOfProjectType1FollowProjectID(str_ProjectIDLocal);
            int i_Number2Local = ProjectDAO.Instance.getIntNumberOfProjectType2FollowProjectID(str_ProjectIDLocal);
            int i_Number345Local = ProjectDAO.Instance.getIntNumberOfProjectType345FollowProjectID(str_ProjectIDLocal);
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectIDLocal);

            if (projectDTOLocal == null || i_Number1Local == -1 || i_Number2Local == -1 || i_Number345Local == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (projectDTOLocal.Empty())
            {
                return;
            }

            #region Nếu 4 thuộc tính ở giá trị mặc định.
            if (projectDTOLocal.DateRepeat == "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat == string.Empty
                && projectDTOLocal.EndDateRepeat == string.Empty)
            {
                this.nmrUpDwnDateRepeat.Enabled = true;
                this.chkBxAutoRepeat.Enabled = false;

                if (i_Number1Local == 1 || i_Number2Local > 0) // Nếu đã tạo dự án 1 hay 2 thì khóa Date Repeat và AutoRepeat.
                {
                    if (dtEdtStartDate.Text == string.Empty)
                    {
                        this.nmrUpDwnDateRepeat.Value = 0;
                        chkBxAutoRepeat.Checked = false;

                        this.nmrUpDwnDateRepeat.Enabled = false;
                        this.chkBxAutoRepeat.Enabled = false;
                    }
                    else
                    {
                        this.nmrUpDwnDateRepeat.Enabled = true;
                    }
                }
                else if (i_Number345Local > 0) // Nếu đã tạo dự án 3 hay 4 hay 5 thì khóa Date Repeat và AutoRepeat.
                {
                    if (dtEdtStartDate.Text == string.Empty)
                    {
                        this.nmrUpDwnDateRepeat.Value = 0;
                        chkBxAutoRepeat.Checked = false;

                        this.nmrUpDwnDateRepeat.Enabled = false;
                        this.chkBxAutoRepeat.Enabled = false;
                    }
                    else
                    {
                        this.nmrUpDwnDateRepeat.Enabled = true;
                    }
                }
            }
            #endregion

            //ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectIDLocal);

            //// Nếu chưa tạo dự án 3 HAY đang tạo dự án 4, 5: khi tắt start date repeat => tắt hết 3 ô còn lại
            //if ((projectDTOLocal.DateRepeat == "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat != string.Empty
            //    && projectDTOLocal.EndDateRepeat != string.Empty)
            //    || (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat != string.Empty
            //    && projectDTOLocal.EndDateRepeat != string.Empty)
            //    || (projectDTOLocal.DateRepeat != "0" && projectDTOLocal.AutoRepeat == "1" && projectDTOLocal.StartDateRepeat != string.Empty
            //    && projectDTOLocal.EndDateRepeat != string.Empty))
            //{
            //    if (dtEdtStartDate.Text == string.Empty)
            //    {
            //        this.nmrUpDwnDateRepeat.Value = 0;
            //        chkBxAutoRepeat.Checked = false;

            //        this.nmrUpDwnDateRepeat.Enabled = false;
            //        this.chkBxAutoRepeat.Enabled = false;
            //    }
            //    else
            //    {
            //        this.nmrUpDwnDateRepeat.Enabled = true;
            //    }
            //}

            if (dtEdtStartDate.Text != string.Empty)
            {
                int i_StartDateEndDateTemp = 0;
                i_StartDateEndDateTemp = DateTime.Parse(projectDTOLocal.EndDate).Subtract(DateTime.Parse(projectDTOLocal.StartDate)).Days;
                dtEdtEndDate.DateTime = dtEdtStartDate.DateTime.AddDays(i_StartDateEndDateTemp);
            }
            else
            {
                dtEdtEndDate.EditValue = null;
            }
        }

        private void dtEdtEndDate_EditValueChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.Text.Trim();

            int i_Number1Local = ProjectDAO.Instance.getIntNumberOfProjectType1FollowProjectID(str_ProjectIDLocal);
            int i_Number2Local = ProjectDAO.Instance.getIntNumberOfProjectType2FollowProjectID(str_ProjectIDLocal);
            int i_Number345Local = ProjectDAO.Instance.getIntNumberOfProjectType345FollowProjectID(str_ProjectIDLocal);
            ProjectDTO projectDTOLocal = ProjectDAO.Instance.getDataObjectFollowProjectID(str_ProjectIDLocal);

            if (projectDTOLocal == null || i_Number1Local == -1 || i_Number2Local == -1 || i_Number345Local == -1)
            {
                XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (projectDTOLocal.Empty())
            {
                return;
            }

            #region Nếu 4 thuộc tính ở giá trị mặc định.
            if (projectDTOLocal.DateRepeat == "0" && projectDTOLocal.AutoRepeat == "0" && projectDTOLocal.StartDateRepeat == string.Empty
                && projectDTOLocal.EndDateRepeat == string.Empty)
            {
                this.nmrUpDwnDateRepeat.Enabled = true;
                this.chkBxAutoRepeat.Enabled = false;

                if (i_Number1Local == 1 || i_Number2Local > 0) // Nếu đã tạo dự án 1 hay 2 thì khóa Date Repeat và AutoRepeat.
                {
                    if (dtEdtStartDate.Text == string.Empty)
                    {
                        this.nmrUpDwnDateRepeat.Value = 0;
                        chkBxAutoRepeat.Checked = false;

                        this.nmrUpDwnDateRepeat.Enabled = false;
                        this.chkBxAutoRepeat.Enabled = false;
                    }
                    else
                    {
                        this.nmrUpDwnDateRepeat.Enabled = true;
                    }
                }
                else if (i_Number345Local > 0) // Nếu đã tạo dự án 3 hay 4 hay 5 thì khóa Date Repeat và AutoRepeat.
                {
                    if (dtEdtStartDate.Text == string.Empty)
                    {
                        this.nmrUpDwnDateRepeat.Value = 0;
                        chkBxAutoRepeat.Checked = false;

                        this.nmrUpDwnDateRepeat.Enabled = false;
                        this.chkBxAutoRepeat.Enabled = false;
                    }
                    else
                    {
                        this.nmrUpDwnDateRepeat.Enabled = true;
                    }
                }
            }
            #endregion

            if (dtEdtEndDate.Text != string.Empty)
            {
                int i_StartDateEndDateTemp = 0;
                i_StartDateEndDateTemp = DateTime.Parse(projectDTOLocal.EndDate).Subtract(DateTime.Parse(projectDTOLocal.StartDate)).Days;

                TimeSpan difference = new TimeSpan(i_StartDateEndDateTemp, 0, 0, 0);
                dtEdtStartDate.DateTime = dtEdtEndDate.DateTime.Subtract(difference);
            }
            else
            {
                dtEdtStartDate.EditValue = null;
            }
        }

        private void cbbProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            //int i_IsRepeatedProjectLocal = 0;

            if (str_ProjectIDLocal != string.Empty)
            {
                //i_IsRepeatedProjectLocal = ProjectDAO.Instance.getIntConfirmRepeatedProject(str_ProjectIDLocal);

                //if (i_IsRepeatedProjectLocal == 1)
                //    this.btnStop.Enabled = true;
                //else
                //    this.btnStop.Enabled = false;

                //this.btnStart.Enabled = true;
                setValue(str_ProjectIDLocal);
            }
            else
            {
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = false;
            }
        }

        private void cbbProjectID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectProjectIDGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();
            //int i_IsRepeatedProjectLocal = 0;

            if (str_ProjectIDLocal != string.Empty)
            {
                //i_IsRepeatedProjectLocal = ProjectDAO.Instance.getIntConfirmRepeatedProject(str_ProjectIDLocal);

                //if (i_IsRepeatedProjectLocal == 1)
                //    this.btnStop.Enabled = true;
                //else
                //    this.btnStop.Enabled = false;

                //this.btnStart.Enabled = true;
                setValue(str_ProjectIDLocal);
            }
            else
            {
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = false;
            }
        }

        private void cbbProjectID_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectProjectIDGlobal == false)
            {
                this.nmrUpDwnDateRepeat.Value = Decimal.Zero;
                this.chkBxAutoRepeat.Checked = false;
                dtEdtStartDate.EditValue = null;
                dtEdtEndDate.EditValue = null;

                this.btnStart.Enabled = false;
                this.btnStop.Enabled = false;
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
                this.nmrUpDwnDateRepeat.Focus();
            }
        }

        private void nmrUpDwnDateRepeat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chkBxAutoRepeat.Focus();
            }
        }

        private void chkBxAutoRepeat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEdtStartDate.Select();
            }
        }

        private void dtEdtStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtEdtEndDate.Select();
            }
        }

        private void dtEdtEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnStart.Enabled == true)
                    this.btnStart.PerformClick();
                if (this.btnStop.Enabled == true)
                    this.btnStop.PerformClick();
            }
        }

        private void formRepeatedProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

    }
}