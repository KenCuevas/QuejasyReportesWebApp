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
    public class EstadoClientesController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: EstadoClientes
        public ActionResult Index()
        {
            return View(db.Estado_Clientes.ToList());
        }

        // GET: EstadoClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Clientes estado_Clientes = db.Estado_Clientes.Find(id);
            if (estado_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(estado_Clientes);
        }

        // GET: EstadoClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Estado,Descripcion")] Estado_Clientes estado_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Estado_Clientes.Add(estado_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estado_Clientes);
        }

        // GET: EstadoClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Clientes estado_Clientes = db.Estado_Clientes.Find(id);
            if (estado_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(estado_Clientes);
        }

        // POST: EstadoClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Estado,Descripcion")] Estado_Clientes estado_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estado_Clientes);
        }

        // GET: EstadoClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado_Clientes estado_Clientes = db.Estado_Clientes.Find(id);
            if (estado_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(estado_Clientes);
        }

        // POST: EstadoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado_Clientes estado_Clientes = db.Estado_Clientes.Find(id);
            db.Estado_Clientes.Remove(estado_Clientes);
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
