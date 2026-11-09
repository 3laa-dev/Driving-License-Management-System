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
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
            
        }
        public Person person { set; get; }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbSearhcWith.Items.Add("PersonID");
            cbSearhcWith.Items.Add("NationalNO");
            cbSearhcWith.SelectedIndex = 0;
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            if (person != null)
            {
                if (clsUser.isUser(this.person.PersonID))
                {
                    MessageBox.Show($"Allready {person.FirstName} is user");
                }
                else {
                    MessageBox.Show("is not user");

                }
            }
            else {
                MessageBox.Show("Please Select A Person");
            }
        }
        public void loadPerson(Person person) { 
            lbFilterBy.Enabled = false;
            cbSearhcWith.Enabled = false;
            tbSeacrhWord.Enabled = false;
            btnAddNew.Enabled = false;
            btnSearch.Enabled = false;
            ctrlPersonCard1.loadPerson(person);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cbSearhcWith.Items[cbSearhcWith.SelectedIndex].ToString() == "PersonID")
            {
                int PersonID = -1;
                try
                {
                    PersonID = Convert.ToInt32(tbSeacrhWord.Text);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("ID must not contain letters");
                    return;
                }
                if (PersonID != -1)
                    this.person = Person.Find(PersonID);
                
            }
            else if (cbSearhcWith.Items[cbSearhcWith.SelectedIndex].ToString() == "NationalNO") { 
                this.person = Person.Find(tbSeacrhWord.Text);
            }
            if (this.person != null)
                ctrlPersonCard1.loadPerson(this.person);
            else
                MessageBox.Show("This Person not found");

        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            new frmAddNewUpdatePerson().ShowDialog();
        }
    }
}
