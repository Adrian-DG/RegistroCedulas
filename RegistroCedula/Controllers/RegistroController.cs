using System;
using System.Collections.Generic;
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

    }
}