using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace csharpProject_gestionStock
{
    public partial class UC_BilanVenteGen : UserControl
    {
        public UC_BilanVenteGen()
        {
            InitializeComponent();
        }

        private void AddUserControl2(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            plBilanContainer.Controls.Clear();
            plBilanContainer.Controls.Add(uc);
            uc.BringToFront();
        }

        private void UC_BilanVenteGen_Load(object sender, EventArgs e)
        {
            UC_BilanGeneral uc = new UC_BilanGeneral();
            AddUserControl2(uc);
        }



        private void btnVendeurs_Click(object sender, EventArgs e)
        {
            UC_BilanVente uc = new UC_BilanVente();
            AddUserControl2(uc);
        }

        private void btnProduits_Click(object sender, EventArgs e)
        {
            UC_BilanProduit uc = new UC_BilanProduit();
            AddUserControl2(uc);
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnBilanGeneral_Click(object sender, EventArgs e)
        {
            UC_BilanGeneral uc = new UC_BilanGeneral();
            AddUserControl2(uc);
        }
    }
}
