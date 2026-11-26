using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Auth;
using DVLD.Tests;
using DVLDBusinessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.TestAppointments
{
    public partial class frmEditVisionTest : Form
    {
        clsTestAppointment _appointment;
        clsTest Test;
        public event RefreshHandler refreshHandler;
        public frmEditVisionTest(clsTestAppointment appointment)
        {

            InitializeComponent();
            _appointment = appointment;
            Test = new clsTest();
        }

        private void frmEditVisionTest_Load(object sender, EventArgs e)
        {
            lbID.Text = _appointment.LocalDrivingLicesenseApplicationID.ToString();
            LbFullName.Text = (_appointment.LocalDrivingLicenseApplication.Person.FullName);
            lbClass.Text = _appointment.LocalDrivingLicenseApplication.Type.Title;
            lbFees.Text = _appointment.PaidFees.ToString();
            lbTrail.Text = "0";

            Test.TestAppointmentID = _appointment.TestAppointmentID;
            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            _appointment.AppointmentDate = dtDate.Value;
           
            if (_appointment.Save())
            {
                MessageBox.Show("Appointment Updated Successfully");
            }
            else
            {
                MessageBox.Show("Appointment Update Failed");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.refreshHandler?.Invoke();
            this.Close();
        }
    }
}
