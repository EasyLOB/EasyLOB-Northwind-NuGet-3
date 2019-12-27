using EasyLOB.AuditTrail;
using EasyLOB.Environment;
using System;
using System.Web.Mvc;

namespace EasyLOB
{
    public class EasyLOBProfileAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (String.IsNullOrEmpty(ProfileHelper.Profile.UserName))
            {
                ProfileHelper.Login(DependencyResolver.Current.GetService<IAuthenticationManager>(),
                    DependencyResolver.Current.GetService<IAuditTrailUnitOfWork>());
            }

            base.OnActionExecuting(filterContext);
        }
    }
}