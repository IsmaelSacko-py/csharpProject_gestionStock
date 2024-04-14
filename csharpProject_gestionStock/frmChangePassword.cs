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
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            UC_changePassword uc = new UC_changePassword();
            uc.id = id;
            uc.UserEmail = UserEmail;
            plContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
            plContainer.Controls.Add(uc);
        }

        private void plContainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
