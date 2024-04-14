using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Model
{
    public class RapportListeProduit
    {

        public string CodeProduit { get; set; }
        public string DesignationProduit { get; set; }
        public double PrixUnitaire { get; set; }
        public int QuantiteMinimale { get; set; }
        public int QuantiteMaximale { get; set; }
        public string CodeCategorie { get; set; }
    }
}
