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
    public partial class UC_PrintFacture : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();

        public UC_PrintFacture()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           
        }


        private void UC_PrintFacture_Load(object sender, EventArgs e)
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
            table.Columns.Add("Quantite", typeof(int));
            table.Columns.Add("Prix", typeof(int));
            table.Columns.Add("Total", typeof(int));
            var liste = db.Facture.ToList();
            foreach (var item in liste)
            {
                string Produit = db.Produit.Where(a => a.CodeProduit == item.CodeProduit).FirstOrDefault().DesignationProduit;
                table.Rows.Add(
                    item.CodeProduit,
                    Produit,
                    item.Quantite,
                    item.Prix,
                    item.Total);
            }

            return table;
        }

    }
}
