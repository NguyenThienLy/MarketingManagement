using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ProjectManagement.DTO;

namespace ProjectManagement.DAO
{
    public class TaskDAO
    {
        private static TaskDAO instance;

        public static TaskDAO Instance
        {
            get { if (instance == null) instance = new TaskDAO(); return TaskDAO.instance; }

            set { TaskDAO.instance = value; }
        }

        private TaskDAO() { }

        public bool updateData(TaskDTO taskDTO)
        {
            if (taskDTO.ProjectID == string.Empty || taskDTO.Stage == string.Empty || taskDTO.Task == string.Empty)
                return false;

            string query = "UPDATE TASK SET TASKDESCRIPTION = '" + taskDTO.TaskDescription + "', STARTDATE = '" + taskDTO.StartDate + "', ENDDATE = '" + taskDTO.EndDate + "', TASKTYPE = '" + taskDTO.TaskType + "', APPROVAL = '" + taskDTO.Approval + "', NOTE = '" + taskDTO.Note + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool deleteData(string projectID, string stage, string task)
        {
            string query = "DELETE TASK WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}
