using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Model
{
    public class ProduitInfo
    {
        public string Ref_Categorie { get; set; }
        public string Categorie { get; set; }
        public string Ref_Produit { get; set; }
        public string Produit { get; set; }
        public double? Prix { get; set; }
        public int? Qte_Critique { get; set; }
        public int? Qte_Minimale { get; set; }
    }
}
