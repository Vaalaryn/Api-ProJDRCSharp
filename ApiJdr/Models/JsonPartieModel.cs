using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiJdr.Models
{
    public class JsonPartieModel
    {
        public string ID_PARTIE { get; set; }
        public string TITRE { get; set; }
        public string DESCRIPTION_PARTIE { get; set; }

        public virtual List<image> image { get; set; }
        public virtual List<joueur> joueur { get; set; }
        public virtual List<personnage> personnage { get; set; }
        //public virtual List<log> log { get; set; }
    }
}