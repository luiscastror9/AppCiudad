using Lamarque_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
    }
}
