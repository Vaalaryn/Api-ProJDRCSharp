using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiJdr.Models
{
    public class JoueurModel
    {
        public int ID_JOUEUR { get; set; }
        public string ID_PARTIE { get; set; }
        public bool IS_MJ { get; set; }
        public virtual List<personnage> personnage { get; set; }
        public virtual List<stock> stock { get; set; }
    }
}