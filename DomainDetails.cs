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
    public partial class DomainDetails : Form
    {
        public static string key;
        public static DataTable KeyTable;
        private static string[] dtlst;
        private static string[] dtlst_cp;
        public DomainDetails()
        {
            InitializeComponent();
        }

        private void DomainDetails_Load(object sender, EventArgs e)
        {
             foreach (DataRow row in KeyTable.Rows)
            {
                dtlst = new string[] {
                        row["DomainName"].ToString(),
                        row["SyncType"].ToString(),
                        row["orderCycle"].ToString(),
                        row["lastInventoryTime"].ToString(),
                        row["SyncTypeNum"].ToString()
                };
            }
            dtlst_cp = (string[])dtlst.Clone();

            textBox1.Text = dtlst[2].ToString();
            for (int i = 0; i < dtlst.Length; i++) { Console.WriteLine(dtlst[i]);}
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            label5.Text = dtlst[0].ToString(); // DomainName
        }
        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            label6.Text = dtlst[3].ToString(); // lastinventorytime
        }

        private void radioButton1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(dtlst[4]);
            // local
            dtlst[4] = "1";
            Console.WriteLine(dtlst[4]);

            for (int i = 0; i < dtlst.Length; i++) { Console.WriteLine(dtlst[i]); }

        }

        private void radioButton2_MouseClick(object sender, MouseEventArgs e)
        {
            // Global
            Console.WriteLine(dtlst[4]);
            dtlst[4] = "2";
            Console.WriteLine(dtlst[4]);

            for (int i = 0; i < dtlst.Length; i++) { Console.WriteLine(dtlst[i]); }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtlst.Length; i++)
            {
                Console.WriteLine(dtlst[i]);
            }
            DataController.DomainListDetailsUpdate(dtlst);
            MessageBox.Show("Save");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in KeyTable.Rows)
            {
                dtlst = new string[] {
                        row["DomainName"].ToString(),
                        row["SyncType"].ToString(),
                        row["orderCycle"].ToString(),
                        row["lastInventoryTime"].ToString(),
                        row["SyncTypeNum"].ToString()
                };
            }
            for (int i = 0; i < dtlst.Length; i++) { Console.WriteLine(dtlst[i]); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtlst[2] = textBox1.Text;
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
