using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectManagement.DTO;
using ProjectManagement.DAO;
using ProjectManagement.View;
using ProjectManagement.CO;
using DevExpress.XtraSplashScreen;
using System.Net.NetworkInformation;
using System.IO;

namespace ProjectManagement
{
    public partial class formMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static System.Windows.Forms.Timer timerOffApp = new System.Windows.Forms.Timer();

        bool isHaveLANNetwork = true;

        formMenu frmMenu = null;

        // singleton.
        private static formMain instance;

        public static formMain Instance
        {
            get { if (instance == null) instance = new formMain(); return formMain.instance; }

            set { formMain.instance = value; }
        }

        private formMain()
        {
            InitializeComponent();

            disableMenuLogin(true);
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
                //XtraMessageBox.Show("Empty data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (str_RoleLocal == StaticVarClass.role_Admin)
            {
                RbPgCtrlCreating.Visible = true;
            }
            else if (str_RoleLocal == StaticVarClass.role_Member)
            {
                RbPgCtrlCreating.Visible = false;
            }
            else if (str_RoleLocal == StaticVarClass.role_Staff)
            {
                RbPgCtrlCreating.Visible = false;
            }
        }

        // Khi chưa đăng nhập thì ẩn các phím đi.
        public void disableMenuLogin(bool e)
        {
            btnLogIn.Enabled = e;
            btnLogOut.Enabled = !e;
            btnShowMenu.Enabled = !e;
            btnChangePassword.Enabled = !e;

            btnPersonalInformation.Enabled = !e;
            btnHistory.Enabled = !e;
            btnProjectHistory.Enabled = !e;

            btnEmployee.Enabled = !e;
            btnDepartment.Enabled = !e;
            btnProject.Enabled = !e;
            btnStage.Enabled = !e;
            btnTask.Enabled = !e;
            btnProjectsDiagram.Enabled = !e;
            btnProjectCreating.Enabled = !e;
        }

        // Đưa thông tin rớt mạng.
        public void setInfo(bool isHaveLANNetwork)
        {
            this.isHaveLANNetwork = isHaveLANNetwork;
        }

        private void PingTest(object sender, EventArgs e)
        {
            Ping pingSender = null;

            try
            {
                pingSender = new Ping();
                PingReply reply = pingSender.Send(StaticVarClass.server_ConnectSQLServer);

                if (reply.Status != IPStatus.Success)
                {
                    timerOffApp.Stop();

                    this.isHaveLANNetwork = false;
                    this.btnLogOut_ItemClick(null, null);

                    //Application.Exit();
                }
            }
            catch (PingException)
            {
                timerOffApp.Stop();

                this.isHaveLANNetwork = false;
                this.btnLogOut_ItemClick(null, null);
            }

            if (pingSender != null)
            {
                pingSender.Dispose();
                pingSender = null;
            }
        }

        // Hiện thị tên của người đang sử dụng.
        private void loadNameUser()
        {
            this.Text = "Project Management - " + StaticVarClass.account_Username;
        }

        private void formMain_Load(object sender, EventArgs e)
        {           
            this.btnLogIn_ItemClick(sender, null);

        }

        private void btnLogIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            formLogIn frmLogIn = new formLogIn();

            while (true)
            {
                if (frmLogIn.ShowDialog() == DialogResult.OK)
                {
                    string str_UsernameTemp = frmLogIn.cbbUsername.Text.Trim();
                    string str_PasswordTemp = frmLogIn.txtEdtPassword.Text.Trim();

                    #region Lưu/ ko lưu account vào file.
                    if (frmLogIn.chkBxRememberAccount.Checked == true && str_PasswordTemp != string.Empty)
                    {
                        string str_FilePathTemp = StaticVarClass.linkFile_Account;

                        if (System.IO.File.Exists(str_FilePathTemp))
                        {
                            string str_IsCheckTemp = "Yes";
                            string str_AccountTemp = string.Empty;
                            string[] str_ArrValueTemp;
                            bool b_ExistTemp = false;
                            bool b_UpdateAccTemp = false;
                            //int i_LineLength = 0;
                            string str_BeforeUpdatedAccTemp = string.Empty;

                            FileStream fs_FileTemp = new FileStream(str_FilePathTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                            StreamReader strRe_ReaderTemp = new StreamReader(fs_FileTemp);
                            StreamWriter strWr_WriterTemp = new StreamWriter(fs_FileTemp);

                            // Kiểm tra username và password hiện tại đã lưu trong file chưa.
                            while ((str_AccountTemp = strRe_ReaderTemp.ReadLine()) != null)
                            {
                                if (str_AccountTemp.Trim() != string.Empty)
                                {
                                    str_ArrValueTemp = str_AccountTemp.Trim().Split(' ');
                                    if (str_ArrValueTemp.Count() == 2)
                                    {
                                        if (str_ArrValueTemp[0] == str_UsernameTemp)
                                        {
                                            //i_LineLength = str_AccountTemp.Length + 2;
                                            b_UpdateAccTemp = true;
                                            break;
                                        }

                                        if (str_ArrValueTemp[0] == str_UsernameTemp && str_ArrValueTemp[1] == str_PasswordTemp)
                                        {
                                            b_ExistTemp = true;
                                            break;
                                        }
                                    }

                                    if (str_AccountTemp == StaticVarClass.attachFile_Yes || str_AccountTemp == StaticVarClass.attachFile_No)
                                        str_BeforeUpdatedAccTemp += str_AccountTemp; // Lấy chữ "Yes"/ "No".
                                    else
                                        str_BeforeUpdatedAccTemp += "\r\n" + str_AccountTemp;
                                }
                            }

                            if (b_UpdateAccTemp == true)
                            {
                                fs_FileTemp.Seek(0, SeekOrigin.Current);

                                string str_AfterUpdatedAccTemp = strRe_ReaderTemp.ReadToEnd();
                                string newLog = str_BeforeUpdatedAccTemp + "\r\n" + str_AfterUpdatedAccTemp;

                                fs_FileTemp.SetLength(0);
                                strWr_WriterTemp.Write(newLog);

                                strWr_WriterTemp.Close();
                                strRe_ReaderTemp.Close();
                                fs_FileTemp.Close();
                            }

                            if (b_UpdateAccTemp != true)
                            {
                                strWr_WriterTemp.Close();
                                strRe_ReaderTemp.Close();
                                fs_FileTemp.Close();
                            }

                            if (b_ExistTemp == false) // Nếu chưa tồn tại thì thêm vào file.
                            {
                                FileStream _fs_FileTemp = new FileStream(str_FilePathTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                                StreamReader _strRe_ReaderTemp = new StreamReader(_fs_FileTemp);
                                StreamWriter _strWr_WriterTemp = new StreamWriter(_fs_FileTemp);

                                _fs_FileTemp.Seek(0, SeekOrigin.Begin);
                                _strRe_ReaderTemp.ReadLine();
                                string newLog = str_IsCheckTemp + "\r\n" + str_UsernameTemp + " " + str_PasswordTemp + "\r\n" + _strRe_ReaderTemp.ReadToEnd();
                                _fs_FileTemp.SetLength(0);
                                _strWr_WriterTemp.Write(newLog);

                                _strWr_WriterTemp.Close();
                                _strRe_ReaderTemp.Close();
                                _fs_FileTemp.Close();
                            }

                            frmLogIn.getLoginStatus(true, str_UsernameTemp, str_PasswordTemp, 1);
                        }
                        else
                        {
                            XtraMessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (frmLogIn.chkBxRememberAccount.Checked == false)
                    {
                        string str_FilePathTemp = StaticVarClass.linkFile_Account;

                        if (System.IO.File.Exists(str_FilePathTemp))
                        {
                            string str_IsCheckTemp = "No";

                            StreamWriter str_Wr = new StreamWriter(str_FilePathTemp);

                            str_Wr.Write(str_IsCheckTemp);

                            str_Wr.Flush();
                            str_Wr.Close();

                            frmLogIn.getLoginStatus(true, str_UsernameTemp, str_PasswordTemp, 2);
                        }
                        else
                        {
                            XtraMessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion

                    if (EmployeeDAO.Instance.checkLogin(str_UsernameTemp, str_PasswordTemp))
                    {
                        // Lưu lại tên đăng nhập và mật khẩu.
                        StaticVarClass.account_Username = str_UsernameTemp;
                        StaticVarClass.account_Password = str_PasswordTemp;

                        timerOffApp.Tick += new EventHandler(PingTest); // Every time timer ticks, timer_Tick will be called
                        timerOffApp.Interval = StaticVarClass.timeAutoOff;    // Timer will tick every 15 min.
                        timerOffApp.Start();

                        this.loadNameUser();
                        this.Authorize();

                        disableMenuLogin(false);

                        if (StaticVarClass.formMenu == null)
                        {
                            this.frmMenu = new formMenu();

                            StaticVarClass.formMenu = this.frmMenu;

                            StaticVarClass.formMenu.MdiParent = this;
                            StaticVarClass.formMenu.Show();
                        }
                        else
                        {
                            StaticVarClass.formMenu.Activate();
                        }

                        break;
                    }
                    else
                    {
                        XtraMessageBox.Show("Sorry, your username or password was incorrect! Please check again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    this.disableMenuLogin(true);
                    break;
                }
            }
        }

        private void btnLogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.isHaveLANNetwork == false)
            {
                // Đóng tất cả các tab đã bật để đăng nhập tài khoản mới.
                for (int i = mdimain.Pages.Count - 1; i >= 0; i--)
                {
                    mdimain.Pages[i].MdiChild.Close();
                }

                #region Trả các tab đã bật bằng null
                StaticVarClass.formPersonalInformation = null;

                StaticVarClass.formHistory = null;

                StaticVarClass.formProjectHistory = null;

                StaticVarClass.formMenu = null;

                StaticVarClass.formEmployee = null;

                StaticVarClass.formDepartment = null;

                StaticVarClass.formProject = null;

                StaticVarClass.formStage = null;

                StaticVarClass.formTaskCreating = null;

                StaticVarClass.formProjectDiagram = null;
                #endregion

                disableMenuLogin(true);
                this.Text = "Project Management";
                btnLogIn_ItemClick(sender, e);
            }
            else if (XtraMessageBox.Show("Log out?", "Confirm log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Đóng tất cả các tab đã bật để đăng nhập tài khoản mới.
                for (int i = mdimain.Pages.Count - 1; i >= 0; i--)
                {
                    mdimain.Pages[i].MdiChild.Close();
                }

                #region Trả các tab đã bật bằng null
                StaticVarClass.formPersonalInformation = null;

                StaticVarClass.formHistory = null;

                StaticVarClass.formProjectHistory = null;

                StaticVarClass.formMenu = null;

                StaticVarClass.formEmployee = null;

                StaticVarClass.formDepartment = null;

                StaticVarClass.formProject = null;

                StaticVarClass.formStage = null;

                StaticVarClass.formTaskCreating = null;

                StaticVarClass.formProjectDiagram = null;
                #endregion

                disableMenuLogin(true);
                this.Text = "Marketing Project Management";
                btnLogIn_ItemClick(sender, e);
                this.Authorize();
            }
        }

        private void btnShowMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formMenu == null)
            {
                this.frmMenu = new formMenu();

                StaticVarClass.formMenu = this.frmMenu;

                StaticVarClass.formMenu.MdiParent = this;

                StaticVarClass.formMenu.Show();
            }
            else
            {
                StaticVarClass.formMenu.Activate();
            }
        }

        private void btnChangePassword_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            formChangePassword frmChangePassword = new formChangePassword();

            string str_OldPasswordTemp = StaticVarClass.account_Password; // Lưu lại password trước khi thay đổi.

            if (frmChangePassword.ShowDialog() != DialogResult.Cancel)
            {
                string str_CurrentPasswordTemp = frmChangePassword.txtEdtCurrentPassword.Text.Trim();
                string str_NewPasswordTemp = frmChangePassword.txtEdtNewPassword.Text.Trim();
                string str_ConfirmNewPasswordTemp = frmChangePassword.txtEdtConfirmNewPassword.Text.Trim();

                // Nếu nhập mật khẩu hiện tại sai (!= str_OldPasswordTemp) hay Xác nhận mật khẩu mới ko trùng nhau thì show lại form.
                while ((str_OldPasswordTemp != str_CurrentPasswordTemp) || (String.Compare(str_NewPasswordTemp, str_ConfirmNewPasswordTemp, false) != 0))
                {
                    if (frmChangePassword.ShowDialog() == DialogResult.Cancel)
                        break;
                }

                if (str_OldPasswordTemp != StaticVarClass.account_Password)
                {
                    // Đóng tất cả các tab đã bật để đăng nhập lại với mật khẩu mới.
                    for (int i = mdimain.Pages.Count - 1; i >= 0; i--)
                    {
                        mdimain.Pages[i].MdiChild.Close();
                    }

                    #region Trả các tab đã bật bằng null
                    StaticVarClass.formPersonalInformation = null;

                    StaticVarClass.formHistory = null;

                    StaticVarClass.formProjectHistory = null;

                    StaticVarClass.formMenu = null;

                    StaticVarClass.formEmployee = null;

                    StaticVarClass.formDepartment = null;

                    StaticVarClass.formProject = null;

                    StaticVarClass.formStage = null;

                    StaticVarClass.formTaskCreating = null;

                    StaticVarClass.formProjectDiagram = null;
                    #endregion

                    disableMenuLogin(true);
                    btnLogIn_ItemClick(sender, e);
                }
            }
        }

        private void btnPersonalInformation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formPersonalInformation == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formPersonalInformation = new formPersonalInformation();

                StaticVarClass.formPersonalInformation.MdiParent = this;
                StaticVarClass.formPersonalInformation.Show();
            }
            else
            {
                StaticVarClass.formPersonalInformation.Activate();
            }
        }

        private void btnProjectHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formProjectHistory == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formProjectHistory = new formProjectHistory();

                StaticVarClass.formProjectHistory.MdiParent = this;
                StaticVarClass.formProjectHistory.Show();
            }
            else
            {
                StaticVarClass.formProjectHistory.Activate();
            }
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formHistory == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formHistory = new formHistory();

                StaticVarClass.formHistory.MdiParent = this;
                StaticVarClass.formHistory.Show();
            }
            else
            {
                StaticVarClass.formHistory.Activate();
            }
        }

        private void btnEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formEmployee == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formEmployee = new formEmployee();

                StaticVarClass.formEmployee.MdiParent = this;
                StaticVarClass.formEmployee.Show();
            }
            else
            {
                StaticVarClass.formEmployee.Activate();
            }
        }

        private void btnDepartment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formDepartment == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formDepartment = new formDepartment();

                StaticVarClass.formDepartment.MdiParent = this;
                StaticVarClass.formDepartment.Show();
            }
            else
            {
                StaticVarClass.formDepartment.Activate();
            }
        }

        private void btnProject_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formProject == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formProject = new formProject();

                StaticVarClass.formProject.MdiParent = this;
                StaticVarClass.formProject.Show();
            }
            else
            {
                StaticVarClass.formProject.Activate();
            }
        }

        private void btnStage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formStage == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();


                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formStage = new formStage();

                StaticVarClass.formStage.MdiParent = this;
                StaticVarClass.formStage.Show();
            }
            else
            {
                StaticVarClass.formStage.Activate();
            }
        }

        private void btnTaskCreating_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formTaskCreating == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();


                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formTaskCreating = new formTaskCreating();

                StaticVarClass.formTaskCreating.MdiParent = this;
                StaticVarClass.formTaskCreating.Show();
            }
            else
            {
                StaticVarClass.formTaskCreating.Activate();
            }
        }

        private void btnProjectCreating_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            formProjectCreating frmProjectCreating = formProjectCreating.Instance;
            frmProjectCreating.ShowDialog();
        }

        private void btnProjectsDiagram_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (StaticVarClass.formProjectDiagram == null)
            {
                if (StaticVarClass.formMenu != null)
                    this.frmMenu.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                StaticVarClass.formProjectDiagram = new formProjectDiagram();

                StaticVarClass.formProjectDiagram.MdiParent = this;
                StaticVarClass.formProjectDiagram.Show();
            }
            else
            {
                StaticVarClass.formProjectDiagram.Activate();
            }
        }

        private void mdimain_SelectedPageChanged(object sender, EventArgs e)
        {
            //this.Hide();

            //frmMenu.Hide();
        }

        private void mdimain_PageAdded(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {

        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isHaveLANNetwork == true)
            {
                if ((XtraMessageBox.Show("Are you sure you want to exit?", "Confirm exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        public void ribbonControl1_MinimizedChanged(object sender, EventArgs e)
        {
            if (this.ribbonControl1.Minimized == true && StaticVarClass.formMenu != null)
                this.frmMenu.setControlHide(frmMenu.flPnCtrlRight.Width - 10, frmMenu.GetScreen().Height);
            else if (this.ribbonControl1.Minimized == false && StaticVarClass.formMenu != null)
                this.frmMenu.setControlNotHide(frmMenu.flPnCtrlRight.Width - 10, frmMenu.GetScreen().Height);
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
