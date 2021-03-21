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
    public class DepartamentoResponsableController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: DepartamentoResponsable
        public ActionResult Index()
        {
            return View(db.Departamento_Responsable.ToList());
        }

        // GET: DepartamentoResponsable/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento_Responsable departamento_Responsable = db.Departamento_Responsable.Find(id);
            if (departamento_Responsable == null)
            {
                return HttpNotFound();
            }
            return View(departamento_Responsable);
        }

        // GET: DepartamentoResponsable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentoResponsable/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Departamento_Responsable,Descripcion")] Departamento_Responsable departamento_Responsable)
        {
            if (ModelState.IsValid)
            {
                db.Departamento_Responsable.Add(departamento_Responsable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento_Responsable);
        }

        // GET: DepartamentoResponsable/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento_Responsable departamento_Responsable = db.Departamento_Responsable.Find(id);
            if (departamento_Responsable == null)
            {
                return HttpNotFound();
            }
            return View(departamento_Responsable);
        }

        // POST: DepartamentoResponsable/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Departamento_Responsable,Descripcion")] Departamento_Responsable departamento_Responsable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departamento_Responsable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento_Responsable);
        }

        // GET: DepartamentoResponsable/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento_Responsable departamento_Responsable = db.Departamento_Responsable.Find(id);
            if (departamento_Responsable == null)
            {
                return HttpNotFound();
            }
            return View(departamento_Responsable);
        }

        // POST: DepartamentoResponsable/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departamento_Responsable departamento_Responsable = db.Departamento_Responsable.Find(id);
            db.Departamento_Responsable.Remove(departamento_Responsable);
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
