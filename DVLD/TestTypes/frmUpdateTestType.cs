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

namespace DVLD.TestTypes
{
    public partial class frmUpdateTestType : Form
    {
        clsTestType testType;
        frmManageTestTypes ParentForm;
        public frmUpdateTestType(clsTestType testType, frmManageTestTypes parentForm)
        {
            InitializeComponent();
            this.testType = testType;
            ParentForm = parentForm;
        }

        private void UpdateTestType_Load(object sender, EventArgs e)
        {
            lbID.Text = testType.TestTypeID.ToString();
            tbDescription.Text = testType.TestTypeDescription.ToString();   
            tbFees.Text = testType.TestFees.ToString();
            tbTitle.Text = testType.TestTypeTitle.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testType.TestTypeTitle = tbTitle.Text;
            testType.TestFees = Convert.ToDecimal(tbFees.Text);
            testType.TestTypeDescription = tbDescription.Text;
            if (testType.Save())
            {
                MessageBox.Show("Application Type Updated Successfully");
            };
            ParentForm.refreshPage();
        }
    }
}
