using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;
using Guna.UI2.WinForms;
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
    public partial class UC_Produit : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        LoadComboBox load = new LoadComboBox();



        private Guna2Button btnProduit;
        private Guna2Panel plContainer;
        public UC_Produit(Guna2Button btnProduit, Guna2Panel plContainer)
        {
            this.btnProduit = btnProduit;
            this.plContainer = plContainer;
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UC_Produit_Load(object sender, EventArgs e)
        {
            dgProduit.DataSource = db.Produit.Select(x => new
            {
                Id = x.idProduit,
                Code = x.CodeProduit,
                Désignaton = x.DesignationProduit,
                Prix_Achat = x.PrixAchat,
                Prix_Vente = x.PrixUnitaire,
                Qte_Minimale = x.QuantiteMinimale,
                Qte_Critique = x.QuantiteMaximale,
                Categorie = x.CodeCategorie
            }).ToList();


            cbbCategorie.DataSource = load.loadCategorie();
            cbbCategorie.ValueMember = "Value";
            cbbCategorie.DisplayMember = "Text";

        }

        private void AddUserControl(UserControl uc)
        {
            this.plContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            plContainer.Controls.Add(uc);
        }

        private void resetForm()
        {
            txtCode.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtPrixVente.Text = string.Empty;
            txtPrixAchat.Text = string.Empty;
            txtQuantiteMinimale.Text = string.Empty;
            txtQuantiteCritique.Text = string.Empty;

            dgProduit.DataSource = db.Produit.Select(x => new
            {
                Id = x.idProduit,
                Code = x.CodeProduit,
                Désignaton = x.DesignationProduit,
                Prix_Achat = x.PrixAchat,
                Prix_Vente = x.PrixUnitaire,
                Qte_Minimale = x.QuantiteMinimale,
                Qte_Critique = x.QuantiteMaximale,
                Categorie = x.CodeCategorie
            }).ToList();

            cbbCategorie.DataSource = load.loadCategorie();
            cbbCategorie.ValueMember = "Value";
            cbbCategorie.DisplayMember = "Text";

            txtCode.Focus();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Produit produit = new Produit();
            produit.CodeProduit = txtCode.Text;
            produit.DesignationProduit = txtDesignation.Text;
            produit.PrixUnitaire = CheckEnter.CheckIsFloat(txtPrixVente.Text) ? float.Parse(txtPrixVente.Text) : 0;
            produit.PrixAchat = CheckEnter.CheckIsFloat(txtPrixAchat.Text) ? float.Parse(txtPrixAchat.Text) : 0;
            produit.QuantiteMinimale = int.Parse(txtQuantiteMinimale.Text);
            produit.QuantiteMaximale = int.Parse(txtQuantiteCritique.Text);
            produit.CodeCategorie = cbbCategorie.SelectedValue.ToString();

            db.Produit.Add(produit);
            db.SaveChanges();

            resetForm();
        }

        /*private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtCode.Text = dgProduit.CurrentRow.Cells[1].Value.ToString();
            txtDesignation.Text = dgProduit.CurrentRow.Cells[2].Value.ToString();
            txtPrixUnitaire.Text = dgProduit.CurrentRow.Cells[3].Value.ToString();
            txtQuantiteMinimale.Text = dgProduit.CurrentRow.Cells[4].Value.ToString();
            txtQuantiteCritique.Text = dgProduit.CurrentRow.Cells[5].Value.ToString();
            cbbCategorie.SelectedValue = dgProduit.CurrentRow.Cells[6].Value;
        }*/

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            Produit produit = db.Produit.Find(id);//Produit produit = db.Produit.Where(a => a.idProduit == id).FirstOrDefault();

            produit.CodeProduit = txtCode.Text;
            produit.DesignationProduit = txtDesignation.Text;
            produit.PrixUnitaire = float.Parse(txtPrixVente.Text);
            produit.PrixAchat = float.Parse(txtPrixAchat.Text);
            produit.QuantiteMinimale = int.Parse(txtQuantiteMinimale.Text);
            produit.QuantiteMaximale = int.Parse(txtQuantiteCritique.Text);
            produit.CodeCategorie = cbbCategorie.SelectedValue.ToString();

            db.SaveChanges();

            resetForm();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            Produit produit = db.Produit.Find(id);//Produit produit = db.Produit.Where(a => a.idProduit == id).FirstOrDefault();

            db.Produit.Remove(produit);

            db.SaveChanges();

            resetForm();
        }

        private void btnApprovisionner_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            UC_Approvisionner uc = new UC_Approvisionner();
            uc.produit = db.Produit.Find(id);
            AddUserControl(uc);
            this.btnProduit.Text = "Approvisionner";
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            frmPrintListeProduit form = new frmPrintListeProduit();
            form.Show();
            this.Enabled = false;
        }

        private void dgProduit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dgProduit.Rows)
            {
                //int? id = int.Parse(row.Cells[0].Value.ToString());
                //Produit produit = db.Produit.Find(id); 
                string CodeProduit = row.Cells[5].Value.ToString();
                Approvisionnement appro = db.Approvisionnement.Where(a => a.CodeProduit == CodeProduit).FirstOrDefault();


                if (appro != null)
                {/*
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;*/
                    if (Convert.ToInt64(row.Cells[5].Value) <= appro.QuantiteRestante)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
        }

        private void dgProduit_Cell(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProduit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.Text = dgProduit.CurrentRow.Cells[1].Value.ToString();
            txtDesignation.Text = dgProduit.CurrentRow.Cells[2].Value.ToString();
            txtPrixAchat.Text = dgProduit.CurrentRow.Cells[3].Value.ToString();
            txtPrixVente.Text = dgProduit.CurrentRow.Cells[4].Value.ToString();
            txtQuantiteMinimale.Text = dgProduit.CurrentRow.Cells[5].Value.ToString();
            txtQuantiteCritique.Text = dgProduit.CurrentRow.Cells[6].Value.ToString();
            cbbCategorie.SelectedValue = dgProduit.CurrentRow.Cells[7].Value;
        }
    }
}
