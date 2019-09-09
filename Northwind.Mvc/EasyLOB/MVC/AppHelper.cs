using System;
using System.Web.Mvc.Ajax;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        private static AjaxOptions _ajaxOptions;

        public static AjaxOptions AjaxOptions
        {
            get
            {
                if (_ajaxOptions == null)
                {
                    _ajaxOptions = new AjaxOptions()
                    {
                        HttpMethod = "POST",
                        InsertionMode = InsertionMode.Replace,
                        OnFailure = "zAjaxFailure",
                        OnSuccess = "zAjaxSuccess",
                        UpdateTargetId = "Ajax"
                    };
                }

                return _ajaxOptions;
            }
        }

        #endregion Properties

        #region Methods

        public static string DocumentTitle(string pageTitle, bool isMasterDetail = false)
        {
            return AppDefaults.AppName +
                (!String.IsNullOrEmpty(AppDefaults.AppVersion) ? " " + AppDefaults.AppVersion : "") +
                (!String.IsNullOrEmpty(pageTitle) ? AppDefaults.TitleSeparator + pageTitle : "");
        }

        public static void Login()
        {
        }

        public static void Logout()
        {
            ManagerHelper.EnvironmentManager.SessionAbandon();
        }

        public static string PageTitle(string entity, string action, string actionResource, bool isMasterDetail = false)
        {
            string result = "";

            if (action == "search" && isMasterDetail)
            {
                result = entity;
            }
            else
            {
                result = entity + AppDefaults.TitleSeparator + actionResource;
            }

            return result;
        }

        #endregion Methods
    }
}