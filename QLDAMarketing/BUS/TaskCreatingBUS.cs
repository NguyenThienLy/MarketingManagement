using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    class TaskCreatingBUS
    {
        // singleton.
        private static TaskCreatingBUS instance;

        public static TaskCreatingBUS Instance
        {
            get { if (instance == null) instance = new TaskCreatingBUS(); return TaskCreatingBUS.instance; }

            set { TaskCreatingBUS.instance = value; }
        }

        private TaskCreatingBUS() { }

        public DataTable getData()
        {
            return TaskCreatingDAO.Instance.getData();
        }

        public DataTable getDataForFormProjectHistory(string employee, string startDate, string endDate, string POSMProject, string status)
        {
            return TaskCreatingDAO.Instance.getDataForFormProjectHistory(employee, startDate, endDate, POSMProject, status);
        }

        public DataTable getDataForFormMyTask(string employee, string startDate, string endDate, string POSMProject, string status)
        {
            return TaskCreatingDAO.Instance.getDataForFormMyTask(employee, startDate, endDate, POSMProject, status);
        }

        public DataTable getDataFollowProjectID(string projectID)
        {
            return TaskCreatingDAO.Instance.getDataFollowProjectID(projectID);
        }

        public TaskCreatingDTO getDataObjectFollowProjectIDAndStageAndTask(string projectID, string stage, string task)
        {
            return TaskCreatingDAO.Instance.getDataObjectFollowProjectIDAndStageAndTask(projectID, stage, task);
        }

        public TaskCreatingDTO getDataObjectForQuickAccessTaskWorking(string projectID, string stage, string employee)
        {
            return TaskCreatingDAO.Instance.getDataObjectForQuickAccessTaskWorking(projectID, stage, employee);
        }

        public TaskCreatingDTO getDataObjectForUpdateWhenRemovingTask(string projectID, string stage)
        {  
            return TaskCreatingDAO.Instance.getDataObjectForUpdateWhenRemovingTask(projectID, stage);
        }

        public List<TaskCreatingDTO> getDataListFollowProjectIDAndStageAndDept(string projectID, string stage, string dept)
        {
            return TaskCreatingDAO.Instance.getDataListFollowProjectIDAndStageAndDept(projectID, stage, dept);
        }
   
        public List<string> getDataListQuantityForFormProjectHistory(string employee, string startDate, string endDate, string POSMProject)
        {
            return TaskCreatingDAO.Instance.getDataListQuantityForFormProjectHistory(employee, startDate, endDate, POSMProject);
        }

        public List<string> getDataListQuantityForFormMyTask(string employee, string startDate, string endDate, string POSMProject)
        {
            return TaskCreatingDAO.Instance.getDataListQuantityForFormProjectHistory(employee, startDate, endDate, POSMProject);
        }

        public List<string> getDataListQuantityInStageForFormProjectDiagram(string projectID)
        {
            return TaskCreatingDAO.Instance.getDataListQuantityInStageForFormProjectDiagram(projectID);
        }

        public List<string> getDataListQuantityInDeptForFormProjectDiagram(string projectID, string stage)
        {
            return TaskCreatingDAO.Instance.getDataListQuantityInDeptForFormProjectDiagram(projectID, stage);
        }

        public int getIntQuantityInStageForFormProjectDiagram(string projectID, string stage)
        {
            return TaskCreatingDAO.Instance.getIntQuantityInStageForFormProjectDiagram(projectID, stage);
        }

        public int getIntWarningWhenRemovingTask(string project, string stage, string task)
        {
            return TaskCreatingDAO.Instance.getIntWarningWhenRemovingTask(project, stage, task);
        }

        public int getIntQuantityStatusNotCompleteFollowEmployee(string employee)
        {
            return TaskCreatingDAO.Instance.getIntQuantityStatusNotCompleteFollowEmployee(employee);
        }

        public int checkIfJoinProject(string projectID, string username)
        {
            return TaskCreatingDAO.Instance.checkIfJoinProject(projectID, username);
        }

        public string getStringAttachFileFollowAllPrimaryKeys(string projectID, string stage, string task)
        {
            return TaskCreatingDAO.Instance.getStringAttachFileFollowAllPrimaryKeys(projectID, stage, task);
        }

        public string getStringStatusFollowAllPrimaryKeys(string projectID, string stage, string task)
        {
            return TaskCreatingDAO.Instance.getStringStatusFollowAllPrimaryKeys(projectID, stage, task);
        }

        public bool addData(TaskCreatingDTO taskCreatingDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskCreatingDTO.ProjectID == string.Empty || taskCreatingDTO.Stage == string.Empty
                || taskCreatingDTO.Task == string.Empty || taskCreatingDTO.Employee == null || taskCreatingDTO.StartDate == null || taskCreatingDTO.EndDate == null)
                return false;

            return TaskCreatingDAO.Instance.addData(taskCreatingDTO);
        }

        public bool updateData(TaskCreatingDTO taskCreatingDTO, string newTask)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskCreatingDTO.ProjectID == string.Empty || taskCreatingDTO.Stage == string.Empty
                || taskCreatingDTO.Task == string.Empty || taskCreatingDTO.Employee == null || newTask == null || taskCreatingDTO.StartDate == null || taskCreatingDTO.EndDate == null)
                return false;

            return TaskCreatingDAO.Instance.updateData(taskCreatingDTO, newTask);
        }

        public bool updateDataForFormTaskDetail(string projectID, string stage, string task, string finishDate, string status)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty || finishDate == null)
                return false;

            return TaskCreatingDAO.Instance.updateDataForFormTaskDetail(projectID, stage, task, finishDate, status);
        }

        public bool updateDataForTaskAssign(TaskCreatingDTO taskCreatingDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskCreatingDTO.ProjectID == string.Empty || taskCreatingDTO.Stage == string.Empty
                || taskCreatingDTO.Task == string.Empty || taskCreatingDTO.Employee == null || taskCreatingDTO.StartDate == null || taskCreatingDTO.EndDate == null)
                return false;

            return TaskCreatingDAO.Instance.updateDataForTaskAssign(taskCreatingDTO);
        }

        public bool updateDataForConfirmApprove(string projectID, string stage, string task, string status)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            return TaskCreatingDAO.Instance.updateDataForConfirmApprove(projectID, stage, task, status);
        }

        public bool updateDataForProgress(string project, string stage, string task, string progress)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (project == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            return TaskCreatingDAO.Instance.updateDataForProgress(project, stage, task, progress);
        }

        public bool updateDataForStatusAndProgress(string projectID, string stage, string task, string status, string progress)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            return TaskCreatingDAO.Instance.updateDataForStatusAndProgress(projectID, stage, task, status, progress);
        }

        public bool deleteData(string projectID, string stage, string task)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty)
                return false;

            return TaskCreatingDAO.Instance.deleteData(projectID, stage, task);
        }


        public bool checkApprover(string name)
        {
            return TaskCreatingDAO.Instance.checkApprover(name);
        }
    }
}
