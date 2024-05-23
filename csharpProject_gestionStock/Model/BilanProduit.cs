using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Model
{
    public class BilanProduit
    {
        public string Ref_Produit { get; set; }
        public string Produit { get; set; }
        public int? Stock { get; set; }
        public Nullable<double> Ventes { get; set; }
        public int? Montant { get; set; }
        public double? Chiffre_Affaire { get; set; }
    }
}
