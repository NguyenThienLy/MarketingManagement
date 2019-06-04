using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    public class ProjectBUS
    {
        // singleton.
        private static ProjectBUS instance;

        public static ProjectBUS Instance
        {
            get { if (instance == null) instance = new ProjectBUS(); return ProjectBUS.instance; }

            set { ProjectBUS.instance = value; }
        }

        private ProjectBUS() { }

        public DataTable getData()
        {
            return ProjectDAO.Instance.getData();
        }

        public DataTable getDataProjectIDForFormTaskCreating()
        {
            return ProjectDAO.Instance.getDataProjectIDForFormTaskCreating();
        }

        public DataTable getDataProjectIDNotComplete()
        {
            return ProjectDAO.Instance.getDataProjectIDNotComplete();
        }

        public DataTable getDataForDialogProjectSelection(string employee, string POSMProject, string status)
        {
            return ProjectDAO.Instance.getDataForDialogProjectSelection(employee, POSMProject, status);
        }

        public ProjectDTO getDataObjectFollowProjectID(string projectID)
        {
            return ProjectDAO.Instance.getDataObjectFollowProjectID(projectID);
        }

        public string getStringStatusFollowProjectID(string projectID)
        {
            return ProjectDAO.Instance.getStringStatusFollowProjectID(projectID);
        }

        public string getStringTypeProjectFollowProjectID(string projectID)
        {
            return ProjectDAO.Instance.getStringTypeProjectFollowProjectID(projectID);
        }

        public int getIntNumberOfProjectType1FollowProjectID(string projectID)
        {
            return ProjectDAO.Instance.getIntNumberOfProjectType1FollowProjectID(projectID);
        }

        public int getIntNumberOfProjectType2FollowProjectID(string projectID)
        {
            return ProjectDAO.Instance.getIntNumberOfProjectType2FollowProjectID(projectID);
        }

        public int getIntNumberOfProjectType345FollowProjectID(string projectID)
        {
            return ProjectDAO.Instance.getIntNumberOfProjectType345FollowProjectID(projectID);
        }

        public int getIntNumberOfProjectType5FollowProjectIDAndStartDate(string projectID, string startDate)
        {
            return ProjectDAO.Instance.getIntNumberOfProjectType5FollowProjectIDAndStartDate(projectID, startDate);
        }

        public int getIntConfirmRepeatedProject(string projectID)
        {
            return ProjectDAO.Instance.getIntConfirmRepeatedProject(projectID);
        }

        public List<string> getDataListQuantityForDialogProjectSelection(string employee, string POSMProject)
        {
            return ProjectDAO.Instance.getDataListQuantityForDialogProjectSelection(employee, POSMProject);
        }

        public List<string> getListQuantityRelatedToRemovingProject(string project)
        {
            return ProjectDAO.Instance.getListQuantityRelatedToRemovingProject(project);
        }

        public bool addData(ProjectDTO projectDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectDTO.ProjectID == string.Empty || projectDTO.Leader == null || projectDTO.StartDate == null || projectDTO.EndDate == null)
                return false;

            return ProjectDAO.Instance.addData(projectDTO);
        }

        public bool updateData(ProjectDTO projectDTO, string newProjectID)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectDTO.ProjectID == string.Empty || projectDTO.Leader == null || newProjectID == null || projectDTO.StartDate == null || projectDTO.EndDate == null)
                return false;

            return ProjectDAO.Instance.updateData(projectDTO, newProjectID);
        }

        public bool updateDataRepeatedProject(string projectID, string dateRepeat, string autoRepeat, string startDateRepeat, string endDateRepeat)
        {
            if (projectID == string.Empty)
                return false;

            return ProjectDAO.Instance.updateDataRepeatedProject(projectID, dateRepeat, autoRepeat, startDateRepeat, endDateRepeat);
        }

        public bool deleteData(string projectID)
        {
            if (projectID == string.Empty)
                return false;

            return ProjectDAO.Instance.deleteData(projectID);
        }

        public bool checkLeader(string name)
        {
            return ProjectDAO.Instance.checkLeader(name);
        }
    }
}
