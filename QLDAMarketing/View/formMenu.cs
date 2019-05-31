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
using DevExpress.XtraSplashScreen;
using ProjectManagement.CO;
using ProjectManagement.View;
using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System.IO;

namespace ProjectManagement.View
{
    public partial class formMenu : DevExpress.XtraEditors.XtraForm
    {
        formMain frmMain = formMain.Instance;

        bool b_IsFirstGlobal = true;

        int i_WidthGlobal = 0;
        int i_HeightGlobal = 0;

        public formMenu()
        {
            InitializeComponent();

            this.i_WidthGlobal = this.GetScreen().Width - this.pnLeft.Width - 30;
            this.i_HeightGlobal = this.GetScreen().Height;
        }

        public Rectangle GetScreen()
        {
            return Screen.FromControl(this).Bounds;
        }

        public void setControlHide(int width, int height)
        {
            this.btnProjectHistory.Width = (width * 15) / 46;
            this.btnProjectHistory.Height = (height * 7) / 25;

            this.btnHistory.Width = (width * 15) / 46;
            this.btnHistory.Height = (height * 7) / 25;

            this.btnDepartment.Width = (width * 15) / 46;
            this.btnDepartment.Height = (height * 7) / 25;

            this.btnEmployee.Width = (width * 15) / 46;
            this.btnEmployee.Height = (height * 7) / 25;

            this.btnProjectDiagram.Width = (width * 15) / 46;
            this.btnProjectDiagram.Height = (height * 7) / 25;

            this.btnTaskCreating.Width = (width * 15) / 46;
            this.btnTaskCreating.Height = (height * 7) / 25;

            this.btnStage.Width = (width * 15) / 46;
            this.btnStage.Height = (height * 7) / 25;

            this.btnProjectCreating.Width = (width * 15) / 46;
            this.btnProjectCreating.Height = (height * 7) / 25;

            this.btnProjectCreating.Width = (width * 15) / 46;
            this.btnProjectCreating.Height = (height * 7) / 25;

            this.btnPersonalInformation.Width = (width * 15) / 46;
            this.btnPersonalInformation.Height = (height * 7) / 25;
        }

        public void setControlNotHide(int width, int height)
        {
            this.btnProjectHistory.IconZoom = (width * 1) / 32;
            this.btnProjectHistory.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnProjectHistory.Width = (width * 15) / 46;
            this.btnProjectHistory.Height = (height * 1) / 4;

            this.btnHistory.IconZoom = (width * 1) / 32;
            this.btnHistory.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnHistory.Width = (width * 15) / 46;
            this.btnHistory.Height = (height * 1) / 4;

            this.btnDepartment.IconZoom = (width * 1) / 32;
            this.btnDepartment.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnDepartment.Width = (width * 15) / 46;
            this.btnDepartment.Height = (height * 1) / 4;

            this.btnEmployee.IconZoom = (width * 1) / 32;
            this.btnEmployee.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnEmployee.Width = (width * 15) / 46;
            this.btnEmployee.Height = (height * 1) / 4;

            this.btnProjectDiagram.IconZoom = (width * 1) / 32;
            this.btnProjectDiagram.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnProjectDiagram.Width = (width * 15) / 46;
            this.btnProjectDiagram.Height = (height * 1) / 4;

            this.btnTaskCreating.IconZoom = (width * 1) / 32;
            this.btnTaskCreating.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnTaskCreating.Width = (width * 15) / 46;
            this.btnTaskCreating.Height = (height * 1) / 4;

            this.btnStage.IconZoom = (width * 1) / 32;
            this.btnStage.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnStage.Width = (width * 15) / 46;
            this.btnStage.Height = (height * 1) / 4;

            this.btnProjectCreating.IconZoom = (width * 1) / 32;
            this.btnProjectCreating.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnProjectCreating.Width = (width * 15) / 46;
            this.btnProjectCreating.Height = (height * 1) / 4;

            this.btnPersonalInformation.IconZoom = (width * 1) / 32;
            this.btnPersonalInformation.TextFont = new Font(this.btnProjectDiagram.TextFont.FontFamily, width * 1 / 68);
            this.btnPersonalInformation.Width = (width * 15) / 46;
            this.btnPersonalInformation.Height = (height * 1) / 4;
        }

        private void NotHideRibon()
        {
            formMain frmMain = formMain.Instance;
            frmMain.ribbonControl1.Minimized = false;
        }

        public void hideControl()
        {
            this.pnLeft.Hide();
            // this.pnRight.Hide();
            this.btnProjectHistory.Hide();

            this.btnHistory.Hide();

            this.btnDepartment.Hide();

            this.btnEmployee.Hide();

            this.btnProjectDiagram.Hide();

            this.btnTaskCreating.Hide();

            this.btnStage.Hide();

            this.btnProjectCreating.Hide();

            this.btnPersonalInformation.Hide();
        }

        public void showControl()
        {
            this.pnLeft.Show();
            // this.pnRight.Show();
            this.btnProjectHistory.Show();

            this.btnHistory.Show();

            this.btnDepartment.Show();

            this.btnEmployee.Show();

            this.btnProjectDiagram.Show();

            this.btnTaskCreating.Show();

            this.btnStage.Show();

            this.btnProjectCreating.Show();

            this.btnProjectCreating.Show();

            this.btnPersonalInformation.Show();
        }

        // Kiểm tra có trễ dự án nào không.
        private void checkTimeDelayProject()
        {
            int i_QuantityTaskNotComplete = TaskCreatingDAO.Instance.getIntQuantityStatusNotCompleteFollowEmployee(StaticVarClass.account_Username);

            if (i_QuantityTaskNotComplete > 0)
            {
                DialogResult dr = XtraMessageBox.Show("You have not completed your tasks. Go to My Tasks?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    this.hideControl();
                    Cursor.Current = Cursors.WaitCursor;

                    if (StaticVarClass.formPersonalInformation == null)
                    {
                        formMain frmMain = formMain.Instance;
                        StaticVarClass.formPersonalInformation = new formPersonalInformation();

                        StaticVarClass.formPersonalInformation.MdiParent = frmMain;
                        StaticVarClass.formPersonalInformation.Show();
                    }
                    else
                    {
                        StaticVarClass.formPersonalInformation.Activate();
                    }
                }
            }
            else
            {
                DialogResult dr = XtraMessageBox.Show("You have no tasks or have completed your tasks!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        // Hiện thị tên của người đang sử dụng.
        private void loadNameUser()
        {
            frmMain.Text = "Project Management - " + StaticVarClass.account_Username;
        }

        private void loadFormLogin()
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

                        frmMain.disableMenuLogin(false);

                        if (StaticVarClass.formMenu == null)
                        {
                            StaticVarClass.formMenu = new formMenu();

                            StaticVarClass.formMenu.MdiParent = frmMain;
                            StaticVarClass.formMenu.Show();
                        }
                        else
                        {
                            StaticVarClass.formMenu.Activate();
                        }

                        this.loadNameUser();

                        break;
                    }
                    else
                    {
                        XtraMessageBox.Show("Sorry, your username or password was incorrect! Please check again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    break;
                }
            }

        }

        private void formMenu_Load(object sender, EventArgs e)
        {
            if (b_IsFirstGlobal == true)
            {
                b_IsFirstGlobal = false;

                this.setControlNotHide(i_WidthGlobal, i_HeightGlobal);

                this.lblName.Text = StaticVarClass.account_Username;
            }
        }

        private void formMenu_Activated(object sender, EventArgs e)
        {
            this.NotHideRibon();

            this.showControl();

            this.setControlNotHide(i_WidthGlobal, i_HeightGlobal);
        }

        private void btnBell_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.checkTimeDelayProject();
        }

        //private void btnLogout_Click(object sender, EventArgs e)
        //{
        //    if (XtraMessageBox.Show("Log out?", "Confirm log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        formMain frmMain = formMain.Instance;

        //        // Đóng tất cả các tab đã bật để đăng nhập tài khoảng mới.
        //        for (int i = frmMain.mdimain.Pages.Count - 1; i >= 0; i--)
        //        {
        //            frmMain.mdimain.Pages[i].MdiChild.Close();
        //        }

        //        #region Trả các tab đã bật bằng null
        //        StaticVarClass.formPersonalInformation = null;

        //        StaticVarClass.formHistory = null;

        //        StaticVarClass.formProjectHistory = null;

        //        StaticVarClass.formMenu = null;

        //        StaticVarClass.formEmployee = null;

        //        StaticVarClass.formDepartment = null;

        //        StaticVarClass.formProject = null;

        //        StaticVarClass.formStage = null;

        //        StaticVarClass.formTaskCreating = null;

        //        StaticVarClass.formProjectDiagram = null;
        //        #endregion

        //        frmMain.disableMenuLogin(true);
        //        this.Text = "Project Management";
        //        this.loadFormLogin();
        //    }
        //}

        //private void btnChangePassword_Click(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;

        //    formChangePassword frmChangePassword = new formChangePassword();

        //    string str_OldPasswordTemp = StaticVarClass.account_Password; // Lưu lại password trước khi thay đổi.

        //    if (frmChangePassword.ShowDialog() == DialogResult.OK)
        //    {
        //        string str_CurrentPasswordTemp = frmChangePassword.txtEdtCurrentPassword.Text.Trim();
        //        string str_NewPasswordTemp = frmChangePassword.txtEdtNewPassword.Text.Trim();
        //        string str_ConfirmNewPasswordTemp = frmChangePassword.txtEdtConfirmNewPassword.Text.Trim();

        //        // Nếu nhập mật khẩu hiện tại sai (!= str_OldPasswordTemp) hay Xác nhận mật khẩu mới ko trùng nhau thì show lại form.
        //        while ((str_OldPasswordTemp != str_CurrentPasswordTemp) || (String.Compare(str_NewPasswordTemp, str_ConfirmNewPasswordTemp, false) != 0))
        //        {
        //            if (frmChangePassword.ShowDialog() == DialogResult.Cancel)
        //                break;
        //        }

        //        if (str_OldPasswordTemp != StaticVarClass.account_Password)
        //        {
        //            // Đóng tất cả các tab đã bật để đăng nhập lại với mật khẩu mới.
        //            for (int i = this.frmMain.mdimain.Pages.Count - 1; i >= 0; i--)
        //            {
        //                this.frmMain.mdimain.Pages[i].MdiChild.Close();
        //            }

        //            #region Trả các tab đã bật bằng null
        //            StaticVarClass.formPersonalInformation = null;

        //            StaticVarClass.formHistory = null;

        //            StaticVarClass.formProjectHistory = null;

        //            StaticVarClass.formMenu = null;

        //            StaticVarClass.formEmployee = null;

        //            StaticVarClass.formDepartment = null;

        //            StaticVarClass.formProject = null;

        //            StaticVarClass.formStage = null;

        //            StaticVarClass.formTaskCreating = null;

        //            StaticVarClass.formProjectDiagram = null;
        //            #endregion

        //            this.frmMain.disableMenuLogin(true);
        //            this.loadFormLogin();
        //        }
        //    }
        //}

        private void btnPersonalInformation_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formPersonalInformation == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formPersonalInformation = new formPersonalInformation();

                StaticVarClass.formPersonalInformation.MdiParent = frmMain;
                StaticVarClass.formPersonalInformation.Show();
            }
            else
            {
                StaticVarClass.formPersonalInformation.Activate();
            }
        }

        private void btnProjectHistory_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formProjectHistory == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formProjectHistory = new formProjectHistory();

                StaticVarClass.formProjectHistory.MdiParent = frmMain;
                StaticVarClass.formProjectHistory.Show();
            }
            else
            {
                StaticVarClass.formProjectHistory.Activate();
            }
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formHistory == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;

                StaticVarClass.formHistory = new formHistory();

                StaticVarClass.formHistory.MdiParent = frmMain;
                StaticVarClass.formHistory.Show();
            }
            else
                StaticVarClass.formHistory.Activate();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formEmployee == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formEmployee = new formEmployee();

                StaticVarClass.formEmployee.MdiParent = frmMain;
                StaticVarClass.formEmployee.Show();
            }
            else
            {
                StaticVarClass.formEmployee.Activate();
            }
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formDepartment == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formDepartment = new formDepartment();

                StaticVarClass.formDepartment.MdiParent = frmMain;
                StaticVarClass.formDepartment.Show();
            }
            else
            {
                StaticVarClass.formDepartment.Activate();
            }
        }

        private void btnProjectCreating_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formProject == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formProject = new formProject();

                StaticVarClass.formProject.MdiParent = frmMain;
                StaticVarClass.formProject.Show();
            }
            else
            {
                StaticVarClass.formProject.Activate();
            }
        }

        private void btnStage_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formStage == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formStage = new formStage();

                StaticVarClass.formStage.MdiParent = frmMain;
                StaticVarClass.formStage.Show();
            }
            else
            {
                StaticVarClass.formStage.Activate();
            }
        }

        private void btnTaskCreating_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formTaskCreating == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formTaskCreating = new formTaskCreating();

                StaticVarClass.formTaskCreating.MdiParent = frmMain;
                StaticVarClass.formTaskCreating.Show();
            }
            else
            {
                StaticVarClass.formTaskCreating.Activate();
            }
        }

        private void btnProjectDiagram_Click(object sender, EventArgs e)
        {
            if (StaticVarClass.formProjectDiagram == null)
            {
                this.hideControl();

                Cursor.Current = Cursors.WaitCursor;

                formMain frmMain = formMain.Instance;
                StaticVarClass.formProjectDiagram = new formProjectDiagram();

                StaticVarClass.formProjectDiagram.MdiParent = frmMain;
                StaticVarClass.formProjectDiagram.Show();
            }
            else
            {
                StaticVarClass.formProjectDiagram.Activate();
            }
        }

        //#region mouse.

        //private void btnEmployee_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnEmployee_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnDepartment_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnDepartment_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnProjectDiagram_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnProjectDiagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnProjectDiagram_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnProjectDiagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnProjectCreating_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnProjectCreating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnProjectCreating_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnProjectCreating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnStage_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnStage_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnStage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnProjectHistory_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnProjectHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnProjectHistory_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnProjectHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnPersonalInformation_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnPersonalInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnPersonalInformation_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnPersonalInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnTaskCreating_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnTaskCreating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnTaskCreating_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnTaskCreating.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}

        //private void btnHistory_MouseHover(object sender, EventArgs e)
        //{
        //    this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(141)))), ((int)(((byte)(43)))));
        //}

        //private void btnHistory_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(161)))), ((int)(((byte)(93)))));
        //}
        //#endregion

        private void formMenu_FormClosed(object sender, FormClosedEventArgs e)
        {

            StaticVarClass.formMenu = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void btnProjectDiagram_MouseUp(object sender, EventArgs e)
        {

        }
    }
}