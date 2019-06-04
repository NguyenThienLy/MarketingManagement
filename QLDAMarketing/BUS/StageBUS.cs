using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    class StageBUS
    {
        private static StageBUS instance;

        public static StageBUS Instance
        {
            get { if (instance == null) instance = new StageBUS(); return StageBUS.instance; }

            set { StageBUS.instance = value; }
        }

        private StageBUS() { }

        public DataTable getData()
        {
            return StageDAO.Instance.getData();
        }

        public DataTable getDataStageFollowProjectIDForFormTaskCreating(string projectID)
        {
            return StageDAO.Instance.getDataStageFollowProjectIDForFormTaskCreating(projectID);
        }

        public StageDTO getDataObjectForUpdateWhenRemovingStage(string projectID)
        {
            return StageDAO.Instance.getDataObjectForUpdateWhenRemovingStage(projectID);
        }

        public List<int> getDataListStageAndStageOrdinalNumberFollowProjectIDForQuickAccessTaskWorking(string projectID)
        {
            return StageDAO.Instance.getDataListStageAndStageOrdinalNumberFollowProjectIDForQuickAccessTaskWorking(projectID);
        }

        public List<string> getDataListFollowProjectID(string projectID)
        {
            return StageDAO.Instance.getDataListFollowProjectID(projectID);
        }

        public string getDataStringStageFollowProjectIDAndIndex(string projectID, int index)
        {
            return StageDAO.Instance.getDataStringStageFollowProjectIDAndIndex(projectID, index);
        }

        public int getIntSumStageFollowProjectID(string projectID)
        {
            return StageDAO.Instance.getIntSumStageFollowProjectID(projectID);
        }

        public int getIntMaxStageFollowProjectID(string projectID)
        {
            return StageDAO.Instance.getIntMaxStageFollowProjectID(projectID);
        }

        public int getIntWarningWhenRemovingStage(string projectID, string stage)
        {
            return StageDAO.Instance.getIntWarningWhenRemovingStage(projectID, stage);
        }

        public string getStringStatusFollowProjectIDAndStage(string projectID, string stage)
        {
            return StageDAO.Instance.getStringStatusFollowProjectIDAndStage(projectID, stage);
        }

        public string getStringStatusFollowProjectIDAndStageBefore(string projectID, string stage)
        {
            return StageDAO.Instance.getStringStatusFollowProjectIDAndStageBefore(projectID, stage);
        }

        public bool addData(StageDTO stageDTO)
        {
            if (stageDTO.ProjectID == string.Empty || stageDTO.Stage == string.Empty)
                return false;

            return StageDAO.Instance.addData(stageDTO);
        }

        public bool updateData(StageDTO stageDTO)
        {
            if (stageDTO.ProjectID == string.Empty || stageDTO.Stage == string.Empty)
                return false;

            return StageDAO.Instance.updateData(stageDTO);
        }

        public bool updateDataStatus(string projectID, string stage, string status)
        {
            if (projectID == string.Empty || stage == string.Empty)
                return false;

            return StageDAO.Instance.updateDataStatus(projectID, stage, status);
        }

        public bool deleteData(string projectID, string stage)
        {
            if (projectID == string.Empty || stage == string.Empty)
                return false;

            return StageDAO.Instance.deleteData(projectID, stage);
        }
    }
}
