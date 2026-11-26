using DVLD.Auth;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.TestAppointments.Written
{
    public partial class frmWrittenTestAppointment : Form
    {
        private void refresh()
        {

            frmWrittenTestAppointment_Load(null, null);
        }
        public event RefreshHandler refreshHandler;
        clsLocalDrivingLicenseApplication _application;
        public frmWrittenTestAppointment(clsLocalDrivingLicenseApplication application)
        {
            InitializeComponent();
            _application = application;
        }

        private void frmWrittenTestAppointment_Load(object sender, EventArgs e)
        {
            ctrlLocalDrivingLicesnseApplication1.loadLocalDrivingLiceseApplication(_application);
            dataGridView1.DataSource = clsTestAppointment.GetTestAppointments(_application.LocalDrivingLicenseApplicationID, 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clsTestAppointment.hasActiveAppointment(_application.LocalDrivingLicenseApplicationID))
            {
                MessageBox.Show("This Person Alleady have Active Appointment");
            }
            else if (ctrlLocalDrivingLicesnseApplication1.PassedTests >= 2)
            {
                MessageBox.Show("This Person Alleady Passed Test Before");
            }
            else if (clsTest.CountFailedTests(_application.Person.PersonID, _application.ApplicationID) > 0)
            {
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
                    frmSchedualWrittenTestcs frm = new frmSchedualWrittenTestcs(_application, app);
                    frm.refreshHandler += refresh;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Error:Connot Retake Test");
                }


            }
            else
            {

                frmSchedualWrittenTestcs frm = new frmSchedualWrittenTestcs(_application);
                frm.refreshHandler += refresh;
                frm.ShowDialog();

            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TestAppointmentID"].Value.ToString());
            clsTestAppointment appointment = clsTestAppointment.Find(id);
            if (appointment != null)
            {
                frmTakeWrittenTest frm = new frmTakeWrittenTest(appointment);
                frm.refreshHandler += refresh;
                frm.ShowDialog();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshHandler?.Invoke();
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TestAppointmentID"].Value.ToString());
            clsTestAppointment appointment = clsTestAppointment.Find(id);
            if (appointment != null)
            {
                
                frmEditWrittenTestAppointment frm = new frmEditWrittenTestAppointment(appointment);
                frm.refreshHandler += refresh;
                frm.ShowDialog();
            }
        }
    }
}
