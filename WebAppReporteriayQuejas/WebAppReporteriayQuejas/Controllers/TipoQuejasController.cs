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
    public class TipoQuejasController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: TipoQuejas
        public ActionResult Index()
        {
            return View(db.Tipo_Quejas.ToList());
        }

        // GET: TipoQuejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Quejas tipo_Quejas = db.Tipo_Quejas.Find(id);
            if (tipo_Quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Quejas);
        }

        // GET: TipoQuejas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoQuejas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Tipo_Quejas,Descripcion")] Tipo_Quejas tipo_Quejas)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Quejas.Add(tipo_Quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Quejas);
        }

        // GET: TipoQuejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Quejas tipo_Quejas = db.Tipo_Quejas.Find(id);
            if (tipo_Quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Quejas);
        }

        // POST: TipoQuejas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Tipo_Quejas,Descripcion")] Tipo_Quejas tipo_Quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Quejas);
        }

        // GET: TipoQuejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Quejas tipo_Quejas = db.Tipo_Quejas.Find(id);
            if (tipo_Quejas == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Quejas);
        }

        // POST: TipoQuejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Quejas tipo_Quejas = db.Tipo_Quejas.Find(id);
            db.Tipo_Quejas.Remove(tipo_Quejas);
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
