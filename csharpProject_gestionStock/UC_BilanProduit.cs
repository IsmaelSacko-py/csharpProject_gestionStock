using csharpProject_gestionStock.Model;
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
    public partial class UC_BilanProduit : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        public List<BilanProduit> ListeBilan = new List<BilanProduit>();
        //public List<BilanVend> ListeBilanVente = new List<BilanVend>();

        public UC_BilanProduit()
        {
            InitializeComponent();
        }

        private void UC_BilanProduit_Load(object sender, EventArgs e)
        {
            ListeBilan = db.Facture
               .GroupBy(user => user.CodeProduit)
               .Select(group => new BilanProduit
               {
                   Ref_Produit = group.Key,
                   Produit = db.Produit.Where(u => u.CodeProduit == group.Key).FirstOrDefault().DesignationProduit,
                   Stock = db.Approvisionnement.Where(u => u.CodeProduit == group.Key).FirstOrDefault().QuantiteRestante,
                   Ventes = group.Sum(x => x.Quantite),
                   Montant = group.Sum(x => x.Total),
                   Chiffre_Affaire = 0,

               })
               .OrderByDescending(x => x.Ventes)
               .ToList();

            // Determine le chiffre d'affaire de chaque produit vendu
            foreach(var bilan in ListeBilan)
            {
                bilan.Chiffre_Affaire = calculBeneficeProduit(bilan.Ref_Produit);
            }

            dgBilanProduit.DataSource = ListeBilan;
        }

        /// <summary>
        /// Determine le chiffre d'affaire d'un produit en particulier
        /// </summary>
        /// <param name="CodeProduit"> Le code du produit dont on souhaite determiner le chiffre d'affaire </param>
        /// <returns>Le chiffre d'affaire</returns>
        public double? calculBeneficeProduit(String CodeProduit)
        {
            var ventes = db.Facture.Where(p => p.CodeProduit == CodeProduit).ToList();
            var PrixAchat = db.Produit.Where(p => p.CodeProduit == CodeProduit).FirstOrDefault().PrixAchat;
            List<double?> benefices = new List<double?>();
            foreach (var vente in ventes)
            {
                //var PrixAchat = produits.Where(p => p.CodeProduit == vente.CodeProduit).FirstOrDefault().PrixAchat;
                var PrixAchatTotal = vente.Quantite * PrixAchat;
                var benefice = vente.Total - PrixAchatTotal;
                benefices.Add(benefice);
            }

            return benefices.Sum();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            var liste = ListeBilan;
            if (!string.IsNullOrEmpty(txtProduit.Text))
            {
                liste = liste.Where(a => a.Produit.ToLower().Contains(txtProduit.Text.ToLower())).ToList();
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


            dgBilanProduit.DataSource = liste;
        }

        private void dgBilanProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
