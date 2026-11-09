using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public delegate void refreshHandler(object sender, EventArgs e);
    
    public partial class frmAddNewUpdatePerson : Form
    {
        enMode Mode;
        Person person ;

        public frmAddNewUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
            person = new Person();
        }

        public frmAddNewUpdatePerson(int PersonID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            person = Person.Find(PersonID);
            fillDataToForm(person);
            label1.Text = $"Update Person ID:{PersonID}";
        }
        public event refreshHandler refreshHandler;

        void fillDataToForm(Person person) { 
            ctrlAddNewUpdatePerson1.NationalNo = person.NationalNO;
            ctrlAddNewUpdatePerson1.FirstName = person.FirstName;
            ctrlAddNewUpdatePerson1.LastName = person.LastName;
            ctrlAddNewUpdatePerson1.SecondName = person.SecondName;
            ctrlAddNewUpdatePerson1.ThirdName = person.ThirdName;
            ctrlAddNewUpdatePerson1.Gender = person.Gender;
            ctrlAddNewUpdatePerson1.Email = person.Email;
            ctrlAddNewUpdatePerson1.BirthOfDate = person.DateOfBirth;
            ctrlAddNewUpdatePerson1.Address = person.Address;
            ctrlAddNewUpdatePerson1.Email = person.Email;
            ctrlAddNewUpdatePerson1.Phone = person.Phone;
            ctrlAddNewUpdatePerson1.Pictrue = person.ImagePath;
            ctrlAddNewUpdatePerson1.Country = person.NationalityCountryID;
        }


        private void frmAddNewUpdatePerson_Load(object sender, EventArgs e)
        {

        }
        

        public void onClickSaveButton(object sender, EventArgs e) { 

            person.NationalNO = ctrlAddNewUpdatePerson1.NationalNo;
            person.FirstName = ctrlAddNewUpdatePerson1.FirstName;
            person.LastName = ctrlAddNewUpdatePerson1.LastName;
            person.SecondName = ctrlAddNewUpdatePerson1.SecondName;
            person.ThirdName = ctrlAddNewUpdatePerson1.ThirdName;
            person.Gender = ctrlAddNewUpdatePerson1.Gender;
            person.Address = ctrlAddNewUpdatePerson1.Address;
            person.Email = ctrlAddNewUpdatePerson1.Email;
            person.DateOfBirth = ctrlAddNewUpdatePerson1.BirthOfDate;
            person.NationalityCountryID = ctrlAddNewUpdatePerson1.Country;
            person.Phone = ctrlAddNewUpdatePerson1.Phone;
            // person.ImagePath = ctrlAddNewUpdatePerson1.Pictrue;
            string imagePath = ctrlAddNewUpdatePerson1.Pictrue;
            if (imagePath != person.ImagePath && imagePath != null)
            {
                
                if (clsUtil.CopyImageToProjectImagesFolder(ref imagePath))
                {
                    ctrlAddNewUpdatePerson1.Pictrue = imagePath;
                    person.ImagePath = ctrlAddNewUpdatePerson1.Pictrue;
                    
                }
                else
                {
                    MessageBox.Show("Error in file uploading");
                    return;
                }
            }

            
            if (person.Save()) {
                MessageBox.Show("Saved");
                refreshHandler?.Invoke( sender,  e);
                this.Close();
           
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onClickSaveButton( sender,  e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
