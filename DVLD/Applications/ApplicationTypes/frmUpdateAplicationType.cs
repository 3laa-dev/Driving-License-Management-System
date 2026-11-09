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

namespace DVLD.Applications.ApplicationTypes
{
    public partial class frmUpdateAplicationType : Form
    {
        clsApplicationType ApplicationType;
        frmManageApplicationTypes ParentForm;
        public frmUpdateAplicationType(clsApplicationType ApplicationType , frmManageApplicationTypes form)
        {
            InitializeComponent();
            this.ApplicationType = ApplicationType;
            this.ParentForm = form;
        }

        private void frmUpdateAplicationType_Load(object sender, EventArgs e)
        {
            lbID.Text = ApplicationType.ApplicationTypeID.ToString();
            tbFees.Text = ApplicationType.Fees.ToString();
            tbTitle.Text = ApplicationType.Title.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)

        {
            ApplicationType.Title = tbTitle.Text;
            ApplicationType.Fees = Convert.ToDecimal(tbFees.Text);
            if (ApplicationType.Save()) {
                MessageBox.Show("Application Type Updated Successfully");
            };
           ParentForm.refreshPage();
        }
    }
}
