using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class EmployeeTerritoryDTO : ZDTOBase<EmployeeTerritoryDTO, EmployeeTerritory>
    {
        #region Properties
               
        public virtual int EmployeeId { get; set; }
               
        public virtual string TerritoryId { get; set; }

        #endregion Properties

        #region Associations (FK)

        public virtual string EmployeeLookupText { get; set; } // EmployeeId

        public virtual string TerritoryLookupText { get; set; } // TerritoryId

        #endregion Associations (FK)

        #region Methods

        public EmployeeTerritoryDTO()
        {
            OnConstructor();
        }

        public EmployeeTerritoryDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
