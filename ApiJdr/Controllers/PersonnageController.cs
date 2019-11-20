using ApiJdr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class PersonnageController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        public personnage GetByJoueur(int idJoueur)
        {
            return db.personnage.Where(x => x.joueur.ID_JOUEUR == idJoueur).FirstOrDefault();
        }

        public personnage GetByPartie(string idPartie)
        {
            return db.personnage.Where(x => x.joueur.partie.ID_PARTIE == idPartie).FirstOrDefault();
        }

        public personnage GetById(int idPerso)
        {
            return db.personnage.Find(idPerso);
        }



    }
}
