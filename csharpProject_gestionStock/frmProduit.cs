using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;

namespace csharpProject_gestionStock
{
    public partial class frmProduit : Form
    {
        BdKireneEntities db = new BdKireneEntities();

        LoadComboBox load = new LoadComboBox();
        public frmProduit()
        {
            InitializeComponent();
        }

        private void frmProduit_Load(object sender, EventArgs e)
        {
            dgProduit.DataSource = db.Produit.ToList();
            dgProduit.CurrentRow.DefaultCellStyle.ForeColor = Color.Red;
            cbbCategorie.DataSource = load.loadCategorie();
            cbbCategorie.ValueMember = "Value";
            cbbCategorie.DisplayMember = "Text";
        }

        private void resetForm()
        {
            txtCode.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            txtPrixUnitaire.Text = string.Empty;
            txtQuantiteMinimale.Text = string.Empty;
            txtQuantiteMaximale.Text = string.Empty;

            dgProduit.DataSource = db.Produit.ToList();
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
            produit.PrixUnitaire = CheckEnter.CheckIsFloat(txtPrixUnitaire.Text)? float.Parse(txtPrixUnitaire.Text) : 0;
            produit.QuantiteMinimale = int.Parse(txtQuantiteMinimale.Text);
            produit.QuantiteMaximale = int.Parse(txtQuantiteMaximale.Text);
            produit.CodeCategorie = cbbCategorie.SelectedValue.ToString();
            
            db.Produit.Add(produit);
            db.SaveChanges();

            resetForm();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtCode.Text = dgProduit.CurrentRow.Cells[1].Value.ToString();
            txtDesignation.Text = dgProduit.CurrentRow.Cells[2].Value.ToString();
            txtPrixUnitaire.Text = dgProduit.CurrentRow.Cells[3].Value.ToString();
            txtQuantiteMinimale.Text = dgProduit.CurrentRow.Cells[4].Value.ToString();
            txtQuantiteMaximale.Text = dgProduit.CurrentRow.Cells[5].Value.ToString();
            cbbCategorie.SelectedValue = dgProduit.CurrentRow.Cells[6].Value;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            Produit produit = db.Produit.Find(id);//Produit produit = db.Produit.Where(a => a.idProduit == id).FirstOrDefault();
            
            produit.CodeProduit = txtCode.Text;
            produit.DesignationProduit = txtDesignation.Text;
            produit.PrixUnitaire = float.Parse(txtPrixUnitaire.Text);
            produit.QuantiteMinimale = int.Parse(txtQuantiteMinimale.Text);
            produit.QuantiteMaximale = int.Parse(txtQuantiteMaximale.Text);
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

        private void dgProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgProduit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach(DataGridViewRow row in dgProduit.Rows)
            {
                //int? id = int.Parse(row.Cells[0].Value.ToString());
                //Produit produit = db.Produit.Find(id); 
                string CodeProduit = row.Cells[1].Value.ToString();
                Approvisionnement appro = db.Approvisionnement.Where( a => a.CodeProduit == CodeProduit).FirstOrDefault();   


                if( appro != null )
                {
                    if (Convert.ToInt64(row.Cells[4].Value) <= appro.QuantiteRestante)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }

        }

        private void btnApprovisionner_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgProduit.CurrentRow.Cells[0].Value.ToString());
            frmApprovisionnement frm = new frmApprovisionnement();
            frm.produit = db.Produit.Find(id);
            frm.ShowDialog();
        }


        private void btnImprimer_Click(object sender, EventArgs e)
        {
            frmPrintListeProduit form = new frmPrintListeProduit();
            form.Show();
            this.Enabled = false;
        }

        private void cbbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
