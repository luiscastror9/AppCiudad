using System.Linq;
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
        public ActionResult eventos_bd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Buscar(FormCollection collection)
        {
            DB_A2A1B8_netbd1Entities1 db = new DB_A2A1B8_netbd1Entities1();
            var x = db.eventos_bd.Where(z => z.descripcion.Contains(collection["busqueda_txt"].ToString())).ToList();
            return View();
        }
    }
}