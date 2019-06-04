﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProjectManagement.DTO
{
    public class departmentDTO
    {
        private string department, leader;

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
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

        //private static PhongBanObject instance;

        //public static PhongBanObject Instance
        //{
        //    get { if (instance == null) instance = new PhongBanObject(); return PhongBanObject.instance; }

        //    set { PhongBanObject.instance = value; }
        //}

        public departmentDTO() { }

        public departmentDTO(DataRow row)
        {
            this.department = row["DEPARTMENT"].ToString().Trim();
            this.leader = row["LEADER"].ToString().Trim();
        }

        public departmentDTO(string department, string leader)
        {
            this.department = department;
            this.leader = leader;
        }

   
    }
}
