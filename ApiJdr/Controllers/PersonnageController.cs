using ApiJdr.Models;
using System;
using System.Linq;
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

        [HttpPost]
        public bool Ajouter(
            string nom,
            string prenom,
            string description,
            string blocnote,
            int? vie,
            int? mana,
            int? experience,
            int? niveau
            )
        {
            personnage perso = new personnage();

            return true;
        }

        [HttpPost]
        public string UpdatePersonnage(
            int idPersonnage,
            string nom,
            string prenom,
            string description,
            string blocnote,
            string vie,
            string mana,
            string experience,
            string niveau,
            string vivant)
        {
            personnage personnage = db.personnage.Find(idPersonnage);
            try
            {
                if (nom != "")
                    personnage.NOM = nom;
                if (prenom != "")
                    personnage.PRENOM = prenom;
                if (description != "")
                    personnage.DESCRIPTION = description;
                if (blocnote != "")
                    personnage.BLOCNOTE = blocnote;
                if (vie != "")
                    personnage.VIE = System.Convert.ToInt16(vie);
                if (mana != "")
                    personnage.MANA = System.Convert.ToInt16(mana);
                if (experience != "")
                    personnage.EXPERIENCE = System.Convert.ToInt16(experience);
                if (niveau != "")
                    personnage.NIVEAU = System.Convert.ToInt16(niveau);
                if (vivant != "")
                    personnage.VIVANT = (vivant == "true");
                db.SaveChanges();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
