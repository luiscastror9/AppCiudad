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
    public class usersController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        // GET: users
        public async Task<ActionResult> Index()
        {
            return View(await db.people_bd.ToListAsync());
        }

     

       // GET: users/Create
        public ActionResult Create()
        {
            return View();
        }

    // GET: users/Login
    public ActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Login(FormCollection collection )
    {
       
         HttpContext.Session.Add("logged", true);

        return View("~/Views/Home/Index.cshtml");
    }

    // POST: users/Create
    // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
    // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "user,pass,name,lastname,birth,mail,id")] people_bd people_bd)
        {
            if (ModelState.IsValid)
            {
                db.people_bd.Add(people_bd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(people_bd);
        }

        // GET: users/Edit/5
        public async Task<ActionResult> Edit(int? id)
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

        // POST: users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "user,pass,name,lastname,birth,mail,id")] people_bd people_bd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(people_bd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(people_bd);
        }

        // GET: users/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            people_bd people_bd = await db.people_bd.FindAsync(id);
            db.people_bd.Remove(people_bd);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    
    }
}
