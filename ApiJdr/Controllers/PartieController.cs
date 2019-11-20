using ApiJdr.Models;
using System;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class PartieController : ApiController
    {
        private jdrEntities db = new jdrEntities();

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

    }
}
