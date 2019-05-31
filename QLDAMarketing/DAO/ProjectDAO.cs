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
    public class ProjectDAO
    {
        // singleton.
        private static ProjectDAO instance;

        public static ProjectDAO Instance
        {
            get { if (instance == null) instance = new ProjectDAO(); return ProjectDAO.instance; }

            set { ProjectDAO.instance = value; }
        }

        private ProjectDAO() { }

        public DataTable getData()
        {
            string str_Query = ("SELECT * FROM PROJECT");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return null;

            return dt_Result;
        }

        public DataTable getDataProjectIDForFormTaskCreating()
        {
            string str_Query = ("SELECT DISTINCT P.PROJECTID FROM PROJECT P, STAGE S WHERE P.PROJECTID=S.PROJECTID AND P.STATUS <> '" + StaticVarClass.status_Complete + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return null;

            return dt_Result;
        }

        public DataTable getDataProjectIDNotComplete()
        {
            string str_Query = ("SELECT PROJECTID FROM PROJECT WHERE STATUS <> '" + StaticVarClass.status_Complete + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return null;

            return dt_Result;
        }

        public DataTable getDataForDialogProjectSelection(string employee, string POSMProject, string status)
        {
            string str_Query = ("EXECUTE sp_getDataForDialogProjectSelection  '" + employee + "', '" + POSMProject + "', '" + status + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        //public DataTable getDataPOSMProject()
        //{
        //    string str_Query = "SELECT * FROM PROJECT WHERE POSMPROJECT = '" + StaticVarClass.POSM_POSMProject + "'";

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    return dt_Result;
        //}

        public ProjectDTO getDataObjectFollowProjectID(string projectID)
        {
            string str_Query = ("SELECT * FROM PROJECT WHERE PROJECTID = '" + projectID + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            ProjectDTO projectDTOResult = new ProjectDTO();

            if (dt_Data.Rows.Count != 0)
            {
                DataRow dataRow = dt_Data.Rows[0];
                projectDTOResult = new ProjectDTO(dataRow);
            }

            return projectDTOResult;
        }

        public string getStringStatusFollowProjectID(string projectID)
        {
            string str_Query = ("SELECT STATUS FROM PROJECT WHERE PROJECTID = '" + projectID + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0)
                return string.Empty;

            string str_ResultLocal = dt_Data.Rows[0].ItemArray[0].ToString().Trim();

            return str_ResultLocal;
        }

        public string getStringTypeProjectFollowProjectID(string projectID)
        {
            string str_Query = ("SELECT PROJECTTYPE FROM PROJECT WHERE PROJECTID = '" + projectID + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0)
                return string.Empty;

            string str_ResultLocal = dt_Data.Rows[0].ItemArray[0].ToString().Trim();

            return str_ResultLocal;
        }

        public int getIntNumberOfProjectType1FollowProjectID(string projectID)
        {
            string str_Query = ("SELECT COUNT(*) FROM PROJECT WHERE PROJECTID LIKE '" + projectID.Trim() + " 1%" + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        public int getIntNumberOfProjectType2FollowProjectID(string projectID)
        {
            string str_Query = ("SELECT COUNT(*) FROM PROJECT WHERE PROJECTID LIKE '" + projectID.Trim() + " 2%" + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        public int getIntNumberOfProjectType345FollowProjectID(string projectID)
        {
            string str_Query = ("SELECT COUNT(*) FROM PROJECT WHERE PROJECTID LIKE '" + projectID.Trim() + " 3%" + "' OR PROJECTID LIKE '"
                + projectID.Trim() + " 4%" + "' OR PROJECTID LIKE '" + projectID.Trim() + " 5%" + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        //public int getIntNumberOfProjectType4FollowProjectIDAndStartDate(string projectID, string startDate)
        //{
        //    string str_Query = ("SELECT COUNT(*) FROM PROJECT WHERE PROJECTID = '" + projectID.Trim() + " 4, " + DateTime.Parse(startDate).ToString("dd/MM/yyyy") + "'");

        //    int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

        //    return i_Result;
        //}

        public int getIntNumberOfProjectType5FollowProjectIDAndStartDate(string projectID, string startDate)
        {
            string str_Query = ("SELECT COUNT(*) FROM PROJECT WHERE PROJECTID LIKE '" + projectID.Trim() + "%" + "' AND STARTDATE >= '" + DateTime.Parse(startDate).ToString("MM/dd/yyyy") + "'");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        public int getIntConfirmRepeatedProject(string projectID)
        {
            string str_Query = ("SELECT COUNT(*) FROM PROJECT WHERE PROJECTID = '" + projectID + "' AND (DATEREPEAT <> 0 OR (STARTDATEREPEAT IS NOT NULL AND ENDDATEREPEAT IS NOT NULL))");

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result;
        }

        //public int getIntQuantityOfProjectsFollowLeader(string employee)
        //{
        //    string str_Query = ("SELECT COUNT(*) FROM PROJECT WHERE LEADER = '" + employee + "'");

        //    int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

        //    return i_Result;
        //}

        //public string getStringQuantityRelatedToRemovingStage(string projectID, string stage)
        //{
        //    string str_Query = ("SELECT COUNT(*) FROM STAGE WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'");

        //    string str_Result = (string)DataProvider.Instance.ExecuteScalar(str_Query);

        //    if (str_Result == "-1")
        //        return null;

        //    if (str_Result == "0")
        //        return string.Empty;

        //    return str_Result;
        //}

        //public List<ProjectDTO> getDataList()
        //{
        //    string str_Query = ("SELECT * FROM PROJECT");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<ProjectDTO> lst_ProjectListResult = new List<ProjectDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        ProjectDTO projectDTO = new ProjectDTO(item);
        //        lst_ProjectListResult.Add(projectDTO);
        //    }

        //    return lst_ProjectListResult;
        //}

        //public List<ProjectDTO> getDataListFollowProjectID(string projectID)
        //{
        //    string str_Query = ("SELECT * FROM PROJECT WHERE PROJECTID = '" + projectID + "'");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<ProjectDTO> lst_ProjectListResult = new List<ProjectDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        ProjectDTO projectDTO = new ProjectDTO(item);
        //        lst_ProjectListResult.Add(projectDTO);
        //    }

        //    return lst_ProjectListResult;
        //}

        public List<string> getDataListQuantityForDialogProjectSelection(string employee, string POSMProject)
        {
            string str_Query = ("EXECUTE sp_getDataListQuantityForDialogProjectSelection  '" + employee + "', '" + POSMProject + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<string> lst_Result = new List<string>();

            int i = 0;
            for (i = 0; i < dt_Data.Rows.Count; i++)
            {
                lst_Result.Add(dt_Data.Rows[i].ItemArray[0].ToString());
            }

            return lst_Result;
        }

        public List<string> getListQuantityRelatedToRemovingProject(string project)
        {
            string str_Query = ("EXECUTE sp_getListQuantityRelatedToRemovingProject '" + project + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<string> lst_Result = new List<string>();

            int i = 0;
            for (i = 0; i < dt_Data.Rows.Count; i++)
            {
                lst_Result.Add(dt_Data.Rows[i].ItemArray[0].ToString());
            }

            return lst_Result;
        }

        public bool addData(ProjectDTO projectDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectDTO.ProjectID == string.Empty || projectDTO.Leader == null || projectDTO.StartDate == null || projectDTO.EndDate == null)
                return false;

            string str_Query = string.Empty;

            if (projectDTO.StartDateRepeat != null && projectDTO.EndDateRepeat != null)
            {
                str_Query = "INSERT INTO PROJECT VALUES ('" + projectDTO.ProjectID + "', '"
                  + projectDTO.ProjectName + "', '" + projectDTO.Leader + "', '"
                  + DateTime.Parse(projectDTO.StartDate).ToString("MM/dd/yyyy") + "', '"
                  + DateTime.Parse(projectDTO.EndDate).ToString("MM/dd/yyyy") + "', '" + projectDTO.Progress
                  + "', '" + projectDTO.ProjectType + "', '" + projectDTO.POSMProject + "', '"
                  + projectDTO.DateRepeat + "', '" + projectDTO.AutoRepeat + "', '"
                  + DateTime.Parse(projectDTO.StartDateRepeat).ToString("MM/dd/yyyy") + "', '"
                  + DateTime.Parse(projectDTO.EndDateRepeat).ToString("MM/dd/yyyy") + "', '"
                  + projectDTO.Status + "')";
            }
            else if (projectDTO.StartDateRepeat == null && projectDTO.EndDateRepeat == null)
            {
                str_Query = "INSERT INTO PROJECT VALUES ('" + projectDTO.ProjectID + "', '"
                  + projectDTO.ProjectName + "', '" + projectDTO.Leader + "', '"
                  + DateTime.Parse(projectDTO.StartDate).ToString("MM/dd/yyyy") + "', '"
                  + DateTime.Parse(projectDTO.EndDate).ToString("MM/dd/yyyy") + "', '" + projectDTO.Progress
                  + "', '" + projectDTO.ProjectType + "', '" + projectDTO.POSMProject + "', '"
                  + projectDTO.DateRepeat + "', '" + projectDTO.AutoRepeat + "', NULL, NULL, '"
                  + projectDTO.Status + "')";
            }

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateData(ProjectDTO projectDTO, string newProjectID)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectDTO.ProjectID == string.Empty || projectDTO.Leader == null || newProjectID == null || projectDTO.StartDate == null || projectDTO.EndDate == null)
                return false;

            string str_Query = string.Empty;

            if (projectDTO.StartDateRepeat != null && projectDTO.EndDateRepeat != null)
            {
                str_Query = "UPDATE PROJECT SET PROJECTID = '" + newProjectID + "', PROJECTNAME = '" 
                    + projectDTO.ProjectName + "', LEADER = '" + projectDTO.Leader + "', STARTDATE = '"
                  + DateTime.Parse(projectDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(projectDTO.EndDate).ToString("MM/dd/yyyy") + "', PROGRESS = '"
                  + projectDTO.Progress + "', PROJECTTYPE = '" + projectDTO.ProjectType + "', POSMPROJECT = '"
                  + projectDTO.POSMProject + "', DATEREPEAT = '" + projectDTO.DateRepeat + "', AUTOREPEAT = '"
                  + projectDTO.AutoRepeat + "', STARTDATEREPEAT = '"
                  + DateTime.Parse(projectDTO.StartDateRepeat).ToString("MM/dd/yyyy") + "', ENDDATEREPEAT = '"
                  + DateTime.Parse(projectDTO.EndDateRepeat).ToString("MM/dd/yyyy") + "', STATUS = '"
                  + projectDTO.Status + "'  WHERE PROJECTID = '" + projectDTO.ProjectID + "'";
            }
            else if (projectDTO.StartDateRepeat == null && projectDTO.EndDateRepeat == null)
            {
                str_Query = "UPDATE PROJECT SET PROJECTID = '" + newProjectID + "', PROJECTNAME = '" + projectDTO.ProjectName + "', LEADER = '"
                  + projectDTO.Leader + "', STARTDATE = '"
                  + DateTime.Parse(projectDTO.StartDate).ToString("MM/dd/yyyy") + "', ENDDATE = '"
                  + DateTime.Parse(projectDTO.EndDate).ToString("MM/dd/yyyy") + "', PROGRESS = '"
                  + projectDTO.Progress + "', PROJECTTYPE = '" + projectDTO.ProjectType + "', POSMPROJECT = '"
                  + projectDTO.POSMProject + "', DATEREPEAT = '" + projectDTO.DateRepeat + "', AUTOREPEAT = '"
                  + projectDTO.AutoRepeat + "', STARTDATEREPEAT = NULL, ENDDATEREPEAT = NULL, STATUS = '"
                  + projectDTO.Status + "'  WHERE PROJECTID = '" + projectDTO.ProjectID + "'";
            }

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateDataRepeatedProject(string projectID, string dateRepeat, string autoRepeat, string startDateRepeat, string endDateRepeat)
        {
            if (projectID == string.Empty)
                return false;

            string str_Query = string.Empty;

            if (startDateRepeat != null && endDateRepeat != null)
            {
                str_Query = "UPDATE PROJECT SET DATEREPEAT = '" + dateRepeat + "', AUTOREPEAT = '" + autoRepeat + "', STARTDATEREPEAT = '" + DateTime.Parse(startDateRepeat).ToString("MM/dd/yyyy") + "', ENDDATEREPEAT = '" + DateTime.Parse(endDateRepeat).ToString("MM/dd/yyyy") + "' WHERE PROJECTID = '" + projectID + "'";
            }
            else if (startDateRepeat == null && endDateRepeat == null)
            {
                str_Query = "UPDATE PROJECT SET DATEREPEAT = '" + dateRepeat + "', AUTOREPEAT = '" + autoRepeat + "', STARTDATEREPEAT = NULL, ENDDATEREPEAT = NULL WHERE PROJECTID = '" + projectID + "'";
            }

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool deleteData(string projectID)
        {
            if (projectID == string.Empty)
                return false;

            string str_Query = "DELETE PROJECT WHERE PROJECTID = '" + projectID + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool checkLeader(string name)
        {
            string str_Query = "SELECT COUNT(*) FROM PROJECT WHERE LEADER = '" + name + "'";

            int i_Result = (int)DataProvider.Instance.ExecuteScalar(str_Query);

            return i_Result > 0;
        }
    }
}
