using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace voluntariado2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Complaints()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Signoff()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}