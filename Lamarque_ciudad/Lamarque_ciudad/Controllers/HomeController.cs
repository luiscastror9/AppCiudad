using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lamarque_ciudad.Controllers
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
        public ActionResult Servicios()
        {
            return View();
        }

        public ActionResult eventos_bd()
        {
            return View();
        }
    }
}