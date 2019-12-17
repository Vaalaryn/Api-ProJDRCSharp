using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiJdr.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return RedirectToAction("Get","Utilisateur");
        }
    }
}
