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
            string str_Query = ("SELECT * FROM HISTORY");

            DataTable result = DataProvider.Instance.ExecuteQuery(str_Query);

            return result;
        }

        public bool addData(HistoryDTO historyDTO)
        {
            if (historyDTO.Name == string.Empty || historyDTO.Time == string.Empty)
                return false;

            string str_Query = "INSERT INTO HISTORY VALUES ('" + historyDTO.Name + "', '" + historyDTO.Time + "', '" + historyDTO.Action + "', '" + historyDTO.Status + "')";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool deleteDataFollowNameAndTime(string name, string time)
        {
            if (name == string.Empty || time == string.Empty)
                return false;

            string str_Query = "DELETE HISTORY WHERE NAME = '" + name + "' AND TIME = '" + DateTime.Parse(time).ToString("MM/dd/yyyy HH:mm:ss") + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool deleteData()
        {
            string str_Query = "DELETE HISTORY";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }
    }
}
