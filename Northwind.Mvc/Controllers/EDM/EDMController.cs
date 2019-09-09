using EasyLOB.Extensions.Edm;
using EasyLOB.Library;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    [Authorize]
    public class EDMController : Controller
    {
        [HttpGet]
        public ActionResult Read(string entityName, int id, string acronym)
        {
            IEdmManager edmManager = DependencyResolver.Current.GetService<IEdmManager>();
            ZFileTypes fileType = LibraryHelper.GetFileType(acronym);
            byte[] file = edmManager.ReadFile(entityName, id, fileType);
            string extension = LibraryHelper.GetFileExtension(fileType);

            return File(file, LibraryHelper.GetContentType(fileType), entityName + "-" + id.ToString().Trim() + extension);
        }
    }
}