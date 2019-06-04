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
            string str_Query = ("SELECT * FROM DEPARTMENT");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        //public List<DepartmentDTO> getDataList()
        //{
        //    string str_Query = ("SELECT * FROM DEPARTMENT");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //    {
        //        return null;
        //    }

        //    List<DepartmentDTO> lst_DepartmentListResult = new List<DepartmentDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        DepartmentDTO departmentDTO = new DepartmentDTO(item);
        //        lst_DepartmentListResult.Add(departmentDTO);
        //    }

        //    return lst_DepartmentListResult;
        //}

        public bool addData(DepartmentDTO departmentDTO)
        {
            if (departmentDTO.Department == string.Empty)
                return false;

            string str_Query = string.Empty;

            if (departmentDTO.Leader == null)
                str_Query = "INSERT INTO DEPARTMENT VALUES ('" + departmentDTO.Department + "', NULL)";
            else
                str_Query = "INSERT INTO DEPARTMENT VALUES ('" + departmentDTO.Department + "', '" + departmentDTO.Leader + "')";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateData(DepartmentDTO departmentDTO, string newDepartment)
        {
            if (departmentDTO.Department == string.Empty || newDepartment == null)
                return false;

            string str_Query = string.Empty;

            if (departmentDTO.Leader == null)
                str_Query ="UPDATE DEPARTMENT SET DEPARTMENT = '" + newDepartment + "', LEADER = NULL WHERE DEPARTMENT = '" + departmentDTO.Department + "'";
            else
                str_Query = "UPDATE DEPARTMENT SET DEPARTMENT = '" + newDepartment + "', LEADER = '" + departmentDTO.Leader + "' WHERE DEPARTMENT = '" + departmentDTO.Department + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        //public bool deleteData(string department)
        //{
        //    if (department == string.Empty)
        //        return false;

        //    string str_Query = "DELETE DEPARTMENT WHERE DEPARTMENT = '" + department + "'";

        //    int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return i_Result > 0;
        //}

        //public bool checkAdmin(string leader)
        //{
        //    string str_Query = "SELECT COUNT(*) FROM DEPARTMENT WHERE LEADER = '" + leader + "'";

        //    int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

        //    return i_Result > 0;
        //}

        public bool checkLeader(string name)
        {
            string str_Query = "SELECT COUNT(*) FROM DEPARTMENT WHERE LEADER = '" + name + "'";

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result > 0;
        }
    }
}
