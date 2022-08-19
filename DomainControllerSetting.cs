using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class DomainControllerSetting : Form
    {
        public static string key;
        public static DataTable KeyTable;
        DomainController dc1;
        private static string[] dtlst;


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
          (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        private void SetHeight(ListView LV, int height)
        {      // listView 높이 지정      
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            LV.SmallImageList = imgList;
        }

        [DllImport("user32.dll")]
        public static extern bool ShowScrollBar(System.IntPtr hWnd, int wBar, bool bShow);
        private const uint SB_HORZ = 0;
        private const uint SB_VERT = 1;
        private const uint ESB_ENABLE_BOTH = 0x3;

        public DomainControllerSetting()
        {
            InitializeComponent();
        }

        private void DomainControllerSetting_Load(object sender, EventArgs e)
        {
            
            Console.WriteLine(key);
            foreach (DataRow row in KeyTable.Rows)
            {
                //Console.WriteLine(row["DomainName"].ToString() + row["DC IP"].ToString());
                dtlst = new string[] {
                    row["DomainName"].ToString(),
                    row["DC Name"].ToString(),
                    row["DC IP"].ToString(),
                    row[" PWDManager Server IP"].ToString(),
                    row["Hearbeat Cycle(inbound) / Sec"].ToString(),
                    row["Hearbeat Cycle(outbound) / Sec"].ToString(),
                    row["Hearbeat Time(inbound) / Sec"].ToString(),
                    row["Hearbeat Tiime(outbound) / Sec"].ToString(),
                    row["Heartbeat Fail Count "].ToString(),
                    row["version"].ToString()
                };
                comboBox1.Items.Add(row[" PWDManager Server IP"].ToString());
            }
            //for (int i = 0; i < dtlst.Length; i++) { Console.WriteLine(dtlst[i]); }
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox1.Text = dtlst[4].ToString();
            textBox2.Text = dtlst[5].ToString();
        }
#region 판넬
        private void panel19_Paint(object sender, PaintEventArgs e)
        {
            label11.Text = dtlst[0].ToString(); // DomainName
            
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {
            label12.Text = dtlst[1].ToString(); // DC Name
        }

        private void panel21_Paint(object sender, PaintEventArgs e)
        {
            label13.Text = dtlst[2].ToString(); //  DC IP
        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            label14.Text = dtlst[6].ToString(); // HT(in)
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            label15.Text = dtlst[7].ToString();//HT(out)
        }

        private void panel15_Paint(object sender, PaintEventArgs e)
        {
            label16.Text = dtlst[8].ToString(); //(HFC)
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {
            label17.Text = dtlst[9].ToString();//version
        }
#endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            dtlst[4] = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dtlst[5] = textBox2.Text;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtlst.Length; i++)
            {
                Console.WriteLine(dtlst[i]);
            }
            DataController.DomainControllerSetting_Update(dtlst);
            MessageBox.Show("Save");
            this.Close();
        }

        private void Save_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel1.Height, 15, 15));
        }
    }
}
