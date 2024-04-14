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
    public partial class frmSearchProduit : Form
    {
        public frmSearchProduit()
        {
            InitializeComponent();
        }

        private void btnSearchProduit_Click(object sender, EventArgs e)
        {
            var liste = db.VRechercheProduit.ToList();
            if(!string.IsNullOrEmpty(txtProduit.Text))
            {
                liste = liste.Where(a => a.DesignationProduit.ToLower().Contains(txtProduit.Text.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(cbbCategorie.Text))
            {
                liste = liste.Where(a => a.CodeCategorie.ToLower() == cbbCategorie.SelectedValue.ToString()).ToList();
            }

            if (!string.IsNullOrEmpty(txtPrixUnitaire.Text))
            {
                double PU = double.Parse(txtPrixUnitaire.Text);
                liste = liste.Where(a => a.PrixUnitaire <= PU).ToList();
            }


            dgSearchProduit.DataSource = liste;




        }

        BdKireneEntities db = new BdKireneEntities();

        LoadComboBox load = new LoadComboBox();
        private void frmSearchProduit_Load(object sender, EventArgs e)
        { 
            cbbCategorie.DataSource = load.loadCategorie();
            cbbCategorie.DisplayMember = "Text";
            cbbCategorie.ValueMember = "Value";

        }

        private void dgSearchProduit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
