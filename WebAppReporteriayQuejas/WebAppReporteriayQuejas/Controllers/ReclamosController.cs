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
    public class ReclamosController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: Reclamos
        public ActionResult Index()
        {
            var reclamo = db.Reclamo.Include(r => r.Departamento_Origen).Include(r => r.Departamento_Responsable).Include(r => r.Tipo_Reclamacion).Include(r => r.Usuarios);
            return View(reclamo.ToList());
        }

        // GET: Reclamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamo.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        // GET: Reclamos/Create
        public ActionResult Create()
        {
            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion");
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion");
            ViewBag.Id_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo_Reclamacion", "Descripcion");
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre");
            return View();
        }

        // POST: Reclamos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Reclamo,Identificacion,Id_Tipo_Reclamacion,Descripcion_Reclamacion,Id_Departamento_Origen,Id_Departamento_Responsable,Id_Usuario,Fecha_Reclamacion,Hora_Reclamacion,Id_Estado_Reclamacion,Comentario_Estado")] Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {
                db.Reclamo.Add(reclamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion", reclamo.Id_Departamento_Origen);
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion", reclamo.Id_Departamento_Responsable);
            ViewBag.Id_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo_Reclamacion", "Descripcion", reclamo.Id_Tipo_Reclamacion);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", reclamo.Id_Usuario);
            return View(reclamo);
        }

        // GET: Reclamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamo.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion", reclamo.Id_Departamento_Origen);
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion", reclamo.Id_Departamento_Responsable);
            ViewBag.Id_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo_Reclamacion", "Descripcion", reclamo.Id_Tipo_Reclamacion);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", reclamo.Id_Usuario);
            return View(reclamo);
        }

        // POST: Reclamos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Reclamo,Identificacion,Id_Tipo_Reclamacion,Descripcion_Reclamacion,Id_Departamento_Origen,Id_Departamento_Responsable,Id_Usuario,Fecha_Reclamacion,Hora_Reclamacion,Id_Estado_Reclamacion,Comentario_Estado")] Reclamo reclamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion", reclamo.Id_Departamento_Origen);
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion", reclamo.Id_Departamento_Responsable);
            ViewBag.Id_Tipo_Reclamacion = new SelectList(db.Tipo_Reclamacion, "Id_Tipo_Reclamacion", "Descripcion", reclamo.Id_Tipo_Reclamacion);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", reclamo.Id_Usuario);
            return View(reclamo);
        }

        // GET: Reclamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reclamo reclamo = db.Reclamo.Find(id);
            if (reclamo == null)
            {
                return HttpNotFound();
            }
            return View(reclamo);
        }

        // POST: Reclamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reclamo reclamo = db.Reclamo.Find(id);
            db.Reclamo.Remove(reclamo);
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
