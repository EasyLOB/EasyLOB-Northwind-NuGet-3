using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class RegionDTO : ZDTOBase<RegionDTO, Region>
    {
        #region Properties
               
        public virtual int RegionId { get; set; }
               
        public virtual string RegionDescription { get; set; }

        #endregion Properties

        #region Methods

        public RegionDTO()
        {
            OnConstructor();
        }

        public RegionDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
