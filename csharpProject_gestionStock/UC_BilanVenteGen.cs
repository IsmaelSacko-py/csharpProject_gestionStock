using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;

namespace csharpProject_gestionStock
{
    public partial class UC_BilanVenteGen : UserControl
    {
        public string profil;
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
            
            if(Session.Profil != "GEST")
            {
                UC_BilanVente uc = new UC_BilanVente();
                AddUserControl2(uc);

                plNavBar.Size = new System.Drawing.Size(500, 45);
                btnBilanGeneral.Visible = false;
                btnProduits.Location = btnVendeurs.Location;
                btnVendeurs.Location = btnBilanGeneral.Location;
                btnVendeurs.Text = "VENTES";
                btnVendeurs.Checked = true;
            }
            else
            {
                UC_BilanGeneral uc = new UC_BilanGeneral();
                AddUserControl2(uc);
            }
            

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
