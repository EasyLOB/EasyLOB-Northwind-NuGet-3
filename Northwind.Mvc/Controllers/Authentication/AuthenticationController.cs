using EasyLOB.Authentication.Resources;
using EasyLOB.Environment;
using EasyLOB.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyLOB.Authentication
{
    [Authorize]
    public class AuthenticationController : Controller
    {
        #region Fields

        private ApplicationSignInManager _signInManager;

        private ApplicationUserManager _userManager;

        #endregion Fields

        #region Properties

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            //get
            //{
            //    return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); // !?!
            //}
            get
            {
                if (_userManager == null)
                {
                    _userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var provider = new DpapiDataProtectionProvider("EasyLOB");
                    UserManager.UserTokenProvider =
                        new DataProtectorTokenProvider<EasyLOB.Identity.ApplicationUser, string>(provider.Create("UserToken")) as IUserTokenProvider<EasyLOB.Identity.ApplicationUser, string>;
                }

                return _userManager;
            }
            private set
            {
                _userManager = value;
            }
        }

        #endregion Properties

        #region Methods

        public AuthenticationController()
        {
        }

        public AuthenticationController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        // GET: /Authentication/ChangePassword
        [EasyLOBProfile]
        public ActionResult ChangePassword()
        {
            EasyLOB.IAuthenticationManager AuthenticationManager = DependencyResolver.Current.GetService<EasyLOB.IAuthenticationManager>();
            ViewBag.Menu = MenuHelper.Menu(AuthenticationManager); // !?!

            return View();
        }

        // POST: /Authentication/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EasyLOBProfile]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                //return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess }); // !?!
                return RedirectToAction("Index", "Home");
            }
            AddErrors(result);
            return View(model);
        }

        // GET: /Authentication/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        // POST: /Authentication/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = await UserManager.FindByNameAsync(model.Email); // !?!
                var user = await UserManager.FindByEmailAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Authentication", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // !?!
                await UserManager.SendEmailAsync(user.Id,
                    AppDefaults.AppName + " - " + AuthenticationResources.ForgotPassword,
                    String.Format(AuthenticationResources.ForgotPasswordEMail, callbackUrl));
                return RedirectToAction("ForgotPasswordConfirmation", "Authentication");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Authentication/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // GET: /Authentication/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            AppHelper.Logout(); // !?!

            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Authentication/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false); // !?!
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:

                    AppHelper.Login(); // !?!

                    return RedirectToLocal(returnUrl);

                case SignInStatus.LockedOut:
                    ModelState.AddModelError("", AuthenticationResources.UserLocked);
                    return View(model);

                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });

                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", AuthenticationResources.LoginInvalid);
                    return View(model);
            }
        }

        // GET: /Authentication/Logout
        public ActionResult Logout() // !?!
        {
            AppHelper.Logout(); // !?!

            AuthenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // GET: /Authentication/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        // POST: /Authentication/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //var user = await UserManager.FindByNameAsync(model.Email); // !?!
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Authentication");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Authentication");
            }
            AddErrors(result);
            return View();
        }

        // GET: /Authentication/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #endregion Methods

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private Microsoft.Owin.Security.IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion Helpers
    }
}