using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using app_ciudad;

namespace app_ciudad.Controllers
{
    public class reclamosController : Controller
    {
        private DB_A2A1B8_lamarqueBDEntities db = new DB_A2A1B8_lamarqueBDEntities();

        // GET: reclamos
        public async Task<ActionResult> Index()
        {
            return View(await db.reclamos.ToListAsync());
        }

        // GET: reclamos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamos reclamos = await db.reclamos.FindAsync(id);
            if (reclamos == null)
            {
                return HttpNotFound();
            }
            return View(reclamos);
        }

        // GET: reclamos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: reclamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Reclamos1,usuario,direccion,fecha,descripcion,foto")] reclamos reclamos)
        {
            if (ModelState.IsValid)
            {
                db.reclamos.Add(reclamos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(reclamos);
        }

        // GET: reclamos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamos reclamos = await db.reclamos.FindAsync(id);
            if (reclamos == null)
            {
                return HttpNotFound();
            }
            return View(reclamos);
        }

        // POST: reclamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Reclamos1,usuario,direccion,fecha,descripcion,foto")] reclamos reclamos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reclamos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(reclamos);
        }

        // GET: reclamos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reclamos reclamos = await db.reclamos.FindAsync(id);
            if (reclamos == null)
            {
                return HttpNotFound();
            }
            return View(reclamos);
        }

        // POST: reclamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            reclamos reclamos = await db.reclamos.FindAsync(id);
            db.reclamos.Remove(reclamos);
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
