using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.DTO;

namespace ProjectManagement.DAO
{
    public class DepartmentDAO
    {
        // singleton.
        private static DepartmentDAO instance;

        public static DepartmentDAO Instance
        {
            get { if (instance == null) instance = new DepartmentDAO(); return DepartmentDAO.instance; }

            set { DepartmentDAO.instance = value; }
        }

        private DepartmentDAO() { }

        public DataTable getData()
        {
            string query = ("SELECT * FROM DEPARTMENT");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        public List<DepartmentDTO> getDataList()
        {
            string query = ("SELECT * FROM DEPARTMENT");

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<DepartmentDTO> deptListResult = new List<DepartmentDTO>();

            foreach (DataRow item in data.Rows)
            {
                DepartmentDTO deptDTO = new DepartmentDTO(item);
                deptListResult.Add(deptDTO);
            }

            return deptListResult;
        }

        public bool addData(DepartmentDTO deptDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (deptDTO.Department == string.Empty || deptDTO.Leader == "null")
                return false;

            string query = "INSERT INTO DEPARTMENT VALUES ('" + deptDTO.Department + "', '" + deptDTO.Leader + "')";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateData(DepartmentDTO deptDTO)
        {
            if (deptDTO.Department == string.Empty || deptDTO.Leader == "null")
                return false;

            string query = "UPDATE DEPARTMENT SET LEADER = '" + deptDTO.Leader + "' WHERE DEPARTMENT = '" + deptDTO.Department + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool deleteData(string department)
        {
            if (department == string.Empty)
                return false;

            string query = "DELETE DEPARTMENT WHERE DEPARTMENT = '" + department + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool checkAdmin(string leader)
        {
            string query = "SELECT COUNT(*) FROM DEPARTMENT WHERE LEADER = '" + leader + "'";

            int result = (int)DataProvider.Instance.ExecuteScalar(query);

            return result >= 1;
        }
    }
}
