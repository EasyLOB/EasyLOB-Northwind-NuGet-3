using EasyLOB.Environment;
using EasyLOB.Resources;
using Syncfusion.JavaScript.Models.ReportViewer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

// Syncfusion Report Viewer
// http://help.syncfusion.com/aspnetmvc/reportviewer/getting-started
// http://help.syncfusion.com/aspnetmvc/reportviewer/report-controller

namespace EasyLOB.Mvc
{
    public partial class ReportsController
    {
        [HttpGet]
        public ActionResult RDL(string reportDirectory, string reportName)
        {
            OperationResultModel viewModel = new OperationResultModel();

            try
            {
                if (String.IsNullOrEmpty(reportName))
                {
                    viewModel.OperationResult.ErrorMessage = ErrorResources.RDL_Parameters;

                    return ZViewOperationResult(viewModel.OperationResult);
                }
                else
                {
                    if (!IsReport(reportDirectory, reportName, viewModel.OperationResult))
                    {
                        return ZViewOperationResult(viewModel.OperationResult);
                    }
                    else
                    {
                        ReportModelRDL reportModel = new ReportModelRDL();

                        reportModel.ReportDirectory = MultiTenantHelper.Tenant.Name + 
                            (String.IsNullOrEmpty(reportDirectory) ? "" : "/" + reportDirectory);
                        reportModel.ReportName = reportName;

                        // Parameter(s)

                        if (System.Web.HttpContext.Current.Request.QueryString.Count > 2)
                        {
                            for (int q = 2; q < System.Web.HttpContext.Current.Request.QueryString.Count; q++)
                            {
                                ReportParameter reportParameter = new ReportParameter()
                                {
                                    Name = System.Web.HttpContext.Current.Request.QueryString.AllKeys[q],
                                    Labels = new List<string>() { "" },
                                    Prompt = "",
                                    Values = new List<string>() { System.Web.HttpContext.Current.Request.QueryString[q] },
                                    Nullable = true
                                };
                                reportModel.ReportParameters.Add(reportParameter);
                            }
                        }

                        return ZView("RDL", reportModel);
                    }
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(viewModel.OperationResult);
        }
    }
}