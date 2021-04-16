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
    public class QuejasController : Controller
    {
        private AppReportesyQuejasEntities db = new AppReportesyQuejasEntities();

        // GET: Quejas
        public ActionResult Index()
        {
            var quejas = db.Quejas.Include(q => q.Departamento_Origen).Include(q => q.Departamento_Responsable).Include(q => q.Estado_Reclamacion).Include(q => q.Tipo_Quejas).Include(q => q.Usuarios);
            return View(quejas.ToList());
        }

        // GET: Quejas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quejas quejas = db.Quejas.Find(id);
            if (quejas == null)
            {
                return HttpNotFound();
            }
            return View(quejas);
        }

        // GET: Quejas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion");
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion");
            ViewBag.Id_Estado_Reclamacion = new SelectList(db.Estado_Reclamacion, "Id_Estado_Reclamacion", "Descripcion");
            ViewBag.Id_Tipo_Quejas = new SelectList(db.Tipo_Quejas, "Id_Tipo_Quejas", "Descripcion");
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre");
            return View();
        }

        // POST: Quejas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Quejas,Identificacion,Id_Tipo_Quejas,Descripcion_Quejas,Id_Departamento_Origen,Id_Departamento_Responsable,Id_Usuario,Fecha_Queja,Hora_Queja,Id_Estado_Reclamacion,Comentario_Estado")] Quejas quejas)
        {
            if (ModelState.IsValid)
            {
                db.Quejas.Add(quejas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion", quejas.Id_Departamento_Origen);
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion", quejas.Id_Departamento_Responsable);
            ViewBag.Id_Estado_Reclamacion = new SelectList(db.Estado_Reclamacion, "Id_Estado_Reclamacion", "Descripcion", quejas.Id_Estado_Reclamacion);
            ViewBag.Id_Tipo_Quejas = new SelectList(db.Tipo_Quejas, "Id_Tipo_Quejas", "Descripcion", quejas.Id_Tipo_Quejas);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", quejas.Id_Usuario);
            return View(quejas);
        }

        // GET: Quejas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quejas quejas = db.Quejas.Find(id);
            if (quejas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion", quejas.Id_Departamento_Origen);
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion", quejas.Id_Departamento_Responsable);
            ViewBag.Id_Estado_Reclamacion = new SelectList(db.Estado_Reclamacion, "Id_Estado_Reclamacion", "Descripcion", quejas.Id_Estado_Reclamacion);
            ViewBag.Id_Tipo_Quejas = new SelectList(db.Tipo_Quejas, "Id_Tipo_Quejas", "Descripcion", quejas.Id_Tipo_Quejas);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", quejas.Id_Usuario);
            return View(quejas);
        }

        // POST: Quejas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Quejas,Identificacion,Id_Tipo_Quejas,Descripcion_Quejas,Id_Departamento_Origen,Id_Departamento_Responsable,Id_Usuario,Fecha_Queja,Hora_Queja,Id_Estado_Reclamacion,Comentario_Estado")] Quejas quejas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quejas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Departamento_Origen = new SelectList(db.Departamento_Origen, "Id_Departamento_Origen", "Descripcion", quejas.Id_Departamento_Origen);
            ViewBag.Id_Departamento_Responsable = new SelectList(db.Departamento_Responsable, "Id_Departamento_Responsable", "Descripcion", quejas.Id_Departamento_Responsable);
            ViewBag.Id_Estado_Reclamacion = new SelectList(db.Estado_Reclamacion, "Id_Estado_Reclamacion", "Descripcion", quejas.Id_Estado_Reclamacion);
            ViewBag.Id_Tipo_Quejas = new SelectList(db.Tipo_Quejas, "Id_Tipo_Quejas", "Descripcion", quejas.Id_Tipo_Quejas);
            ViewBag.Id_Usuario = new SelectList(db.Usuarios, "Id_Usuario", "Nombre", quejas.Id_Usuario);
            return View(quejas);
        }

        // GET: Quejas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quejas quejas = db.Quejas.Find(id);
            if (quejas == null)
            {
                return HttpNotFound();
            }
            return View(quejas);
        }

        // POST: Quejas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quejas quejas = db.Quejas.Find(id);
            db.Quejas.Remove(quejas);
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
