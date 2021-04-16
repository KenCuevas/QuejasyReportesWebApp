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
    [Authorize]
    public class DepartamentoOrigenController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: DepartamentoOrigen
        public ActionResult Index()
        {
            return View(db.Departamento_Origen.ToList());
        }

        // GET: DepartamentoOrigen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento_Origen departamento_Origen = db.Departamento_Origen.Find(id);
            if (departamento_Origen == null)
            {
                return HttpNotFound();
            }
            return View(departamento_Origen);
        }

        // GET: DepartamentoOrigen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoOrigen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Departamento_Origen,Descripcion")] Departamento_Origen departamento_Origen)
        {
            if (ModelState.IsValid)
            {
                db.Departamento_Origen.Add(departamento_Origen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento_Origen);
        }

        // GET: DepartamentoOrigen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento_Origen departamento_Origen = db.Departamento_Origen.Find(id);
            if (departamento_Origen == null)
            {
                return HttpNotFound();
            }
            return View(departamento_Origen);
        }

        // POST: DepartamentoOrigen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Departamento_Origen,Descripcion")] Departamento_Origen departamento_Origen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento_Origen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento_Origen);
        }

        // GET: DepartamentoOrigen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento_Origen departamento_Origen = db.Departamento_Origen.Find(id);
            if (departamento_Origen == null)
            {
                return HttpNotFound();
            }
            return View(departamento_Origen);
        }

        // POST: DepartamentoOrigen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento_Origen departamento_Origen = db.Departamento_Origen.Find(id);
            db.Departamento_Origen.Remove(departamento_Origen);
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
