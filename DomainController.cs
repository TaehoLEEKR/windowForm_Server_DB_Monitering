using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DomainController : Form
    {
        public DomainController()
        {
            InitializeComponent();
        }

        
        private void DomainController_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = DataController.DomainControllerList();

            DataTable dt = new DataTable();
            dt = ds.Tables["[adPWDSync].[dbo].[adPWD_DomainController]"];

            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string key = dataGridView1.CurrentRow.Cells["DomainName"].Value.ToString();
            DataSet ds = new DataSet();
            ds = DataController.DomainControllerSetting(key);

            DataTable dt = new DataTable();
            dt = ds.Tables["[adPWDSync].[dbo].[adPWD_DomainController]"];


            if (e != null)
            {
                DomainControllerSetting dcs = new DomainControllerSetting();
                DomainControllerSetting.KeyTable = dt;
                dcs.Show();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = DataController.DomainControllerList();

            DataTable dt = new DataTable();
            dt = ds.Tables["[adPWDSync].[dbo].[adPWD_DomainController]"];

            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
        }
    }
}
