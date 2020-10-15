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
    public class RegistroController : Controller
    {
        private DSJTICKETEntities db = new DSJTICKETEntities();

      
        
        public ActionResult Toner()
        {
                   return View();
        }

        // POST: CL/Registro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Toner(string correo, string clave, string nombre, string celular, string telefono)
        {
            if (ModelState.IsValid)
            {
                db.TblEmpresas.Add(tblEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClasificacion = new SelectList(db.TblClasificacions, "Id", "Descripcion", tblEmpresa.IdClasificacion);
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo", tblEmpresa.IdCuenta);
            return View(tblEmpresa);
        }

       

        // POST: CL/Registro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Logo,Ruc,Telefono,Celular,IdClasificacion,CreadoPor,ActualizadoPor,FechaCreacion,FechaActualizacion,IdCuenta")] TblEmpresa tblEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
