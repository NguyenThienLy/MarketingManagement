using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.DTO
{
   public class StageDTO
    {
        string projectID, stage, stageSubject, status;

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

        public string StageSubject
        {
            get
            {
                return stageSubject;
            }

            set
            {
                stageSubject = value;
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

        public StageDTO()
        {
            this.projectID = string.Empty;
            this.stage = string.Empty;
            this.stageSubject = string.Empty;
            this.status = string.Empty;
        }

        public bool Empty()
        {
            if (this.projectID == string.Empty || this.stage == string.Empty)
                return true;

            return false;
        }

        public StageDTO(DataRow row)
        {
            this.projectID = row["PROJECTID"].ToString().Trim();
            this.stage = row["STAGE"].ToString().Trim();
            this.stageSubject = row["STAGESUBJECT"].ToString().Trim();
            this.status = row["STATUS"].ToString().Trim();
        }

        public StageDTO(string projectID, string stage, string stageSubject, string status)
        {
            this.projectID = projectID;
            this.stage = stage;
            this.stageSubject = stageSubject;
            this.status = status;
        }
    }
}
