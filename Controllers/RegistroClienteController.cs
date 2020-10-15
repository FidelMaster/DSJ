using DSJ.Helpers;
using DSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DSJ.Controllers
{
    public class RegistroClienteController : Controller
    {
        // Instancia

        #region Instancias
        DSJTICKETEntities db = new DSJTICKETEntities();
        MetodosEncriptacion encript = new MetodosEncriptacion();
        TblCuenta cuenta = new TblCuenta();
        TblEmpresa empresa = new TblEmpresa();
        #endregion


        // GET: LOG/Registro
        [HttpGet]
        public ActionResult Toner()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Toner(string correo, string clave, string nombre, int celular, int telefono, string direccion)
        {


            try
            {

                #region CreacionDeCuenta
                cuenta.Correo = correo;
                cuenta.Clave = encript.Encriptado(clave);
                cuenta.IdRol = 2;
                cuenta.idmodulo = 2;
                db.TblCuentas.Add(cuenta);
                db.SaveChanges();

                int id = cuenta.Id;

                #endregion


                #region CreacionEmpresa
                empresa.IdClasificacion = 3;
                empresa.Nombre = nombre;
                empresa.Telefono = telefono;
                empresa.Celular = celular;
                empresa.Direccion = direccion;
                empresa.IdCuenta = id;
                db.TblEmpresas.Add(empresa);
                db.SaveChanges();

                #endregion

                #region CreandoSesion
                // almacenando sesion del cliente
                Session["IdUser"] = id;
                Session["IdEmpresa"] = empresa.Id;
                Session["Rol"] = 2;
                Session["ClasEmpresa"] = 3;
                #endregion
                return RedirectToAction("Perfil", "Toner", new { area = "CL" });
            }
            catch (Exception e)
            {

                throw e;
            }


            return View();
        }



        public ActionResult Servicio()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Servicio(string correo, string clave, string nombre, int celular, int telefono, string direccion)
        {


            try
            {

                #region CreacionDeCuenta
                cuenta.Correo = correo;
                cuenta.Clave = encript.Encriptado(clave);
                cuenta.IdRol = 1;
                cuenta.idmodulo = 1;
                db.TblCuentas.Add(cuenta);
                db.SaveChanges();

                int id = cuenta.Id;

                #endregion


                #region CreacionEmpresa
                empresa.IdClasificacion = 3;
                empresa.Nombre = nombre;
                empresa.Telefono = telefono;
                empresa.Celular = celular;
                empresa.Direccion = direccion;
                empresa.IdCuenta = id;
                db.TblEmpresas.Add(empresa);
                db.SaveChanges();

                #endregion

                #region CreandoSesion
                // almacenando sesion del cliente
                Session["IdUser"] = id;
                Session["IdEmpresa"] = empresa.Id;
                Session["Rol"] = 2;
                Session["ClasEmpresa"] = 3;
                #endregion
                return RedirectToAction("Perfil", "Toner", new { area = "CL" });
            }
            catch (Exception e)
            {

                throw e;
            }


            return View();
        }





    }
}