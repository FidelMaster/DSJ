using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSJ.Areas.CL.Controllers
{
    public class TonerController : Controller
    {
        // aqui cada metodo que anhadas son las opciones del cliente dentro del modulo
        // GET: CL/PerfilToner
        public ActionResult Perfil()
        {
            return View();
        }
    }
}