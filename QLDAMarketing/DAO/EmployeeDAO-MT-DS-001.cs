using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.DTO;

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

        // Lấy ra tất cả nhân viên của bảng Nhân Viên, bỏ cột mật khẩu.
        public DataTable getDataNotAllColumns()
        {
            string query = ("SELECT NAME, FULLNAME, GENDER, YEAROFBIRTH, PHONE, EMAIL, POSITION, ROLE, DEPARTMENT FROM EMPLOYEE");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        // Lấy các cột mã nhân viên, cột cấp bậc để phân quyền.
        public DataTable getDataForAuthorizing()
        {
            string query =  ("SELECT NAME, ROLE FROM EMPLOYEE");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        // Lấy ra danh sách các nhân viên theo phòng ban.
        public DataTable getDataFollowDepartment(string department)
        {
            string query = ("SELECT * FROM EMPLOYEE WHERE DEPARTMENT = '" + department + "'");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        // Lấy nhân viên cùng phòng ban để đẩy công việc.
        public DataTable getDataListForAssigningTask(string name)
        {
            string query = ("SELECT * FROM EMPLOYEE WHERE NAME != '" + name + "' AND DEPARTMENT = (SELECT DEPARTMENT FROM EMPLOYEE WHERE NAME = '" + name + "')");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        // Lấy dữ liệu theo tên employee.
        public DataRow getDataRowFollowName(string name)
        {       
            string query = ("SELECT * FROM EMPLOYEE WHERE NAME = '" + name + "' ");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows[0];
        }

        // Lấy cột role để phân quyền.
        public DataColumn getDataColumnRole(string name)
        {
            string query = ("SELECT ROLE FROM EMPLOYEE WHERE NAME = '" + name + "'");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Columns[0];
        }

        // Lấy cột mã nhân viên.
        public DataColumn getDataColumnName()
        {
            string query = ("SELECT NAME FROM EMPLOYEE");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Columns[0];
        }

        // Lấy ra nhân viên theo mã nhân viên.
        public EmployeeDTO getDataRowFollowName_empDTO(string name)
        {
            string query = ("SELECT * FROM EMPLOYEE WHERE NAME = '" + name + "' ");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            DataRow data = result.Rows[0];

            EmployeeDTO empDTO = new EmployeeDTO(data);

            return empDTO;
        }

        // Lấy ra danh sách các nhân viên theo phòng ban.
        public List<EmployeeDTO> getDataListFollowDepartment(string department)
        {
            string query = ("SELECT * FROM EMPLOYEE WHERE DEPARTMENT = '" + department + "'");

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<EmployeeDTO> empListResult = new List<EmployeeDTO>();

            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO empDTO = new EmployeeDTO(item);
                empListResult.Add(empDTO);
            }

            return empListResult;
        }

        // Lấy ra danh sách tất cả các nhân viên.
        public List<EmployeeDTO> getDataListAllColumns()
        {
            string query = ("SELECT * FROM EMPLOYEE");

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<EmployeeDTO> empListResult = new List<EmployeeDTO>();

            foreach (DataRow item in data.Rows)
            {
                EmployeeDTO empDTO = new EmployeeDTO(item);
                empListResult.Add(empDTO);
            }

            return empListResult;
        }

        // Lấy password của một người.
        public string getStringPasswordFollowName(string name)
        {
            string query = ("SELECT PASSWORD FROM EMPLOYEE WHERE NAME = '" + name + "'");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows[0].ItemArray[0].ToString();
        }

        // Thêm mới 1 nhân viên.
        public bool addData(EmployeeDTO empObj)
        {
            if (empObj.Name == string.Empty || empObj.Department == "null")
                return false;

            string query = ("INSERT INTO EMPLOYEE VALUES ('" + empObj.Name + "', '" + empObj.Password + "', '" + empObj.FullName + "', '" + empObj.Gender + "', '" + empObj.YearOfBirth + "', '" + empObj.Phone + "', '" + empObj.Email + "', '" + empObj.Position + "', '" + empObj.Role + "', '" + empObj.Department + "')");

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Cập nhật tất cả các cột của bảng nhân viên.
        public bool updateData(EmployeeDTO empObj)
        {
            if (empObj.Name == string.Empty || empObj.Department == "null")
                return false;

            string query = ("UPDATE EMPLOYEE SET PASSWORD = '" + empObj.Password + "', FULLNAME = '" + empObj.FullName + "', GENDER = '" + empObj.Gender + "', YEAROFBIRTH = '" + empObj.YearOfBirth + "', PHONE = '" + empObj.Phone + "', EMAIL = '" + empObj.Email + "', POSITION = '" + empObj.Position + "', ROLE = '" + empObj.Role + "', DEPARTMENT = '" + empObj.Department + "' WHERE NAME = '" + empObj.Name + "'");

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Cập nhật cấp bậc.
        public bool updateDataRole(string name, string role)
        {
            if (name == string.Empty)
                return false;

            string query = "UPDATE EMPLOYEE SET ROLE = '" + role + "' WHERE NAME = '" + name + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Cập nhật tất cả các cột của bảng nhân viên trừ cột mật khẩu.
        public bool updateDataNotAllColumns(EmployeeDTO empObj)
        {
            // Nếu khóa chính trống thì không thể cập nhật.
            if (empObj.Name == string.Empty || empObj.Department == "null")
                return false;

            string query = ("UPDATE EMPLOYEE SET FULLNAME = '" + empObj.FullName + "', GENDER = '" + empObj.Gender + "', YEAROFBIRTH = '" + empObj.YearOfBirth + "', PHONE = '" + empObj.Phone + "', EMAIL = '" + empObj.Email + "', POSITION = '" + empObj.Position + "', ROLE = '" + empObj.Role + "', DEPARTMENT = '" + empObj.Department + "' WHERE NAME = '" + empObj.Name + "'");

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Cập nhật password mới cho nhân viên.
        public bool updateDataPassword(string name, string newPassword)
        {
            if (name == string.Empty)
                return false;

            string query = ("UPDATE EMPLOYEE SET PASSWORD = '" + newPassword + "' WHERE NAME = '" + name + "'");

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Xóa dữ liệu của 1 nhân viên.
        public bool deleteData(string name)
        {
            if (name == string.Empty)
                return false;

            string query = ("DELETE EMPLOYEE WHERE NAME = '" + name + "'");

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        // Kiểm tra login.
        public bool checkLogin(string name, string password)
        {
            string query = ("SELECT COUNT(*) FROM EMPLOYEE WHERE NAME = '" + name + "' AND PASSWORD = '" + password + "'");

            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result == 1;
        }    
    }
}
