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
    public class OficinasController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: Oficinas
        public ActionResult Index()
        {
            var oficinas = db.Oficinas.Include(o => o.Regiones).Include(o => o.Zonas);
            return View(oficinas.ToList());
        }

        // GET: Oficinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficinas oficinas = db.Oficinas.Find(id);
            if (oficinas == null)
            {
                return HttpNotFound();
            }
            return View(oficinas);
        }

        // GET: Oficinas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Region = new SelectList(db.Regiones, "Id_Region", "Descripcion");
            ViewBag.Id_Zonas = new SelectList(db.Zonas, "Id_Zonas", "Descripcion");
            return View();
        }

        // POST: Oficinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Oficina,Id_Zonas,Id_Region,Descripcion,Provincia,Municipio,Sector,Barrio,Direccion_1,Direccion_2")] Oficinas oficinas)
        {
            if (ModelState.IsValid)
            {
                db.Oficinas.Add(oficinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Region = new SelectList(db.Regiones, "Id_Region", "Descripcion", oficinas.Id_Region);
            ViewBag.Id_Zonas = new SelectList(db.Zonas, "Id_Zonas", "Descripcion", oficinas.Id_Zonas);
            return View(oficinas);
        }

        // GET: Oficinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficinas oficinas = db.Oficinas.Find(id);
            if (oficinas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Region = new SelectList(db.Regiones, "Id_Region", "Descripcion", oficinas.Id_Region);
            ViewBag.Id_Zonas = new SelectList(db.Zonas, "Id_Zonas", "Descripcion", oficinas.Id_Zonas);
            return View(oficinas);
        }

        // POST: Oficinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Oficina,Id_Zonas,Id_Region,Descripcion,Provincia,Municipio,Sector,Barrio,Direccion_1,Direccion_2")] Oficinas oficinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oficinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Region = new SelectList(db.Regiones, "Id_Region", "Descripcion", oficinas.Id_Region);
            ViewBag.Id_Zonas = new SelectList(db.Zonas, "Id_Zonas", "Descripcion", oficinas.Id_Zonas);
            return View(oficinas);
        }

        // GET: Oficinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oficinas oficinas = db.Oficinas.Find(id);
            if (oficinas == null)
            {
                return HttpNotFound();
            }
            return View(oficinas);
        }

        // POST: Oficinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oficinas oficinas = db.Oficinas.Find(id);
            db.Oficinas.Remove(oficinas);
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
