using DVLD.TestAppointments.Written;
using DVLD.Tests;
using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DVLD.Applications.ManageLocalDrivinigLicseneApplication
{
    public partial class frmManageLocalDrivingLiceseApplications : Form
    {
        
        public frmManageLocalDrivingLiceseApplications()
        {
            InitializeComponent();
        }
        private void updadateCountOfRecord()
        {
            countOfRecords.Text = (dataGridView1.RowCount).ToString();
        }
        private void frmManageLocalDrivingLiceseApplications_Load(object sender, EventArgs e)
        {
           // EnableToolStripMenuItems(false , false , false );
            DataTable dataTable = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
            dataGridView1.DataSource = dataTable;

            foreach (DataColumn col in dataTable.Columns) {
                comboBox1.Items.Add(col.ToString());
            }
            if (comboBox1.Items.Count > 0) {
                comboBox1.SelectedIndex = 0;
            }
            updadateCountOfRecord();
            
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterBy = comboBox1.SelectedItem.ToString();
            string value = textBox1.Text;
            dataGridView1.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication(FilterBy ,   value);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString());
            if (clsLocalDrivingLicenseApplication.CancelLocalDrivingLicenseApplication(id)) {
                MessageBox.Show("Application Cancelled successfully");
            }
            else
            {
                MessageBox.Show("Failed to Cancel Application");
            }
            frmManageLocalDrivingLiceseApplications_Load(sender , e);
        }
        private void EnableToolStripMenuItems(bool Vision, bool Written, bool Street) {
            sechedualVisionTestToolStripMenuItem.Enabled = Vision;
            schedualWritenTestToolStripMenuItem.Enabled = Written;
            schedualStreetTestToolStripMenuItem.Enabled = Street;
        }
            
        private void sechedualVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString());
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find(id);

            frmVisionTest frm = new frmVisionTest(app);
            frm.refreshHandler += () => { dataGridView1.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication(); };
            frm.ShowDialog();
            
        }

        

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString());
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find(id);
            int _PassedTests = clsTest.CountOfPassedTests(app.Person.PersonID, app.ApplicationID );
            if (_PassedTests == 0)
                EnableToolStripMenuItems(true, false, false);
            else if (_PassedTests == 1)
                EnableToolStripMenuItems(false, true, false);
            else if (_PassedTests == 2)
                EnableToolStripMenuItems(false, false, true);
        }

        private void schedualWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value.ToString());
            clsLocalDrivingLicenseApplication app = clsLocalDrivingLicenseApplication.Find(id);

            frmWrittenTestAppointment frm = new frmWrittenTestAppointment(app);
            frm.refreshHandler += () => { dataGridView1.DataSource = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication(); };
            frm.ShowDialog();
        }
    }
}
