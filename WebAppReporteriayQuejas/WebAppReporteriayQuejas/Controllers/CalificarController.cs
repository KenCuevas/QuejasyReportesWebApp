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
    public class CalificarController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: Calificar
        public ActionResult Index()
        {
            var calidads = db.Calidads.Include(c => c.TBCalidadServicio).Include(c => c.Usuario);
            return View(calidads.ToList());
        }

        // GET: Calificar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calidad calidad = db.Calidads.Find(id);
            if (calidad == null)
            {
                return HttpNotFound();
            }
            return View(calidad);
        }

        // GET: Calificar/Create
        public ActionResult Create()
        {
            ViewBag.Id_CalidadServicio = new SelectList(db.TBCalidadServicios, "Id_CalidadServicio", "DescServicio");
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre");
            return View();
        }

        // POST: Calificar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_tiposervicio,DescripcionServicio,Id_CalidadServicio,Id_Usuario")] Calidad calidad)
        {
            if (ModelState.IsValid)
            {
                db.Calidads.Add(calidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_CalidadServicio = new SelectList(db.TBCalidadServicios, "Id_CalidadServicio", "DescServicio", calidad.Id_CalidadServicio);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", calidad.Id_Usuario);
            return View(calidad);
        }

        // GET: Calificar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calidad calidad = db.Calidads.Find(id);
            if (calidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_CalidadServicio = new SelectList(db.TBCalidadServicios, "Id_CalidadServicio", "DescServicio", calidad.Id_CalidadServicio);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", calidad.Id_Usuario);
            return View(calidad);
        }

        // POST: Calificar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_tiposervicio,DescripcionServicio,Id_CalidadServicio,Id_Usuario")] Calidad calidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_CalidadServicio = new SelectList(db.TBCalidadServicios, "Id_CalidadServicio", "DescServicio", calidad.Id_CalidadServicio);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", calidad.Id_Usuario);
            return View(calidad);
        }

        // GET: Calificar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calidad calidad = db.Calidads.Find(id);
            if (calidad == null)
            {
                return HttpNotFound();
            }
            return View(calidad);
        }

        // POST: Calificar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calidad calidad = db.Calidads.Find(id);
            db.Calidads.Remove(calidad);
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
