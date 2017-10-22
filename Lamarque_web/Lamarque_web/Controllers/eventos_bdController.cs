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
    public class eventos_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: eventos_bd
        public ActionResult Index()
        {
            return View(db.eventos_bd.ToList());
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(FormCollection collection)
        {
            string val = collection["busqueda_eventos"];
            List<eventos_bd> x = db.eventos_bd.Where(a => a.descripcion.Contains(val)).ToList();
            Models.resultado_eventos res = new Models.resultado_eventos();
            if (String.IsNullOrEmpty(val))
            {
                return View(res);
            }

            else
            {
                res.eventos = x;
                return View(res);
            }
        }

        // GET: eventos_bd/Details/5
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos_bd eventos_bd = db.eventos_bd.Find(id);
            if (eventos_bd == null)
            {
                return HttpNotFound();
            }
            return View(eventos_bd);
        }

        // GET: eventos_bd/Create
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventos_bd/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion,startDate,endDate")] eventos_bd eventos_bd)
        {
            if (ModelState.IsValid)
            {
                db.eventos_bd.Add(eventos_bd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventos_bd);
        }

        // GET: eventos_bd/Edit/5
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos_bd eventos_bd = db.eventos_bd.Find(id);
            if (eventos_bd == null)
            {
                return HttpNotFound();
            }
            return View(eventos_bd);
        }

        // POST: eventos_bd/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion,startDate,endDate")] eventos_bd eventos_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos_bd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventos_bd);
        }

        // GET: eventos_bd/Delete/5
        [Authorize(Roles = "AdministradorGeneral")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos_bd eventos_bd = db.eventos_bd.Find(id);
            if (eventos_bd == null)
            {
                return HttpNotFound();
            }
            return View(eventos_bd);
        }

        // POST: eventos_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventos_bd eventos_bd = db.eventos_bd.Find(id);
            db.eventos_bd.Remove(eventos_bd);
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
