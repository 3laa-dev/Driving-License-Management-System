using DVLD.Applications.ApplicationTypes;
using DVLD.Applications.ManageLocalDrivinigLicseneApplication;
using DVLD.Applications.NewApplication;
using DVLD.Auth;
using DVLD.TestTypes;
using DVLD.Users;
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

namespace DVLD
{
    public partial class frmHomePage : Form
    {
        frmLogin LoginForm;
        public frmHomePage(frmLogin LoginForm)
        {
            InitializeComponent();
            this.LoginForm = LoginForm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeople frm = new frmPeople();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void applicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUser().ShowDialog();
        }

        private void logAutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            this.LoginForm.Show();
            this.Close();
        }

        private void inProccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmUserDetails(clsGlobal.CurrentUser).ShowDialog();
        }

        private void inProccessToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmChangePassword(clsGlobal.CurrentUser).ShowDialog();
        }

        private void frmHomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGlobal.CurrentUser = null;
            this.LoginForm.Show();
        }

        private void inProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageApplicationTypes().ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmManageTestTypes().ShowDialog();  
        }

        private void localDrivingLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new frmNewDrivingLicese().ShowDialog();
        }

        private void localDrivingLicesnseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmManageLocalDrivingLiceseApplications().ShowDialog();
        }
    }
}
