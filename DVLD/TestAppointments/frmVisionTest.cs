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
            clsTestAppointment testAppointment = new clsTestAppointment();
            
        }
    }
}
