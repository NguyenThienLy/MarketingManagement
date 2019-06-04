using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ProjectManagement.DTO;
using ProjectManagement.CO;

namespace ProjectManagement.DAO
{
    public class StageDAO
    {
        private static StageDAO instance;

        public static StageDAO Instance
        {
            get { if (instance == null) instance = new StageDAO(); return StageDAO.instance; }

            set { StageDAO.instance = value; }
        }

        private StageDAO() { }

        public DataTable getData()
        {
            string str_Query = ("SELECT * FROM STAGE");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        //public DataTable getDataFollowProjectID(string projectID)
        //{
        //    string str_Query = ("SELECT * FROM STAGE WHERE PROJECTID = '" + projectID + "'");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    return dt_Result;
        //}

        public DataTable getDataStageFollowProjectIDForFormTaskCreating(string projectID)
        {
            string str_Query = ("SELECT STAGE FROM STAGE WHERE PROJECTID = '" + projectID + "' AND STATUS <> '" + StaticVarClass.status_Complete + "' ORDER BY STAGE ASC");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            return dt_Result;
        }

        // Lấy dữ liệu theo tên employee đang làm việc.
        //public StageDTO getDataObjectFollowStage(string projectID, string stage)
        //{
        //    string str_Query = ("SELECT * FROM STAGE WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'");

        //    DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Result == null)
        //        return null;

        //    if (dt_Result.Rows.Count == 0)
        //    {
        //        StageDTO stageDToResultTemp = new StageDTO();

        //        return stageDToResultTemp;
        //    }

        //    DataRow dtR_dataRow = dt_Result.Rows[0];

        //    StageDTO stageDTOResult = new StageDTO(dtR_dataRow);

        //    return stageDTOResult;
        //}

        public StageDTO getDataObjectForUpdateWhenRemovingStage(string projectID)
        {
            string str_Query = ("SELECT * FROM STAGE WHERE PROJECTID = '"
                + projectID + "' AND STAGE >= ALL(SELECT STAGE FROM STAGE WHERE PROJECTID = '"
                + projectID + "')");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0)
            {
                StageDTO stageDTOTemp = new StageDTO();
                return stageDTOTemp;
            }

            StageDTO stageDTOResult = new StageDTO(dt_Data.Rows[0]);
            return stageDTOResult;
        }

        public List<int> getDataListStageAndStageOrdinalNumberFollowProjectIDForQuickAccessTaskWorking(string projectID)
        {
            string str_Query = ("SELECT * FROM STAGE WHERE PROJECTID = '" + projectID + "' ORDER BY STAGE ASC");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<int> lst_Result = new List<int>();

            int i_StageLocal = 0;
            int i_StageOrdinalNumberLocal = 0;
            foreach (DataRow item in dt_Data.Rows)
            {
                StageDTO stageDTOTemp = new StageDTO(item);
                if (stageDTOTemp.Status == StaticVarClass.status_NotComplete)
                {
                    i_StageLocal = int.Parse(stageDTOTemp.Stage);
                    lst_Result.Add(i_StageLocal);
                    lst_Result.Add(i_StageOrdinalNumberLocal);
                    break;
                }

                i_StageOrdinalNumberLocal += 1;
            }

            return lst_Result;
        }

        //public List<StageDTO> getDataList()
        //{
        //    string str_Query = ("SELECT * FROM STAGE");

        //    DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (dt_Data == null)
        //        return null;

        //    List<StageDTO> lst_StageListResult = new List<StageDTO>();

        //    foreach (DataRow item in dt_Data.Rows)
        //    {
        //        StageDTO stageDTO = new StageDTO(item);
        //        lst_StageListResult.Add(stageDTO);
        //    }

        //    return lst_StageListResult;
        //}

        public List<string> getDataListFollowProjectID(string projectID)
        {
            string str_Query = ("SELECT STAGE, STAGESUBJECT FROM STAGE WHERE PROJECTID = '" + projectID + "' ORDER BY STAGE ASC");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            List<string> lst_Result = new List<string>();

            int i = 0;
            for (i = 0; i < dt_Data.Rows.Count; i++)
            {
                lst_Result.Add(dt_Data.Rows[i].ItemArray[0].ToString().Trim() + " - " + dt_Data.Rows[i].ItemArray[1].ToString().Trim());
            }
            return lst_Result;
        }

        public string getDataStringStageFollowProjectIDAndIndex(string projectID, int index)
        {
            string str_Query = ("SELECT STAGE FROM STAGE WHERE PROJECTID = '" + projectID + "' ORDER BY STAGE ASC");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count < index + 1)
                return string.Empty;

            return dt_Data.Rows[index].ItemArray[0].ToString().Trim();
        }

        public int getIntSumStageFollowProjectID(string projectID)
        {
            string str_Query = ("SELECT COUNT(*) FROM STAGE WHERE PROJECTID = '" + projectID + "'");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return -1;

            if (dt_Result.Rows.Count == 0)
                return 0;

            return int.Parse(dt_Result.Rows[0].ItemArray[0].ToString());
        }

        public int getIntMaxStageFollowProjectID(string projectID)
        {
            string str_Query = ("SELECT STAGE FROM STAGE WHERE PROJECTID = '" + projectID + "' AND STAGE >= ALL(SELECT STAGE FROM STAGE WHERE PROJECTID = '"
                + projectID + "')");

            DataTable dt_Result = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Result == null)
                return -1;

            if (dt_Result.Rows.Count == 0)
                return 0;

            return int.Parse(dt_Result.Rows[0].ItemArray[0].ToString());
        }

        public int getIntWarningWhenRemovingStage(string projectID, string stage)
        {
            string str_Query = ("SELECT STATUS FROM STAGE WHERE PROJECTID = '"
                + projectID + "' AND STAGE <> '" + stage + "'");

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

        //// Lấy ra stage theo mã dự án.
        //public StageDTO getDataObjectFollowProjectID(string projectID)
        //{
        //    string str_Query = ("SELECT * FROM STAGE WHERE PROJECTID = '" + projectID + "'");

        //    DataTable data = DataProvider.Instance.ExecuteQuery(str_Query);

        //    if (data == null)
        //        return null;

        //    if (data.Rows.Count == 0)
        //    {
        //        StageDTO stageDTOResultTemp = new StageDTO();

        //        return stageDTOResultTemp;
        //    }

        //    DataRow dataRow = data.Rows[0];

        //    StageDTO stageDTOResult = new StageDTO(dataRow);

        //    return stageDTOResult;
        //}

        // Lấy ra status theo stage.

        public string getStringStatusFollowProjectIDAndStage(string projectID, string stage)
        {
            string str_Query = ("SELECT STATUS FROM STAGE WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0)
                return string.Empty;

            string str_ResultLocal = dt_Data.Rows[0].ItemArray[0].ToString().Trim();

            return str_ResultLocal;
        }

        public string getStringStatusFollowProjectIDAndStageBefore(string projectID, string stage)
        {
            string str_Query = ("SELECT STATUS FROM STAGE WHERE PROJECTID = '" + projectID + "' AND STAGE < '" + stage + "' AND STAGE >= ALL(SELECT STAGE FROM STAGE WHERE PROJECTID = '" + projectID + "' AND STAGE < '" + stage + "')");

            DataTable dt_Data = DataProvider.Instance.ExecuteQuery(str_Query);

            if (dt_Data == null)
                return null;

            if (dt_Data.Rows.Count == 0)
                return string.Empty;

            string str_ResultLocal = dt_Data.Rows[0].ItemArray[0].ToString().Trim();

            return str_ResultLocal;
        }

        public bool addData(StageDTO stageDTO)
        {
            if (stageDTO.ProjectID == string.Empty || stageDTO.Stage == string.Empty)
                return false;

            string str_Query = "INSERT INTO STAGE VALUES ('" + stageDTO.ProjectID + "', '" + stageDTO.Stage + "', '" + stageDTO.StageSubject + "', '" + stageDTO.Status + "')";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateData(StageDTO stageDTO)
        {
            if (stageDTO.ProjectID == string.Empty || stageDTO.Stage == string.Empty)
                return false;

            string str_Query = "UPDATE STAGE SET STAGESUBJECT = '" + stageDTO.StageSubject + "' , STATUS = '" + stageDTO.Status + "' WHERE PROJECTID = '" + stageDTO.ProjectID + "' AND STAGE = '" + stageDTO.Stage + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool updateDataStatus(string projectID, string stage, string status)
        {
            if (projectID == string.Empty || stage == string.Empty)
                return false;

            string str_Query = "UPDATE STAGE SET STATUS = '" + status + "' WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }

        public bool deleteData(string projectID, string stage)
        {
            if (projectID == string.Empty || stage == string.Empty)
                return false;

            string str_Query = "DELETE STAGE WHERE PROJECTID = '" + projectID + "' AND STAGE = '" + stage + "'";

            int i_Result = DataProvider.Instance.ExecuteNonQuery(str_Query);

            return i_Result > 0;
        }
    }
}
