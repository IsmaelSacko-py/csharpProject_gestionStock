//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace csharpProject_gestionStock.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class VRechercheProduit
    {
        public string CodeCategorie { get; set; }
        public string LibelleCategorie { get; set; }
        public string DesignationProduit { get; set; }
        public string CodeProduit { get; set; }
        public Nullable<double> PrixUnitaire { get; set; }
        public Nullable<int> QuantiteMinimale { get; set; }
        public Nullable<int> QuantiteMaximale { get; set; }
        public int idProduit { get; set; }
    }
}