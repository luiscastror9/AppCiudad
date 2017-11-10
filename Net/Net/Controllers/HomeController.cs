using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Net.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Historia()
        {
            return View();
        }

        public ActionResult Museo()
        {
            return View();
        }

        public ActionResult Fiesta_tomate()
        {
            return View();
        }

        public ActionResult Clima()
        {
            return View();
        }

        public ActionResult Imagenes()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Administracion()
        {
            return View();
        }
    }
}