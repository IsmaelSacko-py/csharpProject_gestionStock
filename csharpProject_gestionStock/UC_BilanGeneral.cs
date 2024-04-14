using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SeriesCollection = LiveCharts.SeriesCollection;
using csharpProject_gestionStock.Model;
using System.Data.Entity;

namespace csharpProject_gestionStock
{
    public partial class UC_BilanGeneral : UserControl
    {
        BdKireneEntities db = new BdKireneEntities();
        public UC_BilanGeneral()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        

        private void UC_BilanGeneral_Load(object sender, EventArgs e)
        {
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Mois",
                Labels = new[] { "Jan", "Feb", "Mar", "Avr", "Mai", "Jui", "Juillet", "Août", "Sep", "Oct", "Nov", "Dec" }
            });

            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = "Ventes",
                LabelFormatter = value => value.ToString()
            });
            cartesianChart1.LegendLocation = LegendLocation.Right;
            cartesianChart1.BackColor = Color.White;

            cartesianChart1.Series.Clear();
            SeriesCollection series = new SeriesCollection();
            
            
            var dates = db.Facture
                        .Select(x => x.dateVente.Value.Year)
                        .Distinct()
                        .OrderByDescending(year => year)
                        .Take(3);

            //MessageBox.Show(dates.ToString());

            foreach (var date in dates)
            {

                List<int> ListeVentes = new List<int>();
                for (int month = 1; month <= 12; month++)
                {
                    //var month = date.Date;
                    int value = 0;
                    var ventes = db.Facture.Where(x => x.dateVente.Value.Year == date && x.dateVente.Value.Month == month).ToList();
                    /*.GroupBy(x => x.dateVente.Value.Month)
                    .Select(x => x.Key).ToList();*/
                    if (ventes != null)
                        value = ventes.Count();

                    ListeVentes.Add(value);

                    //MessageBox.Show(ventes.Count().ToString());
                }
                series.Add(new LineSeries() { Title = date.ToString(), Values = new ChartValues<int>(ListeVentes) });
            }
            /*foreach (var item in ListeVentes)
            {
                MessageBox.Show(item.ToString());
            }*/
            cartesianChart1.Series = series;

            lbClients.Text = db.Facture.Select(x => x.TelephoneClient).Distinct().Count().ToString();
            lbProduitVendus.Text = db.Facture.Select(x => x.Quantite).Sum().ToString();
            lbBenefices.Text = calculBenefice().ToString();
            lbDevise.Text = "(FCFA)";

        }

        public double? calculBenefice()
        {
            var ventes = db.Facture.ToList();
            var produits = db.Produit.ToList();
            List<double?> benefices = new List<double?>();
            foreach (var vente in ventes)
            {
                var PrixAchat = produits.Where(p => p.CodeProduit == vente.CodeProduit).FirstOrDefault().PrixAchat;
                var PrixAchatTotal = vente.Quantite * PrixAchat;
                var benefice = vente.Total - PrixAchatTotal;
                benefices.Add(benefice);
            }

            return benefices.Sum();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbDevise_Click(object sender, EventArgs e)
        {

        }
    }
}
