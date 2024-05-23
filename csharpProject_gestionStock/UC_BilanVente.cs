using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;
using Microsoft.VisualBasic.ApplicationServices;

namespace csharpProject_gestionStock
{
    public partial class UC_BilanVente : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        public List<BilanGest> ListeBilan = new List<BilanGest>();
        public List<BilanVend> ListeBilanVente = new List<BilanVend>();
        public UC_BilanVente()
        {
            InitializeComponent();
        }

        private void UC_BilanVente_Load(object sender, EventArgs e)
        {
            string profil = db.Utilisateur.Where(x => x.IdentifiantUtilisateur == Session.Identifiant).FirstOrDefault().CodeProfil;
            if(profil == "GEST")
            {
               // dgBilanVente.DataSource = db.Facture.ToList();

                
                ListeBilan = db.Facture
                .GroupBy(user => user.IdentifiantUtilisateur)
                .Select(group => new BilanGest
                {
                    Identifiant = group.Key,
                    Nom = db.Utilisateur.Where(u => u.IdentifiantUtilisateur == group.Key).FirstOrDefault().Nom,
                    Prenom = db.Utilisateur.Where(u => u.IdentifiantUtilisateur == group.Key).FirstOrDefault().Prenom,
                    Email = db.Utilisateur.Where(u => u.IdentifiantUtilisateur == group.Key).FirstOrDefault().Email,
                    Ventes = group.Count(),
                    Montant = group.Sum(x => x.Total),


                })
                .OrderByDescending(x => x.Ventes)
                .ToList();

                dgBilanVente.DataSource = ListeBilan;
            }
            else
            {
                ListeBilanVente = db.Facture.Where(x => x.IdentifiantUtilisateur == Session.Identifiant)
                .GroupBy(user => new {user.CodeProduit, user.IdentifiantUtilisateur})
                .Select(x => new BilanVend
                {
                    Ref_Produit = x.Key.CodeProduit,
                    Article = db.Produit.Where(p => p.CodeProduit == x.Key.CodeProduit).FirstOrDefault().DesignationProduit,
                    Prix = db.Produit.Where(p => p.CodeProduit == x.Key.CodeProduit).FirstOrDefault().PrixUnitaire,
                    Montant = x.Sum(p => p.Total),
                    Quantite = x.Sum(p => p.Quantite),
                    
                })
                .ToList();
                dgBilanVente.DataSource = ListeBilanVente;
            }
        }

        private void dgBilanVente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            var liste = ListeBilan;
            if (!string.IsNullOrEmpty(txtIdentifiant.Text))
            {
                liste = liste.Where(a => a.Identifiant.ToLower().Contains(txtIdentifiant.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(txtVentes.Text))
            {
                int ventes = int.Parse(txtVentes.Text);
                liste = liste.Where(a => a.Ventes <= ventes).ToList();
            }

            if (!string.IsNullOrEmpty(txtTotal.Text))
            {
                int total = int.Parse(txtTotal.Text);
                liste = liste.Where(a => a.Montant <= total).ToList();
            }


            dgBilanVente.DataSource = liste;
        }

        private void dgBilanVente_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgBilanVente_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtVentes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtIdentifiant_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
