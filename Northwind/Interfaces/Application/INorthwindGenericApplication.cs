using EasyLOB;
using EasyLOB.Data;

namespace Northwind.Application
{
    public interface INorthwindGenericApplication<TEntity>
        : IGenericApplication<TEntity>
        where TEntity : class, IZDataBase
    {
    }
}
