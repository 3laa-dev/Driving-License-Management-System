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

namespace DVLD.Users
{
    public partial class frmUserDetails : Form
    {
        public frmUserDetails(clsUser user)
        {
            InitializeComponent();
            this.User = user;

        }
        clsUser User;
        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.loadUser(this.User);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
