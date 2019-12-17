using ApiJdr.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ApiJdr.Helper
{
    public static class JsonToFile
    {
        private static jdrEntities db = new jdrEntities();
        /// <summary>
        /// Met a jour les logs
        /// </summary>
        /// <param name="idPartie"></param>
        /// <returns></returns>
        public static string UpdateLogs(string idPartie)
        {
            try
            {
                EcrireJsonLog(idPartie);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        /// <summary>
        /// Récupère les infos de la partie
        /// </summary>
        /// <param name="idPartie"></param>
        /// <returns></returns>
        public static JsonPartieModel InfoPartie(string idPartie)
        {
            partie p = db.partie.Find(idPartie);
            return new JsonPartieModel
            {
                ID_PARTIE = p.ID_PARTIE,
                TITRE = p.TITRE,
                DESCRIPTION_PARTIE = p.DESCRIPTION_PARTIE,
                joueur = p.joueur.ToList(),
                image = p.image.ToList()
            };
        }
        /// <summary>
        /// Ecrit le json partie dans le fichier associé
        /// </summary>
        /// <param name="idPartie"></param>
        public static void EcrireJsonPartie(string idPartie)
        {
            JsonPartieModel p = InfoPartie(idPartie);

            //Json a écrire dans la partie
            string json = JsonConvert.SerializeObject(p);
            string path = Properties.Settings.Default.ServeurFW.ToString() + "/Parties/" + idPartie + ".json";

            File.WriteAllText(path, json);
        }
        /// <summary>
        /// Ecrit le json log dans le fichier associé
        /// </summary>
        /// <param name="idPartie"></param>
        private static void EcrireJsonLog(string idPartie)
        {
            List<log> logs = db.log.Where(x => x.ID_PARTIE == idPartie).ToList();

            //Json a écrire dans la partie
            string json = JsonConvert.SerializeObject(logs);
            string path = Properties.Settings.Default.ServeurFW.ToString() + "/Logs/" + idPartie + ".json";

            File.WriteAllText(path, json);
        }
    }
}