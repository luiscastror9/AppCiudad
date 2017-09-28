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
    public class usuarios_bdController : Controller
    {
        private DB_A2A1B8_netbd1Entities1 db = new DB_A2A1B8_netbd1Entities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        // GET: usuarios_bd
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.usuarios_bd.ToListAsync());
        //}

        // GET: usuarios_bd/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios_bd usuarios_bd = await db.usuarios_bd.FindAsync(id);
            if (usuarios_bd == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_bd);
        }

        // GET: usuarios_bd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: usuarios_bd/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,usuario,contraseña,nombre,apellido,nacimiento,correo")] usuarios_bd usuarios_bd)
        {
            if (ModelState.IsValid)
            {
                db.usuarios_bd.Add(usuarios_bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(usuarios_bd);
        }

        // GET: usuarios_bd/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios_bd usuarios_bd = await db.usuarios_bd.FindAsync(id);
            if (usuarios_bd == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_bd);
        }

        // POST: usuarios_bd/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,usuario,contraseña,nombre,apellido,nacimiento,correo")] usuarios_bd usuarios_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios_bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuarios_bd);
        }

        // GET: usuarios_bd/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            usuarios_bd usuarios_bd = await db.usuarios_bd.FindAsync(id);
            if (usuarios_bd == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_bd);
        }

        // POST: usuarios_bd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            usuarios_bd usuarios_bd = await db.usuarios_bd.FindAsync(id);
            db.usuarios_bd.Remove(usuarios_bd);
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
