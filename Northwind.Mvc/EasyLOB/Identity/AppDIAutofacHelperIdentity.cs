using Autofac;
using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Persistence;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupIdentity(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<AuthenticationManagerMock>().As<IAuthenticationManager>()
            //    .InstancePerRequest();
            containerBuilder.RegisterType<AuthenticationManager>().As<IAuthenticationManager>().InstancePerDependency()
                .InstancePerRequest();

            containerBuilder.RegisterGeneric(typeof(IdentityGenericApplication<>)).As(typeof(IIdentityGenericApplication<>))
                .InstancePerRequest();
            containerBuilder.RegisterGeneric(typeof(IdentityGenericApplicationDTO<,>)).As(typeof(IIdentityGenericApplicationDTO<,>))
                .InstancePerRequest();

            // Entity Framework
            containerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>()
                .InstancePerRequest();
            containerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>))
                .InstancePerRequest();

            // NHibernate
            //containerBuilder.RegisterType<IdentityUnitOfWorkEF>().As<IIdentityUnitOfWork>()
            //    .InstancePerRequest();
            //containerBuilder.RegisterGeneric(typeof(IdentityGenericRepositoryEF<>)).As(typeof(IIdentityGenericRepository<>))
            //    .InstancePerRequest();
        }
    }
}