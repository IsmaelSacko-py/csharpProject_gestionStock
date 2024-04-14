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
    public partial class frmApprovisionnement : Form
    {

        public Produit produit;

        BdKireneEntities db = new BdKireneEntities();
        public frmApprovisionnement()
        {
            InitializeComponent();
        }
        private void frmApprovisionnement_Load(object sender, EventArgs e)
        {
            lblProduit.Text = produit.DesignationProduit;
            dgApprovisionnement.DataSource = db.Approvisionnement.Where(a => a.CodeProduit == produit.CodeProduit && a.QuantiteRestante > 0).ToList();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetForm()
        {
            txtDatePeremption.Value = DateTime.Now;
            txtQuantite.Text = string.Empty;
            dgApprovisionnement.DataSource = db.Approvisionnement.Where(a => a.CodeProduit == produit.CodeProduit && a.QuantiteRestante > 0).ToList();
            txtQuantite.Focus();

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Approvisionnement appro = new Approvisionnement();
            appro.QuantiteAppro = int.Parse(txtQuantite.Text);
            appro.DatePeremption = txtDatePeremption.Value;
            appro.QuantiteRestante = int.Parse(txtQuantite.Text);
            appro.DateAppro = DateTime.Now.ToShortDateString();
            appro.CodeProduit = produit.CodeProduit;
            db.Approvisionnement.Add(appro);
            db.SaveChanges();
            resetForm();


        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }

        /*
        private void dgApprovisionnement_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            foreach (DataGridViewRow row in dgApprovisionnement.Rows)
            {
                //int? id = int.Parse(row.Cells[0].Value.ToString());
                //Produit produit = db.Produit.Find(id); 
                string CodeProduit = row.Cells[1].Value.ToString();
                Approvisionnement appro = db.Approvisionnement.Where(a => a.CodeProduit == CodeProduit).FirstOrDefault();


                if (appro != null)
                {
                    if (Convert.ToInt64(row.Cells[4].Value) <= appro.QuantiteRestante)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                        row.DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }

        }
        */

    }
}
