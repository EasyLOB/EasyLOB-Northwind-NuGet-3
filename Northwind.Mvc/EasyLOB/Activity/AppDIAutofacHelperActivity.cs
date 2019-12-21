using Autofac;
using EasyLOB.Activity;
using EasyLOB.Activity.Application;
using EasyLOB.Activity.Persistence;
using EasyLOB.Security;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupActivity(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<AuthorizationManagerMock>().As<IAuthorizationManager>();
            //    .InstancePerRequest();
            containerBuilder.RegisterType<AuthorizationManager>().As<IAuthorizationManager>()
                .InstancePerRequest();

            containerBuilder.RegisterGeneric(typeof(ActivityGenericApplication<>)).As(typeof(IActivityGenericApplication<>))
                .InstancePerRequest();
            containerBuilder.RegisterGeneric(typeof(ActivityGenericApplicationDTO<,>)).As(typeof(IActivityGenericApplicationDTO<,>))
                .InstancePerRequest();

            // Entity Framework
            containerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>()
                .InstancePerRequest();
            containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>))
                .InstancePerRequest();

            // LINQ to DB
            //containerBuilder.RegisterType<ActivityUnitOfWorkLINQ2DB>().As<IActivityUnitOfWork>()
            //    .InstancePerRequest();
            //containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryLINQ2DB<>)).As(typeof(IActivityGenericRepository<>))
            //    .InstancePerRequest();

            // NHibernate
            //containerBuilder.RegisterType<ActivityUnitOfWorkEF>().As<IActivityUnitOfWork>()
            //    .InstancePerRequest();
            //containerBuilder.RegisterGeneric(typeof(ActivityGenericRepositoryEF<>)).As(typeof(IActivityGenericRepository<>))
            //    .InstancePerRequest();
        }
    }
}