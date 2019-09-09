using System;

namespace EasyLOB.Mvc
{
    public partial class CollectionModel
    {
        #region Properties
            
        public virtual ZOperationResult OperationResult { get; set; }

        public virtual ZActivityOperations ActivityOperations { get; set; }

        public virtual string ControllerAction { get; set; }

        public virtual string MasterControllerAction { get; set; }

        public virtual string MasterEntity { get; set; }

        public virtual string MasterKey { get; set; }

        public virtual bool IsMasterDetail
        {
            get { return !String.IsNullOrEmpty(MasterEntity) || !String.IsNullOrEmpty(MasterKey); }
        }

        #endregion Properties

        #region Methods

        public CollectionModel()
        {
            OperationResult = new ZOperationResult();
        }

        public virtual void OnConstructor()
        {
        }

        #endregion Methods
    }
}
