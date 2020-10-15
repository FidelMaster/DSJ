using DSJ.Helpers;
using DSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSJ.Controllers
{
    public class CuentaController : Controller
    {

        #region Instancias
        DSJTICKETEntities db = new DSJTICKETEntities();
        MetodosEncriptacion encript = new MetodosEncriptacion();
        TblCuenta cuenta = new TblCuenta();
        
        #endregion
        // GET: Cuenta
        public ActionResult LoginToner()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginToner(string correo, string clave)
        {
            byte[] password = encript.Encriptado(clave);
            var data = db.TblCuentas.Where(s => s.Correo.Equals(correo) && s.Clave.Equals(password)).ToList();
            if (data.Count() > 0)
            {
                //Creando la Sesion
                Session["IdUser"] = data.FirstOrDefault().Id;
                return RedirectToAction("Perfil", "Toner", new { area = "CL" });
            }
            else
            {
                ViewBag.error = "Login failed";
                return RedirectToAction("Login");
            }
        }

        public ActionResult LoginAdministracion()
        {
            return View();
        }
        public ActionResult LoginServicio()
        {
            return View();
        }
    }
}