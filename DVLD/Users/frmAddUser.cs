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
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            tabControl1.TabPages[1].Enabled = false;
        }
        public frmAddUser(clsUser User) {
            InitializeComponent();
            this.person = Person.Find(User.PersonID);
            this.User = User;
            Mode = enMode.Update;
            ctrlPersonCardWithFilter1.loadPerson(this.person);
            lbUserID.Text = User.UserID.ToString();
            tbPassword.Text = "********";
            tbConfPass.Text = "********";
            tbConfPass.Enabled = false;
            tbPassword.Enabled = false;
            cbIsActive.Checked = User.isActive;
            tbUserName.Text = User.UserName;


        }

        enMode Mode;
        Person person { set; get; }
        clsUser User { set; get; }

        private void ctrlPersonCardWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.person != null)
            {
                this.person = ctrlPersonCardWithFilter1.person;
                if (clsUser.isUser(this.person.PersonID))
                    MessageBox.Show("This person allready user");
                else
                {
                    tabControl1.SelectedIndex = 1;
                    tabControl1.TabPages[1].Enabled = true;
                }
            }
            else
                MessageBox.Show("Please select person");
        }


        private void ctrlPersonCardWithFilter1_Load_1(object sender, EventArgs e)
        {

        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            User.UserName = tbUserName.Text;
            User.isActive = cbIsActive.Checked;
            if (tbPassword.Text != tbConfPass.Text)
            {
                MessageBox.Show("Confirm Password");
                return;
            }
            else {
                User.Password = tbPassword.Text;
            }
            User.PersonID = this.person.PersonID;
            if (User.Save())
            {
                MessageBox.Show("Save Successed");
                lbUserID.Text = User.UserID.ToString();
            }
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
