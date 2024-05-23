using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace csharpProject_gestionStock
{
    public partial class frmChangePassword : Form
    {
        BdKireneEntities db = new BdKireneEntities();
        public int id;
        public string UserEmail;
        bool hide1 = true;
        bool hide2 = true;
        public frmChangePassword()
        {
            InitializeComponent();
            txtMotDePasse1.UseSystemPasswordChar = true;
            txtMotDePasse2.UseSystemPasswordChar = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
           /* UC_changePassword uc = new UC_changePassword();
            uc.id = id;
            uc.UserEmail = UserEmail;*/
/*            plContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            plContainer.Controls.Add(uc);*/
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

                        Utilisateur utilisateur = db.Utilisateur.Find(Session.Id);
                        utilisateur.MotDePasse = mdpCrypter;
                        utilisateur.PremiereConnexion = false;
                        int status = db.SaveChanges();

                        string from = "sakoismael.is.1999@gmail.com";
                        string to = Session.Email;
                        string subject = "csharpProject_gestionStock : Modification du mot de passe";
                        string body = "Votre mot de passe a été rénitialisé avec succès !";

                        mail.SendMail(from, to, subject, body);

                        Session.Profil = utilisateur.CodeProfil;
                        Session.Id = utilisateur.idUtilisateur;
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

        private void txtMotDePasse1_IconRightClick(object sender, EventArgs e)
        {
            if (hide1)
            {
                txtMotDePasse1.IconRight = Properties.Resources.view;
                txtMotDePasse1.UseSystemPasswordChar = false;
            }
            else
            {
                txtMotDePasse1.IconRight = Properties.Resources.hide;
                txtMotDePasse1.UseSystemPasswordChar = true;
            }

            hide1 = !hide1;
        }

        private void txtMotDePasse2_IconRightClick(object sender, EventArgs e)
        {
            if (hide2)
            {
                txtMotDePasse2.IconRight = Properties.Resources.view;
                txtMotDePasse2.UseSystemPasswordChar = false;
            }
            else
            {
                txtMotDePasse2.IconRight = Properties.Resources.hide;
                txtMotDePasse2.UseSystemPasswordChar = true;
            }

            hide2 = !hide2;
        }
    }
}
