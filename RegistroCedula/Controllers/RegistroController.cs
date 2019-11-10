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

                        return RedirectToAction("RegistrarCedula");
                    }
                }
            }

            return View(admin);
        }

        /* --------------------------------------- Registrar Cedula ---------------------------- */
        [HttpGet]
        public ActionResult RegistrarCedula()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCedula(Cedula cedula)
        {
            if (ModelState.IsValid)
            {
                using (RegistroContext db = new RegistroContext())
                {
                    db.cedulas.Add(cedula);
                    db.SaveChanges();
                    return View();
                }
            }

            return View(cedula);
        }

        [HttpGet]
        public ActionResult ListaRegistros()
        {
            using(RegistroContext db = new RegistroContext())
            {
                return View(db.cedulas.ToList());
            }
        }

       [HttpGet]
        public ActionResult Edit(int ID)
        {
            RegistroContext db = new RegistroContext();
            var cd = db.cedulas.Where(c => c.ID.Equals(ID)).FirstOrDefault();
            return View(cd);
        }
        [HttpPost]
        public ActionResult Edit(Cedula cedula)
        {
            using(RegistroContext db = new RegistroContext())
            {
                var cd = db.cedulas.Where(c => c.ID.Equals(cedula.ID)).FirstOrDefault();

                cd.CedulaID = cedula.CedulaID;
                cd.Nombre = cedula.Nombre;
                cd.Apellido = cedula.Apellido;
                cd.FechaNacimiento = cedula.FechaNacimiento;
                cd.LugarNacimiento = cedula.LugarNacimiento;
                cd.GetNacionalidad = cedula.GetNacionalidad;
                cd.GetEstado = cedula.GetEstado;
                cd.GetSangre = cedula.GetSangre;
                cd.GetSexo = cedula.GetSexo;
                cd.Provincia = cedula.Provincia;
                cd.Sector = cedula.Sector;
                cd.Municipio = cedula.Municipio;
                cd.Colegio = cedula.Colegio;
                cd.Ocupacion = cedula.Ocupacion;

                db.SaveChanges();
                return RedirectToAction("ListaRegistros");
            }
        }

        [HttpGet]
        public ActionResult Details(int ID)
        {
            RegistroContext db = new RegistroContext();
            var cd = db.cedulas.Where(c => c.ID.Equals(ID)).FirstOrDefault();
            
            return View(cd);
        }
        
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            RegistroContext db = new RegistroContext();
            var cd = db.cedulas.Where(c => c.ID.Equals(ID)).FirstOrDefault();
            return View(cd);
        }
        
        [HttpPost]
        public ActionResult Delete(Cedula cedula)
        {
            RegistroContext db = new RegistroContext();
            db.cedulas.Attach(cedula);
            db.cedulas.Remove(cedula);
            db.SaveChanges();
            return RedirectToAction("ListaRegistros");
        }

        

    }
}