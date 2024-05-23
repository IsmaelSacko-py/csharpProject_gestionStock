using csharpProject_gestionStock.Model;
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
    public partial class frmInfoUtilisateur : Form
    {

        BdKireneEntities db = new BdKireneEntities();
        public frmInfoUtilisateur()
        {
            InitializeComponent();
        }

        private void plContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmInfoUtilisateur_Load(object sender, EventArgs e)
        {
            /*UC_InfoUtilisateur uc = new UC_InfoUtilisateur();
            plContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            plContainer.Controls.Add(uc);*/
        }

        private void btnRecevoirCode_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                Utilisateur utilisateur = db.Utilisateur.Where(a => a.Email == txtEmail.Text).FirstOrDefault();

                if (utilisateur != null)
                {

                    frmCodeValidation form = new frmCodeValidation();

                    Mail mail = new Mail();
                    Random rand = new Random();
                    string code = rand.Next().ToString();
                    form.codeValidation = "gs-" + code;
                    form.email = utilisateur.Email;

                    string from = "sakoismael.is.1999@gmail.com";
                    string to = form.email;
                    string subject = "csharpProject_gestionStock : Code de validation";
                    string body = $"<html> <body> {form.codeValidation} : votre code de validation</body> </html>";

                    mail.SendMail(from, to, subject, body);


                    /*                    string fromMail = "sakoismael.is.1999@gmail.com";
                                        string fromPassword = "znmw ekrx lgrg vrhe";


                                        MailMessage message = new MailMessage();
                                        message.From = new MailAddress(fromMail);
                                        message.Subject = "csharpProject_gestionStock : Code de validation";
                                        message.To.Add(new MailAddress("ismael@groupeisi.com"));
                                        message.Body = $"<html> <body> {form.codeValidation} : votre code de validation</body> </html>";
                                        message.IsBodyHtml = true;

                                        var smtpClient = new SmtpClient("smtp.gmail.com")
                                        {
                                            Port = 587,
                                            Credentials = new NetworkCredential(fromMail, fromPassword),
                                            EnableSsl = true,
                                        };

                                        smtpClient.Send(message);*/


                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe incorrect");
                }

            }
            else
            {
                MessageBox.Show("Tous les champs sont obligatoires");
            }
        }
    }
}
