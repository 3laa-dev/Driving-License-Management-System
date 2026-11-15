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
            lbID.Text = application.ApplicationID;
            lbClass.Text = application.LicenseClass;
            ctrlApplicationInfo1.loadApplication(application);    
        }
    }
}
