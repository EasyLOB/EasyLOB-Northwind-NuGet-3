using EasyLOB.Extensions.Edm;
using EasyLOB.Library;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    [Authorize]
    public class EDMController : Controller
    {
        #region Properties

        public IEdmManager EDMManager;

        #endregion Properties

        #region Methods

        public EDMController(IEdmManager edmManager)
        {
            EDMManager = edmManager;
        }

        [HttpGet]
        public ActionResult Read(string entityName, int id, string acronym)
        {            
            ZFileTypes fileType = LibraryHelper.GetFileType(acronym);
            byte[] file = EDMManager.ReadFile(entityName, id, fileType);
            string extension = LibraryHelper.GetFileExtension(fileType);

            return File(file, LibraryHelper.GetContentType(fileType), entityName + "-" + id.ToString().Trim() + extension);
        }

        #endregion Methods
    }
}