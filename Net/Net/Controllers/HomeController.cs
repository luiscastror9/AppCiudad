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

        public ActionResult Mapa()
        {
            return View();
        }

        public ActionResult Clima()
        {
            return View();
        }

        public ActionResult Historia()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Panel()
        {
            return View();
        }
    }
}