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
    public class ServicioBrindadoesController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: ServicioBrindadoes
        public ActionResult Index()
        {
            var servicioBrindado = db.ServicioBrindado.Include(s => s.Quejas);
            return View(servicioBrindado.ToList());
        }

        // GET: ServicioBrindadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioBrindado servicioBrindado = db.ServicioBrindado.Find(id);
            if (servicioBrindado == null)
            {
                return HttpNotFound();
            }
            return View(servicioBrindado);
        }

        // GET: ServicioBrindadoes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Quejas = new SelectList(db.Quejas, "Id_Quejas", "Identificacion");
            return View();
        }

        // POST: ServicioBrindadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Id_Quejas,calidadServicio")] ServicioBrindado servicioBrindado)
        {
            if (ModelState.IsValid)
            {
                db.ServicioBrindado.Add(servicioBrindado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Quejas = new SelectList(db.Quejas, "Id_Quejas", "Identificacion", servicioBrindado.Id_Quejas);
            return View(servicioBrindado);
        }

        // GET: ServicioBrindadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioBrindado servicioBrindado = db.ServicioBrindado.Find(id);
            if (servicioBrindado == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Quejas = new SelectList(db.Quejas, "Id_Quejas", "Identificacion", servicioBrindado.Id_Quejas);
            return View(servicioBrindado);
        }

        // POST: ServicioBrindadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Id_Quejas,calidadServicio")] ServicioBrindado servicioBrindado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicioBrindado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Quejas = new SelectList(db.Quejas, "Id_Quejas", "Identificacion", servicioBrindado.Id_Quejas);
            return View(servicioBrindado);
        }

        // GET: ServicioBrindadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServicioBrindado servicioBrindado = db.ServicioBrindado.Find(id);
            if (servicioBrindado == null)
            {
                return HttpNotFound();
            }
            return View(servicioBrindado);
        }

        // POST: ServicioBrindadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServicioBrindado servicioBrindado = db.ServicioBrindado.Find(id);
            db.ServicioBrindado.Remove(servicioBrindado);
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
