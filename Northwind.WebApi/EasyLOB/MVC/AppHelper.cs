using EasyLOB.Resources;
using Syncfusion.JavaScript.Models;
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

        #region Properties Syncfusion

        public static DatePickerProperties DateModel
        {
            get
            {
                DatePickerProperties dateModel = new DatePickerProperties();
                dateModel.DateFormat = PatternResources.Format_Date;
                dateModel.Locale = System.Globalization.CultureInfo.CurrentCulture.Name;
                //dateModel.Width = "120";
                dateModel.Width = "180";

                return dateModel;
            }
        }

        public static DateTimePickerProperties DateTimeModel
        {
            get
            {
                DateTimePickerProperties dateTimeModel = new DateTimePickerProperties();
                dateTimeModel.DateTimeFormat = PatternResources.Format_DateTime;
                dateTimeModel.Locale = System.Globalization.CultureInfo.CurrentCulture.Name;
                dateTimeModel.Width = "180";

                return dateTimeModel;
            }
        }

        #endregion Properties Syncfusion

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
            DIHelper.EnvironmentManager.SessionAbandon();
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