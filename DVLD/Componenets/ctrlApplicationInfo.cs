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
    public partial class ctrlApplicationInfo : UserControl
    {
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        public void loadApplication(clsApplication application) { 
            lbID.Text = application.ApplicationID.ToString();
            lbFees.Text = application.PaidFees.ToString();
            lbStatus.Text = application.ApplicationStatus.ToString();
            lbAplicant.Text = application.ApplicationPersonID.ToString();
            lbAplicant.Text = application.Person.FirstName + " " + application.Person.LastName;
            lbDate.Text = application.ApplicationDate.ToString();
            lbStatusDate.Text = application.LastStatusDate.ToString();
            lbCreatedBy.Text = application.User.UserName;
        }
    }
}
