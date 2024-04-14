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
    public partial class UC_changePassword : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        public int id;
        public string UserEmail;
        public UC_changePassword()
        {
            InitializeComponent();
        }

        private void UC_changePassword_Load(object sender, EventArgs e)
        {

        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            string mdp1 = txtMotDePasse1.Text;
            string mdp2 = txtMotDePasse2.Text;
            if (mdp1.Equals(mdp2))
            {
                if (!mdp1.Equals("passer123"))
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        Mail mail = new Mail();
                        frmLayout layout = new frmLayout();
                        string mdpCrypter = Crypts.GetMd5Hash(md5Hash, mdp1);

                        Utilisateur utilisateur = db.Utilisateur.Find(id);
                        utilisateur.MotDePasse = mdpCrypter;
                        utilisateur.PremiereConnexion = false;
                        int status = db.SaveChanges();

                        string from = "sakoismael.is.1999@gmail.com";
                        string to = this.UserEmail;
                        string subject = "csharpProject_gestionStock : Modification du mot de passe";
                        string body = "Votre mot de passe a été rénitialisé avec succès !";

                        mail.SendMail(from, to, subject, body);

                        layout.profil = utilisateur.CodeProfil;
                        layout.id = utilisateur.idUtilisateur;
                        layout.Show();
                        this.Hide();

                    }
                }
                else
                {
                    MessageBox.Show("Ce mot de passe ne peut être defini");
                }


            }
            else
            {
                MessageBox.Show("Mots de passes differents");
                txtMotDePasse1.Text = String.Empty;
                txtMotDePasse2.Text = String.Empty;
            }
        }

    }
}
