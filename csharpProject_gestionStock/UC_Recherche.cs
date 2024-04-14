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


namespace csharpProject_gestionStock
{
    public partial class UC_Recherche : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        LoadComboBox load = new LoadComboBox();
        List<ProduitInfo> ListeProduits = new List<ProduitInfo>();
        public UC_Recherche()
        {
            InitializeComponent();
        }

        private void UC_Recherche_Load(object sender, EventArgs e)
        {
            cbbCategorie.DataSource = load.loadCategorie();
            cbbCategorie.DisplayMember = "Text";
            cbbCategorie.ValueMember = "Value";

            ListeProduits = db.VRechercheProduit
             .Select(x => new ProduitInfo
             {
                 Ref_Categorie = x.CodeCategorie,
                 Categorie = x.LibelleCategorie,
                 Ref_Produit = x.CodeProduit,
                 Produit = x.DesignationProduit,
                 Prix = x.PrixUnitaire,
                 Qte_Critique = x.QuantiteMaximale,
                 Qte_Minimale = x.QuantiteMinimale
             }).ToList();

            dgSearchProduit.DataSource = ListeProduits;
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            var liste = ListeProduits;
            if (!string.IsNullOrEmpty(txtProduit.Text))
            {
                liste = liste.Where(a => a.Produit.ToLower().Contains(txtProduit.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(cbbCategorie.Text) && !cbbCategorie.Text.StartsWith("-------"))
            {
                liste = liste.Where(a => a.Ref_Categorie.ToLower() == cbbCategorie.SelectedValue.ToString()).ToList();
            }

            if (!string.IsNullOrEmpty(txtPrixUnitaire.Text))
            {
                double PU = double.Parse(txtPrixUnitaire.Text);
                liste = liste.Where(a => a.Prix <= PU).ToList();
            }


            dgSearchProduit.DataSource = liste;
        }

        private void dgSearchProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
