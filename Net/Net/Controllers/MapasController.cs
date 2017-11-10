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
    public class MapasController : Controller
    {
        private LamarqueBDEntities db = new LamarqueBDEntities();

        // GET: Mapas
        public ActionResult Index()
        {
            return View(db.Mapa.ToList());
        }

        public ActionResult Mapa()
        {
            return View();
        }

        // GET: Mapas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // GET: Mapas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mapas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Latitud,Logintud,Nombre,Descripcion")] Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                db.Mapa.Add(mapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mapa);
        }

        // GET: Mapas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // POST: Mapas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Latitud,Logintud,Nombre,Descripcion")] Mapa mapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mapa);
        }

        // GET: Mapas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mapa mapa = db.Mapa.Find(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // POST: Mapas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mapa mapa = db.Mapa.Find(id);
            db.Mapa.Remove(mapa);
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
