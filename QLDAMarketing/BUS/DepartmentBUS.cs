using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    public class DepartmentBUS
    {
        // singleton.
        private static DepartmentBUS instance;

        public static DepartmentBUS Instance
        {
            get { if (instance == null) instance = new DepartmentBUS(); return DepartmentBUS.instance; }

            set { DepartmentBUS.instance = value; }
        }

        private DepartmentBUS() { }

        public DataTable getData()
        {
           return DepartmentDAO.Instance.getData();
        }

        public bool addData(DepartmentDTO departmentDTO)
        {
            if (departmentDTO.Department == string.Empty)
                return false;

            return DepartmentDAO.Instance.addData(departmentDTO);
        }

        public bool updateData(DepartmentDTO departmentDTO, string newDepartment)
        {
            if (departmentDTO.Department == string.Empty || newDepartment == null)
                return false;

            return DepartmentDAO.Instance.updateData(departmentDTO, newDepartment);
        }

        public bool checkLeader(string name)
        {
            return DepartmentDAO.Instance.checkLeader(name);
        }
    }
}
