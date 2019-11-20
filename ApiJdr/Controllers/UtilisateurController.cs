using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiJdr.Models;

namespace ApiJdr.Controllers
{
    public class UtilisateurController : ApiController
    {
        private jdrEntities db = new jdrEntities();

        // GET: api/t_utilisateur
        public List<utilisateur> Get()
        {
            return db.utilisateur.ToList();
        }

        public utilisateur GetById(int id)
        {
            return db.utilisateur.Find(id);
        }

        public utilisateur GetByPseudo(string pseudo)
        {
            return db.utilisateur.Where(x => x.PSEUDO == pseudo).FirstOrDefault();
        }

        [HttpPost]
        public bool Connexion(string pseudo, string pass)
        {
            if (db.utilisateur.Where(x => x.PSEUDO.ToLower() == pseudo.ToLower()).Count() > 0)
            {
                utilisateur user = db.utilisateur.Where(x => x.PSEUDO.ToLower() == pseudo.ToLower()).First();
                if (user.MDP == pass)
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

        [HttpPost]
        public bool Ajouter(
            string mail,
            string pseudo,
            string mdp,
            string mdpConfirm,
            byte[] avatar)
        {
            if(!PseudoExist(pseudo) && mdp == mdpConfirm)
            {
                utilisateur utilisateur = new utilisateur
                {
                    PSEUDO = pseudo,
                    MAIL = mail,
                    MDP = mdp,
                    AVATAR = avatar
                    
                };

                db.utilisateur.Add(utilisateur);
                db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }


        // DELETE: api/t_utilisateur/5
        [ResponseType(typeof(utilisateur))]
        public IHttpActionResult Supprimer(int id)
        {
            utilisateur t_utilisateur = db.utilisateur.Find(id);
            if (t_utilisateur == null)
            {
                return NotFound();
            }

            db.utilisateur.Remove(t_utilisateur);
            db.SaveChanges();

            return Ok(t_utilisateur);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        private bool PseudoExist(string pseudo)
        {
            return db.utilisateur.Where(x => x.PSEUDO.ToLower() == pseudo.ToLower()).Count() > 0;
        }
    }
}