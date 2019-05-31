using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectManagement.CO;
using System.Net.NetworkInformation;
using System.IO;

namespace ProjectManagement.View
{
    public partial class formLogIn : DevExpress.XtraEditors.XtraForm
    {
        static System.Windows.Forms.Timer timerOffApp = new System.Windows.Forms.Timer();

        bool b_IsOneReportGlobal = true;

        bool b_IsLoginGlobal = false;
        string str_UsernameGlobal = string.Empty;
        string str_PasswordGlobal = string.Empty;
        int i_IsCheckedGlobal = 0;

        public formLogIn()
        {
            InitializeComponent();

            this.supportInit();
        }

        public void getLoginStatus(bool e, string username, string password, int isChecked)
        {
            this.b_IsLoginGlobal = e;
            this.str_UsernameGlobal = username;
            this.str_PasswordGlobal = password;
            this.i_IsCheckedGlobal = isChecked;
        }

        private void supportInit()
        {
            timerOffApp.Tick += new EventHandler(formLogIn_Load); // Every time timer ticks, timer_Tick will be called
            timerOffApp.Interval = StaticVarClass.timeAutoOffFormLogIn;    // Timer will tick every 15 min.
            timerOffApp.Start();

            //Khóa phím OK đến khi nào nhập username.
            btnOK.Enabled = false;
            // Khóa text server đến khi nào chọn change.
            this.txtEdtServerIP.Enabled = false;

            this.txtEdtServerIP.Text = StaticVarClass.server_Host;

            this.loadUsername();
        }

        private void loadUsername()
        {
            string str_FilePathLocal = StaticVarClass.linkFile_Account;

            if (System.IO.File.Exists(str_FilePathLocal))
            {
                StreamReader strRd_Reader = new StreamReader(StaticVarClass.linkFile_Account);

                string str_RememberAccountLocal = string.Empty;
                string str_LineLocal = string.Empty;
                string[] str_ArrValueLocal;
                List<string> lstStr_UsernameLocal = new List<string>();

                str_RememberAccountLocal = strRd_Reader.ReadLine();

                // Xử lý check ô remember account.
                if (str_RememberAccountLocal == "Yes")
                    this.chkBxRememberAccount.Checked = true;
                else
                    this.chkBxRememberAccount.Checked = false;

                // Xử lý nạp ô combobox name.
                while ((str_LineLocal = strRd_Reader.ReadLine()) != null)
                {
                    if (str_LineLocal.Trim() != string.Empty)
                    {
                        str_ArrValueLocal = str_LineLocal.Trim().Split(' ');
                        if (str_ArrValueLocal.Count() == 2)
                        {
                            lstStr_UsernameLocal.Add(str_ArrValueLocal[0]);
                        }
                    }
                }

                strRd_Reader.Close();

                this.cbbUsername.DataSource = lstStr_UsernameLocal;
                this.cbbUsername.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbUsername.AutoCompleteSource = AutoCompleteSource.ListItems;

                if (this.b_IsLoginGlobal == true)
                {
                    if (this.str_UsernameGlobal != string.Empty && this.i_IsCheckedGlobal == 1)
                        this.cbbUsername.SelectedIndex = this.cbbUsername.FindString(str_UsernameGlobal);
                    else if (this.str_UsernameGlobal != string.Empty && this.i_IsCheckedGlobal == 2)
                    {
                        this.cbbUsername.Text = this.str_UsernameGlobal;
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cbbUsername.DataSource = null;
            }
        }

        private void getPassword(string username)
        {
            string str_FilePathLocal = StaticVarClass.linkFile_Account;

            if (System.IO.File.Exists(str_FilePathLocal))
            {
                StreamReader strRd_Reader = new StreamReader(StaticVarClass.linkFile_Account);

                string str_LineLocal = string.Empty;
                string[] strArr_ValueLocal;

                while ((str_LineLocal = strRd_Reader.ReadLine()) != null)
                {
                    if (str_LineLocal.Trim() != string.Empty)
                    {
                        strArr_ValueLocal = str_LineLocal.Split(' ');
                        if (strArr_ValueLocal.Count() == 2)
                        {
                            if (strArr_ValueLocal[0] == username)
                            {
                                this.txtEdtPassword.Text = strArr_ValueLocal[1];
                                break;
                            }
                        }
                    }
                }

                strRd_Reader.Close();
            }
            else
            {
                XtraMessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kiểm tra dữ liệu nhập vào có phải host không.
        private bool isHost(string host)
        {
            var hostNameType = Uri.CheckHostName(host);

            if (hostNameType == UriHostNameType.IPv4)
                return true;

            return false;
        }

        private bool isHaveLANNetWork()
        {
            Ping pingSender = null;

            if (StaticVarClass.server_ConnectSQLServer == string.Empty || StaticVarClass.server_ConnectSQLServer == null)
                return false;

            try
            {
                pingSender = new Ping();
                PingReply reply = pingSender.Send(StaticVarClass.server_ConnectSQLServer);

                if (reply.Status != IPStatus.Success)
                {
                    if (this.b_IsOneReportGlobal == true)
                    {
                        this.b_IsOneReportGlobal = false;

                        DevExpress.XtraEditors.XtraMessageBox.Show("Cannot connect to " + StaticVarClass.server_ConnectSQLServer + "!");
                    }

                    return false;
                }
            }
            catch (PingException)
            {
                if (this.b_IsOneReportGlobal == true)
                {
                    this.b_IsOneReportGlobal = false;

                    DevExpress.XtraEditors.XtraMessageBox.Show("Cannot connect to " + StaticVarClass.server_ConnectSQLServer + "!");
                }

                return false;
            }

            if (pingSender != null)
            {
                pingSender.Dispose();
                pingSender = null;
            }

            return true;
        }

        private void formLogIn_Load(object sender, EventArgs e)
        {      
            if (this.isHaveLANNetWork() == false)
            {
                this.cbbUsername.Enabled = false;
                this.txtEdtPassword.Enabled = false;
                this.btnOK.Hide();
            }
            else
            {
                this.cbbUsername.Enabled = true;
                this.txtEdtPassword.Enabled = true;
                this.btnOK.Show();
            }

            if (this.b_IsLoginGlobal == true)
            {
                this.loadUsername();
                this.getLoginStatus(false, string.Empty, string.Empty, 0);
            }
        }

        private void cbbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtEdtPassword.Focus();
            }
        }

        private void txtEdtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chkBxRememberAccount.Focus();
            }
        }

        private void chkBxRememberAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnOK.Enabled == true)
                    this.btnOK.PerformClick();
                else
                    this.btnCancel.PerformClick();
            }
        }

        private void cbbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_UsernameLocal = this.cbbUsername.GetItemText(this.cbbUsername.SelectedItem).Trim();
            this.txtEdtPassword.Text = string.Empty;

            if (str_UsernameLocal != string.Empty)
            {
                btnOK.Enabled = true;
                this.getPassword(str_UsernameLocal);
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void cbbUsername_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string str_UsernameLocal = this.cbbUsername.GetItemText(this.cbbUsername.SelectedItem).Trim();
            this.txtEdtPassword.Text = string.Empty;

            if (str_UsernameLocal != string.Empty)
            {
                btnOK.Enabled = true;
                this.getPassword(str_UsernameLocal);
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void cbbUsername_TextChanged(object sender, EventArgs e)
        {
            string str_UsernameLocal = this.cbbUsername.Text.Trim();
            this.txtEdtPassword.Text = string.Empty;

            if (str_UsernameLocal != string.Empty)
            {
                btnOK.Enabled = true;
                this.getPassword(str_UsernameLocal);
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void cbbUsername_DropDown(object sender, EventArgs e)
        {
            this.cbbUsername.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbUsername.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbUsername_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbUsername.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbUsername.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.txtEdtServerIP.Enabled = true;
        }

        private void txtEdtServerIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string str_FilePathLocal = StaticVarClass.linkFile_ServerIP;
                string str_HostLocal = this.txtEdtServerIP.Text.Trim();

                if (this.isHost(str_HostLocal))
                {
                    StaticVarClass.server_Host = str_HostLocal;

                    if (System.IO.File.Exists(str_FilePathLocal))
                    {
                        // FileStream fs = new FileStream(str_FilePathLocal, FileMode.Open);

                        StreamWriter strWr = new StreamWriter(str_FilePathLocal);

                        strWr.WriteLine(str_HostLocal);

                        strWr.Close();

                        this.Close();

                        //Application.Restart();

                        formMain frmMain = formMain.Instance;

                        frmMain.setInfo(false);

                        //frmMain.Close();

                        Application.Restart();
                    }

                    // Khóa txtServer.
                    this.txtEdtServerIP.Enabled = false;
                }
                else
                {
                    this.txtEdtServerIP.Text = StaticVarClass.server_Host;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            timerOffApp.Stop();

            this.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void formLogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerOffApp.Stop();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}