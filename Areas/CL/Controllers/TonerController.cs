using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSJ.Models;

namespace DSJ.Areas.CL.Controllers
{
    public class TonerController : Controller
    {
        private DSJTICKETEntities db = new DSJTICKETEntities();

        // GET: CL/Toner
        public ActionResult Perfil()
        {
            var tblEmpresas = db.TblEmpresas.Include(t => t.TblClasificacion).Include(t => t.TblCuenta);
            return View();
        }

        // GET: CL/Toner/Details/5
        public ActionResult Historial()
        {
            var tblEmpresas = db.TblEmpresas.Include(t => t.TblClasificacion).Include(t => t.TblCuenta);
            return View(tblEmpresas.ToList());
        }

        // GET: CL/Toner/Create
        public ActionResult AbrirTicket()
        {
            ViewBag.IdClasificacion = new SelectList(db.TblClasificacions, "Id", "Descripcion");
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo");
            return View();
        }

        // POST: CL/Toner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AbrirTicket([Bind(Include = "Id,Nombre,Logo,Ruc,Telefono,Celular,IdClasificacion,CreadoPor,ActualizadoPor,FechaCreacion,FechaActualizacion,IdCuenta")] TblEmpresa tblEmpresa)
        {
            #region Test
            if (ModelState.IsValid)
            {
                db.TblEmpresas.Add(tblEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            #endregion
            ViewBag.IdClasificacion = new SelectList(db.TblClasificacions, "Id", "Descripcion", tblEmpresa.IdClasificacion);
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo", tblEmpresa.IdCuenta);
            return View(tblEmpresa);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
