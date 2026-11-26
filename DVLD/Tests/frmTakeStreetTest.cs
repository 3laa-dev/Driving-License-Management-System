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

namespace DVLD.Tests
{
    public partial class frmTakeStreetTest : Form
    {
        clsTestAppointment _appointment;
        bool Result = true;
        string Notes;
        clsTest Test;
        public event RefreshHandler refreshHandler;
        public frmTakeStreetTest(clsTestAppointment appointment)
        {

            InitializeComponent();
            _appointment = appointment;
            Test = new clsTest();
        }

        private void frmTakeStreetTest_Load(object sender, EventArgs e)
        {
            lbID.Text = _appointment.LocalDrivingLicesenseApplicationID.ToString();
            LbFullName.Text = (_appointment.LocalDrivingLicenseApplication.Person.FullName);
            lbClass.Text = _appointment.LocalDrivingLicenseApplication.Type.Title;
            lbFees.Text = _appointment.PaidFees.ToString();
            lbTrail.Text = "0";
            lbDate.Text = _appointment.AppointmentDate.ToString();
            this.Notes = string.Empty;

            Test.TestAppointmentID = _appointment.TestAppointmentID;
            Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Result = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Result = false;
        }

        private void tbNotes_TextChanged(object sender, EventArgs e)
        {
            this.Notes = tbNotes.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test.Notes = this.Notes;
            Test.TestResult = this.Result;
            if (!_appointment.isLocked && Test.Save())
            {
                MessageBox.Show("Test Saved Successfully");
            }
            else
            {
                MessageBox.Show("Test Save Failed");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.refreshHandler?.Invoke();
            this.Close();
        }
        
        
    }
}
