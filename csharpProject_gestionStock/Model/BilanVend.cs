using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Model
{
    public class BilanVend
    {
        public string Ref_Produit { get; set; }
        public string Article { get; set; }
        public Nullable<double> Prix { get; set; }
        public int? Quantite { get; set; }
        public int? Montant { get; set; }
    }
}
