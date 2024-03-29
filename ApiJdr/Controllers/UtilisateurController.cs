﻿using ApiJdr.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

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

        [HttpGet]
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
        public int Inscription(
            //string mail,
            //string pseudo,
            //string mdp,
            //string mdpConfirm,
            //string image = ""

            )
        {

            HttpContext ctx = HttpContext.Current;
            var form = ctx.Request.Form;

            if (!PseudoExist(form["pseudo"].ToString()) && form["mdp"].ToString() == form["mdpConfirm"].ToString())
            {
                HttpPostedFile file = ctx.Request.Files[0];

                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(file.InputStream))
                {
                    fileData = binaryReader.ReadBytes(file.ContentLength);
                }

                utilisateur u = new utilisateur
                {
                    AVATAR = fileData,
                    MAIL = form["mail"].ToString(),
                    MDP = form["mdp"].ToString(),
                    PSEUDO = form["pseudo"].ToString(),
                };

                db.utilisateur.Add(u);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [HttpPost]
        public string UpdateUtilisateur(
            int id,
            string mdp,
            string newMail = "",
            string newMdp = "",
            string newMdpConfirm = "",
            string newPseudo = "")
        {
            try
            {
                utilisateur util;


                util = db.utilisateur.Find(id);

                if (mdp == util.MDP)
                {
                    if (newMail != "")
                        util.MAIL = newMail;
                    if (newPseudo != "")
                        util.PSEUDO = newPseudo;
                    if (newMdp != "" && newMdpConfirm != "" && newMdp == newMdpConfirm)
                        util.MDP = newMdp;
                }
                db.SaveChanges();
                return "ok";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string UpdateAvatar()
        {
            HttpContext ctx = HttpContext.Current;
            var form = ctx.Request.Form;

            HttpPostedFile file = ctx.Request.Files[0];
            byte[] avatar = null;
            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                avatar = binaryReader.ReadBytes(file.ContentLength);
            }
            return "";
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