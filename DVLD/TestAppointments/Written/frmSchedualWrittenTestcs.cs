using DVLD.Auth;
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
    public partial class frmSchedualWrittenTestcs : Form
    {
        enum enTestMode { NormalTest, RetakeTest }

        enTestMode Mode;
        public event RefreshPageHandler refreshHandler;
        clsTestAppointment testAppointment;
        clsLocalDrivingLicenseApplication _application;
        clsApplication RetakeTestApplication;
        public frmSchedualWrittenTestcs(clsLocalDrivingLicenseApplication application)
        {
            InitializeComponent();
            _application = application;
            this.Mode = enTestMode.NormalTest;
        }

        public frmSchedualWrittenTestcs(clsLocalDrivingLicenseApplication application, clsApplication RetakeTestApplication)
        {
            InitializeComponent();
            _application = application;
            this.Mode = enTestMode.RetakeTest;
            this.RetakeTestApplication = RetakeTestApplication;

        }

        private void frmSchedualWrittenTestcs_Load(object sender, EventArgs e)
        {
            lbID.Text = _application.LocalDrivingLicenseApplicationID.ToString();
            LbFullName.Text = _application.Person.FullName;
            lbClass.Text = _application.Type.Title;
            lbFees.Text = _application.PaidFees.ToString();
            lbTotalFees.Text = _application.PaidFees.ToString();
            lbTrail.Text = "0";
            if (this.Mode == enTestMode.RetakeTest)
            {
                lbTilte.Text = "ReTake Test";
                lbTotalFees.Text = $"{_application.PaidFees + RetakeTestApplication.PaidFees}";
                lbRtestFees.Text = RetakeTestApplication.PaidFees.ToString();
                groupBox1.Enabled = true;
            }
            testAppointment = new clsTestAppointment();
            testAppointment.LocalDrivingLicesenseApplicationID = _application.LocalDrivingLicenseApplicationID;
            testAppointment.PaidFees = _application.PaidFees;
            testAppointment.TestTypeID = 2;
            testAppointment.LocalDrivingLicesenseApplicationID = _application.LocalDrivingLicenseApplicationID;
            testAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            testAppointment.isLocked = false;
            testAppointment.AppointmentDate = dtDate.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testAppointment.Save())
            {
                MessageBox.Show("Appointment Saved Successfully");
                if (this.Mode == enTestMode.RetakeTest)
                {
                    lbRTestID.Text = RetakeTestApplication.ApplicationID.ToString();

                }
            }
            else
            {
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
