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
    public class CalidadServiciosController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: CalidadServicios
        public ActionResult Index()
        {
            return View(db.TBCalidadServicios.ToList());
        }

        // GET: CalidadServicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCalidadServicio tBCalidadServicio = db.TBCalidadServicios.Find(id);
            if (tBCalidadServicio == null)
            {
                return HttpNotFound();
            }
            return View(tBCalidadServicio);
        }

        // GET: CalidadServicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalidadServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_CalidadServicio,DescServicio")] TBCalidadServicio tBCalidadServicio)
        {
            if (ModelState.IsValid)
            {
                db.TBCalidadServicios.Add(tBCalidadServicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBCalidadServicio);
        }

        // GET: CalidadServicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCalidadServicio tBCalidadServicio = db.TBCalidadServicios.Find(id);
            if (tBCalidadServicio == null)
            {
                return HttpNotFound();
            }
            return View(tBCalidadServicio);
        }

        // POST: CalidadServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_CalidadServicio,DescServicio")] TBCalidadServicio tBCalidadServicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBCalidadServicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBCalidadServicio);
        }

        // GET: CalidadServicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBCalidadServicio tBCalidadServicio = db.TBCalidadServicios.Find(id);
            if (tBCalidadServicio == null)
            {
                return HttpNotFound();
            }
            return View(tBCalidadServicio);
        }

        // POST: CalidadServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBCalidadServicio tBCalidadServicio = db.TBCalidadServicios.Find(id);
            db.TBCalidadServicios.Remove(tBCalidadServicio);
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
