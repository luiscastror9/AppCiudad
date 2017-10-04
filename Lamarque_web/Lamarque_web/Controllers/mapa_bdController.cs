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
    public class mapa_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: mapa_bd
        public ActionResult Index()
        {
            return View(db.mapa_bd.ToList());
        }

        // GET: mapa_bd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mapa_bd mapa_bd = db.mapa_bd.Find(id);
            if (mapa_bd == null)
            {
                return HttpNotFound();
            }
            return View(mapa_bd);
        }

        // GET: mapa_bd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mapa_bd/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Latitud,Longitud")] mapa_bd mapa_bd)
        {
            if (ModelState.IsValid)
            {
                db.mapa_bd.Add(mapa_bd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapa_bd);
        }

        // GET: mapa_bd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mapa_bd mapa_bd = db.mapa_bd.Find(id);
            if (mapa_bd == null)
            {
                return HttpNotFound();
            }
            return View(mapa_bd);
        }

        // POST: mapa_bd/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Latitud,Longitud")] mapa_bd mapa_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapa_bd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapa_bd);
        }

        // GET: mapa_bd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mapa_bd mapa_bd = db.mapa_bd.Find(id);
            if (mapa_bd == null)
            {
                return HttpNotFound();
            }
            return View(mapa_bd);
        }

        // POST: mapa_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mapa_bd mapa_bd = db.mapa_bd.Find(id);
            db.mapa_bd.Remove(mapa_bd);
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
