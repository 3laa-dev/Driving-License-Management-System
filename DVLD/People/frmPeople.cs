using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBusinessLayer;
namespace DVLD
{


    
    public partial class frmPeople : Form
    {
      
        public frmPeople()
        {
            InitializeComponent();
          
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void refreshPage(object sender, EventArgs e) {
            updadateCountOfRecord();
            frmPeople_Load(sender, e);
        }
        

        private void updadateCountOfRecord() {
            countOfRecords.Text = (dataGridView1.RowCount).ToString();
        }   
        private void frmPeople_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Person.GetPeople();
            comboBox1.Items.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns) {
                comboBox1.Items.Add(column.Name);
            }
            comboBox1.SelectedIndex = 0;
            updadateCountOfRecord();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Person.GetPeople(comboBox1.Items[comboBox1.SelectedIndex].ToString() , textBox1.Text);
            updadateCountOfRecord();
        }

        

        private void cmsShowDetails_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString());
            Person person = Person.Find(id);
            frmPersonDetails frm = new frmPersonDetails(person);
            frm.ShowDialog();
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
           DialogResult result =  MessageBox.Show("Are You Sure", "User Will Be Deleted !!!", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString());
                Person.DeletePerson(id);
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                updadateCountOfRecord();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddNewUpdatePerson frm = new frmAddNewUpdatePerson();
            frm.refreshHandler += refreshPage;
            frm.ShowDialog();
        }

        private void cmsEdit_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value.ToString());
            frmAddNewUpdatePerson frm = new frmAddNewUpdatePerson(id);
            frm.refreshHandler += refreshPage;
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
