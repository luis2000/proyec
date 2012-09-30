using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using seminarioblog.Models;

namespace seminarioblog.Controllers
{
    public class usuarioController : Controller
    {
        //
        // GET: /usuario/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(usuario newuser, string repass)
        {
            if (ModelState.IsValid)
            {
                conectorDataContext db = new conectorDataContext();
                newuser.fecha = DateTime.Now;
                db.usuario.InsertOnSubmit(newuser);
                db.SubmitChanges();
                return RedirectToAction("exito", "usuario");
            }
            return View();
        }
        public ActionResult exito()
        {
            return View();
        }
    }
}
