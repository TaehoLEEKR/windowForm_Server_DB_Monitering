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
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = DataController.ServerList();

            DataTable dt = new DataTable();
            dt = ds.Tables["[adPWDSync].[dbo].[adPWD_Servers]"];

            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string key = dataGridView1.CurrentRow.Cells["ServerName"].Value.ToString();
            string key2 = dataGridView1.CurrentRow.Cells["ServerIP"].Value.ToString();
            DataSet ds = new DataSet();
            ds = DataController.ServerDetails(key,key2);

            DataTable dt = new DataTable();
            dt = ds.Tables["[adPWDSync].[dbo].[adPWD_Servers]"];


            if (e != null)
            {
                ServerDetails.key = key;
                ServerDetails sd = new ServerDetails();
                ServerDetails.KeyTable = dt;
                sd.Show();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = DataController.ServerList();

            DataTable dt = new DataTable();
            dt = ds.Tables["[adPWDSync].[dbo].[adPWD_Servers]"];

            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
        }
    }
}
