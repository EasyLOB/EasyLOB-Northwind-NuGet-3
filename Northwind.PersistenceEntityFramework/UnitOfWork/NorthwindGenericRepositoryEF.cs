using EasyLOB;
using EasyLOB.Data;
using EasyLOB.Persistence;

namespace Northwind.Persistence
{
    public class NorthwindGenericRepositoryEF<TEntity> : GenericRepositoryEF<TEntity>, INorthwindGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericRepositoryEF(INorthwindUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            Context = (unitOfWork as NorthwindUnitOfWorkEF).Context;
        }

        #endregion Methods
    }
}

