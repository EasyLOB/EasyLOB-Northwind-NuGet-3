using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class CustomerDemographicDTO : ZDTOBase<CustomerDemographicDTO, CustomerDemographic>
    {
        #region Properties
               
        public virtual string CustomerTypeId { get; set; }
               
        public virtual string CustomerDesc { get; set; }

        #endregion Properties

        #region Methods

        public CustomerDemographicDTO()
        {
            OnConstructor();
        }

        public CustomerDemographicDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
