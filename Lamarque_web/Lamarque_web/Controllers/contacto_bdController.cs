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
    public class contacto_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: contacto_bd
        public ActionResult Index()
        {
            return View(db.contacto_bd.ToList());
        }

        // GET: contacto_bd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_bd contacto_bd = db.contacto_bd.Find(id);
            if (contacto_bd == null)
            {
                return HttpNotFound();
            }
            return View(contacto_bd);
        }

        // GET: contacto_bd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: contacto_bd/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nombre,correo,descripcion,tipo,asunto")] contacto_bd contacto_bd)
        {
            if (ModelState.IsValid)
            {
                db.contacto_bd.Add(contacto_bd);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(contacto_bd);
        }

        // GET: contacto_bd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_bd contacto_bd = db.contacto_bd.Find(id);
            if (contacto_bd == null)
            {
                return HttpNotFound();
            }
            return View(contacto_bd);
        }

        // POST: contacto_bd/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nombre,correo,descripcion,tipo,asunto")] contacto_bd contacto_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto_bd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacto_bd);
        }

        // GET: contacto_bd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_bd contacto_bd = db.contacto_bd.Find(id);
            if (contacto_bd == null)
            {
                return HttpNotFound();
            }
            return View(contacto_bd);
        }

        // POST: contacto_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contacto_bd contacto_bd = db.contacto_bd.Find(id);
            db.contacto_bd.Remove(contacto_bd);
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
