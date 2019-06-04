using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.DTO;
using ProjectManagement.CO;

namespace ProjectManagement.DAO
{
    public class TaskCreatingDAO
    {
        // singleton.
        private static TaskCreatingDAO instance;

        public static TaskCreatingDAO Instance
        {
            get { if (instance == null) instance = new TaskCreatingDAO(); return TaskCreatingDAO.instance; }

            set { TaskCreatingDAO.instance = value; }
        }

        private TaskCreatingDAO() { }

        public DataTable getData()
        {
            string str_Query = ("SELECT * FROM TASKCREATING");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        public DataTable getDataForFormProjectHistory(string employee, string startDate, string endDate, string POSMProject, string status)
        {
            string str_Query = ("EXECUTE sp_getDataForFormProjectHistory '" + employee + "', '" + startDate + "', '" + endDate + "', '" + POSMProject + "', '" + status + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        public DataTable getDataForFormMyTask(string employee, string startDate, string endDate, string POSMProject, string status)
        {
            string str_Query = ("EXECUTE sp_getDataForFormMyTask '" + employee + "', '" + startDate + "', '" + endDate + "', '" + POSMProject + "', '" + status + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        public DataTable getDataFollowProjectID(string projectID)
        {
            string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        //public DataTable getDataFollowProjectIDAndStage(string projectID, string stage)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    return dt_Result;
        //}

        //public DataTable getDataFollowProjectIDAndStageAndTask(string projectID, string stage, string task)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    return dt_Result;
        //}

        //public DataTable getDataForFormTaskDetail(string employee, string startDate, string endDate)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE EMPLOYEE = '" + employee + "' AND STARTDATE >= '" + DateTime.Parse(startDate).ToString("MM/dd/yyyy") + "' AND ENDDATE <= '" + DateTime.Parse(endDate).ToString("MM/dd/yyyy") + "'");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    return dt_Result;
        //}

        public TaskCreatingDTO getDataObjectFollowProjectIDAndStageAndTask(string projectID, string stage, string task)
        {
            string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0)
            {
                TaskCreatingDTO taskCreatingDTOTemp = new TaskCreatingDTO();

                return taskCreatingDTOTemp;
            }

            DataRow dtR_DataRow = dt_Data.Rows[0];

            TaskCreatingDTO taskCreatingDTOResult = new TaskCreatingDTO(dtR_DataRow);

            return taskCreatingDTOResult;
        }

        //public TaskCreatingDTO getDataObjectFollowProjectID(string projectID)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' ");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    if (dt_Data.Rows.Count == 0)
        //    {
        //        TaskCreatingDTO taskCreatingDTOTemp = new TaskCreatingDTO();

        //        return taskCreatingDTOTemp;
        //    }

        //    DataRow dtR_DataRow = dt_Data.Rows[0];

        //    TaskCreatingDTO taskCreatingDTOResult = new TaskCreatingDTO(dtR_DataRow);

        //    return taskCreatingDTOResult;
        //}

        //public TaskCreatingDTO getDataObjectFollowAllPrimaryKeys(string projectID, string stage, string task)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

        //    DataTable data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (data == null)
        //        return null;

        //    DataRow dataRow = data.Rows[0];

        //    TaskCreatingDTO taskCreatingDTOResult = new TaskCreatingDTO(dataRow);

        //    return taskCreatingDTOResult;
        //}

        //public TaskCreatingDTO getDataObjectForQuickAccessTaskWorking(string employee, string projectID)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE EMPLOYEE = '" + employee + "' AND PROJECTID = '" + projectID + "'");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    if (dt_Data.Rows.Count == 0)
        //    {
        //        TaskCreatingDTO taskCreatingDTOTemp = new TaskCreatingDTO();

        //        return taskCreatingDTOTemp;
        //    }

        //    DataRow dtR_DataRow = dt_Data.Rows[0];

        //    TaskCreatingDTO taskCreatingDTOResult = new TaskCreatingDTO(dtR_DataRow);

        //    return taskCreatingDTOResult;
        //}

        //public TaskCreatingDTO findNextTask(string username, string projectID)
        //{
        //    TaskCreatingDTO taskCreatingDTOResult = null;

        //    List<TaskCreatingDTO> taskCreatingList = this.getDataListForNextStage(username, projectID);
        //    int i_Pos = -1;
        //    int i = 0;

        //    // Tìm task chưa hoàn thành của một người trong giai đoạn.
        //    for (i = 0; i < taskCreatingList.Count(); i++)
        //    {
        //        // Nếu dự án đầu tiên chưa làm xong.
        //        if (taskCreatingList[i].Status == StaticVarClass.status_NotComplete || taskCreatingList[i].Status == StaticVarClass.status_WaitForApproval || taskCreatingList[i].Status == StaticVarClass.status_Overdue || taskCreatingList[i].Status == StaticVarClass.status_Approver)
        //        {
        //            i_Pos = i;
        //            break;
        //        }
        //    }

        //    if (i_Pos != -1)
        //    {
        //        taskCreatingDTOResult = taskCreatingList[i_Pos];
        //    }

        //    return taskCreatingDTOResult;
        //}

        public TaskCreatingDTO getDataObjectForQuickAccessTaskWorking(string projectID, string stage, string employee)
        {
            string str_Query = ("SELECT * FROM TASKCREATING WHERE EMPLOYEE = '" + employee + "' AND PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' ORDER BY STARTDATE ASC");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0) // Không có task nào.
            {
                TaskCreatingDTO taskCreatingDTOTemp = new TaskCreatingDTO();
                return taskCreatingDTOTemp;
            }

            // Có task.
            List<TaskCreatingDTO> lst_TaskCreatingListLocal = new List<TaskCreatingDTO>();
            foreach (DataRow item in dt_Data.Rows)
            {
                TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
                lst_TaskCreatingListLocal.Add(taskCreatingDTO);
            }

            foreach (TaskCreatingDTO taskCreatingDTOTemp in lst_TaskCreatingListLocal)
            {
                if (taskCreatingDTOTemp.Status == StaticVarClass.status_NotComplete)
                    return taskCreatingDTOTemp;
            }

            return lst_TaskCreatingListLocal[lst_TaskCreatingListLocal.Count - 1];
        }

        public TaskCreatingDTO getDataObjectForUpdateWhenRemovingTask(string projectID, string stage)
        {
            string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0)
            {
                TaskCreatingDTO taskCreatingDTOTemp = new TaskCreatingDTO();
                return taskCreatingDTOTemp;
            }

            List<TaskCreatingDTO> lst_TaskCreatingListResult = new List<TaskCreatingDTO>();
            foreach (DataRow item in dt_Data.Rows)
            {
                TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
                lst_TaskCreatingListResult.Add(taskCreatingDTO);
            }

            TaskCreatingDTO taskCreatingDTOResult = new TaskCreatingDTO(lst_TaskCreatingListResult[0]);
            for (int i = 0; i < lst_TaskCreatingListResult.Count; i++)
            {
                if (lst_TaskCreatingListResult[i].Status != StaticVarClass.status_Complete)
                {
                    taskCreatingDTOResult = new TaskCreatingDTO(lst_TaskCreatingListResult[i]);
                    break;
                }
            }

            return taskCreatingDTOResult;
        }

        //public List<TaskCreatingDTO> getDataList()
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<TaskCreatingDTO> lst_TaskCreatingListResult = new List<TaskCreatingDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
        //        lst_TaskCreatingListResult.Add(taskCreatingDTO);
        //    }

        //    return lst_TaskCreatingListResult;
        //}

        public List<TaskCreatingDTO> getDataListFollowProjectIDAndStageAndDept(string projectID, string stage, string dept)
        {
            string str_Query = ("SELECT * FROM TASKCREATING TC, EMPLOYEE EM WHERE TC.EMPLOYEE = EM.NAME AND TC.PROJECTID = '" + projectID + "' AND TC.STAGE = '" + stage + "' AND EM.DEPARTMENT = '" + dept + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<TaskCreatingDTO> lst_TaskCreatingListResult = new List<TaskCreatingDTO>();

            foreach (DataRow item in dt_Data.Rows)
            {
                TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
                lst_TaskCreatingListResult.Add(taskCreatingDTO);
            }

            return lst_TaskCreatingListResult;
        }

        //public List<TaskCreatingDTO> getDataListFollowEmployee(string employee)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE EMPLOYEE = '" + employee + "'");

        //    DataTable data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (data == null)
        //        return null;

        //    List<TaskCreatingDTO> taskCreatingListResult = new List<TaskCreatingDTO>();

        //    foreach (DataRow item in data.Rows)
        //    {
        //        TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
        //        taskCreatingListResult.Add(taskCreatingDTO);
        //    }

        //    return taskCreatingListResult;
        //}

        //public List<TaskCreatingDTO> getDataListForFormTaskDetail(string employee, string startDate, string endDate)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE EMPLOYEE = '" + employee + "' AND STARTDATE >= '" + startDate + "' AND ENDDATE <= '" + endDate + "'");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<TaskCreatingDTO> lst_TaskCreatingListResult = new List<TaskCreatingDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
        //        lst_TaskCreatingListResult.Add(taskCreatingDTO);
        //    }

        //    return lst_TaskCreatingListResult;
        //}

        //public List<TaskCreatingDTO> getDataListForNextStage(string employee, string projectID)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND EMPLOYEE = '" + employee + "' ORDER BY STAGE ASC");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<TaskCreatingDTO> lst_TaskCreatingListResult = new List<TaskCreatingDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
        //        lst_TaskCreatingListResult.Add(taskCreatingDTO);
        //    }

        //    return lst_TaskCreatingListResult;
        //}

        //public List<TaskCreatingDTO> getDataListFollowProjectIDAndEmployee(string projectID, string employee)
        //{
        //    string str_Query = ("SELECT * FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND EMPLOYEE = '" + employee + "'");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<TaskCreatingDTO> lst_TaskCreatingListResult = new List<TaskCreatingDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        TaskCreatingDTO taskCreatingDTO = new TaskCreatingDTO(item);
        //        lst_TaskCreatingListResult.Add(taskCreatingDTO);
        //    }

        //    return lst_TaskCreatingListResult;
        //}

        public List<string> getDataListQuantityForFormProjectHistory(string employee, string startDate, string endDate, string POSMProject)
        {
            string str_Query = ("EXECUTE sp_getDataListQuantityForFormProjectHistory '" + employee + "', '" + startDate + "', '" + endDate + "', '" + POSMProject + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<string> lst_Result = new List<string>();

            int i = 0;
            for (i = 0; i < dt_Data.Rows.Count; i++)
            {
                lst_Result.Add(dt_Data.Rows[i].ItemArray[0].ToString().Trim());
            }
            return lst_Result;
        }

        public List<string> getDataListQuantityForFormMyTask(string employee, string startDate, string endDate, string POSMProject)
        {
            string str_Query = ("EXECUTE sp_getDataListQuantityForFormMyTask '" + employee + "', '" + startDate + "', '" + endDate + "', '" + POSMProject + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<string> lst_Result = new List<string>();

            int i = 0;
            for (i = 0; i < dt_Data.Rows.Count; i++)
            {
                lst_Result.Add(dt_Data.Rows[i].ItemArray[0].ToString().Trim());
            }
            return lst_Result;
        }

        public List<string> getDataListQuantityInStageForFormProjectDiagram(string projectID)
        {
            string str_Query = ("EXECUTE sp_getDataListQuantityInStageForFormProjectDiagram '" + projectID + "'");

            DataTable dt_data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_data == null)
                return null;

            List<string> lst_Result = new List<string>();

            int i = 0;
            for ( i = 0; i < dt_data.Rows.Count; i++)
            {
                lst_Result.Add(dt_data.Rows[i].ItemArray[0].ToString().Trim());
            }
            return lst_Result;
        }

        public List<string> getDataListQuantityInDeptForFormProjectDiagram(string projectID, string stage)
        {
            string str_Query = ("EXECUTE sp_getDataListQuantityInDeptForFormProjectDiagram '" + projectID + "', '" + stage + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<string> lst_Result = new List<string>();

            int i = 0;
            for (i = 0; i < dt_Data.Rows.Count; i++)
            {
                lst_Result.Add(dt_Data.Rows[i].ItemArray[0].ToString().Trim());
            }
            return lst_Result;
        }

        public int getIntQuantityInStageForFormProjectDiagram(string projectID, string stage)
        {
            string str_Query = ("EXECUTE sp_getIntQuantityInStageForFormProjectDiagram '" + projectID + "', '" + stage + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        public int getIntWarningWhenRemovingTask(string project, string stage, string task)
        {
            string str_Query = ("SELECT STATUS FROM TASKCREATING WHERE PROJECTID = '" + project + "' AND STAGE = '" + stage + "' AND TASK <> '" + task + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return -1;

            if (dt_Data.Rows.Count == 0)
                return 0;

            int i_Result = 1;
            for (int i = 0; i < dt_Data.Rows.Count; i++)
            {
                if (dt_Data.Rows[i].ItemArray[0].ToString().Trim() != StaticVarClass.status_Complete)
                {
                    i_Result = 2;
                    break;
                }
            }

            return i_Result;
        }

        public int getIntQuantityStatusNotCompleteFollowEmployee(string employee)
        {
            string str_Query = ("SELECT COUNT(*) FROM TASKCREATING WHERE EMPLOYEE = '" + employee + "' AND STATUS = '" + StaticVarClass.status_NotComplete + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        public int checkIfJoinProject(string projectID, string username)
        {
            string str_Query = "SELECT COUNT(*) FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND EMPLOYEE = '" + username + "'";

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        public string getStringAttachFileFollowAllPrimaryKeys(string projectID, string stage, string task)
        {
            string str_Query = ("SELECT ATTACHFILE FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return string.Empty;

            if (dt_Result.Rows.Count == 0)
                return string.Empty;

            return dt_Result.Rows[0].ItemArray[0].ToString().Trim();
        }

        public string getStringStatusFollowAllPrimaryKeys(string projectID, string stage, string task)
        {
            string str_Query = ("SELECT STATUS FROM TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return string.Empty;

            if (dt_Result.Rows.Count == 0)
                return string.Empty;

            return dt_Result.Rows[0].ItemArray[0].ToString().Trim();
        }

        public bool addData(TaskCreatingDTO taskCreatingDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskCreatingDTO.ProjectID == string.Empty || taskCreatingDTO.Stage == string.Empty
                || taskCreatingDTO.Task == string.Empty || taskCreatingDTO.Employee == null || taskCreatingDTO.StartDate == null || taskCreatingDTO.EndDate == null)
                return false;

            string str_Query = string.Empty;

            if (taskCreatingDTO.Approver != null)
            {
                str_Query = "INSERT INTO TASKCREATING VALUES ('" + taskCreatingDTO.ProjectID + "' , '" + taskCreatingDTO.Stage + "', '"
                + taskCreatingDTO.Task + "', '" + taskCreatingDTO.Employee + "', '" + taskCreatingDTO.TaskDescription + "', '"
                + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', '" + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy")
                + "', '" + taskCreatingDTO.TaskType + "', '" + taskCreatingDTO.Approver + "', '" + taskCreatingDTO.AttachFile + "', '"
                + taskCreatingDTO.Progress + "', '" + taskCreatingDTO.Status + "', NULL, '" + taskCreatingDTO.TimeDelay + "', '"
                + taskCreatingDTO.Color + "',  '" + taskCreatingDTO.Note + "')";
            }
            else if (taskCreatingDTO.Approver == null)
            {
                str_Query = "INSERT INTO TASKCREATING VALUES ('" + taskCreatingDTO.ProjectID + "' , '" + taskCreatingDTO.Stage + "', '"
                + taskCreatingDTO.Task + "', '" + taskCreatingDTO.Employee + "', '" + taskCreatingDTO.TaskDescription + "', '"
                + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', '" + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy")
                + "', '" + taskCreatingDTO.TaskType + "', NULL, '" + taskCreatingDTO.AttachFile + "', '"
                + taskCreatingDTO.Progress + "', '" + taskCreatingDTO.Status + "', NULL, '" + taskCreatingDTO.TimeDelay + "', '"
                + taskCreatingDTO.Color + "',  '" + taskCreatingDTO.Note + "')";
            }

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateData(TaskCreatingDTO taskCreatingDTO, string newTask)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskCreatingDTO.ProjectID == string.Empty || taskCreatingDTO.Stage == string.Empty
                || taskCreatingDTO.Task == string.Empty || taskCreatingDTO.Employee == null || newTask == null || taskCreatingDTO.StartDate == null || taskCreatingDTO.EndDate == null) 
                return false;

            string str_Query = string.Empty;

            if (taskCreatingDTO.FinishDate != null && taskCreatingDTO.Approver != null)
            {
                str_Query = "UPDATE TASKCREATING SET TASK = '" + newTask + "', EMPLOYEE = '" + taskCreatingDTO.Employee + "', TASKDESCRIPTION = '"
                  + taskCreatingDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '" + taskCreatingDTO.TaskType + "', APPROVER = '"
                  + taskCreatingDTO.Approver + "', ATTACHFILE = '" + taskCreatingDTO.AttachFile + "', PROGRESS = '"
                  + taskCreatingDTO.Progress + "', STATUS = '" + taskCreatingDTO.Status + "', FINISHDATE = '"
                  + DateTime.Parse(taskCreatingDTO.FinishDate).ToString("MM/dd/yyyy") + "', TIMEDELAY = '" + taskCreatingDTO.TimeDelay + "', COLOR = '"
                  + taskCreatingDTO.Color + "', NOTE = '" + taskCreatingDTO.Note + "' WHERE PROJECTID = '"
                  + taskCreatingDTO.ProjectID + "' AND STAGE = '"
                  + taskCreatingDTO.Stage + "' AND TASK = '" + taskCreatingDTO.Task + "'";
            }
            else if (taskCreatingDTO.FinishDate == null && taskCreatingDTO.Approver != null)
            {
                str_Query = "UPDATE TASKCREATING SET TASK = '" + newTask + "', EMPLOYEE = '" + taskCreatingDTO.Employee + "', TASKDESCRIPTION = '"
                  + taskCreatingDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '" + taskCreatingDTO.TaskType + "', APPROVER = '"
                  + taskCreatingDTO.Approver + "', ATTACHFILE = '" + taskCreatingDTO.AttachFile + "', PROGRESS = '"
                  + taskCreatingDTO.Progress + "', STATUS = '" + taskCreatingDTO.Status + "', FINISHDATE = NULL, TIMEDELAY = '" 
                  + taskCreatingDTO.TimeDelay + "', COLOR = '"
                  + taskCreatingDTO.Color + "', NOTE = '" + taskCreatingDTO.Note + "' WHERE PROJECTID = '"
                  + taskCreatingDTO.ProjectID + "' AND STAGE = '"
                  + taskCreatingDTO.Stage + "' AND TASK = '" + taskCreatingDTO.Task + "'";
            }
            else if (taskCreatingDTO.FinishDate != null && taskCreatingDTO.Approver == null)
            {
                str_Query = "UPDATE TASKCREATING SET TASK = '" + newTask + "', EMPLOYEE = '" + taskCreatingDTO.Employee + "', TASKDESCRIPTION = '"
                  + taskCreatingDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '" 
                  + taskCreatingDTO.TaskType + "', APPROVER = NULL, ATTACHFILE = '" + taskCreatingDTO.AttachFile + "', PROGRESS = '"
                  + taskCreatingDTO.Progress + "', STATUS = '" + taskCreatingDTO.Status + "', FINISHDATE = '"
                  + DateTime.Parse(taskCreatingDTO.FinishDate).ToString("MM/dd/yyyy") + "', TIMEDELAY = '" + taskCreatingDTO.TimeDelay + "', COLOR = '"
                  + taskCreatingDTO.Color + "', NOTE = '" + taskCreatingDTO.Note + "' WHERE PROJECTID = '"
                  + taskCreatingDTO.ProjectID + "' AND STAGE = '"
                  + taskCreatingDTO.Stage + "' AND TASK = '" + taskCreatingDTO.Task + "'";
            }
            else if (taskCreatingDTO.FinishDate == null && taskCreatingDTO.Approver == null)
            {
                str_Query = "UPDATE TASKCREATING SET TASK = '" + newTask + "', EMPLOYEE = '" + taskCreatingDTO.Employee + "', TASKDESCRIPTION = '"
                  + taskCreatingDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '"
                  + taskCreatingDTO.TaskType + "', APPROVER = NULL, ATTACHFILE = '" + taskCreatingDTO.AttachFile + "', PROGRESS = '"
                  + taskCreatingDTO.Progress + "', STATUS = '" + taskCreatingDTO.Status + "', FINISHDATE = NULL, TIMEDELAY = '" + taskCreatingDTO.TimeDelay + "', COLOR = '"
                  + taskCreatingDTO.Color + "', NOTE = '" + taskCreatingDTO.Note + "' WHERE PROJECTID = '"
                  + taskCreatingDTO.ProjectID + "' AND STAGE = '"
                  + taskCreatingDTO.Stage + "' AND TASK = '" + taskCreatingDTO.Task + "'";
            }

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateDataForFormTaskDetail(string projectID, string stage, string task, string finishDate, string status)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty || finishDate == null)
                return false;

            string str_Query = "UPDATE TASKCREATING SET FINISHDATE = '"
                  + DateTime.Parse(finishDate).ToString("MM/dd/yyyy") + "', STATUS = '" + status + "' WHERE PROJECTID = '"
                  + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateDataForTaskAssign(TaskCreatingDTO taskCreatingDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskCreatingDTO.ProjectID == string.Empty || taskCreatingDTO.Stage == string.Empty
                || taskCreatingDTO.Task == string.Empty || taskCreatingDTO.Employee == null || taskCreatingDTO.StartDate == null || taskCreatingDTO.EndDate == null)
                return false;

            string str_Query = string.Empty;

            if (taskCreatingDTO.Approver == null)
            {
                str_Query = "UPDATE TASKCREATING SET EMPLOYEE = '" + taskCreatingDTO.Employee + "', TASKDESCRIPTION = '"
                  + taskCreatingDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '" + taskCreatingDTO.TaskType + "', APPROVER = NULL, ATTACHFILE = '" + taskCreatingDTO.AttachFile + "', PROGRESS = '"
                  + taskCreatingDTO.Progress + "', STATUS = '" + taskCreatingDTO.Status + "', FINISHDATE = NULL, TIMEDELAY = '" + taskCreatingDTO.TimeDelay + "', COLOR = '"
                  + taskCreatingDTO.Color + "', NOTE = '" + taskCreatingDTO.Note + "' WHERE PROJECTID = '"
                  + taskCreatingDTO.ProjectID + "' AND STAGE = '"
                  + taskCreatingDTO.Stage + "' AND TASK = '" + taskCreatingDTO.Task + "'";
            }
            else
            {
                str_Query = "UPDATE TASKCREATING SET EMPLOYEE = '" + taskCreatingDTO.Employee + "', TASKDESCRIPTION = '"
                  + taskCreatingDTO.TaskDescription + "', STARTDATE = '" + DateTime.Parse(taskCreatingDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(taskCreatingDTO.EndDate).ToString("MM/dd/yyyy") + "', TASKTYPE = '" + taskCreatingDTO.TaskType + "', APPROVER = '" + taskCreatingDTO.Approver + "', ATTACHFILE = '" + taskCreatingDTO.AttachFile + "', PROGRESS = '"
                  + taskCreatingDTO.Progress + "', STATUS = '" + taskCreatingDTO.Status + "', FINISHDATE = NULL, TIMEDELAY = '" + taskCreatingDTO.TimeDelay + "', COLOR = '"
                  + taskCreatingDTO.Color + "', NOTE = '" + taskCreatingDTO.Note + "' WHERE PROJECTID = '"
                  + taskCreatingDTO.ProjectID + "' AND STAGE = '"
                  + taskCreatingDTO.Stage + "' AND TASK = '" + taskCreatingDTO.Task + "'";
            }

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateDataForConfirmApprove(string projectID, string stage, string task, string status)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            string str_Query = "UPDATE TASKCREATING SET STATUS = '" + status + "' WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateDataForProgress(string project, string stage, string task, string progress)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (project == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            string str_Query = "UPDATE TASKCREATING SET PROGRESS = '"
                + progress + "' WHERE PROJECTID = '"
                + project + "' AND STAGE = '"
                + stage + "' AND TASK = '" + task + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateDataForStatusAndProgress(string projectID, string stage, string task, string status, string progress)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            string str_Query = "UPDATE TASKCREATING SET STATUS = '" 
                + status + "',  PROGRESS = '" + progress + "' WHERE PROJECTID = '" 
                + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool deleteData(string projectID, string stage, string task)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            string str_Query = "DELETE TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "' AND TASK = '" + task + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        //public bool deleteDataFollowProjectIDAndStage(string projectID, string stage)
        //{
        //    // Nếu khóa chính trống thì không thể thêm vào.
        //    if (projectID == string.Empty || stage == string.Empty)
        //        return false;

        //    string str_Query = "DELETE TASKCREATING WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'";

        //    int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

        //    return i_Result > 0;
        //}

        public bool checkApprover(string name)
        {
            string str_Query = "SELECT COUNT(*) FROM TASKCREATING WHERE APPROVER = '" + name + "'";

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result > 0;
        }
    }
}
