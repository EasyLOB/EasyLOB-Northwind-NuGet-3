using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class NorthwindTasksController : BaseMvcControllerTask
    {
        #region Properties

        protected INorthwindApplication Application { get; }

        #endregion Properties

        #region Methods

        public NorthwindTasksController(INorthwindApplication application)
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
 