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

namespace DVLD.TestAppointments.Written
{
    public partial class frmEditWrittenTestAppointment : Form
    {
        clsTestAppointment _appointment;
        clsTest Test;
        public event RefreshHandler refreshHandler;
        public frmEditWrittenTestAppointment(clsTestAppointment appointment)
        {

            InitializeComponent();
            _appointment = appointment;
            Test = new clsTest();
        }

        private void frmEditWrittenTestAppointment_Load(object sender, EventArgs e)
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
