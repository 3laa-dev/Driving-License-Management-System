
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
    public partial class ctrlAddNewUpdatePerson : UserControl
    {
        string _imagePath;
        int _selectedValue;
        public string NationalNo
        {
            set
            {
                tbNationalNo.Text = value;
            }
            get
            {
                return tbNationalNo.Text;
            }
        }
        public string FirstName
        {
            set
            {
                tbFirstName.Text = value;
            }
            get
            {
                return tbFirstName.Text;
            }
        }
        public string LastName
        {
            set
            {
                tbLastName.Text = value;
            }
            get
            {
                return tbLastName.Text;
            }
        }
        public string SecondName
        {
            set
            {
                tbSecondName.Text = value;
            }
            get
            {
                return tbSecondName.Text;
            }
        }
        public string ThirdName
        {
            set
            {
                tbThirdName.Text = value;
            }
            get
            {
                return tbThirdName.Text;
            }
        }
        public string Gender
        {
            set
            {
                if (value == "Male")
                {
                    radioButton2.Checked = true;
                }
                else {
                    radioButton3.Checked = true ;
                }
            }
            get
            {
                return (radioButton2.Checked) ? "Male" : "Female";
            }
        }
        public string Email
        {
            set
            {
                tbEmail.Text = value;
            }
            get
            {
                return tbEmail.Text;
            }
        }
        public string Phone
        {
            set
            {
                tbPhone.Text = value;
            }
            get
            {
                return tbPhone.Text;
            }
        }
        public string Address
        {
            set
            {
                tbAddress.Text = value;
            }
            get
            {
                return tbAddress.Text;
            }
        }
        public DateTime BirthOfDate
        {
            set { 
                dateTimePicker1.Value = value;
            }
            get { 
                return dateTimePicker1.Value;
            }

        }
        public int Country
        {
            get
            {
                return Convert.ToInt32(comboBox1.SelectedValue);
            }
            set
            {
                _selectedValue = value;
            }
            
        }

        public string Pictrue {
            set {
                if (!String.IsNullOrEmpty(value)) {
                    pictureBox7.Image = Image.FromFile(value);
                    _imagePath = value;
                }
            }
            get { 
                    return _imagePath;
                }
        }

       
        public ctrlAddNewUpdatePerson()
        {
            InitializeComponent();
        }

        private void ctrlAddNewUpdatePerson_Load(object sender, EventArgs e)
        {
            DataTable dt = clsCountry.GetAllCountries();
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "CountryName";
            comboBox1.ValueMember = "CountryID";
            comboBox1.SelectedValue = _selectedValue;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select Person Image";
            openFileDialog.Filter =
                "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _imagePath = openFileDialog.FileName;
                pictureBox7.Image = Image.FromFile(_imagePath);
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        
    }
}
