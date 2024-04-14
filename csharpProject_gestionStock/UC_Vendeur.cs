using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;
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
namespace csharpProject_gestionStock
{
    public partial class UC_Vendeur : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        LoadComboBox load = new LoadComboBox();
        List<Object> utilisateurs = new List<Object>();
        public UC_Vendeur()
        {
            InitializeComponent();
        }

        private void dgVendeur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void UC_Vendre_Load(object sender, EventArgs e)
        {
            dgVendeur.DataSource = db.Utilisateur
            .Select(x => new
            {
                Id = x.idUtilisateur,
                Identifiant = x.IdentifiantUtilisateur,
                x.Nom,
                x.Prenom,
                Profil = db.Profil.Where(p => p.CodeProfil == x.CodeProfil).FirstOrDefault().LibelleProfil,
                x.Email
            })
            .ToList();
            cbbProfil.DataSource = load.loadProfil();
            cbbProfil.ValueMember = "Value";
            cbbProfil.DisplayMember = "Text";

        }

        private void dgVendeur_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void ResetForm()
        {
            txtIdentifiant.Text = String.Empty;

            dgVendeur.DataSource = db.Utilisateur
            .Select(x => new
            {
                Id = x.idUtilisateur,
                Identifiant = x.IdentifiantUtilisateur,
                x.Nom,
                x.Prenom,
                Profil = db.Profil.Where(p => p.CodeProfil == x.CodeProfil).FirstOrDefault().LibelleProfil,
                x.Email
            })
            .ToList();
            cbbProfil.DataSource = load.loadProfil();
            cbbProfil.DisplayMember = "Text";
            cbbProfil.ValueMember = "Value";
            txtIdentifiant.Focus();
        }

        private void btnAjouer_Click(object sender, EventArgs e)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                Utilisateur utilisateur = new Utilisateur();
                utilisateur.IdentifiantUtilisateur = txtIdentifiant.Text;
                utilisateur.Nom = txtNom.Text;
                utilisateur.Prenom = txtPrenom.Text;
                utilisateur.Email = $"{txtIdentifiant.Text.ToLower()}@gmail.com";
                utilisateur.MotDePasse = Crypts.GetMd5Hash(md5Hash, "passer123");
                utilisateur.CodeProfil = cbbProfil.SelectedValue.ToString();
                db.Utilisateur.Add(utilisateur);
                db.SaveChanges();
                ResetForm();
            }
        }
    }
}
