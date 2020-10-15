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
    public class ServicioController : Controller
    {
        private DSJTICKETEntities db = new DSJTICKETEntities();

        // GET: CL/Servicio
        public ActionResult Perfil()
        {
            return View();
        }

        // GET: CL/Servicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblModulo tblModulo = db.TblModulos.Find(id);
            if (tblModulo == null)
            {
                return HttpNotFound();
            }
            return View(tblModulo);
        }

        // GET: CL/Servicio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CL/Servicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Modulo,FechaCreacion")] TblModulo tblModulo)
        {
            if (ModelState.IsValid)
            {
                db.TblModulos.Add(tblModulo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblModulo);
        }

        // GET: CL/Servicio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblModulo tblModulo = db.TblModulos.Find(id);
            if (tblModulo == null)
            {
                return HttpNotFound();
            }
            return View(tblModulo);
        }

        // POST: CL/Servicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Modulo,FechaCreacion")] TblModulo tblModulo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblModulo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblModulo);
        }

        // GET: CL/Servicio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblModulo tblModulo = db.TblModulos.Find(id);
            if (tblModulo == null)
            {
                return HttpNotFound();
            }
            return View(tblModulo);
        }

        // POST: CL/Servicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblModulo tblModulo = db.TblModulos.Find(id);
            db.TblModulos.Remove(tblModulo);
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
