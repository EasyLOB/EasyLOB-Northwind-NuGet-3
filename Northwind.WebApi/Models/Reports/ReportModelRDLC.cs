using Syncfusion.JavaScript.Models.ReportViewer;
using System.Collections.Generic;

namespace EasyLOB.Mvc
{
    public class ReportModelRDLC
    {
        public ZOperationResult OperationResult { get; set; }

        public string ReportDirectory { get; set; }

        public string ReportName { get; set; }

        public List<ReportParameter> ReportParameters { get; set; }

        public ReportModelRDLC()
        {
            OperationResult = new ZOperationResult();
            ReportParameters = new List<ReportParameter>();
        }
    }
}