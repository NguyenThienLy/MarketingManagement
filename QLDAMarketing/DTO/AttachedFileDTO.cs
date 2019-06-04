using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectManagement.DTO
{
    public class AttachedFileDTO
    {
        string projectID, stage, task, time, fileName, note;

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

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                fileName = value;
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

        public AttachedFileDTO()
        {
            this.projectID = string.Empty;
            this.stage = string.Empty;
            this.task = string.Empty;
            this.time = string.Empty;
            this.fileName = string.Empty;
            this.note = string.Empty;
        }

        public bool Empty()
        {
            if (this.projectID == string.Empty || this.stage == string.Empty || this.task == string.Empty || this.time== string.Empty)
                return true;

            return false;
        }

        public AttachedFileDTO(DataRow row)
        {
            this.ProjectID = row["PROJECTID"].ToString().Trim();
            this.Stage = row["STAGE"].ToString().Trim();
            this.Task = row["TASK"].ToString().Trim();
            this.Time = row["TIME"].ToString().Trim();
            this.FileName = row["FILENAME"].ToString().Trim();
            this.Note = row["NOTE"].ToString().Trim();
        }

        public AttachedFileDTO(string projectID, string stage, string task, string time, string fileName, string note)
        {
            this.ProjectID = projectID;
            this.Stage = stage;
            this.Task = task;
            this.Time = time;
            this.FileName = fileName;
            this.Note = note;
        }
    }
}
