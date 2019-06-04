using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    public class HistoryBUS
    {
        // singleton.
        private static HistoryBUS instance;

        public static HistoryBUS Instance
        {
            get { if (instance == null) instance = new HistoryBUS(); return HistoryBUS.instance; }

            set { HistoryBUS.instance = value; }
        }

        private HistoryBUS() { }

        public DataTable getData()
        {
            return HistoryDAO.Instance.getData();
        }

        public bool addData(HistoryDTO historyDTO)
        {
            if (historyDTO.Name == string.Empty || historyDTO.Time == string.Empty)
                return false;

            return HistoryDAO.Instance.addData(historyDTO);
        }

        public bool deleteDataFollowNameAndTime(string name, string time)
        {
            if (name == string.Empty || time == string.Empty)
                return false;

            return HistoryDAO.Instance.deleteDataFollowNameAndTime(name, time);
        }

        public bool deleteData()
        {
            return HistoryDAO.Instance.deleteData();
        }
    }
}
