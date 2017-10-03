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
    public class contacto_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities1 db = new DB_A2A1B8_netbd1Entities1();
        public ActionResult Index()
        {
            return View();
        }
        // GET: contacto_bd
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.contacto_bd.ToListAsync());
        //}

        // GET: contacto_bd/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_bd contacto_bd = await db.contacto_bd.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,nombre,correo,descripcion,tipo")] contacto_bd contacto_bd)
        {
            if (ModelState.IsValid)
            {
                db.contacto_bd.Add(contacto_bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            return View(contacto_bd);
        }

        // GET: contacto_bd/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_bd contacto_bd = await db.contacto_bd.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,nombre,correo,descripcion,tipo")] contacto_bd contacto_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto_bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contacto_bd);
        }

        // GET: contacto_bd/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contacto_bd contacto_bd = await db.contacto_bd.FindAsync(id);
            if (contacto_bd == null)
            {
                return HttpNotFound();
            }
            return View(contacto_bd);
        }

        // POST: contacto_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            contacto_bd contacto_bd = await db.contacto_bd.FindAsync(id);
            db.contacto_bd.Remove(contacto_bd);
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
