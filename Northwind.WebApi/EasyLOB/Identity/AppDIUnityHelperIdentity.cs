using EasyLOB.Identity;
using EasyLOB.Identity.Application;
using EasyLOB.Identity.Persistence;
using EasyLOB.Security;
using Unity;

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        public static void SetupIdentity(IUnityContainer container)
        {
            container.RegisterType(typeof(IAuthenticationManager), typeof(AuthenticationManagerMock), AppLifetimeManager); // Web API
            //container.RegisterType(typeof(IAuthenticationManager), typeof(AuthenticationManager), AppLifetimeManager);

            container.RegisterType(typeof(IIdentityGenericApplication<>), typeof(IdentityGenericApplication<>), AppLifetimeManager);
            container.RegisterType(typeof(IIdentityGenericApplicationDTO<,>), typeof(IdentityGenericApplicationDTO<,>), AppLifetimeManager);

            // Entity Framework
            container.RegisterType(typeof(IIdentityUnitOfWork), typeof(IdentityUnitOfWorkEF), AppLifetimeManager);
            container.RegisterType(typeof(IIdentityGenericRepository<>), typeof(IdentityGenericRepositoryEF<>), AppLifetimeManager);

            // NHibernate
            //container.RegisterType(typeof(IIdentityUnitOfWork), typeof(IdentityUnitOfWorkNH), AppLifetimeManager);
            //container.RegisterType(typeof(IIdentityGenericRepository<>), typeof(IdentityGenericRepositoryNH<>), AppLifetimeManager);
        }
    }
}