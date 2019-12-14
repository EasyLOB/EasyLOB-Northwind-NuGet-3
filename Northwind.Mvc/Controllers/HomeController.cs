using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public class HomeController : BaseMvc
    {
        #region Methods

        public HomeController(IAuthorizationManager authorizationManager)
            : base(authorizationManager.AuthenticationManager)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        #endregion
    }
}