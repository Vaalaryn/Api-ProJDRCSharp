using ApiJdr.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class PartieController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        [HttpPost]
        public string Ajouter(int idUtilisateur, string titre, string description)
        {
            try
            {
                string key = Helper.Fonctions.KeyGen();
                joueur j = new joueur
                {
                    ID_PARTIE = key,
                    ID_UTIL = idUtilisateur,
                    IS_MJ = true
                };

                partie newPartie = new partie
                {
                    ID_PARTIE = key,
                    DESCRIPTION_PARTIE = description,
                    TITRE = titre,
                    joueur = new List<joueur> { j }
                };
                try
                {
                    string curFile = Properties.Settings.Default.ServeurFW.ToString() + key + ".json";
                    if (File.Exists(curFile) == false)
                    {
                        File.Create(curFile);
                    }
                }
                catch
                {

                }
                
                db.partie.Add(newPartie);
                db.SaveChanges();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public string UpdatePartie(string idPartie, string titre, string description)
        {
            partie p = db.partie.Find(idPartie);
            try
            {
                if (titre != "")
                    p.TITRE = titre;
                if (description != "")
                    p.DESCRIPTION_PARTIE = description;

                db.SaveChanges();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public List<JsonPartieModel> PartiesEnCours(int idUtilisateur)
        {
            return db.partie.Where(x => x.joueur.Select(j => j.ID_UTIL).ToList().Contains(idUtilisateur)).Select(x => new JsonPartieModel
            {
                ID_PARTIE = x.ID_PARTIE,
                TITRE = x.TITRE,
                DESCRIPTION_PARTIE = x.DESCRIPTION_PARTIE
            }).ToList();
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
