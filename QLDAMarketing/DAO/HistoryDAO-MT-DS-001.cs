using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.DTO;

namespace ProjectManagement.DAO
{
    public class HistoryDAO
    {
        // singleton.
        private static HistoryDAO instance;

        public static HistoryDAO Instance
        {
            get { if (instance == null) instance = new HistoryDAO(); return HistoryDAO.instance; }

            set { HistoryDAO.instance = value; }
        }

        private HistoryDAO() { }

        public DataTable getData()
        {
            string query = ("SELECT * FROM HISTORY");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        public bool addData(HistoryDTO hisDTO)
        {
            if (hisDTO.Name == string.Empty || hisDTO.Time == string.Empty)
                return false;

            string query = "INSERT INTO HISTORY VALUES ('" + hisDTO.Name + "', '" + hisDTO.Time + "', '" + hisDTO.Action + "', '" + hisDTO.Status + "')";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool deleteData()
        {
            string query = "DELETE HISTORY";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
