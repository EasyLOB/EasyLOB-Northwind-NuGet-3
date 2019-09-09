namespace EasyLOB.Mvc
{
    public class BaseMvcControllerTask : BaseMvcController
    {
        #region Properties

        protected ZOperationResult OperationResult { get; }

        #endregion Properties

        #region Methods

        public BaseMvcControllerTask()
        {
            OperationResult = new ZOperationResult();
        }

        //[HttpGet]
        //public virtual ActionResult Download(string filePath)
        //{
        //    string extension = System.IO.Path.GetExtension(filePath);
        //    ZFileTypes fileType = LibraryHelper.GetFileType(extension);

        //    return File(filePath, LibraryHelper.GetContentType(fileType), Path.GetFileName(filePath));
        //}

        protected virtual bool IsValid(ZOperationResult operationResult, IZValidatableObject entity)
        {
            entity.Validate(operationResult);

            return base.IsValid(operationResult, entity.GetType().Name);
        }

        #endregion Methods

        #region Methods Authorization

        protected bool IsTask(string task)
        {
            ZOperationResult operationResult = new ZOperationResult();

            return IsTask(task, operationResult);
        }

        protected bool IsTask(string task, ZOperationResult operationResult)
        {
            return AuthorizationManager.IsTask("", task, operationResult);
        }

        #endregion Methods Authorization
    }
}