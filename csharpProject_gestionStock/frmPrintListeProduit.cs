using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csharpProject_gestionStock.Model;
using csharpProject_gestionStock.Report;

namespace csharpProject_gestionStock
{
    public partial class frmPrintListeProduit : Form
    {
        BdKireneEntities db = new BdKireneEntities();   
        public frmPrintListeProduit()
        {
            InitializeComponent();
        }

        private void frmPrintListeProduit_Load(object sender, EventArgs e)
        {
            rptListeProduit objReport = new rptListeProduit();
            objReport.SetDataSource(GetTableProduit());
            crystalReportViewer1.ReportSource = objReport;
            crystalReportViewer1.Refresh();
        }

        public DataTable GetTableProduit()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CodeProduit", typeof(string));   
            table.Columns.Add("DesignationProduit", typeof(string));   
            table.Columns.Add("PrixUnitaire", typeof(double));   
            table.Columns.Add("QuantiteMinimale", typeof(int));   
            table.Columns.Add("QuantiteMaximale", typeof(int));   
            table.Columns.Add("CodeCategorie", typeof(string));
            var liste = db.Produit.ToList();
            foreach (var item in liste)
            {
                string Categorie = db.Categorie.Where(a => a.CodeCategorie == item.CodeCategorie).FirstOrDefault().LibelleCategorie;
                table.Rows.Add(
                    item.CodeProduit, 
                    item.DesignationProduit,
                    item.PrixUnitaire, 
                    item.QuantiteMinimale, 
                    item.QuantiteMaximale, 
                    Categorie);
            }

            return table;
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
   
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
