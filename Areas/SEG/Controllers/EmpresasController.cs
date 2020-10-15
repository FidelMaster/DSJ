using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DSJ.Models;

namespace DSJ.Areas.SEG.Controllers
{
    public class EmpresasController : Controller
    {
        private DSJTICKETEntities db = new DSJTICKETEntities();

        // GET: SEG/Empresas
        public ActionResult Index()
        {
            var tblEmpresas = db.TblEmpresas.Include(t => t.TblClasificacion).Include(t => t.TblCuenta);
            return View(tblEmpresas.ToList());
        }

        // GET: SEG/Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresa tblEmpresa = db.TblEmpresas.Find(id);
            if (tblEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresa);
        }

        // GET: SEG/Empresas/Create
        public ActionResult Create()
        {
            ViewBag.IdClasificacion = new SelectList(db.TblClasificacions, "Id", "Descripcion");
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo");
            return View();
        }

        // POST: SEG/Empresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Logo,Ruc,Telefono,Celular,IdClasificacion,CreadoPor,ActualizadoPor,FechaCreacion,FechaActualizacion,IdCuenta")] TblEmpresa tblEmpresa)
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

        // GET: SEG/Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresa tblEmpresa = db.TblEmpresas.Find(id);
            if (tblEmpresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClasificacion = new SelectList(db.TblClasificacions, "Id", "Descripcion", tblEmpresa.IdClasificacion);
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo", tblEmpresa.IdCuenta);
            return View(tblEmpresa);
        }

        // POST: SEG/Empresas/Edit/5
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

        // GET: SEG/Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblEmpresa tblEmpresa = db.TblEmpresas.Find(id);
            if (tblEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(tblEmpresa);
        }

        // POST: SEG/Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblEmpresa tblEmpresa = db.TblEmpresas.Find(id);
            db.TblEmpresas.Remove(tblEmpresa);
            db.SaveChanges();
            return RedirectToAction("Index");
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
