using System.Web.Mvc;
using voluntariado2.Permissions;

namespace voluntariado2.Controllers
{
    //[ValidateSession]
    public class InterfacesController : Controller
    {
        // GET: Interfaces
        public ActionResult UserRegisterOferror()
        {
            return View();
        }
        public ActionResult UserRegisterInterested() 
        {
            return View();
        }
    }
}