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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace csharpProject_gestionStock
{
    public partial class frmCategorie : Form
    {
        BdKireneEntities bd = new BdKireneEntities();
        public frmCategorie()
        {
            InitializeComponent();
        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {
            dgCategorie.DataSource = bd.Categorie.ToList();
        }

        private void resetForm()
        {
            txtCode.Text = String.Empty;
            txtLibelle.Text = String.Empty;
            dgCategorie.DataSource = bd.Categorie.ToList();
            txtCode.Focus();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Categorie categorie = new Categorie();
            categorie.CodeCategorie = txtCode.Text;
            categorie.LibelleCategorie = txtLibelle.Text;
            bd.Categorie.Add(categorie);
            bd.SaveChanges();

            resetForm();

        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtCode.Text = dgCategorie.CurrentRow.Cells[1].Value.ToString();
            txtLibelle.Text = dgCategorie.CurrentRow.Cells[2].Value.ToString();

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgCategorie.CurrentRow.Cells[0].Value.ToString());
            Categorie categorie = bd.Categorie.Find(id);
            categorie.CodeCategorie = txtCode.Text;
            categorie.LibelleCategorie = txtLibelle.Text;
            bd.SaveChanges();

            resetForm();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgCategorie.CurrentRow.Cells[0].Value.ToString());
            Categorie categorie = bd.Categorie.Find(id);
            bd.Categorie.Remove(categorie);
            bd.SaveChanges();

            resetForm();
        }
    }
}
