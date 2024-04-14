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
    public partial class UC_Approvisionner : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        public Produit produit;
        public UC_Approvisionner()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void UC_Approvisionner_Load(object sender, EventArgs e)
        {
            lblProduit.Text = produit.DesignationProduit;
            dgApprovisionnement.DataSource = db.Approvisionnement.Where(a => a.CodeProduit == produit.CodeProduit && a.QuantiteRestante > 0)
                .ToList();
/*            List<Approvisionnement> appro = db.Approvisionnement.Where(x => x.CodeProduit == produit.CodeProduit).OrderBy(x => x.DatePeremption).ToList();
            foreach(var item in appro)
            {
                MessageBox.Show(item.DatePeremption.ToString());
            }    */
        }

        private void lblProduit_Click(object sender, EventArgs e)
        {

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

        private void btnModifier_Click(object sender, EventArgs e)
        {

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

        }
    }
}
