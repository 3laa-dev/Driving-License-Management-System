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

namespace DVLD.Componenets
{
    public partial class ctrlLocalDrivingLicesnseApplication : UserControl
    {
        public ctrlLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
        }

        public void loadLocalDrivingLiceseApplication(clsLocalDrivingLicenseApplication application) {
            lbID.Text = application.ApplicationID.ToString();
            lbClass.Text = application.LicenseClassID.ToString();
            lbPassedTests.Text = $"{clsTest.CountOfPassedTests(application.Person)}/3";
            ctrlApplicationInfo1.loadApplication(application);    
        }

        private void ctrlLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {

        }
    }
}
