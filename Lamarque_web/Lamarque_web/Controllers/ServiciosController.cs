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
    public class ServiciosController : Controller
    {
        private lamarquebdEntities db = new lamarquebdEntities();

        // GET: Servicios
        public ActionResult Index()
        {
            return View(db.servicios_bd.ToList());
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(FormCollection collection)
        {
            string val = collection["busqueda_servicios"];
            List<servicios_bd> y = db.servicios_bd.Where(a => a.Contacto.Contains(val) || a.Tipo.Contains(val) || a.Nombre.Contains(val)).ToList();

            Models.resultado_servicios res = new Models.resultado_servicios();
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

        // GET: Servicios/Details/5
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

        // GET: Servicios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Nombre,Contacto")] servicios_bd servicios_bd)
        {
            if (ModelState.IsValid)
            {
                db.servicios_bd.Add(servicios_bd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicios_bd);
        }

        // GET: Servicios/Edit/5
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

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Nombre,Contacto")] servicios_bd servicios_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios_bd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicios_bd);
        }

        // GET: Servicios/Delete/5
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

        // POST: Servicios/Delete/5
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
    }
}
