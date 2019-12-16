using ApiJdr.Models;
using System;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class LogController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        [HttpPost]
        public string Ajouter()
        {
            log l = new log();
            try
            {
                db.log.Add(l);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }




    }
}
