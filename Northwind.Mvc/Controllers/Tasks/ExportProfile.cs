using EasyLOB.Data;
using EasyLOB.Library;
using EasyLOB.Resources;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    public partial class TasksController
    {
        // GET: Tasks/ExportProfile
        [HttpGet]
        public ActionResult ExportProfile()
        {
            try
            {
                if (IsTask("ExportProfile", OperationResult))
                {
                    TaskViewModel viewModel = new TaskViewModel("Tasks", "ExportProfile", EasyLOBPresentationResources.TaskExportProfile);

                    return ZView("Task", viewModel);
                }
            }
            catch (Exception exception)
            {
                OperationResult.ParseException(exception);
            }

            return ZViewOperationResult(OperationResult);
        }

        // POST: Tasks/ExportProfile
        [HttpPost]
        public ActionResult ExportProfile(TaskViewModel viewModel)
        {
            viewModel.OperationResult.Clear();

            try
            {
                if (IsTask("ExportProfile", viewModel.OperationResult))
                {
                    if (IsValid(viewModel.OperationResult, viewModel))
                    {
                        string fileDirectory = Server.MapPath(ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Export"));
                        string filePath;

                        if (ExportProfile(viewModel.OperationResult, fileDirectory, out filePath))
                        {
                            byte[] file = System.IO.File.ReadAllBytes(filePath);

                            return File(file, LibraryHelper.GetContentType(ZFileTypes.ftXLSX), Path.GetFileName(filePath));
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                viewModel.OperationResult.ParseException(exception);
            }

            return ZView("Task", viewModel);
        }

        private bool ExportProfile(ZOperationResult operationResult, string fileDirectory,
            out string filePath)
        {
            filePath = Path.Combine(fileDirectory, "Profile.json");

            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter stream = new StreamWriter(filePath))
                using (JsonWriter writer = new JsonTextWriter(stream))
                {
                    serializer.Serialize(writer, DataHelper.Profiles);
                }
            }
            catch (Exception exception)
            {
                operationResult.ParseException(exception);
            }

            return operationResult.Ok;
        }
    }
}