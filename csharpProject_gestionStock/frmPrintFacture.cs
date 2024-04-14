using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Report;
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
    public partial class frmPrintFacture : Form
    {

        BdKireneEntities db = new BdKireneEntities();
        private List<Facture> ListeFacture;
        Utilisateur utilisateur = new Utilisateur();
        public frmPrintFacture(List<Facture> ListeFacture)
        {
            InitializeComponent();
            this.ListeFacture = ListeFacture;   
        }

        private void frmPrintFacture_Load(object sender, EventArgs e)
        {
            rptFacture objReport = new rptFacture();
            objReport.SetDataSource(GetTableProduit());
            crystalReportViewer1.ReportSource = objReport;
            crystalReportViewer1.Refresh();
        }

        public DataTable GetTableProduit()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CodeProduit", typeof(string));
            table.Columns.Add("DesignationProduit", typeof(string));
            table.Columns.Add("Quantite", typeof(double));
            table.Columns.Add("Prix", typeof(int));
            table.Columns.Add("Total", typeof(int));
            table.Columns.Add("TypeTva", typeof(int));
            table.Columns.Add("TauxTva", typeof(int));
            table.Columns.Add("Vendeur", typeof(string));
            table.Columns.Add("NINEA", typeof(string));
            table.Columns.Add("RegistreCommerce", typeof(string));

            int TypeTva = 3;
            int TauxTva = 18;

            string NINEA = "00140012G3";
            string RegistreCommerce = "SN-DK-84-B-30";


            Utilisateur user = db.Utilisateur.Where(x => x.IdentifiantUtilisateur == Form1.IdentifiantUtilisateur).FirstOrDefault();
            string Vendeur = user.Nom + user.Prenom;

            var liste = this.ListeFacture;
            foreach (var item in liste)
            {
                //int? stock = db.Approvisionnement.Where(a => a.CodeProduit == item.CodeProduit).FirstOrDefault().QuantiteRestante;
                string libelle = db.Produit.Where(a => a.CodeProduit == item.CodeProduit).FirstOrDefault().DesignationProduit;
                table.Rows.Add(
                    item.CodeProduit,
                    libelle,
                    item.Quantite,
                    item.Prix,
                    item.Total,
                    TypeTva,
                    TauxTva,
                    Vendeur,
                    NINEA,
                    RegistreCommerce
                    );
            }

            return table;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
