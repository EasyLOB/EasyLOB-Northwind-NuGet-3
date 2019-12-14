using EasyLOB.Library;
using Syncfusion.EJ.Export;
using Syncfusion.JavaScript.Models;
using Syncfusion.XlsIO;
using System.Collections;
using System.IO;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public class BaseMvcController : BaseMvc
    {
        #region Properties

        protected IAuthorizationManager AuthorizationManager { get; }

        #endregion Properties

        #region Methods

        public BaseMvcController(IAuthorizationManager authorizationManager)
            : base(authorizationManager.AuthenticationManager)
        {
            AuthorizationManager = authorizationManager;
        }

        [HttpGet]
        public virtual ActionResult Download(string filePath)
        {
            string extension = System.IO.Path.GetExtension(filePath);
            ZFileTypes fileType = LibraryHelper.GetFileType(extension);

            return File(filePath, LibraryHelper.GetContentType(fileType), Path.GetFileName(filePath));
        }

        #endregion Methods

        #region Methods Syncfusion

        protected void ExportToExcel(string gridModel, IEnumerable data, string theme, string fileName)
        {
            GridProperties gridProperties = SyncfusionGrid.ModelToObject(gridModel);

            ExcelExport export = new ExcelExport();
            IWorkbook excel = export.Export(gridProperties, data, fileName, ExcelVersion.Excel2013, false, false, theme, true);
            excel.ActiveSheet.DeleteRow(1, 1);
            excel.SaveAs(fileName, ExcelSaveType.SaveAsXLS, System.Web.HttpContext.Current.Response, ExcelDownloadType.Open);
            //excel.SaveAs(fileName, ExcelSaveType.SaveAsXLS, Controller.Response, ExcelDownloadType.Open);
        }

        #endregion Methods Syncfusion
    }
}