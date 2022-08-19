using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using AppConfiguration;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Monitering : Form
    {

        /// <summary>
        ///  Panel , imageList 크기 조정
        /// </summary>
        /// <param name="nLeftRect"></param>
        /// <param name="nTopRect"></param>
        /// <param name="nRightRect"></param>
        /// <param name="nBottomRect"></param>
        /// <param name="nWidthEllipse"></param>
        /// <param name="nHeightEllipse"></param>
        /// <returns></returns>
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


       

        /// <summary>
        /// 첫 화면
        /// </summary>
        public Monitering()
        {
            InitializeComponent();
        }

        private void Monitering_Load(object sender, EventArgs e)
        {
            string[] lst1 = { };
            string[] lst2 = { };


            ListViewItem lvi = new ListViewItem();
            ListViewItem lvi2 = new ListViewItem();


            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.None;
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            SetHeight(listView2, 50);

            listView2.View = View.Details;
            listView2.HeaderStyle = ColumnHeaderStyle.None;
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView2.Columns[0].Width = 130;
            listView2.Columns[1].Width = -2;

            DataSet ds = new DataSet();
            ds = DataController.DomainList(1);

            DataTable dt = new DataTable();
            dt = ds.Tables["[adPWDSync].[dbo].[adPWD_Domains]"];

            DataSet ds2 = new DataSet();
            ds2 = DataController.ServerCheck();

            DataTable dt2 = new DataTable();
            dt2 = ds2.Tables["[adPWDSync].[dbo].[adPWD_Servers]"];



            for (int i =0; i<dt.Rows.Count; i++)
            {
                foreach(DataTable row in ds.Tables)
                {
                    lst1 = new string[] { row.Rows[i]["DomainName"].ToString(), row.Rows[i]["cnt"].ToString(), row.Rows[i]["SyncType"].ToString() };

                }
                lvi = new ListViewItem(lst1);
                listView1.Items.Add(lvi);
            }

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                foreach (DataTable row in ds2.Tables)
                {
                    lst2 = new string[] { row.Rows[i]["ServerName"].ToString(), row.Rows[i]["chk"].ToString() };
                }
                lvi2 = new ListViewItem(lst2);
                listView2.Items.Add(lvi2);
            }
            


        }
        /// <summary>
        /// Panel 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 20, 20));
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));

        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 20, 20));
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            panel5.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 20, 20));
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            panel6.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 20, 20));
        }

        // Data List 
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                //int SelectRow = listView1.SelectedItems[0].Index;
                //string a = listView1.Items[SelectRow].SubItems[0].Text;


                int SelectRow = listView1.SelectedItems[0].Index;
                string strs = listView1.Items[SelectRow].SubItems[0].Text;
                //Console.WriteLine(strs);

                DataSet ds = new DataSet();
                ds = DataController.DomainList(strs);

                DataTable dt = new DataTable();
                dt = ds.Tables["[adPWDSync].[dbo].[adPWD_DomainController]"];

                dataGridView1.DataSource = dt;
                dataGridView1.ReadOnly = true;
                Console.WriteLine(dataGridView1.Rows[0].Cells[1].Value.ToString());

                if (dataGridView1.Rows[0].Cells[1].Value.ToString().Equals("Success"))
                {
                    dataGridView1.Rows[0].Cells[1].Style.ForeColor = Color.Black;
                }
                else
                {
                    dataGridView1.Rows[0].Cells[1].Style.ForeColor = Color.Red;
                }
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            }
        }


    }
}
