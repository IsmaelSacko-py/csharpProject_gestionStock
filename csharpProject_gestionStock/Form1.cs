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
using csharpProject_gestionStock.Utils;
using System.Security.Cryptography;
using System.Data.Entity.Infrastructure;
using System.Net.Mail;
using System.Net;
using Microsoft.VisualBasic.ApplicationServices;

namespace csharpProject_gestionStock
{
    public partial class Form1 : Form
    {

        
        BdKireneEntities db = new BdKireneEntities();
        public static string IdentifiantUtilisateur;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if(txtIdentifiant.Text == "" || txtMotDePasse.Text == "")
            {
                MessageBox.Show("Tous les champs sont obligatoires");
            }else
            {
                var User = db.Utilisateur.Where(a => a.IdentifiantUtilisateur == txtIdentifiant.Text).FirstOrDefault();

                if (User != null)
                {
                    //string hash;
                    if (User.PremiereConnexion)
                    {
                        frmChangePassword form = new frmChangePassword();
                        frmLayout layout = new frmLayout();
                        //layout.MdiParent = this;
                        IdentifiantUtilisateur = User.IdentifiantUtilisateur;
                        layout.profil = User.CodeProfil;
                        form.id = User.idUtilisateur;
                        form.UserEmail = User.Email;
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        string hash = User.MotDePasse;
                        using (MD5 md5Hash = MD5.Create())
                        {
                            if (Crypts.VerifyMd5Hash(md5Hash, txtMotDePasse.Text, hash))
                            {
                                frmLayout layout = new frmLayout();
                                IdentifiantUtilisateur = User.IdentifiantUtilisateur;
                                //layout.MdiParent = this;
                                layout.profil = User.CodeProfil;
                                layout.id = User.idUtilisateur;
                                layout.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Identifiant ou mot de passe incorrect");
                            }
                        }
                    }
                    /*string hash = User.MotDePasse;
                    using (MD5 md5Hash = MD5.Create())
                    {
                        if (Crypts.VerifyMd5Hash(md5Hash, "passer123", hash))
                        {
                            frmChangePassword form = new frmChangePassword();
                            frmLayout layout = new frmLayout();
                            MessageBox.Show(txtMotDePasse.Text);
                            //layout.MdiParent = this;
                            layout.profil = User.CodeProfil;
                            form.id = User.idUtilisateur;
                            form.UserEmail = User.Email;
                            form.Show();
                            this.Hide();
                        }
                        else if (Crypts.VerifyMd5Hash(md5Hash, txtMotDePasse.Text, hash))
                        {
                            frmLayout layout = new frmLayout();
                            IdentifiantUtilisateur = User.IdentifiantUtilisateur;
                            //layout.MdiParent = this;
                            layout.profil = User.CodeProfil;
                            layout.id = User.idUtilisateur;
                            layout.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Identifiant ou mot de passe incorrect");
                        }
                    }*/

                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect");
                }

            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lkMotDePasseOublie_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmInfoUtilisateur form = new frmInfoUtilisateur();
            form.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void txtIdentifiant_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMotDePasse_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmVente form = new frmVente();
            form.Show();

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            UC_PrintFacture form = new UC_PrintFacture();
            form.Show();
            this.Enabled = false;

        }

        private void btnTest_Click_1(object sender, EventArgs e)
        {
            frmUtilisateur form = new frmUtilisateur();
            form.Show();
            
        }

        private void btnTest_Click_2(object sender, EventArgs e)
        {
        }

        private void btnTest_Click_3(object sender, EventArgs e)
        {
            frmLayout layout = new frmLayout();
            IdentifiantUtilisateur = "User.IdentifiantUtilisateur";
            //layout.MdiParent = this;
            layout.profil =" GEST";
            layout.id = 2;
            layout.Show();
            this.Hide();
        }
    }
}
