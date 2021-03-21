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
    public class ZonasController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: Zonas
        public ActionResult Index()
        {
            return View(db.Zonas.ToList());
        }

        // GET: Zonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zonas zonas = db.Zonas.Find(id);
            if (zonas == null)
            {
                return HttpNotFound();
            }
            return View(zonas);
        }

        // GET: Zonas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Zonas,Descripcion")] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                db.Zonas.Add(zonas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zonas);
        }

        // GET: Zonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zonas zonas = db.Zonas.Find(id);
            if (zonas == null)
            {
                return HttpNotFound();
            }
            return View(zonas);
        }

        // POST: Zonas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Zonas,Descripcion")] Zonas zonas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zonas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zonas);
        }

        // GET: Zonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zonas zonas = db.Zonas.Find(id);
            if (zonas == null)
            {
                return HttpNotFound();
            }
            return View(zonas);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zonas zonas = db.Zonas.Find(id);
            db.Zonas.Remove(zonas);
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
