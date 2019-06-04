using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    class TaskAssignBUS
    {
        // singleton.
        private static TaskAssignBUS instance;

        public static TaskAssignBUS Instance
        {
            get { if (instance == null) instance = new TaskAssignBUS(); return TaskAssignBUS.instance; }

            set { TaskAssignBUS.instance = value; }
        }

        private TaskAssignBUS() { }

    
        public bool addData(TaskAssignDTO taskAssignDTO)
        {
            // Nếu khóa chính trống thì không thể thêm vào.
            if (taskAssignDTO.Employee == string.Empty || taskAssignDTO.ProjectID == string.Empty || taskAssignDTO.Stage == string.Empty || taskAssignDTO.Task == string.Empty)
                return false;

            return TaskAssignDAO.Instance.addData(taskAssignDTO);
        }
    }
}
