using EasyLOB;
using EasyLOB.Application;

namespace Northwind.Application
{
    public class NorthwindGenericApplication<TEntity>
        : GenericApplication<TEntity>, INorthwindGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericApplication(INorthwindUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}