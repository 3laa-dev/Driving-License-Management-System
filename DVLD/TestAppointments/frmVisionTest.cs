using DVLD.TestAppointments;
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

namespace DVLD.Tests
{
    public partial class frmVisionTest : Form
    {
        clsLocalDrivingLicenseApplication _application;
        public frmVisionTest(clsLocalDrivingLicenseApplication application)
        {
            InitializeComponent();
            _application = application;
        }

        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicesnseApplication1.loadLocalDrivingLiceseApplication(_application);
            dataGridView1.DataSource = clsTestAppointment.GetTestAppointments(_application.LocalDrivingLicenseApplicationID ,1 );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSechudulVisionTest frm;
            if (clsTestAppointment.hasActiveAppointment(_application.LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("This Person Alleady have Active Appointment");
            }
            else
            {
               
                frm = new frmSechudulVisionTest(_application);
                frm.refreshHandler += refresh;
                frm.ShowDialog();
                
            }
            
        }

        private void refresh() {
            // dataGridView1.DataSource = clsTestAppointment.GetTestAppointments(_application.LocalDrivingLicenseApplicationID, 1);
            frmVisionTest_Load(null, null);


        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TestAppointmentID"].Value.ToString());
            clsTestAppointment appointment = clsTestAppointment.Find(id);
            if (appointment != null)
            {
                frmTakeTest frm = new frmTakeTest(appointment);
                frm.refreshHandler += refresh;
                frm.ShowDialog();
            }
            
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TestAppointmentID"].Value.ToString());
            clsTestAppointment appointment = clsTestAppointment.Find(id);
            if (appointment != null)
            {
                // frmTakeTest frm = new frmTakeTest(appointment);
                frmEditVisionTest frm = new frmEditVisionTest(appointment);
                frm.refreshHandler += refresh;
                frm.ShowDialog();
            }
        }
    }
}
