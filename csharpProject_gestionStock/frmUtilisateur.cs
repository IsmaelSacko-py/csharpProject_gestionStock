using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;

namespace csharpProject_gestionStock
{
    public partial class frmUtilisateur : Form
    {
        public frmUtilisateur()
        {
            InitializeComponent();
        }


        BdKireneEntities db = new BdKireneEntities();
        LoadComboBox load = new LoadComboBox();
        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            dgUtilisateur.DataSource = db.Utilisateur.Select(x => new { x.idUtilisateur, x.IdentifiantUtilisateur, x.CodeProfil }).ToList();
            cbbProfil.DataSource = load.loadProfil();
            cbbProfil.DisplayMember = "Text";
            cbbProfil.ValueMember = "Value";

        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                Utilisateur utilisateur = new Utilisateur();
                utilisateur.IdentifiantUtilisateur = txtIdentifiant.Text;
                utilisateur.MotDePasse = Crypts.GetMd5Hash(md5Hash, "passer123");
                utilisateur.CodeProfil = cbbProfil.SelectedValue.ToString();
                db.Utilisateur.Add(utilisateur);
                db.SaveChanges();
                ResetForm();
            }
        }

        public void ResetForm()
        {
            txtIdentifiant.Text = String.Empty;

            dgUtilisateur.DataSource = db.Utilisateur.Select(x => new { x.idUtilisateur, x.IdentifiantUtilisateur, x.CodeProfil }).ToList();
            cbbProfil.DataSource = load.loadProfil();
            cbbProfil.DisplayMember = "Text";
            cbbProfil.ValueMember = "Value";
            txtIdentifiant.Focus();
        }
    }
}
