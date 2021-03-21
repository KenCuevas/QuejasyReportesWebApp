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
    public class RegionesController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: Regiones
        public ActionResult Index()
        {
            return View(db.Regiones.ToList());
        }

        // GET: Regiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = db.Regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // GET: Regiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Regiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Region,Descripcion")] Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                db.Regiones.Add(regiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regiones);
        }

        // GET: Regiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = db.Regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // POST: Regiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Region,Descripcion")] Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regiones);
        }

        // GET: Regiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = db.Regiones.Find(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // POST: Regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Regiones regiones = db.Regiones.Find(id);
            db.Regiones.Remove(regiones);
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
