using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public class HomeController : BaseMvc
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}