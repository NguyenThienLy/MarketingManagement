using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.DTO;
using ProjectManagement.CO;

namespace ProjectManagement.DAO
{
    public class EmployeeDAO
    {
        // singleton.
        private static EmployeeDAO instance;

        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return EmployeeDAO.instance; }

            set { EmployeeDAO.instance = value; }
        }

        private EmployeeDAO() { }

        // Lấy ra nhân viên đang làm việc của bảng Nhân Viên, bỏ cột mật khẩu.
        public DataTable getDataNotAllColumnsAndWorking()
        {
            string str_Query = ("SELECT NAME, FULLNAME, GENDER, YEAROFBIRTH, PHONE, EMAIL, POSITION, ROLE, DEPARTMENT, STATUS FROM EMPLOYEE WHERE STATUS = '" + StaticVarClass.status_Working + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        // Lấy ra nhân viên của bảng Nhân Viên, bỏ cột mật khẩu.
        public DataTable getDataNotAllColumns()
        {
            string str_Query = ("SELECT NAME, FULLNAME, GENDER, YEAROFBIRTH, PHONE, EMAIL, POSITION, ROLE, DEPARTMENT, STATUS FROM EMPLOYEE");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        // Lấy ra nhân viên duyệt task
        public DataTable getDataApprover(string employee)
        {
            string str_Query = ("SELECT NAME FROM EMPLOYEE WHERE NAME <> '" + employee + "' AND ROLE <> '" + StaticVarClass.role_Admin + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        // Lấy ra tất cả mail nhân viên đang làm việc của bảng Nhân Viên trừ name
        public DataTable getDataEmailFollowName(string name)
        {
            string str_Query = ("SELECT EMAIL FROM EMPLOYEE WHERE NAME <> '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        // Lấy ra danh sách các nhân viên đang làm việc theo phòng ban.
        public DataTable getDataFollowDepartment(string department)
        {
            string str_Query = ("SELECT * FROM EMPLOYEE WHERE DEPARTMENT = '" + department + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        // Lấy nhân viên đang làm việc cùng phòng ban để đẩy công việc.
        public DataTable getDataForAssigningTask(string name)
        {
            string str_Query = ("SELECT * FROM EMPLOYEE WHERE NAME <> '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "' AND DEPARTMENT = (SELECT DEPARTMENT FROM EMPLOYEE WHERE NAME = '" + name + "')");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        // Lấy dữ liệu theo tên employee đang làm việc.
        public EmployeeDTO getDataObjectFollowName(string name)
        {
            string str_Query = ("SELECT * FROM EMPLOYEE WHERE NAME = '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return null;

            if (dt_Result.Rows.Count == 0)
            {
                EmployeeDTO employeeDTOResulTemp = new EmployeeDTO();

                return employeeDTOResulTemp;
            }

            DataRow dtR_dataRow = dt_Result.Rows[0];

            EmployeeDTO employeeDTOResult = new EmployeeDTO(dtR_dataRow);

            return employeeDTOResult;
        }

        // Lấy ra danh sách các nhân viên đang làm việc theo phòng ban.
        //public List<EmployeeDTO> getDataListFollowDepartment(string department)
        //{
        //    string str_Query = ("SELECT * FROM EMPLOYEE WHERE DEPARTMENT = '" + department + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<EmployeeDTO> lst_EmpListResult = new List<EmployeeDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        EmployeeDTO employeeDTO = new EmployeeDTO(item);
        //        lst_EmpListResult.Add(employeeDTO);
        //    }

        //    return lst_EmpListResult;
        //}

        // Lấy ra danh sách tất cả các nhân viên đang làm việc.
        //public List<EmployeeDTO> getDataListAllColumns()
        //{
        //    string str_Query = ("SELECT * FROM EMPLOYEE WHERE STATUS = '" + StaticVarClass.status_Working + "'");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<EmployeeDTO> lst_EmpListResult = new List<EmployeeDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        EmployeeDTO employeeDTO = new EmployeeDTO(item);
        //        lst_EmpListResult.Add(employeeDTO);
        //    }

        //    return lst_EmpListResult;
        //}

        // Lấy password của một người đang làm việc.
        //public string getStringPasswordFollowName(string name)
        //{
        //    string str_Query = ("SELECT PASSWORD FROM EMPLOYEE WHERE NAME = '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Result == null)
        //        return null;

        //    if (dt_Result.Rows.Count == 0)
        //        return string.Empty;

        //    return dt_Result.Rows[0].ItemArray[0].ToString().Trim();
        //}

        // Lấy cột role nhân viên đang làm việc để phân quyền.
        public string getStringRoleFollowName(string name)
        {
            string str_Query = ("SELECT ROLE FROM EMPLOYEE WHERE NAME = '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return null;

            if (dt_Result.Rows.Count == 0)
                return string.Empty;

            return dt_Result.Rows[0].ItemArray[0].ToString().Trim();
        }

        // Lấy phòng của một người đang làm việc.
        //public string getStringDepartmentFollowName(string name)
        //{
        //    string str_Query = ("SELECT DEPARTMENT FROM EMPLOYEE WHERE NAME = '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Result == null)
        //        return null;

        //    if (dt_Result.Rows.Count == 0)
        //        return string.Empty;

        //    return dt_Result.Rows[0].ItemArray[0].ToString().Trim();
        //}

        // Lấy email của một người đang làm việc.
        public string getStringEmailFollowName(string name)
        {
            string str_Query = ("SELECT EMAIL FROM EMPLOYEE WHERE NAME = '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return null;

            if (dt_Result.Rows.Count == 0)
                return string.Empty;

            return dt_Result.Rows[0].ItemArray[0].ToString().Trim();
        }

        // Lấy ra số lượng nhân viên đang làm việc theo phòng ban.
        //public int getIntNumberFollowDepartment(string department)
        //{
        //    string str_Query = ("SELECT COUNT(*) FROM EMPLOYEE WHERE DEPARTMENT = '" + department + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

        //    int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

        //    return i_Result;
        //}

        public int getDataIntOrdinalNumberDepartmentFollowEmployee(string employee)
        {
            string str_Query = ("SELECT DEPARTMENT FROM EMPLOYEE WHERE NAME = '" + employee + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            string str_Dept = DataProvider.Instance.ExecuteScalar(str_Query).ToString().Trim();

            switch (str_Dept)
            {
                case "Customer Service":
                    return 0;

                case "Design":
                    return 1;

                case "HR":
                    return 2;

                case "Marketing":
                    return 3;

                case "Purchase":
                    return 4;

                case "RSD":
                    return 5;

                case "Shop Staff":
                    return 6;

                case "Ware House":
                    return 7;
            }

            return 0;
        }

        // Thêm mới 1 nhân viên.
        public bool addData(EmployeeDTO employeeDTO)
        {
            if (employeeDTO.Name == string.Empty || employeeDTO.Department == null || employeeDTO.Role == null)
                return false;

            string str_Query = ("INSERT INTO EMPLOYEE VALUES ('" + employeeDTO.Name + "', '" + employeeDTO.Password + "', '" + employeeDTO.FullName + "', '" 
                + employeeDTO.Gender + "', '" + employeeDTO.YearOfBirth + "', '" + employeeDTO.Phone + "', '" + employeeDTO.Email + "', '" 
                + employeeDTO.Position + "', '" + employeeDTO.Role + "', '" + employeeDTO.Department + "', '" + employeeDTO.Status + "')");

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        // Cập nhật tất cả các cột của bảng nhân viên.
        //public bool updateData(EmployeeDTO employeeDTO)
        //{
        //    if (employeeDTO.Name == string.Empty || employeeDTO.Department == null || employeeDTO.Role == null)
        //        return false;

        //    string str_Query = ("UPDATE EMPLOYEE SET PASSWORD = '" + employeeDTO.Password + "', FULLNAME = '" + employeeDTO.FullName + "', GENDER = '" 
        //        + employeeDTO.Gender + "', YEAROFBIRTH = '" + employeeDTO.YearOfBirth + "', PHONE = '" + employeeDTO.Phone + "', EMAIL = '" 
        //        + employeeDTO.Email + "', POSITION = '" + employeeDTO.Position + "', ROLE = '" + employeeDTO.Role + "', DEPARTMENT = '" 
        //        + employeeDTO.Department + "', STATUS = '" + employeeDTO.Status + "' WHERE NAME = '" + employeeDTO.Name + "'");

        //    int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return i_Result > 0;
        //}

        // Cập nhật cấp bậc cho nhân viên đang làm việc.
        //public bool updateDataRole(string name, string role)
        //{
        //    if (name == string.Empty || role == null)
        //        return false;

        //    string str_Query = "UPDATE EMPLOYEE SET ROLE = '" + role + "' WHERE NAME = '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'";

        //    int result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return result > 0;
        //}

        // Cập nhật tất cả các cột của bảng nhân viên trừ cột mật khẩu.
        public bool updateDataNotAllColumns(EmployeeDTO employeeDTO)
        {
            if (employeeDTO.Name == string.Empty || employeeDTO.Department == null || employeeDTO.Role == null) // department, role not null.
                return false;

            string str_Query = ("UPDATE EMPLOYEE SET FULLNAME = '" + employeeDTO.FullName + "', GENDER = '" + employeeDTO.Gender + "', YEAROFBIRTH = '" 
                + employeeDTO.YearOfBirth + "', PHONE = '" + employeeDTO.Phone + "', EMAIL = '" + employeeDTO.Email + "', POSITION = '" 
                + employeeDTO.Position + "', ROLE = '" + employeeDTO.Role + "', DEPARTMENT = '" + employeeDTO.Department + "' , STATUS = '" 
                + employeeDTO.Status + "' WHERE NAME = '" + employeeDTO.Name + "'");

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        // Cập nhật password mới cho nhân viên đang làm việc.
        public bool updateDataPassword(string name, string newPassword)
        {
            if (name == string.Empty)
                return false;

            string str_Query = ("UPDATE EMPLOYEE SET PASSWORD = '" + newPassword + "' WHERE NAME = '" + name + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        // Xóa dữ liệu của 1 nhân viên.
        public bool deleteData(string name)
        {
            if (name == string.Empty)
                return false;

            string str_Query = ("DELETE EMPLOYEE WHERE NAME = '" + name + "'");

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        // Kiểm tra login của nhân viên đang làm việc.
        public bool checkLogin(string name, string password)
        {
            string str_Query = ("SELECT COUNT(*) FROM EMPLOYEE WHERE NAME = '" + name + "' AND PASSWORD = '" + password + "' AND STATUS = '" + StaticVarClass.status_Working + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result == 1;
        }
    }
}
