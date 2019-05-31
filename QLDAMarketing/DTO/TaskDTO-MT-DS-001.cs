using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.DTO
{
    public class TaskDTO
    {
        string projectID, stage, task, taskDescription, startDate, endDate, taskType, note;


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

        public TaskDTO()
        {

        }

        public TaskDTO(DataRow row)
        {
            this.projectID = row["PROJECTID"].ToString().Trim();
            this.stage = row["STAGE"].ToString().Trim();
            this.task = row["TASK"].ToString().Trim();
            this.taskDescription = row["TASKDESCRIPTION"].ToString().Trim();
            this.startDate = row["STARTDATE"].ToString().Trim();
            this.endDate = row["ENDDATE"].ToString().Trim();
            this.taskType = row["TASKTYPE"].ToString().Trim();
            this.note = row["NOTE"].ToString().Trim();
        }

        public TaskDTO(string projectID, string stage, string task, string taskDescription, string startDate, string endDate, string taskType, string note)
        {
            this.projectID = projectID;
            this.stage = stage;
            this.task = task;
            this.taskDescription = taskDescription;
            this.startDate = startDate;
            this.endDate = endDate;
            this.taskType = taskType;
            this.note = note;
        }
    }
}
