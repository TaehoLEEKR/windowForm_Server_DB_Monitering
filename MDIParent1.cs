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
    public partial class MDIParent1 : Form
    {
        private int childFormNumber = 0;
        private static DomainController dc = null;
        private static MainForm mainform = null;
        private static Monitering moniter = null;
        private static Domain domain = null;
        private static Server sv = null;



        public MDIParent1()
        {
            
            InitializeComponent();
            this.Load += new EventHandler(MDIParent1_Load);
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new MainForm();
            childForm.MdiParent = this;
            childForm.Text = "MainForm" + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void MDIParent1_Load_1(object sender, EventArgs e)
        {

        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            try
            {
                if (moniter == null)
                {
                    moniter = new Monitering();
                    moniter.MdiParent = this;
                    moniter.Show();
                }
            //mainform.MdiParent = this;
            //mainform.Show();
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void menuForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (dc == null)
                {
                    dc = new DomainController();
                    dc.MdiParent = this;
                    dc.Show();
                }
                else if (dc.Text == "")
                {
                    dc.Dispose();
                    dc = null;

                    dc = new DomainController();
                    dc.MdiParent = this;
                    dc.Show();
                }
                else
                {
                    dc.MdiParent = this;
                    dc.Show();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }

        private void moniterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(moniter == null)
                {
                    moniter = new Monitering();
                    moniter.MdiParent = this;
                    moniter.Show();

                }
                else if( moniter.Text == "")
                {
                    moniter.Dispose();
                    moniter = null;
                    moniter = new Monitering();
                    moniter.MdiParent = this;
                    moniter.Show();
                }
                else
                {
                    moniter.MdiParent = this;
                    moniter.Show();
                }
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }


        private void doimainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (domain == null)
                {
                    domain = new Domain();
                    domain.MdiParent = this;
                    domain.Show();

                }
                else if (domain.Text == "")
                {
                    domain.Dispose();
                    domain = null;
                    domain = new Domain();
                    domain.MdiParent = this;
                    domain.Show();
                }
                else
                {
                    domain.MdiParent = this;
                    domain.Show();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sv == null)
                {
                    sv = new Server();
                    sv.MdiParent = this;
                    sv.Show();

                }
                else if (sv.Text == "")
                {
                    sv.Dispose();
                    sv = null;
                    sv = new Server();
                    sv.MdiParent = this;
                    sv.Show();
                }
                else
                {
                    sv.MdiParent = this;
                    sv.Show();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}
