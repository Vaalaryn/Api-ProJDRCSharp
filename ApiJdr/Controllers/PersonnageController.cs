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
            short vie = -1,
            short mana = -1,
            short experience = -1,
            short niveau = -1
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
                if (vie != -1)
                    personnage.VIE = vie;
                if (mana != -1)
                    personnage.MANA = mana;
                if (experience != -1)
                    personnage.EXPERIENCE = experience;
                if (niveau != -1)
                    personnage.NIVEAU = niveau;
                if (vivant != "")
                    personnage.VIVANT = vivant == "true" ? true : false;

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
