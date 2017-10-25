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
    public class TelefonosController : Controller
    {
        private lamarquebdEntities db = new lamarquebdEntities();

        // GET: Telefonos
        public ActionResult Index()
        {
            return View(db.telefonos_bd.ToList());
        }

        // GET: Telefonos/Details/5
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

        // GET: Telefonos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Telefonos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Telefono")] telefonos_bd telefonos_bd)
        {
            if (ModelState.IsValid)
            {
                db.telefonos_bd.Add(telefonos_bd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telefonos_bd);
        }

        // GET: Telefonos/Edit/5
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

        // POST: Telefonos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Telefono")] telefonos_bd telefonos_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonos_bd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefonos_bd);
        }

        // GET: Telefonos/Delete/5
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

        // POST: Telefonos/Delete/5
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
