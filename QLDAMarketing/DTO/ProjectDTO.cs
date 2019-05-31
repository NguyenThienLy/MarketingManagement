using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectManagement.DTO
{
    public class ProjectDTO
    {
        string projectID, projectName, leader, startDate, endDate, progress, projectType, posmProject, dateRepeat, autoRepeat, startDateRepeat, endDateRepeat, status;

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

        public string ProjectName
        {
            get
            {
                return projectName;
            }

            set
            {
                projectName = value;
            }
        }

        public string Leader
        {
            get
            {
                return leader;
            }

            set
            {
                leader = value;
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

        public string ProjectType
        {
            get
            {
                return projectType;
            }

            set
            {
                projectType = value;
            }
        }

        public string POSMProject
        {
            get
            {
                return posmProject;
            }

            set
            {
                posmProject = value;
            }
        }

        public string DateRepeat
        {
            get
            {
                return dateRepeat;
            }

            set
            {
                dateRepeat = value;
            }
        }

        public string AutoRepeat
        {
            get
            {
                return autoRepeat;
            }

            set
            {
                autoRepeat = value;
            }
        }

        public string StartDateRepeat
        {
            get
            {
                return startDateRepeat;
            }

            set
            {
                startDateRepeat = value;
            }
        }

        public string EndDateRepeat
        {
            get
            {
                return endDateRepeat;
            }

            set
            {
                endDateRepeat = value;
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

        public ProjectDTO()
        {
            this.projectID = string.Empty;
            this.projectName = string.Empty;
            this.leader = string.Empty;
            this.startDate = string.Empty;
            this.endDate = string.Empty;
            this.progress = string.Empty;
            this.projectType = string.Empty;
            this.posmProject = string.Empty;
            this.dateRepeat = string.Empty;
            this.autoRepeat = string.Empty;
            this.startDateRepeat = string.Empty;
            this.endDateRepeat = string.Empty;
            this.status = string.Empty;
        }

        public bool Empty()
        {
            if (this.projectID == string.Empty)
                return true;

            return false;
        }

        public ProjectDTO(DataRow row)
        {
            this.projectID = row["PROJECTID"].ToString().Trim();
            this.projectName = row["PROJECTNAME"].ToString().Trim();
            this.leader = row["LEADER"].ToString().Trim();

            this.startDate = DateTime.Parse(row["STARTDATE"].ToString().Trim()).ToString("dd/MM/yyyy");
            this.endDate = DateTime.Parse(row["ENDDATE"].ToString().Trim()).ToString("dd/MM/yyyy");

            this.progress = row["PROGRESS"].ToString().Trim();
            this.projectType = row["PROJECTTYPE"].ToString().Trim();
            this.posmProject = row["POSMPROJECT"].ToString().Trim();
            this.dateRepeat = row["DATEREPEAT"].ToString().Trim();
            this.autoRepeat = row["AUTOREPEAT"].ToString().Trim();

            if (row["STARTDATEREPEAT"].ToString().Trim() == string.Empty)
                this.startDateRepeat = string.Empty;
            else
                this.startDateRepeat = DateTime.Parse(row["STARTDATEREPEAT"].ToString().Trim()).ToString("dd/MM/yyyy");

            if (row["ENDDATEREPEAT"].ToString().Trim() == string.Empty)
                this.endDateRepeat = string.Empty;
            else
                this.endDateRepeat = DateTime.Parse(row["ENDDATEREPEAT"].ToString().Trim()).ToString("dd/MM/yyyy");

            this.status = row["STATUS"].ToString().Trim();
        }

        public ProjectDTO(string projectID, string projectName, string leader, string startDate, string endDate, string progress, string projectType, string posmProject, string dateRepeat, string autoRepeat, string startDateRepeat, string endDateRepeat, string status)
        {
            this.projectID = projectID;
            this.projectName = projectName;
            this.leader = leader;
            this.startDate = startDate;
            this.endDate = endDate;
            this.progress = progress;
            this.projectType = projectType;
            this.posmProject = posmProject;
            this.dateRepeat = dateRepeat;
            this.autoRepeat = autoRepeat;
            this.startDateRepeat = startDateRepeat;
            this.endDateRepeat = endDateRepeat;
            this.status = status;
        }

    }
}
