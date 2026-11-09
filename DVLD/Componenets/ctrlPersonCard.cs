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
namespace DVLD
{
    public partial class ctrlPersonCard : UserControl
    {
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
            
        }

        public void loadPerson(Person person) { 
            lbID.Text = person.PersonID.ToString();
            lbName.Text = $"{person.FirstName} {person.LastName} {person.ThirdName} {person.LastName}";
            lbNationalNo.Text = person.NationalNO;
            lbEmail.Text = person.Email;
            lbPhone.Text = person.Phone;
            lbDataOfBirth.Text = $"{person.DateOfBirth.Day}-{person.DateOfBirth.Month}-{person.DateOfBirth.Year}" ;
            lbAddress.Text = person.Address;
            lbCountry.Text = clsCountry.GetCountryID(person.NationalityCountryID).CountryName;
            llbGender.Text = person.Gender;
            if (person.ImagePath != null && person.ImagePath != "")
            {
                pictureBox1.Image = Image.FromFile(person.ImagePath);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
