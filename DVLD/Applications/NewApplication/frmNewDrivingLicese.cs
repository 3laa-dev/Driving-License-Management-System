using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Auth;
using DVLDBusinessLayer;

namespace DVLD.Applications.NewApplication
{
    public partial class frmNewDrivingLicese : Form
    {
        public frmNewDrivingLicese()
        {
            InitializeComponent();
            this.person = null;
            this.app = null;
        }

        private void frmNewDrivingLicese_Load(object sender, EventArgs e)
        {
            
            DataTable dataTable = clsLicenseClass.GetAllLicenseClasses();
            

            cbLicenseClass.DataSource = dataTable;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
            cbLicenseClass.SelectedIndex = 2;

            tabControl1.TabPages[1].Enabled = false;
            

        }
        Person person;
        clsApplicationType app;
        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbLicenseClass.SelectedValue.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.person != null)
            {
                tabControl1.TabPages[1].Enabled = true;

                this.person = ctrlPersonCardWithFilter1.person;
                this.app = clsApplicationType.Find(1);

                lbApplicationDate.Text = DateTime.Now.ToString();
                lbApplicationFees.Text = app.Fees.ToString();
                lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
                tabControl1.SelectedIndex = 1;

                
            }
            else {
                MessageBox.Show("Please Select A Person");
                return;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!clsLocalDrivingLicenseApplication.
                    IsPersonRegisteredForLocalDrivingLicenseApplication
                    (ctrlPersonCardWithFilter1.person.PersonID , (int)cbLicenseClass.SelectedValue))
            {
                clsLocalDrivingLicenseApplication NewApp = new clsLocalDrivingLicenseApplication();
                NewApp.ApplicationPersonID = this.person.PersonID;
                NewApp.ApplicationDate = DateTime.Parse(lbApplicationDate.Text);
                NewApp.PaidFees = this.app.Fees;
                NewApp.ApplicationStatus = 0;
                NewApp.LicenseClassID = (int)cbLicenseClass.SelectedValue;
                NewApp.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                if (NewApp.Save())
                {
                    lbApplicationID.Text = NewApp.LocalDrivingLicenseApplicationID.ToString();
                }
                else
                {
                    MessageBox.Show("Process  failed");
                }
            }
            else
            {
                MessageBox.Show($@"Choose another License Class,
                                    the selected Person Already have an active
                                        application for the selected
                                 class with id={ctrlPersonCardWithFilter1.person.PersonID}");
            }

            

        }
    }
}
