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
    public partial class ctrlUserCard : UserControl
    {
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void loadUser(clsUser User) {
            ctrlPersonCard1.loadPerson(User.Person);
            lbUserID.Text = User.UserID.ToString();
            lbUserName.Text = User.UserName;
            lbIsActive.Text = (User.isActive) ? "Yes" : "No";
        }
        private void ctrlUserCard_Load(object sender, EventArgs e)
        {

        }
    }
}
