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
                partie newPartie = new partie
                {
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
