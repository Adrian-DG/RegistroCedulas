using RegistroCedula.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegistroCedula.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }

        /* --------------- Crear Administrador ---------------- */ 
        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(Administrador admin)
        {
            if (ModelState.IsValid)
            {
                using (RegistroContext db = new RegistroContext())
                {
                    db.administradors.Add(admin);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }

            return View(admin);
        }

        /* ------------------------------- Ingresar como administrador ------------------------------- */
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Administrador admin)
        {
            if (ModelState.IsValid)
            {
                using(RegistroContext db = new RegistroContext())
                {
                    var row = db.administradors.Where(a => a.Usuario.Equals(admin.Usuario) && a.Clave.Equals(admin.Clave)).FirstOrDefault();
                    if(row != null)
                    {
                        Session["AdminID"] = admin.AdminID.ToString();
                        Session["Usuario"] = admin.Usuario.ToString();

                        return RedirectToAction("Index");
                    }
                }
            }

            return View(admin);
        }

        /* --------------------------------------- Registrar Cedula ---------------------------- */
       
    }
}