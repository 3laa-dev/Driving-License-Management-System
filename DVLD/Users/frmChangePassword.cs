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

namespace DVLD.Users
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword(clsUser User)
        {
            InitializeComponent();
            this.User = User;
        }
        clsUser User;
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.loadUser(this.User);  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbNewPassword.Text == tbNewPassword.Text)
            {
                if (User.ChangePassword(tbCurrentPassword.Text, tbNewPassword.Text))
                    MessageBox.Show("Password Has Changed Successfully");
                else
                    MessageBox.Show("Password Change Filled");

            }
            else {
                MessageBox.Show("Confirm Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
