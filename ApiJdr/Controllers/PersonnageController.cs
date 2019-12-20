using ApiJdr.Helper;
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
        public string Ajouter(
            int idJoueur,
            int idClasse,
            string nom,
            string prenom,
            string description,
            short mana,
            short vie
            )
        {
            try
            {
            personnage perso = new personnage
            {
                NOM = nom,
                PRENOM = prenom,
                VIVANT = true,
                DESCRIPTION = description,
                BLOCNOTE = "",
                ID_JOUEUR = idJoueur,
                joueur = db.joueur.Find(idJoueur),
                ID_CLASSE = idClasse,
                classe = db.classe.Find(idClasse),   
                EXPERIENCE = 0,
                MANA = mana,
                NIVEAU = 1

                
            };
            //Ajout du perso
            db.personnage.Add(perso);
            db.SaveChanges();

                if (JsonToFile.UpdatePartie(perso.joueur.ID_PARTIE) != "ok")
                    return "Erreur";
                else
                    return "ok";

            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public string UpdatePersonnage(
            int idPersonnage,
            string vivant = "",
            string nom = "",
            string prenom = "",
            string description = "",
            string blocnote = "",
            short vie = 0,
            short mana = 0,
            short experience = 0,
            short niveau = 0
            )
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
                if (vie != 0)
                    personnage.VIE += vie;
                if (mana != 0)
                    personnage.MANA += mana;
                if (experience != 0)
                    personnage.EXPERIENCE += experience;
                if (niveau != 0)
                    personnage.NIVEAU += niveau;
                if (vie <= 0)
                    personnage.VIVANT = false;
                else
                    personnage.VIVANT = true;

                db.SaveChanges();
                JsonToFile.UpdatePartie(personnage.joueur.ID_PARTIE);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
