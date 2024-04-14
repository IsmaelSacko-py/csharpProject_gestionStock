using Guna.UI2.WinForms;
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

        public string profil;
        public int id;
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
            /*Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);*/
            bool Visibility = (profil == "VEND")? false : true;


            btnCategorie.Visible = Visibility;
            btnProduit.Visible = Visibility;
            btnVendeur.Visible = Visibility;
            btnRechercher.Visible = Visibility;

            if(!Visibility)
            {
                UC_Vendre uc = new UC_Vendre();
                AddUserControl(uc);

                btnVendre.Location = new Point(23, 278);
                btnVendre.SendToBack();
                btnVendre.Checked = true;

                imgSlide.Location = new Point(141, 248);
                imgSlide.SendToBack();

                btnBilanVente.Location = new Point(23, 350);
                btnBilanVente.SendToBack();
            }else
            {
                UC_Categorie uc = new UC_Categorie();
                AddUserControl(uc);
            }

            lblIdentifiantUtilisateur.Text = Form1.IdentifiantUtilisateur;

            /* formulaireToolStripMenuItem.Visible = Visibility;
             sécuritéToolStripMenuItem.Visible = Visibility;*/

        }

/**        private void seDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void produitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmProduit formProduit = new frmProduit { MdiParent = this };
            formProduit.Show();
            formProduit.WindowState = FormWindowState.Maximized;
        }

        private void rechercheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmSearchProduit formRecherchProduit = new frmSearchProduit { MdiParent = this };
            formRecherchProduit.Show();
            formRecherchProduit.WindowState = FormWindowState.Maximized;
        }

        private void utilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmUtilisateur formUtilisateur = new frmUtilisateur { MdiParent = this };
            formUtilisateur.Show();
            formUtilisateur.WindowState = FormWindowState.Maximized;
        }*/





        private void moveImageBox(object sender)
        {
            Guna2Button button = (Guna2Button)sender;
            imgSlide.Location = new Point(button.Location.X + 118, button.Location.Y - 30);
            imgSlide.SendToBack();
        }

        private void AddUserControl(UserControl uc)
        {
            plContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            plContainer.Controls.Add(uc);
            btnProduit.Text = "Produit";
        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            moveImageBox(sender);
        }

        private void btnVendre_Click(object sender, EventArgs e)
        {
 
            UC_Vendre uc = new UC_Vendre();
            AddUserControl(uc);
        }

        private void btnCategorie_Click(object sender, EventArgs e)
        {
            UC_Categorie uc = new UC_Categorie();
            AddUserControl(uc);
        }

        private void btnProduit_Click(object sender, EventArgs e)
        {
            UC_Produit uc = new UC_Produit(btnProduit, plContainer);
            AddUserControl(uc);
        }

        private void btnVendeur_Click(object sender, EventArgs e)
        {
            UC_Vendeur uc = new UC_Vendeur();
            AddUserControl(uc);
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            UC_Recherche uc = new UC_Recherche();
            AddUserControl(uc);
        }

        private void plContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void btnBilanVente_Click(object sender, EventArgs e)
        {
            UC_BilanVenteGen uc = new UC_BilanVenteGen();
            AddUserControl(uc);
        }
    }
}
