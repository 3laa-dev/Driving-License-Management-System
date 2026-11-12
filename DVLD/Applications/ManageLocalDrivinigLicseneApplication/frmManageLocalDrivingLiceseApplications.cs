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

namespace DVLD.Applications.ManageLocalDrivinigLicseneApplication
{
    public partial class frmManageLocalDrivingLiceseApplications : Form
    {
        public frmManageLocalDrivingLiceseApplications()
        {
            InitializeComponent();
        }

        private void frmManageLocalDrivingLiceseApplications_Load(object sender, EventArgs e)
        {
            DataTable dataTable = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplication();
            dataGridView1.DataSource = dataTable;

            foreach (DataColumn col in dataTable.Columns) {
                comboBox1.Items.Add(col.ToString());
            }
        }
    }
}
