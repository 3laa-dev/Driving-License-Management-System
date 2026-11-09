using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.ApplicationTypes;
using DVLDBusinessLayer;

namespace DVLD.TestTypes
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsTestType.GetAllTestTypes();

            countOfRecords.Text = dataGridView1.RowCount.ToString();

        }
        public void refreshPage()
        {
            DataTable dt = clsTestType.GetAllTestTypes();
            dt.Columns[0].ColumnName = "ID";
            dataGridView1.DataSource = dt;
        }
        private void edToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            clsTestType TestType = clsTestType.Find(id);
            if (TestType != null)
            {
                new frmUpdateTestType(TestType, this).ShowDialog();
            }
        }
    }
}
