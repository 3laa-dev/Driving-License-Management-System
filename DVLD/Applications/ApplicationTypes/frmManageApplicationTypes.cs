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

namespace DVLD.Applications.ApplicationTypes
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            DataTable dt = clsApplicationType.GetAllApplicationTypes();
            dt.Columns[0].ColumnName = "ID";
            dataGridView1.DataSource = dt;
            
            countOfRecords.Text = dataGridView1.Rows.Count.ToString();
        }
        public void refreshPage() {
            DataTable dt = clsApplicationType.GetAllApplicationTypes();
            dt.Columns[0].ColumnName = "ID";
            dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            
            clsApplicationType appType = clsApplicationType.Find(id);
            if (appType != null) {
                new frmUpdateAplicationType(appType , this).ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
