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
    public partial class ServerDetails : Form
    {
        public static string key;
        public static DataTable KeyTable;
        private static string[] dtlst;
        public ServerDetails()
        {
            InitializeComponent();
        }

        private void ServerDetails_Load(object sender, EventArgs e)
        {
            foreach (DataRow row in KeyTable.Rows)
            {
                dtlst = new string[] {
                        row["ServerName"].ToString(),
                        row["ServerIP"].ToString(),
                        row["ServerPort"].ToString(),
                        row["lastInventoryTime"].ToString(),
                        row["InBoundCycle"].ToString(),
                        row["InBoundTime"].ToString(),
                        row["OutBoundTime"].ToString(),
                        row["OutBoundFailCnt"].ToString(),
                };
                
            }
            for (int i = 0; i < dtlst.Length; i++) { Console.WriteLine(dtlst[i]); }
            textBox1.Text = dtlst[0].ToString();
            textBox2.Text = dtlst[1].ToString();
            textBox3.Text = dtlst[2].ToString();
            textBox4.Text = dtlst[4].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtlst[0] = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dtlst[1] = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dtlst[2] = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dtlst[4] = textBox4.Text;
        }
        private void panel11_Paint(object sender, PaintEventArgs e)
        {
            label9.Text = dtlst[3].ToString();
        }
        private void panel12_Paint(object sender, PaintEventArgs e)
        {
            label10.Text = dtlst[5].ToString();
        }
        
        private void label10_Paint(object sender, PaintEventArgs e)
        {
            label10.Text = dtlst[5].ToString();
        }

        private void label11_Paint(object sender, PaintEventArgs e)
        {
            label11.Text = dtlst[6].ToString();
        }

        private void label12_Paint(object sender, PaintEventArgs e)
        {
            label12.Text = dtlst[7].ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtlst.Length; i++)
            {
                Console.WriteLine(dtlst[i]);
            }
            DataController.ServerList_Update(dtlst,key);
            MessageBox.Show("Save");
            this.Close();
        }
    }
}
