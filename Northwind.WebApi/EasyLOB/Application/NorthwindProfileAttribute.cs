using System.Web.Mvc;

namespace EasyLOB
{
    public class NorthwindProfileAttribute : ActionFilterAttribute // !!!
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}