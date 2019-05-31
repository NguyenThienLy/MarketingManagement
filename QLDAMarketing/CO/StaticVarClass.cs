using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.View;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.IO;

namespace ProjectManagement.CO
{
    // Biến toàn cục cho tên đăng nhập
    public class StaticVarClass
    {
        #region time
        public static int timeAutoOff = 5 * 1000;

        public static int timeAutoOffFormLogIn = 1 * 1000;
        #endregion

        #region Link file server IP.
        public static string linkFile_ServerIP = "Server.txt";
        public static string linkFile_Account = "Account.txt";
        #endregion

        #region server.
        public static string server_Host = getHost();

        public static string server_ServerDirectory = @"\\" + server_Host + @"\Server\";

        public static string server_ConnectSQLServer = server_Host;

        public static string server_ConnectSQLServerCatalog = "ProjectManagement";

        // sửa cái này cho đúng với máy bà
        public static string server_ConnectSQLServerUser = "sa";

        public static string server_ConnectSQLServerPass = "123456789";
        #endregion

        #region account.
        public static string account_Username = string.Empty;

        public static string account_Password = string.Empty;
        #endregion

        #region ftp.
        public static string ftp_Username = "ly";

        public static string ftp_Password = "1";

        public static string ftp_Server = @"ftp://" + server_Host + "/";
        #endregion

        #region form.
        public static Form formMenu = null;

        public static Form formProjectHistory = null;

        public static Form formPersonalInformation = null;

        public static Form formEmployee = null;

        public static Form formDepartment = null;

        public static Form formProject = null;

        public static Form formStage = null;

        public static Form formTaskCreating = null;

        public static Form formHistory = null;

        public static Form formProjectDiagram = null;
        #endregion

        #region Role
        public static string role_Admin = "Admin";
        public static string role_Member = "Member";
        public static string role_Staff = "Staff";
        #endregion

        #region status.
        public static string status_Complete = "Complete";
        public static string status_NotComplete = "Not complete";
        public static string status_Overdue = "Overdue";
        public static string status_AssignedTask = "Assigned task";
        public static string status_WaitForApproval = "Wait for approval";
        public static string status_NeedApproving = "Need approving";

        public static string status_Working = "Working";
        public static string status_NotWorking = "Not working";
        #endregion

        #region type.
        public static string type_Normal = "Normal";
        public static string type_AdminApproval = "Admin approval";
        #endregion

        #region POSMProject.
        public static string POSM_POSMProject = "Yes";

        public static string POSM_NotPOSMProject = "No";
        #endregion

        #region other.
        public static int maxStage = 20;

        public static int numberOfDept = 8;

        public static string completeProgress = "100";
        #endregion

        #region email.
        public static int email_PortEmail = 587;

        public static string email_HostEmail = "smtp.gmail.com";
        #endregion

        #region Btn Task creating.
        public static int btn_TaskCreatingWidth = 200;
        public static int btn_TaskCreatingHeight = 80;
        #endregion

        #region Dept.
        public static string dept_CustomerService = "Customer Service";
        public static string dept_Design = "Design";
        public static string dept_HR = "HR";
        public static string dept_Marketing = "Marketing";
        public static string dept_Purchase = "Purchase";
        public static string dept_RSD = "RSD";
        public static string dept_ShopStaff = "Shop Staff";
        public static string dept_WareHouse = "Ware House";
        public static int dept_Quantity = 8;
        #endregion

        #region attach file.
        public static string attachFile_Yes = "Yes";

        public static string attachFile_No = "No";
        #endregion

        #region Yes/No
        public static string YN_Yes = "Yes";
        public static string YN_No = "No";
        #endregion

        #region status project.
        public static string projectSelect_ProjectsInProgress = "Projects in progress";
        public static string projectSelect_CompletedProjects = "Completed projects";
        public static string projectSelect_DepartmentProjects = "Department projects";
        #endregion

        #region gmail.
        public static string gmail_User = "LongDanKimSonOffice2018@gmail.com";
        public static string gmail_Password = "123456789aA123456789";
        #endregion

        // Hàm lấy host.
        public static string getHost()
        {
            string str_FilePathLocal = StaticVarClass.linkFile_ServerIP;
            string str_HostLocal = string.Empty;

            if (System.IO.File.Exists(str_FilePathLocal))
            {
                // FileStream fs = new FileStream(str_FilePathLocal, FileMode.Open);

                StreamReader strRd = new StreamReader(str_FilePathLocal);

                str_HostLocal = strRd.ReadLine();

                strRd.Close();
            }
            else
            {
                XtraMessageBox.Show("File does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return str_HostLocal;
        }
    }
}
