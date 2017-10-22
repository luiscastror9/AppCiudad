using Lamarque_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Lamarque_web.Controllers
{
    public class HomeController : Controller
    {
        private DB_A2A1B8_netbd1Entities db = new DB_A2A1B8_netbd1Entities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Historia()
        {
            return View();
        }

        [Authorize]
        public ActionResult Panel()
        {
            if (User.Identity.IsAuthenticated)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var IdUsuarioActual = User.Identity.GetUserId();

                    var roleManager = new RoleManager<IdentityRole>
                        (new RoleStore<IdentityRole>(db));

                    //Creo un rol
                    var resultado = roleManager.Create(new IdentityRole("AdministradorGeneral"));

                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                    //Agregar usuario al rol
                    resultado = userManager.AddToRole(IdUsuarioActual, "AdministradorGeneral");

                    //Usuario esta en rol?
                }

            }
            return View();
        }

        public ActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(FormCollection collection)
        {
            string val = collection["busqueda_txt"];
            List<eventos_bd> x = db.eventos_bd.Where(a => a.descripcion.Contains(val)).ToList();
            List<servicios_bd> y = db.servicios_bd.Where(a => a.descripcion.Contains(val) || a.tipo.Contains(val) || a.nombre.Contains(val)).ToList();

            Models.resultadobusqueda res = new Models.resultadobusqueda();
            if (String.IsNullOrEmpty(val))
            {
                return View(res);
            }

            else {
                res.eventos = x;
                res.servicios = y;
                return View(res);
            }
        }

        public ActionResult Mapa()
        {
            return View();
        }

        public ActionResult Clima()
        {
            return View();
        }

        public ActionResult Telefonos()
        {
            return View();
        }
    }
}
