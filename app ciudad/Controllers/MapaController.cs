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
    public class MapaController : Controller
    {
        private DB_A2A1B8_lamarqueBDEntities db = new DB_A2A1B8_lamarqueBDEntities();

        // GET: Mapa
        public async Task<ActionResult> Index()
        {
            return View(await db.mapa.ToListAsync());
        }

        // GET: Mapa/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mapa mapa = await db.mapa.FindAsync(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // GET: Mapa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mapa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "mapa1,nombre,latitud,longitud,descripcion")] mapa mapa)
        {
            if (ModelState.IsValid)
            {
                db.mapa.Add(mapa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mapa);
        }

        // GET: Mapa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mapa mapa = await db.mapa.FindAsync(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // POST: Mapa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "mapa1,nombre,latitud,longitud,descripcion")] mapa mapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mapa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mapa);
        }

        // GET: Mapa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mapa mapa = await db.mapa.FindAsync(id);
            if (mapa == null)
            {
                return HttpNotFound();
            }
            return View(mapa);
        }

        // POST: Mapa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            mapa mapa = await db.mapa.FindAsync(id);
            db.mapa.Remove(mapa);
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
