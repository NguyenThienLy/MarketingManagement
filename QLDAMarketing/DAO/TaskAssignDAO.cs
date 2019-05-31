using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ProjectManagement.DTO;
using ProjectManagement.CO;

namespace ProjectManagement.DAO
{
    class TaskAssignDAO
    {
        // singleton.
        private static TaskAssignDAO instance;

        public static TaskAssignDAO Instance
        {
            get { if (instance == null) instance = new TaskAssignDAO(); return TaskAssignDAO.instance; }

            set { TaskAssignDAO.instance = value; }
        }

        private TaskAssignDAO() { }

        //public DataTable getData()
        //{
        //    string str_Query = ("SELECT * FROM TASKASSIGN");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    return dt_Result;
        //}

        //public TaskCreatingDTO getDataObjectFollowAllPrimaryKeys(string projectID, string stage, string task, string employee)
        //{
        //    string str_Query = ("SELECT * FROM TASKASSIGN WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "' AND EMPLOYEE = '" + employee + "'");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    if (dt_Data.Rows.Count == 0)
        //    {
        //        TaskCreatingDTO taskCreatingDTOResultTemp = new TaskCreatingDTO();

        //        return taskCreatingDTOResultTemp;
        //    }

        //    DataRow dtR_DataRow = dt_Data.Rows[0];

        //    TaskCreatingDTO taskCreatingDTOResult = new TaskCreatingDTO(dtR_DataRow);

        //    return taskCreatingDTOResult;
        //}

        //public List<TaskAssignDTO> getDataList()
        //{
        //    string str_Query = ("SELECT * FROM TASKASSIGN");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<TaskAssignDTO> lst_TaskAssignListResult = new List<TaskAssignDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        TaskAssignDTO taskCreatingDTO = new TaskAssignDTO(item);
        //        lst_TaskAssignListResult.Add(taskCreatingDTO);
        //    }

        //    return lst_TaskAssignListResult;
        //}

        public bool addData(TaskAssignDTO taskAssignDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskAssignDTO.Employee == string.Empty || taskAssignDTO.ProjectID == string.Empty || taskAssignDTO.Stage == string.Empty || taskAssignDTO.Task == string.Empty)
                return false;

            string str_Query = "INSERT INTO TASKASSIGN VALUES ('" + taskAssignDTO.ProjectID + "' , '" + taskAssignDTO.Stage + "', '"
                + taskAssignDTO.Task + "', '" + taskAssignDTO.Employee + "', '" + taskAssignDTO.TaskDescription + "', '"
                + DateTime.Parse(taskAssignDTO.StartDate).ToString("MM/dd/yyyy") + "', '" + DateTime.Parse(taskAssignDTO.EndDate).ToString("MM/dd/yyyy") + "', '" + taskAssignDTO.TaskType + "', '"
                + taskAssignDTO.Approval + "', '" + taskAssignDTO.AttachFile + "', '" + taskAssignDTO.Progress + "', '"
                + taskAssignDTO.Status + "', NULL, '" + taskAssignDTO.TimeDelay + "', '"
                + taskAssignDTO.Color + "', '" + taskAssignDTO.Note + "')";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        //public bool updateData(TaskAssignDTO taskAssignDTO)
        //{
        //    // Nếu khóa chính trống thì không thể thêm vào.
        //    if (taskAssignDTO.Employee == string.Empty || taskAssignDTO.ProjectID == string.Empty || taskAssignDTO.Stage == string.Empty || taskAssignDTO.Task == string.Empty)
        //        return false;

        //    string str_Query = "UPDATE TASKCREATING SET EMPLOYEE = '" + taskAssignDTO.Employee + "', TASKDESCRIPTION = '"
        //        + taskAssignDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskAssignDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
        //        + DateTime.Parse(taskAssignDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '" + taskAssignDTO.TaskType + "', APPROVAL = '"
        //        + taskAssignDTO.Approval + "', ATTACHFILE = '" + taskAssignDTO.AttachFile + "', PROGRESS = '"
        //        + taskAssignDTO.Progress + "', STATUS = '" + taskAssignDTO.Status + "', FINISHDATE = '"
        //        + DateTime.Parse(taskAssignDTO.FinishDate).ToString("MM/dd/yyyy") + "', TIMEDELAY = '" + taskAssignDTO.TimeDelay + "', COLOR = '"
        //        + taskAssignDTO.Color + "', NOTE = '"+ taskAssignDTO.Note + "' WHERE PROJECTID = '" 
        //        + taskAssignDTO.ProjectID + "' AND STAGE = '"
        //        + taskAssignDTO.Stage + "' AND TASK = '" + taskAssignDTO.Task + "'";

        //    int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return i_Result > 0;
        //}

        //public bool updateDataAssignTask(TaskAssignDTO taskAssignDTO)
        //{
        //    // Nếu khóa chính trống thì không thể thêm vào.
        //    if (taskAssignDTO.Employee == string.Empty || taskAssignDTO.ProjectID == string.Empty || taskAssignDTO.Stage == string.Empty || taskAssignDTO.Task == string.Empty)
        //        return false;

        //    string str_Query = "UPDATE TASKCREATING SET EMPLOYEE = '" + taskAssignDTO.Employee + "', TASKDESCRIPTION = '"
        //        + taskAssignDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskAssignDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
        //        + DateTime.Parse(taskAssignDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '" + taskAssignDTO.TaskType + "', APPROVAL = '"
        //        + taskAssignDTO.Approval + "', ATTACHFILE = '" + taskAssignDTO.AttachFile + "', PROGRESS = '"
        //        + taskAssignDTO.Progress + "', STATUS = '" + taskAssignDTO.Status + "', FINISHDATE = NULL, TIMEDELAY = '" + taskAssignDTO.TimeDelay + "', COLOR = '"
        //        + taskAssignDTO.Color + "', NOTE = '" + taskAssignDTO.Note + "' WHERE PROJECTID = '"
        //        + taskAssignDTO.ProjectID + "' AND STAGE = '"
        //        + taskAssignDTO.Stage + "' AND TASK = '" + taskAssignDTO.Task + "'";

        //    int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return i_Result > 0;
        //}

        //public bool deleteData(string projectID, string stage, string task, string employee)
        //{
        //    if (projectID == string.Empty || stage == string.Empty || task == string.Empty || employee == string.Empty)
        //        return false;

        //    string str_Query = "DELETE TASKASSIGN WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "' AND EMPLOYEE = '" + employee + "'";

        //    int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return i_Result > 0;
        //}
    }
}
