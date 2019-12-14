using EasyLOB;
using EasyLOB.Application;

namespace Northwind.Application
{
    public class NorthwindGenericApplicationDTO<TEntityDTO, TEntity>
        : GenericApplicationDTO<TEntityDTO, TEntity>, INorthwindGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Methods

        public NorthwindGenericApplicationDTO(INorthwindUnitOfWork unitOfWork,
            IAuditTrailManager auditTrailManager,
            IAuthorizationManager authorizationManager)
            : base(unitOfWork, auditTrailManager, authorizationManager)
        {
        }

        #endregion Methods
    }
}