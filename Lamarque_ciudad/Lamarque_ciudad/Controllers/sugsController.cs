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
    public class sugsController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: sugs
        public async Task<ActionResult> Index()
        {
            return View();
            //return View(await db.sug.ToListAsync());
        }

        // GET: sugs/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sug sug = await db.sug.FindAsync(id);
            if (sug == null)
            {
                return HttpNotFound();
            }
            return View(sug);
        }

        // GET: sugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sugs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "name,desc")] sug sug)
        {
            if (ModelState.IsValid)
            {
                db.sug.Add(sug);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sug);
        }

        // GET: sugs/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sug sug = await db.sug.FindAsync(id);
            if (sug == null)
            {
                return HttpNotFound();
            }
            return View(sug);
        }

        // POST: sugs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "name,desc")] sug sug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sug).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sug);
        }

        // GET: sugs/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sug sug = await db.sug.FindAsync(id);
            if (sug == null)
            {
                return HttpNotFound();
            }
            return View(sug);
        }

        // POST: sugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            sug sug = await db.sug.FindAsync(id);
            db.sug.Remove(sug);
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
