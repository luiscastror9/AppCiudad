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
    public class servicios_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: servicios_bd
        public ActionResult Index()
        {
            return View(db.servicios_bd.ToList());
        }

        // GET: servicios_bd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicios_bd servicios_bd = db.servicios_bd.Find(id);
            if (servicios_bd == null)
            {
                return HttpNotFound();
            }
            return View(servicios_bd);
        }

        // GET: servicios_bd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: servicios_bd/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tipo,nombre,descripcion")] servicios_bd servicios_bd)
        {
            if (ModelState.IsValid)
            {
                db.servicios_bd.Add(servicios_bd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicios_bd);
        }

        // GET: servicios_bd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicios_bd servicios_bd = db.servicios_bd.Find(id);
            if (servicios_bd == null)
            {
                return HttpNotFound();
            }
            return View(servicios_bd);
        }

        // POST: servicios_bd/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tipo,nombre,descripcion")] servicios_bd servicios_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios_bd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicios_bd);
        }

        // GET: servicios_bd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicios_bd servicios_bd = db.servicios_bd.Find(id);
            if (servicios_bd == null)
            {
                return HttpNotFound();
            }
            return View(servicios_bd);
        }

        // POST: servicios_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicios_bd servicios_bd = db.servicios_bd.Find(id);
            db.servicios_bd.Remove(servicios_bd);
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

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(FormCollection collection)
        {
            string val = collection["busqueda_txt"];
            List<servicios_bd> y = db.servicios_bd.Where(a => a.descripcion.Contains(val) || a.tipo.Contains(val) || a.nombre.Contains(val)).ToList();

            Models.resultadobusqueda res = new Models.resultadobusqueda();
            if (String.IsNullOrEmpty(val))
            {
                return View(res);
            }

            else
            {
                res.servicios = y;
                return View(res);
            }
        }
    }
}
