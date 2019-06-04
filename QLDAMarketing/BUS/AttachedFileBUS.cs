using ProjectManagement.DAO;
using ProjectManagement.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProjectManagement.BUS
{
    public class AttachedFileBUS
    {
        private static AttachedFileBUS instance;

        public static AttachedFileBUS Instance
        {
            get { if (instance == null) instance = new AttachedFileBUS(); return AttachedFileBUS.instance; }

            set { AttachedFileBUS.instance = value; }
        }

        private AttachedFileBUS() { }

        public DataTable getData(string projectID, string stage, string task)
        {
            return AttachedFileDAO.Instance.getData(projectID, stage, task);
        }

        public int getIntCheckHaveAttachedFile(string project, string stage, string task)
        {
            return AttachedFileDAO.Instance.getIntCheckHaveAttachedFile(project, stage, task);
        }

        public bool addData(AttachedFileDTO attachedFileDTO)
        {
            if (attachedFileDTO.ProjectID == string.Empty || attachedFileDTO.Stage == string.Empty || attachedFileDTO.Task == string.Empty || attachedFileDTO.Time == string.Empty)
                return false;

            return AttachedFileDAO.Instance.addData(attachedFileDTO);
        }


        public bool deleteData(string projectID, string stage, string task, string time)
        {
            if (projectID == string.Empty || stage == string.Empty || task == string.Empty || time == string.Empty)
                return false;

            return deleteData(projectID, stage, task, time);
        }
    }
}
