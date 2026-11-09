using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Users;
using DVLDBusinessLayer;

namespace DVLD
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }

        private void updadateCountOfRecord()
        {
            countOfRecords.Text = (dataGridView1.RowCount).ToString();
        }
        private void frmUser_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsUser.GetAllUsers();
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn item in dataGridView1.Columns )
            {
                    comboBox1.Items.Add( item.Name );
            }
            updadateCountOfRecord();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = clsUser.GetAllUsers(comboBox1.Items[comboBox1.SelectedIndex].ToString(), textBox1.Text);
            updadateCountOfRecord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmAddUser().ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Are You Sure", "User Will Be Deleted !!!", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString()); 
                clsUser.DeleteUser(id);
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                updadateCountOfRecord();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 4)
            {
                textBox1.Visible = false;
                comboBox2.Visible = true;
            }
            else {
                textBox1.Visible = true;
                comboBox2.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Yes")
            {
                dataGridView1.DataSource = clsUser.GetAllUsers("isActive", "1");
            }
            else if (comboBox2.SelectedItem.ToString() == "No")
            {
                dataGridView1.DataSource = clsUser.GetAllUsers("isActive", "0");
            }
            else {
                dataGridView1.DataSource = clsUser.GetAllUsers();
            }

            updadateCountOfRecord();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString());

            clsUser user = clsUser.Find(userID);
            new frmAddUser(user).ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString());
            new frmChangePassword(clsUser.Find(userID)).ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value.ToString());
            new frmUserDetails(clsUser.Find(userID)).ShowDialog();
        }
    }
}
