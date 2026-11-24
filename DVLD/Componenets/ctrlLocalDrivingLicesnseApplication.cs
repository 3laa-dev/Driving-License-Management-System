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

namespace DVLD.Componenets
{
    public partial class ctrlLocalDrivingLicesnseApplication : UserControl
    {
        public ctrlLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
        }
        
        public int PassedTests { set; get; }
        public void loadLocalDrivingLiceseApplication(clsLocalDrivingLicenseApplication application) {
            lbID.Text = application.ApplicationID.ToString();
            lbClass.Text = application.LicenseClassID.ToString();
            PassedTests = clsTest.CountOfPassedTests(application.Person.PersonID, application.ApplicationID );
            lbPassedTests.Text = $"{PassedTests}/3";
            ctrlApplicationInfo1.loadApplication(application);    
        }

       
    }
}
