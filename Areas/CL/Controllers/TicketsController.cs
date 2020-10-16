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
    public class TicketsController : Controller
    {
        private DSJTICKETEntities db = new DSJTICKETEntities();

        // GET: CL/Tickets
        public ActionResult Index()
        {
            var tblTickets = db.TblTickets.Include(t => t.TblCuenta).Include(t => t.TblCuenta1).Include(t => t.TblModulo).Include(t => t.TblEstado).Include(t => t.TblPrioridad);
            return View();
        }

        // GET: CL/Tickets/Details/5
        public ActionResult DetalleTicket()
        {
            return View();
        }

        // GET: CL/Tickets/Create
        public ActionResult Create()
        {
            ViewBag.IdAgente = new SelectList(db.TblCuentas, "Id", "Correo");
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo");
            ViewBag.IdModulo = new SelectList(db.TblModulos, "Id", "Modulo");
            ViewBag.IdEstado = new SelectList(db.TblEstadoes, "Id", "Nombre");
            ViewBag.IdPrioridad = new SelectList(db.TblPrioridads, "Id", "Nombre");
            return View();
        }

        // POST: CL/Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCuenta,Titulo,Descripcion,FechaApertura,HoraApertura,FechaRevision,FechaProceso,FechaCierre,IdAgente,IdEstado,IdModulo,IdPrioridad,EsEmpleado,FechaRegistro,FechaModificacion")] TblTicket tblTicket)
        {
            if (ModelState.IsValid)
            {
                db.TblTickets.Add(tblTicket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgente = new SelectList(db.TblCuentas, "Id", "Correo", tblTicket.IdAgente);
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo", tblTicket.IdCuenta);
            ViewBag.IdModulo = new SelectList(db.TblModulos, "Id", "Modulo", tblTicket.IdModulo);
            ViewBag.IdEstado = new SelectList(db.TblEstadoes, "Id", "Nombre", tblTicket.IdEstado);
            ViewBag.IdPrioridad = new SelectList(db.TblPrioridads, "Id", "Nombre", tblTicket.IdPrioridad);
            return View(tblTicket);
        }

        // GET: CL/Tickets/Edit/5
        public ActionResult Inventario()
        {
            return View();
        }

        // POST: CL/Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdCuenta,Titulo,Descripcion,FechaApertura,HoraApertura,FechaRevision,FechaProceso,FechaCierre,IdAgente,IdEstado,IdModulo,IdPrioridad,EsEmpleado,FechaRegistro,FechaModificacion")] TblTicket tblTicket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTicket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgente = new SelectList(db.TblCuentas, "Id", "Correo", tblTicket.IdAgente);
            ViewBag.IdCuenta = new SelectList(db.TblCuentas, "Id", "Correo", tblTicket.IdCuenta);
            ViewBag.IdModulo = new SelectList(db.TblModulos, "Id", "Modulo", tblTicket.IdModulo);
            ViewBag.IdEstado = new SelectList(db.TblEstadoes, "Id", "Nombre", tblTicket.IdEstado);
            ViewBag.IdPrioridad = new SelectList(db.TblPrioridads, "Id", "Nombre", tblTicket.IdPrioridad);
            return View(tblTicket);
        }

        // GET: CL/Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TblTicket tblTicket = db.TblTickets.Find(id);
            if (tblTicket == null)
            {
                return HttpNotFound();
            }
            return View(tblTicket);
        }

        // POST: CL/Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TblTicket tblTicket = db.TblTickets.Find(id);
            db.TblTickets.Remove(tblTicket);
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
