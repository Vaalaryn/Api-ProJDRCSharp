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
        public bool IS_MJ { get; set; }
        public int ID_JOUEUR { get; set; }
        public virtual List<image> image { get; set; }
        public virtual List<JoueurModel> joueur { get; set; }
    }
}