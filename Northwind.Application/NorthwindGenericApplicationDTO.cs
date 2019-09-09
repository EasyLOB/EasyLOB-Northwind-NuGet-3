using Northwind.Persistence;
using EasyLOB;
using EasyLOB.Application;
using EasyLOB.Data;

namespace Northwind.Application
{
    public class NorthwindGenericApplicationDTO<TEntityDTO, TEntity>
        : GenericApplicationDTO<TEntityDTO, TEntity>, INorthwindGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericApplicationDTO(INorthwindUnitOfWork unitOfWork, IDIManager diManager)
            : base(unitOfWork, diManager)
        {
        }

        #endregion Methods
    }
}