using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;

namespace Northwind.Data
{
    public partial class CategoryDTO : ZDTOBase<CategoryDTO, Category>
    {
        #region Properties
               
        public virtual int CategoryId { get; set; }
               
        public virtual string CategoryName { get; set; }
               
        public virtual string Description { get; set; }
               
        public virtual byte[] Picture { get; set; }

        #endregion Properties

        #region Methods

        public CategoryDTO()
        {
            OnConstructor();
        }

        public CategoryDTO(IZDataBase dataModel)
        {
            FromData(dataModel);
        }
        
        #endregion Methods
    }
}
