using ApiJdr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class ValuesController : ApiController
    {
        private projdrEntities db = new projdrEntities();
        // GET api/values
        public IEnumerable<t_utilisateur> Get()
        {
            return db.t_utilisateur.ToList();
        }
        [HttpGet]
        public bool Connected(string pseudo, string pass)
        {
            if(db.t_utilisateur.Where(x => x.pseudo.ToLower() == pseudo.ToLower()).Count() > 0)
            {
                t_utilisateur user = db.t_utilisateur.Where(x => x.pseudo.ToLower() == pseudo.ToLower()).First();
                if(user.mdp == pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
