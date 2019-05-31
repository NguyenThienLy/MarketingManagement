using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.DTO;

namespace ProjectManagement.DAO
{
    class AttachedFileDAO
    {
        // singleton.
        private static AttachedFileDAO instance;

        public static AttachedFileDAO Instance
        {
            get { if (instance == null) instance = new AttachedFileDAO(); return AttachedFileDAO.instance; }

            set { AttachedFileDAO.instance = value; }
        }

        private AttachedFileDAO() { }

        public DataTable getData(string projectID, string stage, string task)
        {
            string str_Query = ("SELECT TIME, FILENAME, NOTE FROM ATTACHEDFILE WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        public int getIntCheckHaveAttachedFile(string project, string stage, string task)
        {
            string str_Query = ("SELECT COUNT(*) FROM ATTACHEDFILE WHERE PROJECTID = '" + project + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        public bool addData(AttachedFileDTO attachedFileDTO)
        {
            if (attachedFileDTO.ProjectID == string.Empty || attachedFileDTO.Stage == string.Empty || attachedFileDTO.Task == string.Empty || attachedFileDTO.Time == string.Empty)
                return false;

            string str_Query = "INSERT INTO ATTACHEDFILE VALUES ('" + attachedFileDTO.ProjectID + "', '" + attachedFileDTO.Stage + "', '" + attachedFileDTO.Task + "', '" + DateTime.Parse(attachedFileDTO.Time).ToString("MM/dd/yyyy HH:mm:ss") + "', '" + attachedFileDTO.FileName + "', '" + attachedFileDTO.Note + "')";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        //public bool updateData(AttachedFileDTO attachedFileDTO)
        //{
        //    if (attachedFileDTO.ProjectID == string.Empty || attachedFileDTO.Stage == string.Empty || attachedFileDTO.Task == string.Empty || attachedFileDTO.Time == string.Empty)
        //        return false;

        //    string str_Query = "UPDATE ATTACHEDFILE SET FILENAME = '" + attachedFileDTO.FileName + "', NOTE = '" + attachedFileDTO.Note + "' WHERE PROJECTID = '" + attachedFileDTO.ProjectID + "' AND STAGE = '" + attachedFileDTO.Stage + "' AND TASK = '" + attachedFileDTO.Task + "' AND TIME = '" + attachedFileDTO.Time + "'";

        //    int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return i_Result > 0;
        //}

        public bool deleteData(string projectID, string stage, string task, string time)
        {
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty || time == string.Empty)
                return false;

            string str_Query = "DELETE ATTACHEDFILE WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'  AND TIME = '" + DateTime.Parse(time).ToString("MM/dd/yyyy HH:mm:ss") + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }
    }
}
