using ApiJdr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class PartieController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        [HttpPost]
        public bool Ajouter(string titre, string description)
        {
            try
            {
                string key = Helper.Fonctions.KeyGen();
                partie newPartie = new partie
                {
                    ID_PARTIE = key,
                    DESCRIPTION_PARTIE = description,
                    TITRE = titre
                };
                db.partie.Add(newPartie);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpGet]
        public List<partie> PartiesEnCours()
        {
            return db.partie.ToList();
        }

        [HttpPost]
        public List<InfoPerso> GetAllPerso(string idPartie)
        {
            List<InfoPerso> infos = new List<InfoPerso>();

            List<personnage> personnages = db.personnage.Where(x => x.joueur.ID_PARTIE == idPartie).ToList();
            foreach (personnage perso in personnages)
            {
                InfoPerso info = new InfoPerso
                {
                    perso = perso,
                    classePerso = perso.classe,
                    objetPerso = db.stock.Where(x => x.ID_PERSO == perso.ID_PERSO).Select(x => x.objet).ToList()
                };

                infos.Add(info);
            }

            return infos;
        }
    }
}
