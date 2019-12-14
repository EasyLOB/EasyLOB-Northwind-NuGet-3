using Northwind;
using Northwind.Application;
using Northwind.Persistence;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupApplication() // !!!
        {
            Container.RegisterType(typeof(INorthwindApplication), typeof(NorthwindApplication), AppLifetimeManager);

            Container.RegisterType(typeof(INorthwindGenericApplication<>), typeof(NorthwindGenericApplication<>), AppLifetimeManager);
            Container.RegisterType(typeof(INorthwindGenericApplicationDTO<,>), typeof(NorthwindGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            Container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkEF), AppLifetimeManager);
            Container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryEF<>), AppLifetimeManager);

            // LINQ to DB
            //Container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkLINQ2DB), AppLifetimeManager);
            //Container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryLINQ2DB<>), AppLifetimeManager);

            // NHibernate
            //Container.RegisterType(typeof(INorthwindUnitOfWork), typeof(NorthwindUnitOfWorkNH), AppLifetimeManager);
            //Container.RegisterType(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}