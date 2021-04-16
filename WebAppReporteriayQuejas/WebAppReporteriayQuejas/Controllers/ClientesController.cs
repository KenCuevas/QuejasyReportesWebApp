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
    public class ClientesController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Estado_Clientes).Include(c => c.Oficinas).Include(c => c.Pais).Include(c => c.Servidor);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Estado = new SelectList(db.Estado_Clientes, "Id_Estado", "Descripcion");
            ViewBag.Id_Oficina = new SelectList(db.Oficinas, "Id_Oficina", "Descripcion");
            ViewBag.Id_Pais = new SelectList(db.Pais, "Id_Pais", "Pais_Perteneciente");
            ViewBag.Id_Servidor = new SelectList(db.Servidor, "Id_Servidor", "Identificacion");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cliente,Identificacion,Nombre,Direccion,Fecha_Creacion,Id_Estado,Id_Oficina,Id_Servidor,Provincia,Sector,Municipio,Barrio,Direccion_1,Direccion_2,Id_Pais")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Estado = new SelectList(db.Estado_Clientes, "Id_Estado", "Descripcion", clientes.Id_Estado);
            ViewBag.Id_Oficina = new SelectList(db.Oficinas, "Id_Oficina", "Descripcion", clientes.Id_Oficina);
            ViewBag.Id_Pais = new SelectList(db.Pais, "Id_Pais", "Pais_Perteneciente", clientes.Id_Pais);
            ViewBag.Id_Servidor = new SelectList(db.Servidor, "Id_Servidor", "Identificacion", clientes.Id_Servidor);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Estado = new SelectList(db.Estado_Clientes, "Id_Estado", "Descripcion", clientes.Id_Estado);
            ViewBag.Id_Oficina = new SelectList(db.Oficinas, "Id_Oficina", "Descripcion", clientes.Id_Oficina);
            ViewBag.Id_Pais = new SelectList(db.Pais, "Id_Pais", "Pais_Perteneciente", clientes.Id_Pais);
            ViewBag.Id_Servidor = new SelectList(db.Servidor, "Id_Servidor", "Identificacion", clientes.Id_Servidor);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cliente,Identificacion,Nombre,Direccion,Fecha_Creacion,Id_Estado,Id_Oficina,Id_Servidor,Provincia,Sector,Municipio,Barrio,Direccion_1,Direccion_2,Id_Pais")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Estado = new SelectList(db.Estado_Clientes, "Id_Estado", "Descripcion", clientes.Id_Estado);
            ViewBag.Id_Oficina = new SelectList(db.Oficinas, "Id_Oficina", "Descripcion", clientes.Id_Oficina);
            ViewBag.Id_Pais = new SelectList(db.Pais, "Id_Pais", "Pais_Perteneciente", clientes.Id_Pais);
            ViewBag.Id_Servidor = new SelectList(db.Servidor, "Id_Servidor", "Identificacion", clientes.Id_Servidor);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            db.Clientes.Remove(clientes);
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
