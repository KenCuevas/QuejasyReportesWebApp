using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppReporteriayQuejas;

namespace WebAppReporteriayQuejas.Controllers
{
    public class EstadoReclamacionController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: EstadoReclamacion
        public ActionResult Index()
        {
            return View(db.Estado_Reclamacion.ToList());
        }

        // GET: EstadoReclamacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Reclamacion estado_Reclamacion = db.Estado_Reclamacion.Find(id);
            if (estado_Reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(estado_Reclamacion);
        }

        // GET: EstadoReclamacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoReclamacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estado_Reclamacion,Descripcion")] Estado_Reclamacion estado_Reclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Reclamacion.Add(estado_Reclamacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Reclamacion);
        }

        // GET: EstadoReclamacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Reclamacion estado_Reclamacion = db.Estado_Reclamacion.Find(id);
            if (estado_Reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(estado_Reclamacion);
        }

        // POST: EstadoReclamacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estado_Reclamacion,Descripcion")] Estado_Reclamacion estado_Reclamacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Reclamacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Reclamacion);
        }

        // GET: EstadoReclamacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Reclamacion estado_Reclamacion = db.Estado_Reclamacion.Find(id);
            if (estado_Reclamacion == null)
            {
                return HttpNotFound();
            }
            return View(estado_Reclamacion);
        }

        // POST: EstadoReclamacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Reclamacion estado_Reclamacion = db.Estado_Reclamacion.Find(id);
            db.Estado_Reclamacion.Remove(estado_Reclamacion);
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
