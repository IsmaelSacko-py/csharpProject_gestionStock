
using System.Windows.Forms;


namespace csharpProject_gestionStock
{
    
    public partial class frmCodeValidation : Form
    {

        public string codeValidation;
        public string infoCodeValidation;
        public string email;
        public frmCodeValidation()
        {
            InitializeComponent();
        }

        private void frmCodeValidation_Load(object sender, System.EventArgs e)
        {
            UC_codeValidation uc = new UC_codeValidation();
            uc.codeValidation = codeValidation;
            uc.email = email;
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
