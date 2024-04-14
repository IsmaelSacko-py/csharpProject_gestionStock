using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Model
{

    using System;
    using System.Collections.Generic;
    public class ProduitsAppro
    {
        public string Code { get; set; }
        public string Désignation { get; set; }
        public Nullable<double> Prix { get; set; }
        public Nullable<int> Stock { get; set; }
        public string Categorie { get; set; }
    }
}
