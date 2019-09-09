using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class SupplierCollectionModel : CollectionModel
    {
        #region Methods

        public SupplierCollectionModel()
            : base()
        {
            OnConstructor();
        }

        public SupplierCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null)
            : this()
        {
            ActivityOperations = activityOperations;
            ControllerAction = controllerAction;
            MasterControllerAction = masterControllerAction;
            MasterEntity = masterEntity;
            MasterKey = masterKey;
        }

        #endregion Methods
    }
}
