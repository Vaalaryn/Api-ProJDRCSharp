//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiJdr.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class personnage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public personnage()
        {
            this.stock = new HashSet<stock>();
        }
    
        public int ID_PERSO { get; set; }
        public int ID_CLASSE { get; set; }
        public int ID_JOUEUR { get; set; }
        public string NOM { get; set; }
        public string PRENOM { get; set; }
        public bool VIVANT { get; set; }
        public string DESCRIPTION { get; set; }
        public string BLOCNOTE { get; set; }
        public Nullable<short> VIE { get; set; }
        public Nullable<short> MANA { get; set; }
        public Nullable<int> EXPERIENCE { get; set; }
        public Nullable<int> NIVEAU { get; set; }


        [JsonIgnore]
        public virtual classe classe { get; set; }

        [JsonIgnore]
        public virtual joueur joueur { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stock> stock { get; set; }
    }
}
