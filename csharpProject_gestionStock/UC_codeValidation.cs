﻿using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Utils;
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
    public partial class UC_codeValidation : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();

        private int secondesRestantes = 20;

        public string codeValidation;
        public string infoCodeValidation;
        public string email;
        public UC_codeValidation()
        {
            InitializeComponent();
        }

        private void UC_codeValidation_Load(object sender, EventArgs e)
        {
            lbInfoCodeValidation.Text = $"Un email contenant un code de validation vient d'être\nenvoyé à {this.email}";
            timer1.Interval = 1000; // L'intervalle du Timer est en millisecondes (1000 ms = 1 seconde)
            timer1.Start();
            AfficherCompteARebours();
            btnRenvoyerCode.Enabled = false;
        }

        private void txtCodeValidation_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show($"txtCode = {txtCodeValidation.Text.Length} - code = {this.codeValidation.Length}");
            if (txtCodeValidation.Text.Length == this.codeValidation.Length)
            {

                if (txtCodeValidation.Text == this.codeValidation)
                {
                    Utilisateur utilisateur = db.Utilisateur.Where(a => a.Email == email).FirstOrDefault();
                    frmChangePassword form = new frmChangePassword();
                    form.id = utilisateur.idUtilisateur;
                    form.UserEmail = utilisateur.Email;
                    form.Show();
                    this.Hide();
                    //MessageBox.Show("Correct");
                }
                else
                {
                    MessageBox.Show("Code de validation incorrect");
                }
            }
        }

        private void btnRenvoyerCode_Click(object sender, EventArgs e)
        {
            secondesRestantes = 20;
            Mail mail = new Mail();
            Random rand = new Random();
            string code = rand.Next().ToString();
            this.codeValidation = "gs-" + code;

            string from = "sakoismael.is.1999@gmail.com";
            string to = email;
            string subject = "csharpProject_gestionStock : Code de validation";
            string body = $"<strong>{this.codeValidation}</strong> : votre code de validation";

            mail.SendMail(from, to, subject, body);

            UC_codeValidation_Load(sender, e);
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            secondesRestantes--;
            AfficherCompteARebours();
            if (secondesRestantes == 0)
            {
                timer1.Stop();
                lbTempsRestant.Text = "Envoyer à nouveau un code";
                btnRenvoyerCode.Enabled = true;
                //MessageBox.Show("Le compte à rebours est terminé !");
            }
        }

        private void AfficherCompteARebours()
        {
            lbTempsRestant.Text = $"Renvoyer un code dans : {secondesRestantes} s";
        }


    }
}