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

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(FormCollection collection)
        {
            string val = collection["busqueda_contacto"];
            List<contacto_bd> z = db.contacto_bd.Where(a => a.nombre.Contains(val) || a.asunto.Contains(val)).ToList();
            Models.resultado_contacto res = new Models.resultado_contacto();
            if (String.IsNullOrEmpty(val))
            {
                return View(res);
            }

            else
            {
                res.contacto = z;
                return View(res);
            }
        }

        // GET: contacto_bd/Details/5
        [Authorize(Roles = "AdministradorGeneral")]
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
        public ActionResult Create([Bind(Include = "Id,nombre,correo,descripcion,asunto,fecha")] contacto_bd contacto_bd)
        {
            if (ModelState.IsValid)
            {
                db.contacto_bd.Add(contacto_bd);
                db.SaveChanges();
                return RedirectToAction("Enviado");
            }

            return View(contacto_bd);
        }

        // GET: contacto_bd/Edit/5
        [Authorize(Roles = "AdministradorGeneral")]
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
        public ActionResult Edit([Bind(Include = "Id,nombre,correo,descripcion,asunto,fecha")] contacto_bd contacto_bd)
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
        [Authorize(Roles = "AdministradorGeneral")]
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

        public ActionResult Enviado()
        {
            return View();
        }
    }
}
