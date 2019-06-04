using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    public class EmployeeBUS
    {
        // singleton.
        private static EmployeeBUS instance;

        public static EmployeeBUS Instance
        {
            get { if (instance == null) instance = new EmployeeBUS(); return EmployeeBUS.instance; }

            set { EmployeeBUS.instance = value; }
        }

        private EmployeeBUS() { }

        // Lấy ra nhân viên đang làm việc của bảng Nhân Viên, bỏ cột mật khẩu.
        public DataTable getDataNotAllColumnsAndWorking()
        {
            return EmployeeDAO.Instance.getDataNotAllColumnsAndWorking();
        }

        // Lấy ra nhân viên của bảng Nhân Viên, bỏ cột mật khẩu.
        public DataTable getDataNotAllColumns()
        {

            return EmployeeDAO.Instance.getDataNotAllColumns();
        }

        // Lấy ra nhân viên duyệt task
        public DataTable getDataApprover(string employee)
        {
            return EmployeeDAO.Instance.getDataApprover(employee);
        }

        // Lấy ra tất cả mail nhân viên đang làm việc của bảng Nhân Viên trừ name
        public DataTable getDataEmailFollowName(string name)
        {
            return EmployeeDAO.Instance.getDataEmailFollowName(name);
        }

        // Lấy ra danh sách các nhân viên đang làm việc theo phòng ban.
        public DataTable getDataFollowDepartment(string department)
        {
            return EmployeeDAO.Instance.getDataFollowDepartment(department);
        }

        // Lấy nhân viên đang làm việc cùng phòng ban để đẩy công việc.
        public DataTable getDataForAssigningTask(string name)
        {
            return EmployeeDAO.Instance.getDataForAssigningTask(name);
        }

        // Lấy dữ liệu theo tên employee đang làm việc.
        public EmployeeDTO getDataObjectFollowName(string name)
        {
            return EmployeeDAO.Instance.getDataObjectFollowName(name);
        }

        // Lấy cột role nhân viên đang làm việc để phân quyền.
        public string getStringRoleFollowName(string name)
        {
            return EmployeeDAO.Instance.getStringRoleFollowName(name);
        }

        // Lấy email của một người đang làm việc.
        public string getStringEmailFollowName(string name)
        {
            return EmployeeDAO.Instance.getStringEmailFollowName(name);
        }

        public int getDataIntOrdinalNumberDepartmentFollowEmployee(string employee)
        {
            return EmployeeDAO.Instance.getDataIntOrdinalNumberDepartmentFollowEmployee(employee);
        }

        // Thêm mới 1 nhân viên.
        public bool addData(EmployeeDTO employeeDTO)
        {
            if (employeeDTO.Name == string.Empty || employeeDTO.Department == null || employeeDTO.Role == null)
                return false;

            return EmployeeDAO.Instance.addData(employeeDTO);
        }


        // Cập nhật tất cả các cột của bảng nhân viên trừ cột mật khẩu.
        public bool updateDataNotAllColumns(EmployeeDTO employeeDTO)
        {
            if (employeeDTO.Name == string.Empty || employeeDTO.Department == null || employeeDTO.Role == null) // department, role not null.
                return false;

            return EmployeeDAO.Instance.updateDataNotAllColumns(employeeDTO);
        }

        // Cập nhật password mới cho nhân viên đang làm việc.
        public bool updateDataPassword(string name, string newPassword)
        {
            if (name == string.Empty)
                return false;

            return EmployeeDAO.Instance.updateDataPassword(name, newPassword);
        }

        // Xóa dữ liệu của 1 nhân viên.
        public bool deleteData(string name)
        {
            if (name == string.Empty)
                return false;

            return EmployeeDAO.Instance.deleteData(name);
        }

        // Kiểm tra login của nhân viên đang làm việc.
        public bool checkLogin(string name, string password)
        {
            return EmployeeDAO.Instance.checkLogin(name, password);
        }
    }
}
