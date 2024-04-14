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

               })
               .OrderByDescending(x => x.Ventes)
               .ToList();

            dgBilanProduit.DataSource = ListeBilan;
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
