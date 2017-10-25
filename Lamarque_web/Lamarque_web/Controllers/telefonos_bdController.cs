using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lamarque_web.Models;

namespace Lamarque_web.Controllers
{
    public class telefonos_bdController : Controller
    {
        private lamarquebdEntities db = new lamarquebdEntities();

        // GET: telefonos_bd
        public ActionResult Index()
        {
            return View(db.telefonos_bd.ToList());
        }

        // GET: telefonos_bd/Details/5
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefonos_bd telefonos_bd = db.telefonos_bd.Find(id);
            if (telefonos_bd == null)
            {
                return HttpNotFound();
            }
            return View(telefonos_bd);
        }

        // GET: telefonos_bd/Create
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: telefonos_bd/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,telefono,direccion")] telefonos_bd telefonos_bd)
        {
            if (ModelState.IsValid)
            {
                db.telefonos_bd.Add(telefonos_bd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telefonos_bd);
        }

        // GET: telefonos_bd/Edit/5
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefonos_bd telefonos_bd = db.telefonos_bd.Find(id);
            if (telefonos_bd == null)
            {
                return HttpNotFound();
            }
            return View(telefonos_bd);
        }

        // POST: telefonos_bd/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,telefono,direccion")] telefonos_bd telefonos_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonos_bd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefonos_bd);
        }

        // GET: telefonos_bd/Delete/5
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            telefonos_bd telefonos_bd = db.telefonos_bd.Find(id);
            if (telefonos_bd == null)
            {
                return HttpNotFound();
            }
            return View(telefonos_bd);
        }

        // POST: telefonos_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            telefonos_bd telefonos_bd = db.telefonos_bd.Find(id);
            db.telefonos_bd.Remove(telefonos_bd);
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
