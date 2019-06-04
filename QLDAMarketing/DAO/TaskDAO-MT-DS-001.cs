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

        public DataTable getData()
        {
            string query = ("SELECT * FROM TASK");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        public DataTable getDataFollowProjectIDAndStage(string projectID, string stage)
        {
            string query = ("SELECT * FROM TASK WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result;
        }

        public TaskDTO getDataRowFollowProjectIDAndStageAndTask_taskDTO(string projectID, string stage, string task)
        {
            string query = ("SELECT * FROM TASK WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            DataRow data = result.Rows[0];

            TaskDTO taskDTO = new TaskDTO(data);

            return taskDTO;
        }

        public List<TaskDTO> getDataList()
        {
            string query = ("SELECT * FROM TASK");

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<TaskDTO> taskListResult = new List<TaskDTO>();

            foreach (DataRow item in data.Rows)
            {
                TaskDTO taskDTO = new TaskDTO(item);
                taskListResult.Add(taskDTO);
            }

            return taskListResult;
        }

        public bool addData(TaskDTO taskDTO)
        {
            if (taskDTO.ProjectID == string.Empty || taskDTO.Stage == string.Empty || taskDTO.Task == string.Empty)
                return false;

            string query = "INSERT INTO TASK VALUES ('" + taskDTO.ProjectID + "', '" + taskDTO.Stage + "', '" + taskDTO.Task + "', '" + taskDTO.TaskDescription + "', '" + taskDTO.StartDate + "', '" + taskDTO.EndDate + "', '" + taskDTO.TaskType + "', '" + taskDTO.Note + "')";

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool updateData(TaskDTO taskDTO)
        {
            if (taskDTO.ProjectID == string.Empty || taskDTO.Stage == string.Empty || taskDTO.Task == string.Empty)
                return false;

            string query = "UPDATE TASK SET TASKDESCRIPTION = '" + taskDTO.TaskDescription + "', STARTDATE = '" + taskDTO.StartDate + "', ENDDATE = '" + taskDTO.EndDate + "', TASKTYPE = '" + taskDTO.TaskType + "', NOTE = '" + taskDTO.Note + "'";

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
