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
    public partial class UC_Vendre : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        LoadComboBox load = new LoadComboBox();
        List<Facture> ListeFactures = new List<Facture>();
        List<ProduitsAppro> ListeProduits = new List<ProduitsAppro>();
        public int? montantTotal = 0;

        public UC_Vendre()
        {
            InitializeComponent();
            

        }

        private void UC_Vendre_Load(object sender, EventArgs e)
        {
            ListeProduits = db.Approvisionnement
            .Where(approvisionnement => approvisionnement.QuantiteRestante > 0)
            .GroupBy(approvisionnement => approvisionnement.CodeProduit)
            .Select(group => new ProduitsAppro
            {
                Code = group.Key,
                Désignation = db.Produit.FirstOrDefault(p => p.CodeProduit == group.Key).DesignationProduit,
                Prix = db.Produit.FirstOrDefault(p => p.CodeProduit == group.Key).PrixUnitaire,
                Stock = group.Sum(x => x.QuantiteRestante),
                Categorie = db.Produit.FirstOrDefault(p => p.CodeProduit == group.Key).CodeCategorie
            })
            .ToList();

            dgProduit.DataSource = ListeProduits;

            cbbCategorie.DataSource = load.loadCategorie();
            cbbCategorie.ValueMember = "Value";
            cbbCategorie.DisplayMember = "Text";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtArticle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtQuantite_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProduitVendu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void resetForm()
        {
            txtCode.Text = string.Empty;
            txtArticle.Text = string.Empty;
            txtQuantite.Text = string.Empty;
            txtPrix.Text = string.Empty;

            dgProduitVendu.DataSource = ListeFactures
                .Join(db.Produit,
                facture => facture.CodeProduit,
                produit => produit.CodeProduit,
                (facture, produit) => new
                {
                    Code = produit.CodeProduit,
                    Article = produit.DesignationProduit,
                    Quantité = facture.Quantite,
                    Prix = produit.PrixUnitaire,
                    facture.Total

                }).ToList();

            //dgProduit.ClearSelection();
            dgProduit.Refresh();
            dgProduit.DataSource = ListeProduits;


            /*dgProduitVendu.DataSource = db.Facture
                .Join(db.Produit,
                facture => facture.CodeProduit,
                produit => produit.CodeProduit,
                (facture, produit) => new
                {
                    facture.Id,
                    Article = produit.DesignationProduit,
                    Quantité = facture.Quantite,
                    Prix = produit.PrixUnitaire,
                    facture.Total

                }).ToList();*/

            txtCode.Focus();
        }

        private void dgProduit_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.Text = dgProduit.CurrentRow.Cells[0].Value.ToString();
            txtArticle.Text = dgProduit.CurrentRow.Cells[1].Value.ToString();
            txtPrix.Text = dgProduit.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {

            /*Facture facture = db.Facture.Where(x => x.CodeProduit == txtCode.Text).FirstOrDefault();  
            facture = (facture != null)? facture : new Facture();*/

            Facture facture = new Facture();
            facture.CodeProduit = txtCode.Text;
            facture.NomClient = txtNom.Text;
            facture.PrenomClient = txtPrenom.Text;
            facture.TelephoneClient = txtTelephone.Text;
            facture.Quantite = int.Parse(txtQuantite.Text);
            facture.Prix = int.Parse(txtPrix.Text);
            facture.Total = facture.Quantite * facture.Prix;

            montantTotal += facture.Total;
            lblMontantTotal.Text = $"<p>Total : <strong>{string.Format("{0:n}", montantTotal)}</strong> FCFA</p>";

            /*db.Facture.Add(facture);
            db.SaveChanges();*/
/*
            Approvisionnement approvisionnement = db.Approvisionnement.Where(x => x.CodeProduit == facture.CodeProduit).FirstOrDefault();
            approvisionnement.QuantiteRestante -= facture.Quantite;
*/

            foreach(var item in ListeProduits)
            {
                if(item.Code == txtCode.Text)
                {
                    item.Stock -= int.Parse(txtQuantite.Text);
                }
            }





                /**
                 * Permet de changer la quntite d'un produit deja present dans la facture.
                 * Si le produit est deja dans la facture, sa quantite est incrementée.
                 * Sinon, il est ajoute.
                 */
            if (ListeFactures.Count != 0)
            {
                bool trouver = false;
                foreach (var fact in ListeFactures)
                {
                    if (fact.CodeProduit == txtCode.Text)
                    {
                        fact.Quantite += int.Parse(txtQuantite.Text);
                        fact.Total = fact.Quantite * fact.Prix;
                        trouver = true;
                        break;
                    }
                }
                if( !trouver)
                {
                    ListeFactures.Add(facture);
                }
            }else
            {
                ListeFactures.Add(facture);
            }

/*
            db.SaveChanges();*/

            resetForm();
        }

        private List<Approvisionnement> GetApprovisionnements(string CodeProduit)
        {
            return db.Approvisionnement.Where(x => x.CodeProduit == CodeProduit).OrderBy(x => x.DatePeremption).ToList();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            btnValider_Click(sender, e);
            frmPrintFacture form = new frmPrintFacture(ListeFactures);
            form.Show();
            this.Enabled = false;

        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            var liste = ListeFactures.ToList();
            List<ProduitsAppro> produitsappr = ListeProduits;

            
            if (!string.IsNullOrEmpty(txtLibelle.Text))
            {
                //liste = liste.Where(a => a.DesignationProduit.ToLower().Contains(txtLibelle.Text.ToLower())).ToList();
                produitsappr = ListeProduits.Where(a => a.Désignation.ToLower().Contains(txtLibelle.Text.ToLower())).ToList();

            }

            if (!string.IsNullOrEmpty(cbbCategorie.Text) && !cbbCategorie.Text.StartsWith("---"))
            {
                produitsappr = ListeProduits.Where(a => a.Categorie.ToLower() == cbbCategorie.SelectedValue.ToString()).ToList();
            }

            if (!string.IsNullOrEmpty(txtPrixUnitaire.Text))
            {
                double PU = double.Parse(txtPrixUnitaire.Text);
                produitsappr = ListeProduits.Where(a => a.Prix <= PU).ToList();
            }


            dgProduit.DataSource = produitsappr;
        }

        private void txtLibelle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelephone_Leave(object sender, EventArgs e)
        {
            Facture facture = db.Facture.Where(x => x.TelephoneClient == txtTelephone.Text).FirstOrDefault();
            if(facture != null)
            {
                txtNom.Text = facture.NomClient;
                txtPrenom.Text = facture.PrenomClient;
            }else
            {
                txtNom.Text = String.Empty;
                txtPrenom.Text = String.Empty;
            }
        }

        private void cbbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2VSeparator2_Click(object sender, EventArgs e)
        {

        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            
            foreach (var item in ListeFactures)
            {
                List<Approvisionnement> listeApprovisionnements = GetApprovisionnements(item.CodeProduit);

                int? quantiteVouluRestante = null; // Represente la quantite restante d'un produit voulu par le client

                foreach (var appro in listeApprovisionnements)
                {

                    if (quantiteVouluRestante == null)
                    {


                        if (item.Quantite <= appro.QuantiteRestante)
                        {
                            appro.QuantiteRestante -= item.Quantite;
                            break;
                        }
                        else
                        {
                            quantiteVouluRestante = item.Quantite - appro.QuantiteRestante;
                            appro.QuantiteRestante = 0;
                        }
                    }
                    else
                    {
                        if (quantiteVouluRestante <= appro.QuantiteRestante)
                        {
                            appro.QuantiteRestante -= quantiteVouluRestante;
                            break;
                        }
                        else
                        {
                            quantiteVouluRestante = quantiteVouluRestante - appro.QuantiteRestante;
                            appro.QuantiteRestante = 0;
                        }
                    }



                }

            }
            db.SaveChanges();

            foreach (var fact in ListeFactures)
            {
                Facture facture = new Facture();
                facture.CodeProduit = fact.CodeProduit;
                facture.NomClient = fact.NomClient;
                facture.PrenomClient = fact.PrenomClient;
                facture.TelephoneClient = fact.TelephoneClient;
                facture.Quantite = fact.Quantite;
                facture.Prix = fact.Prix;
                facture.Total = fact.Total;
                facture.IdentifiantUtilisateur = Session.Identifiant;
                facture.dateVente = DateTime.Now;

                db.Facture.Add(facture);
                db.SaveChanges();

            }

            dgProduitVendu.Columns.Clear();
            ListeFactures.Clear();
            lblMontantTotal.Text = "";
            montantTotal = 0;
        }

        private void btnEfface_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrix_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
