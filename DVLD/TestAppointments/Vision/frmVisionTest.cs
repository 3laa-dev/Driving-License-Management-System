using DVLD.Auth;
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
        public event RefreshHandler refreshHandler;
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

            if (clsTestAppointment.hasActiveAppointment(_application.LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("This Person Alleady have Active Appointment");
            }
            else if (ctrlLocalDrivingLicesnseApplication1.PassedTests >= 1)
            {
                MessageBox.Show("This Person Alleady Passed Test Before");
            }
            else if (clsTest.CountFailedTests(_application.Person.PersonID ,_application.ApplicationID) > 0) { 
                clsApplication app = new clsApplication();
                app.ApplicationStatus = 0;
                app.ApplicationDate = DateTime.Now;
                app.CreatedByUserID = clsGlobal.CurrentUser.UserID; 
                app.ApplicationTypeID = 1;

                app.ApplicationPersonID = _application.ApplicationPersonID;
                app.ApplicationTypeID = 7;
                app.PaidFees = clsApplicationType.Find(7).Fees;

                if (app.Save())
                {
                    frmSechudulVisionTest frm = new frmSechudulVisionTest(_application , app);
                    frm.refreshHandler += refresh;
                    frm.ShowDialog();
                }
                else {
                    MessageBox.Show("Error:Connot Retake Test");
                }
                    
            
            }
            else
            {

                frmSechudulVisionTest frm = new frmSechudulVisionTest(_application);
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
        
        

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshHandler?.Invoke();
            this.Close();
        }
    }
}
