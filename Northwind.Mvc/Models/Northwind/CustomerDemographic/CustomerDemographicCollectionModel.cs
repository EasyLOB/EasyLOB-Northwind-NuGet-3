using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class CustomerDemographicCollectionModel : CollectionModel
    {
        #region Methods

        public CustomerDemographicCollectionModel()
            : base()
        {
            OnConstructor();
        }

        public CustomerDemographicCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null)
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
