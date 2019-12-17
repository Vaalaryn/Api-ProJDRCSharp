using ApiJdr.Helper;
using ApiJdr.Models;
using System;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class LogController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        [HttpPost]
        public string Ajouter(string idPartie,short type, string message)
        {
            log l = new log {
                DATE_ENVOI = DateTime.Now,
                ID_PARTIE = idPartie,
                MESSAGE = message,
                partie = db.partie.Find(idPartie),
                TYPE = type
            };

            try
            {
                db.log.Add(l);
                db.SaveChanges();

                JsonToFile.UpdateLogs(idPartie);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
