using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using EasyTabs;
using ProjectManagement.DTO;
using ProjectManagement.DAO;

namespace ProjectManagement.View
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        private void btnProjectHistory_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Long dep trai");


        }

        private void bunifuThinButton21_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}