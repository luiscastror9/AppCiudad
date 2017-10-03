using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lamarque_ciudad;
using DHTMLX.Scheduler;

namespace Lamarque_ciudad.Controllers
{
    public class eventos_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities1 db = new DB_A2A1B8_netbd1Entities1();

        // GET: eventos_bd
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler(this);
            scheduler.Skin = DHXScheduler.Skins.Flat;
            scheduler.Localization.Set(SchedulerLocalization.Localizations.Spanish);
            return View( scheduler);
        }

        // GET: eventos_bd/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos_bd eventos_bd = await db.eventos_bd.FindAsync(id);
            if (eventos_bd == null)
            {
                return HttpNotFound();
            }
            return View(eventos_bd);
        }

        // GET: eventos_bd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eventos_bd/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,descripcion,startDate,endDate")] eventos_bd eventos_bd)
        {
            if (ModelState.IsValid)
            {
                db.eventos_bd.Add(eventos_bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(eventos_bd);
        }

        // GET: eventos_bd/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos_bd eventos_bd = await db.eventos_bd.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,descripcion,startDate,endDate")] eventos_bd eventos_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventos_bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(eventos_bd);
        }

        // GET: eventos_bd/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            eventos_bd eventos_bd = await db.eventos_bd.FindAsync(id);
            if (eventos_bd == null)
            {
                return HttpNotFound();
            }
            return View(eventos_bd);
        }

        // POST: eventos_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            eventos_bd eventos_bd = await db.eventos_bd.FindAsync(id);
            db.eventos_bd.Remove(eventos_bd);
            await db.SaveChangesAsync();
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
