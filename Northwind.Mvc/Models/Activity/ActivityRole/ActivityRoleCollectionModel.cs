﻿using EasyLOB;
using EasyLOB.Mvc;

namespace EasyLOB.Activity.Mvc
{
    public partial class ActivityRoleCollectionModel : CollectionModel
    {
        #region Methods

        public ActivityRoleCollectionModel()
            : base()
        {
            OnConstructor();
        }

        public ActivityRoleCollectionModel(ZActivityOperations activityOperations, string controllerAction, string masterControllerAction = null, string masterEntity = null, string masterKey = null)
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