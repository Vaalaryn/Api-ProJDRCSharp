using ApiJdr.Helper;
using ApiJdr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiJdr.Controllers
{
    public class StockController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        [HttpPost]
        public string Ajouter(
            int idPerso,
            int idObjet,
            short quantite
            )
        {
            try
            {
                stock st = new stock
                {
                    ID_OBJET = idObjet,
                    ID_PERSO = idPerso,
                    QUANTITE = quantite,
                    objet = db.objet.Find(idObjet),
                    personnage = db.personnage.Find(idPerso)
                };

                db.stock.Add(st);
                db.SaveChanges();
                JsonToFile.UpdatePartie(st.personnage.joueur.ID_PARTIE);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpPost]
        public string Update(
            int idStock,
            short quantite
            )
        {
            try
            {
                stock st = db.stock.Find(idStock);
                st.QUANTITE = quantite;
                db.SaveChanges();

                JsonToFile.UpdatePartie(st.personnage.joueur.ID_PARTIE);
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        public List<stock> StockPerso(int idPerso)
        {
            return db.personnage.Find(idPerso).stock.ToList();
        }
    }
}
