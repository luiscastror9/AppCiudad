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
    public class complainController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: complain
        public async Task<ActionResult> Index()
        {
            return View(await db.complain_bd.ToListAsync());
        }

        // GET: complain/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complain_bd complain_bd = await db.complain_bd.FindAsync(id);
            if (complain_bd == null)
            {
                return HttpNotFound();
            }
            return View(complain_bd);
        }

        // GET: complain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: complain/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "user,photo,adr,desc,day")] complain_bd complain_bd)
        {
            if (ModelState.IsValid)
            {
                db.complain_bd.Add(complain_bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(complain_bd);
        }

        // GET: complain/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complain_bd complain_bd = await db.complain_bd.FindAsync(id);
            if (complain_bd == null)
            {
                return HttpNotFound();
            }
            return View(complain_bd);
        }

        // POST: complain/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "user,photo,adr,desc,day")] complain_bd complain_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complain_bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(complain_bd);
        }

        // GET: complain/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            complain_bd complain_bd = await db.complain_bd.FindAsync(id);
            if (complain_bd == null)
            {
                return HttpNotFound();
            }
            return View(complain_bd);
        }

        // POST: complain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            complain_bd complain_bd = await db.complain_bd.FindAsync(id);
            db.complain_bd.Remove(complain_bd);
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
