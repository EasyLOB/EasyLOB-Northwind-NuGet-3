using Northwind;
using Northwind.Application;
using Northwind.Persistence;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupApplication(IUnityContainer container) // !!!
        {
            container.RegisterType(typeof(INorthwindApplication), typeof(NorthwindApplication), AppLifetimeManager);

            container.RegisterType(typeof(INorthwindGenericApplication<>), typeof(NorthwindGenericApplication<>), AppLifetimeManager);
            container.RegisterType(typeof(INorthwindGenericApplicationDTO<,>), typeof(NorthwindGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkEF), AppLifetimeManager);
            container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkLINQ2DB), AppLifetimeManager);
            //container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkNH), AppLifetimeManager);
            //container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}