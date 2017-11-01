using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Net.Models;

namespace Net.Controllers
{
    public class TelefonosController : Controller
    {
        private lamarqueBDEntities db = new lamarqueBDEntities();

        // GET: Telefonos
        public ActionResult Index()
        {
            return View(db.Telefonos.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult IndexAdmin()
        {
            return View(db.Telefonos.ToList());
        }

        // GET: Telefonos/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = db.Telefonos.Find(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            return View(telefonos);
        }

        // GET: Telefonos/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Telefonos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Telefono")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                db.Telefonos.Add(telefonos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telefonos);
        }

        // GET: Telefonos/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = db.Telefonos.Find(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            return View(telefonos);
        }

        // POST: Telefonos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Telefono")] Telefonos telefonos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefonos);
        }

        // GET: Telefonos/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Telefonos telefonos = db.Telefonos.Find(id);
            if (telefonos == null)
            {
                return HttpNotFound();
            }
            return View(telefonos);
        }

        // POST: Telefonos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefonos telefonos = db.Telefonos.Find(id);
            db.Telefonos.Remove(telefonos);
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
