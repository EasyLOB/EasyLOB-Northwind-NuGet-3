namespace EasyLOB.WebApi
{
    public class BaseApiControllerPersistence<TEntity> : BaseApiController<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Properties

        protected override string Entity
        {
            get { return Repository.Entity; }
        }

        protected IUnitOfWork UnitOfWork { get; set; }

        protected IGenericRepository<TEntity> Repository { get { return UnitOfWork.GetRepository<TEntity>(); } }

        #endregion Properties
    }
}