using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DTO
{
    public class HistoryDTO
    {
        string name, time, action, status;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Action
        {
            get
            {
                return action;
            }

            set
            {
                action = value;
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

        public HistoryDTO()
        {
            this.name = string.Empty;
            this.time = string.Empty;
            this.action = string.Empty;
            this.status = string.Empty;
        }

        public bool Empty()
        {
            if (this.name == string.Empty || this.time == string.Empty)
                return true;

            return false;
        }

        public HistoryDTO(string employee, string time, string action, string status)
        {
            this.name = employee;
            this.time = time;
            this.action = action;
            this.status = status;
        }

    }
}
