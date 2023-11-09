using System.Web;
using System.Web.Mvc;

namespace voluntariado2.Permissions
{
    public class ValidateSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["User"]== null)
            {
                filterContext.Result = new RedirectResult("~/Users/Login");
            }


            base.OnActionExecuting(filterContext);
        }

    }
}