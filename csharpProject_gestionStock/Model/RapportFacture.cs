using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Model
{
    public class RapportFacture
    {
        public string CodeProduit { get; set; }
        public string DesignationProduit { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public string Telephone { get; set; }
        public int Quantite { get; set; }
        public int Prix { get; set; }
        public int Total { get; set; }
        public int TypeTva { get; set; }
        public int TauxTva { get; set; }
        public string NINEA { get; set; }
        public string RegistreCommerce { get; set; }

        public string Vendeur { get; set; }
    }
}
