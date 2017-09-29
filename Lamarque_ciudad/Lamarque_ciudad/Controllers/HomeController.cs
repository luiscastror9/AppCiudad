using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Lamarque_ciudad.Controllers
{
    public class HomeController : Controller
    {
        private DB_A2A1B8_netbd1Entities1 db = new DB_A2A1B8_netbd1Entities1();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Historia()
        {
            return View();
        }
        public ActionResult Servicios()
        {
            return View();
        }

        public ActionResult eventos_bd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buscar(FormCollection collection)
        {
            string val = collection["busqueda_txt"];
           List<eventos_bd> x = db.eventos_bd.Where(a=> a.descripcion.Contains(val)).ToList();
            List<servicios_bd> y = db.servicios_bd.Where(a => a.descripcion.Contains(val) || a.tipo.Contains(val) || a.nombre.Contains(val)).ToList();
            Models.resultadobusqueda res = new Models.resultadobusqueda();

            res.eventos = x;
            res.servicios = y;
            return View(res);
        }
    }
}