﻿using System;
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
    public class sugerenciasController : Controller
    {
        private DB_A2A1B8_lamarqueBDEntities db = new DB_A2A1B8_lamarqueBDEntities();

        // GET: sugerencias
        public async Task<ActionResult> Index()
        {
            return View(await db.sugerencia.ToListAsync());
        }

        // GET: sugerencias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sugerencia sugerencia = await db.sugerencia.FindAsync(id);
            if (sugerencia == null)
            {
                return HttpNotFound();
            }
            return View(sugerencia);
        }

        // GET: sugerencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sugerencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Sugerencias,descripcion")] sugerencia sugerencia)
        {
            if (ModelState.IsValid)
            {
                db.sugerencia.Add(sugerencia);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sugerencia);
        }

        // GET: sugerencias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sugerencia sugerencia = await db.sugerencia.FindAsync(id);
            if (sugerencia == null)
            {
                return HttpNotFound();
            }
            return View(sugerencia);
        }

        // POST: sugerencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Sugerencias,descripcion")] sugerencia sugerencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sugerencia).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sugerencia);
        }

        // GET: sugerencias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sugerencia sugerencia = await db.sugerencia.FindAsync(id);
            if (sugerencia == null)
            {
                return HttpNotFound();
            }
            return View(sugerencia);
        }

        // POST: sugerencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            sugerencia sugerencia = await db.sugerencia.FindAsync(id);
            db.sugerencia.Remove(sugerencia);
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
