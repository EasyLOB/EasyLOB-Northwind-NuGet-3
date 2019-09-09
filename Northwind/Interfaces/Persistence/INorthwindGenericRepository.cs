using EasyLOB;
using EasyLOB.Data;

namespace Northwind.Persistence
{
    public interface INorthwindGenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}
