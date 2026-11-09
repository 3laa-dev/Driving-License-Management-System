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
using DVLD.Auth;
using DVLDBusinessLayer;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            _DataHasChanged = false;
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        bool _LoadedUserData;
        bool _DataHasChanged;
        
        void loadUserDataToFile(string UserName, string Password)
        {
            string directoryPath = @"C:\DVLD-SYSTEM-USER-DATA";

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "UserData.txt");

            File.WriteAllText(filePath, UserName);
            File.AppendAllText(filePath, $"\n{Password}");
        }
        bool getUserDataFromFile(out string UserName, out string Password)
        {
            string path = @"C:\DVLD-SYSTEM-USER-DATA\UserData.txt";

            UserName = null;
            Password = null;

            if (!File.Exists(path))
                return false;

            string[] lines = File.ReadAllLines(path);

            if (lines.Length < 2)
                return false;

            UserName = lines[0];
            Password = lines[1];

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.UserName = tbUserName.Text;
            this.Password = tbPassword.Text;

            if (!string.IsNullOrEmpty(this.UserName)
                &&
                !string.IsNullOrEmpty(this.Password)
                )
            {
                clsUser user = clsUser.Find(this.UserName, Password);
                if (user == null)
                {
                    MessageBox.Show("UserName Or Password invaled");
                    return;
                }
                if (!user.isActive) {
                    MessageBox.Show("Your account isn't active");
                    return;
                }
                else
                {
                    if (checkBox2.Checked && (!_LoadedUserData || _DataHasChanged))
                    {
                        loadUserDataToFile(this.UserName, this.Password);
                    }
                    if (!checkBox2.Checked)
                    {
                        loadUserDataToFile("", "");
                    }

                    this.Hide();
                    clsGlobal.CurrentUser = user;
                    frmHomePage homePage = new frmHomePage(this);
                    homePage.ShowDialog();
                    
                }

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName , Password; 
            _LoadedUserData =  getUserDataFromFile(out UserName,out  Password);
            checkBox2.Checked = _LoadedUserData;

            this.UserName=UserName;
            this.Password=Password;
            tbPassword.Text = Password;
            tbUserName.Text = UserName;
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            _DataHasChanged = true;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            _DataHasChanged = true;
        }
    }
}
