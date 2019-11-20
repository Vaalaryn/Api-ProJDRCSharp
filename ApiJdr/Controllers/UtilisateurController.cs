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

        public utilisateur GetById(int id)
        {
            return db.utilisateur.Find(id);
        }

        public utilisateur GetByPseudo(string pseudo)
        {
            return db.utilisateur.Where(x => x.PSEUDO == pseudo).FirstOrDefault();
        }

        public utilisateur GetByMail(string mail)
        {
            return db.utilisateur.Where(x => x.MAIL == mail).FirstOrDefault();
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
        public bool Inscription(
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
        private bool MailExist(string mail)
        {
            return db.utilisateur.Where(x => x.MAIL.ToLower() == mail.ToLower()).Count() > 0;
        }
    }
}