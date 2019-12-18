using ApiJdr.Helper;
using ApiJdr.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                    //Création du fichier partie
                    string curFileParties = Properties.Settings.Default.ServeurFW.ToString() + "/Parties/" + key + ".json";
                    if (!File.Exists(curFileParties))
                    {
                        FileStream fs = File.Create(curFileParties);
                        fs.Close();

                    }
                    //Création du fichier log
                    string curFileLog = Properties.Settings.Default.ServeurFW.ToString() + "/Logs/" + key + ".json";
                    if (!File.Exists(curFileLog))
                    {
                        FileStream fs = File.Create(curFileLog);
                        fs.Close();

                    }
                }
                catch
                {
                    //Erreur de réseau
                }

                db.partie.Add(newPartie);
                db.SaveChanges();

                JsonToFile.EcrireJsonPartie(key);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// Mettre à jour les informations de la partie.
        /// </summary>
        /// <param name="idPartie">Id de la partie.</param>
        /// <param name="titre">Titre de la partie.</param>
        /// <param name="description">Description de la partie.</param>
        /// <returns>Message de retour.</returns>
        [HttpPost]
        public string UpdatePartie(string idPartie,
            string titre = "",
            string description = ""
        )
        {
            partie p = db.partie.Find(idPartie);
            try
            {
                //Update partie
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


        [HttpGet]
        public JsonPartieModel GetById(string idPartie)
        {
            partie p = db.partie.Find(idPartie);
            return new JsonPartieModel
            {
                DESCRIPTION_PARTIE = p.DESCRIPTION_PARTIE,
                ID_PARTIE = p.ID_PARTIE,
                image = p.image.ToList(),
                joueur = p.joueur.ToList(),
                TITRE = p.TITRE
            };
        }

        [HttpGet]
        public int EstDansLaPartie(int idUtil,string idPartie)
        {
            try
            {
            partie p = db.partie.Find(idPartie);
            if (p.joueur.Select(x => x.ID_UTIL).Contains(idUtil))
                return 1; //Est dans la partie
            else
                return 0; //N'est pas dans la partie
            }
            catch
            {
                //Erreur
                return -1;
            }
        }

    }
}
