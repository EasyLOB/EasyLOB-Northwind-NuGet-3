using EasyLOB;

namespace Northwind
{
    public interface INorthwindGenericApplicationDTO<TEntityDTO, TEntity>
        : IGenericApplicationDTO<TEntityDTO, TEntity>
        where TEntityDTO : class, IZDTOBase<TEntityDTO, TEntity>
        where TEntity : class, IZDataBase
    {
    }
}
