using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.CO;

namespace ProjectManagement.DTO
{
    class TaskAssignDTO
    {
        private string projectID, stage, task, employee, taskDescription, startDate, endDate, taskType, approval, attachFile,
          progress, status, finishDate, timeDelay, color, note;

        public string ProjectID
        {
            get
            {
                return projectID;
            }

            set
            {
                projectID = value;
            }
        }

        public string Stage
        {
            get
            {
                return stage;
            }

            set
            {
                stage = value;
            }
        }

        public string Task
        {
            get
            {
                return task;
            }

            set
            {
                task = value;
            }
        }

        public string Employee
        {
            get
            {
                return employee;
            }

            set
            {
                employee = value;
            }
        }

        public string TaskDescription
        {
            get
            {
                return taskDescription;
            }

            set
            {
                taskDescription = value;
            }
        }

        public string StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
            }
        }

        public string EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
            }
        }

        public string TaskType
        {
            get
            {
                return taskType;
            }

            set
            {
                taskType = value;
            }
        }

        public string Approval
        {
            get
            {
                return approval;
            }

            set
            {
                approval = value;
            }
        }

        public string AttachFile
        {
            get
            {
                return attachFile;
            }

            set
            {
                attachFile = value;
            }
        }

        public string Progress
        {
            get
            {
                return progress;
            }

            set
            {
                progress = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string FinishDate
        {
            get
            {
                return finishDate;
            }

            set
            {
                finishDate = value;
            }
        }

        public string TimeDelay
        {
            get
            {
                return timeDelay;
            }

            set
            {
                timeDelay = value;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
            }
        }

        public string Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public TaskAssignDTO()
        {
            this.projectID = string.Empty;
            this.stage = string.Empty;
            this.task = string.Empty;
            this.employee = string.Empty;
            this.taskDescription = string.Empty;
            this.startDate = string.Empty;
            this.endDate = string.Empty;
            this.taskType = string.Empty;
            this.approval = string.Empty;
            this.attachFile = string.Empty;
            this.progress = string.Empty;
            this.status = string.Empty;
            this.finishDate = string.Empty;
            this.timeDelay = string.Empty;
            this.color = string.Empty;
            this.note = string.Empty; 
        }

        public bool Empty()
        {
            if (this.projectID == string.Empty || this.stage == string.Empty || this.task == string.Empty || this.employee == string.Empty)
                return true;

            return false;
        }

        public TaskAssignDTO(TaskAssignDTO taskAssignDTO)
        {
            this.projectID = taskAssignDTO.projectID;
            this.stage = taskAssignDTO.stage;
            this.task = taskAssignDTO.task;
            this.employee = taskAssignDTO.employee;
            this.taskDescription = taskAssignDTO.taskDescription;
            this.startDate = taskAssignDTO.startDate;
            this.endDate = taskAssignDTO.endDate;
            this.taskType = taskAssignDTO.taskType;
            this.approval = taskAssignDTO.approval;
            this.attachFile = taskAssignDTO.attachFile;
            this.progress = taskAssignDTO.progress;
            this.status = taskAssignDTO.status;
            this.finishDate = taskAssignDTO.finishDate;
            this.timeDelay = taskAssignDTO.timeDelay;
            this.color = taskAssignDTO.color;
            this.note = taskAssignDTO.note;
        }

        public TaskAssignDTO(TaskCreatingDTO taskCreatingDTO)
        {
            this.projectID = taskCreatingDTO.ProjectID;
            this.stage = taskCreatingDTO.Stage;
            this.task = taskCreatingDTO.Task;
            this.employee = taskCreatingDTO.Employee;
            this.taskDescription = taskCreatingDTO.TaskDescription;
            this.startDate = taskCreatingDTO.StartDate;
            this.endDate = taskCreatingDTO.EndDate;
            this.taskType = taskCreatingDTO.TaskType;
            this.approval = taskCreatingDTO.Approver;
            this.attachFile = taskCreatingDTO.AttachFile;
            this.progress = taskCreatingDTO.Progress;
            this.status = taskCreatingDTO.Status;
            this.finishDate = taskCreatingDTO.FinishDate;
            this.timeDelay = taskCreatingDTO.TimeDelay;
            this.color = taskCreatingDTO.Color;
            this.note = taskCreatingDTO.Note;
        }

        public TaskAssignDTO(DataRow row)
        {
            this.projectID = row["PROJECTID"].ToString().Trim();
            this.stage = row["STAGE"].ToString().Trim();
            this.task = row["TASK"].ToString().Trim();
            this.employee = row["EMPLOYEE"].ToString().Trim();
            this.taskDescription = row["TASKDESCRIPTION"].ToString().Trim();
            this.startDate = row["STARTDATE"].ToString().Trim();
            this.endDate = row["ENDDATE"].ToString().Trim();
            this.taskType = row["TASKTYPE"].ToString().Trim();
            this.approval = row["APPROVAL"].ToString().Trim();
            this.attachFile = row["ATTACHFILE"].ToString().Trim();
            this.progress = row["PROGRESS"].ToString().Trim();
            this.status = row["STATUS"].ToString().Trim();
            this.finishDate = row["FINISHDATE"].ToString().Trim();
            this.timeDelay = row["TIMEDELAY"].ToString().Trim();
            this.color = row["COLOR"].ToString().Trim();
            this.note = row["NOTE"].ToString().Trim();
        }

        public TaskAssignDTO(string projectID, string stage, string task, string employee, string taskDescription, string startDate, string endDate, string taskType, string approval, string attachFile, string progress, string status, string finishDate, string timeDelay, string color, string assignTask, string note)
        {
            this.projectID = projectID;
            this.stage = stage;
            this.task = task;
            this.employee = employee;
            this.taskDescription = taskDescription;
            this.startDate = startDate;
            this.endDate = endDate;
            this.taskType = taskType;
            this.approval = approval;
            this.attachFile = attachFile;
            this.progress = progress;
            this.status = status;
            this.finishDate = finishDate;
            this.timeDelay = timeDelay;
            this.color = color;
            this.note = note;
        }
    }
}
