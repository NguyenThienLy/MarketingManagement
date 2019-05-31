using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace ProjectManagement.View
{
    public partial class formProjectCreating : DevExpress.XtraEditors.XtraForm
    {
        // singleton.
        private static formProjectCreating instance;

        public static formProjectCreating Instance
        {
            get { if (instance == null) instance = new formProjectCreating(); return formProjectCreating.instance; }

            set { formProjectCreating.instance = value; }
        }

        private formProjectCreating()
        {
            InitializeComponent();
        }

        private void formProjectCreating_Load(object sender, EventArgs e)
        {
            formProjectCreating frmProjectCreating = formProjectCreating.Instance;
            formCreatingProject frmCreatingProject = new formCreatingProject();
            frmCreatingProject.MdiParent = frmProjectCreating;
            frmCreatingProject.Show();
        }

        private void formProjectCreating_FormClosed(object sender, FormClosedEventArgs e)
        {
            formProjectCreating frmProjectCreating = formProjectCreating.Instance;
            formProjectCreating.Instance = null;
            frmProjectCreating.Close();
        }

        private void mdiProjectCreating_PageRemoved(object sender, DevExpress.XtraTabbedMdi.MdiTabPageEventArgs e)
        {
            formProjectCreating frmProjectCreating = formProjectCreating.Instance;
            formProjectCreating.Instance = null;
            frmProjectCreating.Close();
        }
    }
}