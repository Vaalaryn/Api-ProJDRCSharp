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
    
    public partial class log
    {
        public int ID_LOG { get; set; }
        public string ID_PARTIE { get; set; }
        public short TYPE { get; set; }
        public string MESSAGE { get; set; }
        public System.DateTime DATE_ENVOI { get; set; }
        [JsonIgnore]
        public virtual partie partie { get; set; }
    }
}
