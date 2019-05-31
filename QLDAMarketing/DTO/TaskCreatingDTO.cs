using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProjectManagement.CO;

namespace ProjectManagement.DTO
{
    public class TaskCreatingDTO
    {
        private string projectID, stage, task, employee, taskDescription, startDate, endDate, taskType, approver,
            attachFile, progress, status, finishDate, timeDelay, color, note;

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

        public string Approver
        {
            get
            {
                return approver;
            }

            set
            {
                approver = value;
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

        public TaskCreatingDTO()
        {
            this.projectID = string.Empty;
            this.stage = string.Empty;
            this.task = string.Empty;
            this.employee = string.Empty;
            this.taskDescription = string.Empty;
            this.startDate = string.Empty;
            this.endDate = string.Empty;
            this.taskType = string.Empty;
            this.approver = string.Empty;
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
            if (this.projectID == string.Empty || this.stage == string.Empty || this.task == string.Empty)
                return true;

            return false;
        }

        public TaskCreatingDTO(TaskCreatingDTO taskCreatingDTO)
        {
            this.projectID = taskCreatingDTO.projectID;
            this.stage = taskCreatingDTO.stage;
            this.task = taskCreatingDTO.task;
            this.employee = taskCreatingDTO.employee;
            this.taskDescription = taskCreatingDTO.taskDescription;
            this.startDate = taskCreatingDTO.startDate;
            this.endDate = taskCreatingDTO.endDate;
            this.taskType = taskCreatingDTO.taskType;
            this.approver = taskCreatingDTO.approver;
            this.attachFile = taskCreatingDTO.attachFile;
            this.progress = taskCreatingDTO.progress;
            this.status = taskCreatingDTO.status;
            this.finishDate = taskCreatingDTO.finishDate;
            this.timeDelay = taskCreatingDTO.timeDelay;
            this.color = taskCreatingDTO.color;
            this.note = taskCreatingDTO.note;
        }

        public TaskCreatingDTO(DataRow row)
        {
            this.projectID = row["PROJECTID"].ToString().Trim();
            this.stage = row["STAGE"].ToString().Trim();
            this.task = row["TASK"].ToString().Trim();
            this.employee = row["EMPLOYEE"].ToString().Trim();
            this.taskDescription = row["TASKDESCRIPTION"].ToString().Trim();

            this.startDate = DateTime.Parse(row["STARTDATE"].ToString().Trim()).ToString("dd/MM/yyyy").Trim();
            this.endDate = DateTime.Parse(row["ENDDATE"].ToString().Trim()).ToString("dd/MM/yyyy").Trim();

            this.taskType = row["TASKTYPE"].ToString().Trim();
            this.approver = row["APPROVER"].ToString().Trim();
            this.attachFile = row["ATTACHFILE"].ToString().Trim();
            this.progress = row["PROGRESS"].ToString().Trim();
            this.status = row["STATUS"].ToString().Trim();

            if (row["FINISHDATE"].ToString().Trim() == string.Empty)
                this.finishDate = string.Empty;
            else
                this.finishDate = DateTime.Parse(row["FINISHDATE"].ToString().Trim()).ToString("dd/MM/yyyy").Trim();

            this.timeDelay = row["TIMEDELAY"].ToString().Trim();
            this.color = row["COLOR"].ToString().Trim();
            this.note = row["NOTE"].ToString().Trim();
        }

        public TaskCreatingDTO(string projectID, string stage, string task, string employee, string taskDescription, string startDate, string endDate, string taskType, string approver, string attachFile, string progress, string status, string finishDate, string timeDelay, string color, string note)
        {
            this.projectID = projectID;
            this.stage = stage;
            this.task = task;
            this.employee = employee;
            this.taskDescription = taskDescription;
            this.startDate = startDate;
            this.endDate = endDate;
            this.taskType = taskType;
            this.approver = approver;
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
