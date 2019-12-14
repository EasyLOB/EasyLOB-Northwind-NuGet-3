namespace EasyLOB.WebApi
{
    public class BaseApiControllerApplicationDTO<TEntityDTO, TEntity> : BaseApiController<TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
        #region Properties

        protected override string Entity
        {
            get { return Application.Repository.Entity; }
        }

        protected IGenericApplicationDTO<TEntityDTO, TEntity> Application { get; set; }

        #endregion Properties

        #region Methods

        public BaseApiControllerApplicationDTO(IAuthorizationManager authorizationManager)
            : base(authorizationManager)
        {
        }

        #endregion Methods
    }
}