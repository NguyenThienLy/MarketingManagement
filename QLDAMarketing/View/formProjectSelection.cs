using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ProjectManagement.DTO;
using ProjectManagement.DAO;
using ProjectManagement.CO;
using ProjectManagement.BUS;

namespace ProjectManagement.View
{
    public partial class formProjectSelection : DevExpress.XtraEditors.XtraForm
    {
        // Cờ xử lí chọn value ô combobox để phân biệt với sự kiện textchange
        bool b_IsSelectProjectIDGlobal = false;

        string str_ProjectIDGlobal = string.Empty;

        private Dictionary<TabPage, Color> TabColors = new Dictionary<TabPage, Color>();


        public formProjectSelection()
        {
            InitializeComponent();

            this.loadColorDefault();
            this.addTabColor();

            this.txtEdtProjectName.ReadOnly = true;

            layoutControl1.OptionsFocus.EnableAutoTabOrder = false;
        }

        private void loadProject()
        {
            this.txtEdtProjectName.Text = string.Empty;
            this.cbbProjectID.Text = string.Empty;

            string str_EmployeeLocal = StaticVarClass.account_Username;
            string str_POSMProjectLocal = this.getPOSMProject();
            string str_StatusProjectLocal = this.getStatusProject();

            DataTable dt_ProjectSelectionLocal = ProjectBUS.Instance.getDataForDialogProjectSelection(str_EmployeeLocal, str_POSMProjectLocal, str_StatusProjectLocal);
            List<string> lst_QuanlityLocal = ProjectBUS.Instance.getDataListQuantityForDialogProjectSelection(str_EmployeeLocal, str_POSMProjectLocal);

            if (dt_ProjectSelectionLocal != null && lst_QuanlityLocal != null)
            {
                if (dt_ProjectSelectionLocal.Rows.Count == 0)
                    this.btnSelect.Enabled = false;
                else
                    this.btnSelect.Enabled = true;

                foreach (DataRow row in dt_ProjectSelectionLocal.Rows)
                {
                    string name = row["PROJECTID"].ToString();
                    row["PROJECTID"] = name.Trim();
                }

                this.cbbProjectID.DataSource = dt_ProjectSelectionLocal;
                this.cbbProjectID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cbbProjectID.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cbbProjectID.DisplayMember = "PROJECTID";

                DataRowView dRV = (DataRowView)this.cbbProjectID.SelectedItem;
                if (dRV != null)
                    txtEdtProjectName.Text = dRV["PROJECTNAME"].ToString().Trim();

                this.loadQuanlityListProject(lst_QuanlityLocal);
            }
            else XtraMessageBox.Show("Cannot connect to database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private string getStatusProject()
        {
            int i_PageSelectLocal = this.tbCtrlProjectSelection.SelectedIndex;

            switch (i_PageSelectLocal)
            {
                case 0:
                    return StaticVarClass.projectSelect_ProjectsInProgress;
                case 1:
                    return StaticVarClass.projectSelect_CompletedProjects;
            }

            return StaticVarClass.projectSelect_DepartmentProjects;
        }

        private string getPOSMProject()
        {
            if (this.chkBxPOSMProject.Checked == true)
                return StaticVarClass.YN_Yes;

            return StaticVarClass.YN_No;
        }

        private void SetTabHeader(TabPage page, Color color)
        {
            this.TabColors[page] = color;
            tbCtrlProjectSelection.Invalidate();
        }

        private void addTabColor()
        {
            TabColors.Add(tbPgProjectsInProgress, Color.LightSkyBlue);
            TabColors.Add(tbPgCompletedProjects, Color.ForestGreen);
            TabColors.Add(tbPgDepartmentProjects, Color.LightYellow);
        }

        // Màu mặc định của các btn.
        private void loadColorDefault()
        {
            this.tbPgProjectsInProgress.BackColor = Color.LightSkyBlue;
            this.tbPgProjectsInProgress.ForeColor = Color.LightSkyBlue;

            this.tbPgCompletedProjects.BackColor = Color.ForestGreen;
            this.tbPgCompletedProjects.ForeColor = Color.ForestGreen;

            this.tbPgDepartmentProjects.BackColor = Color.YellowGreen;
            this.tbPgDepartmentProjects.ForeColor = Color.YellowGreen;
        }

        // Hiển thị các số lượng project trong từng status.
        private void loadQuanlityListProject(List<string> lst_QuanlityListProject)
        {
            this.tbPgProjectsInProgress.Text = StaticVarClass.projectSelect_ProjectsInProgress + " ("+ lst_QuanlityListProject[0] + ")";

            this.tbPgCompletedProjects.Text = StaticVarClass.projectSelect_CompletedProjects + " (" + lst_QuanlityListProject[1] + ")";

            this.tbPgDepartmentProjects.Text = StaticVarClass.projectSelect_DepartmentProjects + " (" + lst_QuanlityListProject[2] + ")";
        }

        private void formProjectSelection_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.LightGreen;

            this.loadProject();
        }

        private void chkBxPOSMProject_CheckedChanged(object sender, EventArgs e)
        {
            this.loadProject();
        }

        private void cbbProjectID_DropDown(object sender, EventArgs e)
        {
            this.cbbProjectID.AutoCompleteMode = AutoCompleteMode.None;
            this.cbbProjectID.AutoCompleteSource = AutoCompleteSource.None;
        }

        private void cbbProjectID_DropDownClosed(object sender, EventArgs e)
        {
            this.cbbProjectID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cbbProjectID.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void cbbProjectID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty)
            {
                DataRowView dRV = (DataRowView)this.cbbProjectID.SelectedItem;
                txtEdtProjectName.Text = dRV["PROJECTNAME"].ToString().Trim();
                this.btnSelect.Enabled = true;
            }
            else if (str_ProjectIDLocal == string.Empty)
            {
                this.btnSelect.Enabled = false;
                this.txtEdtProjectName.Text = string.Empty;
            }
        }

        private void cbbProjectID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.b_IsSelectProjectIDGlobal = true;
            string str_ProjectIDLocal = this.cbbProjectID.GetItemText(this.cbbProjectID.SelectedItem).Trim();

            if (str_ProjectIDLocal != string.Empty)
            {
                DataRowView dRV = (DataRowView)this.cbbProjectID.SelectedItem;
                txtEdtProjectName.Text = dRV["PROJECTNAME"].ToString().Trim();
                this.btnSelect.Enabled = true;
            }
            else if (str_ProjectIDLocal == string.Empty)
            {
                this.btnSelect.Enabled = false;
                this.txtEdtProjectName.Text = string.Empty;
            }
        }

        private void cbbProjectID_TextChanged(object sender, EventArgs e)
        {
            if (this.b_IsSelectProjectIDGlobal == false)
            {
                this.btnSelect.Enabled = false;
                this.txtEdtProjectName.Text = string.Empty;
            }
            else
                this.b_IsSelectProjectIDGlobal = false;
        }

        private void cbbProjectID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.chkBxPOSMProject.Focus();
            }
        }

        private void chkBxPOSMProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.btnSelect.Enabled == true)
                    this.btnSelect.PerformClick();
                else
                    this.cbbProjectID.Select();
            }
        }

        private void formProjectSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void tbCtrlProjectSelection_DrawItem(object sender, DrawItemEventArgs e)
        {
            //e.DrawBackground();
            using (Brush br = new SolidBrush(TabColors[tbCtrlProjectSelection.TabPages[e.Index]]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
                SizeF sz = e.Graphics.MeasureString(tbCtrlProjectSelection.TabPages[e.Index].Text, e.Font);

                var x = e.Bounds.Left + (e.Bounds.Width - e.Graphics.MeasureString(this.tbCtrlProjectSelection.TabPages[e.Index].Text, this.tbCtrlProjectSelection.Font).Width) / 2;
                var y = e.Bounds.Top + (e.Bounds.Height - e.Graphics.MeasureString(this.tbCtrlProjectSelection.TabPages[e.Index].Text, this.tbCtrlProjectSelection.Font).Height) / 2;
                e.Graphics.DrawString(tbCtrlProjectSelection.TabPages[e.Index].Text, e.Font, Brushes.Black, x, y);

                Rectangle rect = e.Bounds;
                rect.Offset(0, 1);
                rect.Inflate(0, -1);
                e.Graphics.DrawRectangle(Pens.DarkGray, rect);
                e.DrawFocusRectangle();
            }
        }

        private void tbCtrlProjectSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.loadProject();
        }
    }
}