using ApiJdr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class JoueurController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        public List<InfoPerso> GetByPartie(string idPartie, int idJoueur)
        {
            List<InfoPerso> listInfo = new List<InfoPerso>();

            List<personnage> listPerso = db.joueur.Where(x => x.ID_PARTIE == idPartie && x.ID_JOUEUR == idJoueur).FirstOrDefault().personnage.ToList();
            foreach(personnage perso in listPerso)
            {
                listInfo.Add(new InfoPerso
                {
                    perso = perso,
                    classePerso = perso.classe
                });
            }


            return listInfo;
        }
    }
}
