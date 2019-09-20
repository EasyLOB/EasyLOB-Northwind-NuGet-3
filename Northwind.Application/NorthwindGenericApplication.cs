using Northwind.Persistence;
using EasyLOB;
using EasyLOB.Application;
using EasyLOB.Data;

namespace Northwind.Application
{
    public class NorthwindGenericApplication<TEntity>
        : GenericApplication<TEntity>, INorthwindGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericApplication(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)            
        {
        }

        #endregion Methods
    }
}