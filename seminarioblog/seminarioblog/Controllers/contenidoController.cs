using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using seminarioblog.Models;

namespace seminarioblog.Controllers
{
    public class contenidoController : Controller
    {
        //
        // GET: /contenido/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            conectorDataContext db = new conectorDataContext();
            ViewBag.id = db.usuario.OrderByDescending(a => a.id).First().id;
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(contenido content, string idUs)
        {
            if (ModelState.IsValid)
            {
                conectorDataContext db = new conectorDataContext();
                content.fecha = DateTime.Now;
                content.idUs = Convert.ToInt32(idUs);
                db.contenido.InsertOnSubmit(content);
                return RedirectToAction("exito", "contenido");
            }
            return View();
        }
    }
}
