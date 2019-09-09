﻿using EasyLOB;
using EasyLOB.Mvc;

namespace Northwind.Mvc
{
    public partial class CategoryCollectionModel : CollectionModel
    {
        #region Methods

        public CategoryCollectionModel()
            : base()
        {
            OnConstructor();
        }

        public CategoryCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null)
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
