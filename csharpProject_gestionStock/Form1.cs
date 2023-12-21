using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnConnexion_Click(object sender, EventArgs e)
        {
          
            frmLayout layout = new frmLayout();
            //layout.MdiParent = this;
            layout.Show();  

        }
    }
}
