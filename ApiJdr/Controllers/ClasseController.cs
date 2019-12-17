using ApiJdr.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class ClasseController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        [HttpGet]
        public List<classe> GetAll()
        {
            return db.classe.ToList();
        }

    }
}
