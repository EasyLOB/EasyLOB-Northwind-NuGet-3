using EasyLOB.AuditTrail;
using EasyLOB.Environment;
using EasyLOB.Security;
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
                ProfileHelper.Login(ManagerHelper.DIManager.GetService<IAuthenticationManager>(),
                    ManagerHelper.DIManager.GetService<IAuditTrailUnitOfWork>());
            }

            base.OnActionExecuting(filterContext);
        }
    }
}