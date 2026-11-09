using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;

namespace DVLD.Applications.NewApplication
{
    public partial class frmNewDrivingLicese : Form
    {
        public frmNewDrivingLicese()
        {
            InitializeComponent();
        }

        private void frmNewDrivingLicese_Load(object sender, EventArgs e)
        {

            DataTable dataTable = clsLicenseClass.GetAllLicenseClasses();
            

            cbLicenseClass.DataSource = dataTable;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            cbLicenseClass.SelectedIndex = 3;
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cbLicenseClass.SelectedValue.ToString());
        }
    }
}
