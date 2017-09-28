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

namespace Lamarque_ciudad.Controllers
{
    public class servicios_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities1 db = new DB_A2A1B8_netbd1Entities1();

        // GET: servicios_bd
        public async Task<ActionResult> Index()
        {
            return View(await db.servicios_bd.ToListAsync());
        }

        // GET: servicios_bd/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicios_bd servicios_bd = await db.servicios_bd.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,tipo,nombre,descripcion")] servicios_bd servicios_bd)
        {
            if (ModelState.IsValid)
            {
                db.servicios_bd.Add(servicios_bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(servicios_bd);
        }

        // GET: servicios_bd/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicios_bd servicios_bd = await db.servicios_bd.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,tipo,nombre,descripcion")] servicios_bd servicios_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicios_bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(servicios_bd);
        }

        // GET: servicios_bd/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicios_bd servicios_bd = await db.servicios_bd.FindAsync(id);
            if (servicios_bd == null)
            {
                return HttpNotFound();
            }
            return View(servicios_bd);
        }

        // POST: servicios_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            servicios_bd servicios_bd = await db.servicios_bd.FindAsync(id);
            db.servicios_bd.Remove(servicios_bd);
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
