using EasyLOB.Application;
using EasyLOB.Data;

namespace EasyLOB.Mvc
{
    public partial class TasksController : BaseMvcControllerTask
    {
        #region Properties

        protected IEasyLOBApplication Application { get; }

        #endregion Properties

        #region Methods

        public TasksController(IEasyLOBApplication application)
        {
            Application = application;
        }

        protected override bool IsValid(ZOperationResult operationResult, IZValidatableObject entity)
        {
            bool result = base.IsValid(operationResult, entity);

            if (!result)
            {
                operationResult.Clear(); // Html.BeginForm() + Html.ValidationSummary()
            }

            return result;
        }

        #endregion Methods
    }
}