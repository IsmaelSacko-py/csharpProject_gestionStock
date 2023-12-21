using Microsoft.VisualBasic.Devices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpProject_gestionStock
{
    public partial class frmLayout : Form
    {
        public frmLayout()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
        }

        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fermer()
        {
            Form[] charr = this.MdiChildren;

            //For each child form set the window state to Maximized 
            foreach (Form chform in charr)
            {
                //chform.WindowState = FormWindowState.Maximized;
                chform.Close();
            }
        }

        private void formulaireBleuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmBleu formBleu = new frmBleu();
            formBleu.MdiParent = this;
            formBleu.Show();
            formBleu.WindowState = FormWindowState.Maximized;
        }

        private void formulaireVertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmVert formVert = new frmVert {MdiParent = this};
            formVert.Show();
            formVert.WindowState = FormWindowState.Maximized;
        }

        private void frmLayout_Load(object sender, EventArgs e) 
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
        }

        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void categorieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmCategorie formCategorie = new frmCategorie { MdiParent = this };
            formCategorie.Show();
            formCategorie.WindowState = FormWindowState.Maximized;
        }
    }
}
