using ApiJdr.Helper;
using ApiJdr.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class JoueurController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        public List<InfoPerso> GetByPartie(string idPartie)
        {
            List<InfoPerso> listInfo = new List<InfoPerso>();

            List<personnage> listPerso = db.joueur.Where(x => x.ID_PARTIE == idPartie).FirstOrDefault().personnage.ToList();
            foreach (personnage perso in listPerso)
            {
                listInfo.Add(new InfoPerso
                {
                    perso = perso,
                    classePerso = perso.classe
                });
            }


            return listInfo;
        }

        public List<partie> GetPartieByJoueur(int idUtil)
        {
            return db.joueur.Where(x => x.ID_UTIL == idUtil).ToList().Select(x => x.partie).ToList();
        }

        public joueur GetUtilByJoueur(int idJoueur)
        {
            return db.joueur.Find(idJoueur);
        }

        public int Ajouter(
                string idPartie,
                int idUtil
            )
        {
            try
            {
                joueur j = new joueur
                {
                    ID_PARTIE = idPartie,
                    ID_UTIL = idUtil,
                    utilisateur = db.utilisateur.Find(idUtil),
                    partie = db.partie.Find(idPartie),
                    IS_MJ = false,
                };

                db.joueur.Add(j);
                db.SaveChanges();

                JsonToFile.UpdatePartie(idPartie);

                return j.ID_JOUEUR;
            }
            catch (System.Exception e)
            {
                //Erreur
                return 0;
            }
        }
    }
}
