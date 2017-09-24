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
    public class peopleController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: people
        public async Task<ActionResult> Index()
        {
            return View(await db.people_bd.ToListAsync());
        }

        // GET: people/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people_bd people_bd = await db.people_bd.FindAsync(id);
            if (people_bd == null)
            {
                return HttpNotFound();
            }
            return View(people_bd);
        }

        // GET: people/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: people/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "user,photo,pass,name,lastname,birth,mail")] people_bd people_bd)
        {
            if (ModelState.IsValid)
            {
                db.people_bd.Add(people_bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(people_bd);
        }

        // GET: people/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people_bd people_bd = await db.people_bd.FindAsync(id);
            if (people_bd == null)
            {
                return HttpNotFound();
            }
            return View(people_bd);
        }

        // POST: people/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "user,photo,pass,name,lastname,birth,mail")] people_bd people_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(people_bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(people_bd);
        }

        // GET: people/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people_bd people_bd = await db.people_bd.FindAsync(id);
            if (people_bd == null)
            {
                return HttpNotFound();
            }
            return View(people_bd);
        }

        // POST: people/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            people_bd people_bd = await db.people_bd.FindAsync(id);
            db.people_bd.Remove(people_bd);
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
