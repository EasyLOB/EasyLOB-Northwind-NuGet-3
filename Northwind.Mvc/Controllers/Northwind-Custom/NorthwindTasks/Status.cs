using EasyLOB.Mvc;
using EasyLOB.Resources;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Mvc
{
    public partial class NorthwindTasksController
    {
        #region Methods

        // GET: NorthwindTasks/Status
        [HttpGet]
        public ActionResult Status()
        {
            StringBuilder result = new StringBuilder();

            NorthwindTenant tenant = NorthwindMultiTenantHelper.Tenant;
            result.Append("<br /><b>Multi-Tenant Northwind</b>");
            result.Append("<br />:: URL: " + tenant.Name);

            HttpSessionStateBase session = Session;
            result.Append("<br />");
            result.Append("<br /><b>Session</b>");
            result.Append("<br />:: SessionID: " + session.SessionID);
            result.Append("<br />:: Key(s)");
            for (int i = 0; i < session.Contents.Count; i++)
            {
                string value = session[i].ToString();
                switch (session.Keys[i])
                {
                    case "EasyLOB.NorthwindMultiTenant":
                        //value = JsonConvert.SerializeObject((List<NorthwindTenant>)session[i]);
                        break;
                }

                result.Append("<br />&nbsp;&nbsp;&nbsp;" + session.Keys[i] + ": " + value);
            }

            ViewBag.Status = result.ToString();

            TaskViewModel taskViewModel = new TaskViewModel("NorthwindTasks", "Status", EasyLOBPresentationResources.TaskApplicationStatus);

            return ZView(taskViewModel);
        }

        #endregion Methods
    }
}