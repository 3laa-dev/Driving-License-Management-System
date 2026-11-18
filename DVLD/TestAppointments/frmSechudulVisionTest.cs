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
using DVLDBusinessLayer;

namespace DVLD.TestAppointments
{
    public delegate void RefreshPageHandler();
    public partial class frmSechudulVisionTest : Form
    {
        public event RefreshPageHandler refreshHandler ;
        clsTestAppointment testAppointment;
        clsLocalDrivingLicenseApplication _application;
        public frmSechudulVisionTest(clsLocalDrivingLicenseApplication application)
        {
            InitializeComponent();
            _application = application;
        }

        private void frmSechudulVisionTest_Load(object sender, EventArgs e)
        {
            lbID.Text = _application.LocalDrivingLicenseApplicationID.ToString();
            LbFullName.Text = _application.Person.FullName;
            lbClass.Text = _application.Type.Title;
            lbFees.Text = _application.PaidFees.ToString();
            lbTrail.Text = "0";

            testAppointment = new clsTestAppointment();
            testAppointment.LocalDrivingLicesenseApplicationID = _application.LocalDrivingLicenseApplicationID;
            testAppointment.PaidFees = _application.PaidFees;
            testAppointment.TestTypeID = 1;
            testAppointment.LocalDrivingLicesenseApplicationID = _application.LocalDrivingLicenseApplicationID;
            testAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            testAppointment.isLocked = false;
            testAppointment.AppointmentDate = dtDate.Value;


        }

        private void dtDate_ValueChanged(object sender, EventArgs e)
        {
            testAppointment.AppointmentDate = dtDate.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testAppointment.Save())
            {
                MessageBox.Show("Appointment Saved Successfully");
            }
            else {
                MessageBox.Show("Appointment Save Failed");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshHandler?.Invoke();
            this.Close();
        }
    }
}
