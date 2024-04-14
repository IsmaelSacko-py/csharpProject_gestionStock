using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpProject_gestionStock.Model
{
    public class BilanGest
    {
        public string Identifiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int Ventes { get; set; }
        public int? Montant { get; set; }


    }
}
