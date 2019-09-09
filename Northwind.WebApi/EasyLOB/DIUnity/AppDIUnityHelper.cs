using EasyLOB.Environment;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

// UnityDependencyResolver :: ASP.NET MVC
// UnityHierarchicalDependencyResolver :: ASP.NET Web API

namespace EasyLOB
{
    public static partial class AppDIUnityHelper
    {
        #region Properties

        private static IUnityContainer Container { get; set; }

        private static LifetimeManager AppLifetimeManager
        {
            // A new object for every HttpRequest
            //get { return new HttpRequestLifetimeManager(); }

            // Just one Singleton for ALL connections leads to EF errors
            //get { return new ContainerControlledLifetimeManager(); }

            // Unity.Mvc5
            // All components that implement IDisposable should be registered with the HierarchicalLifetimeManager
            // to ensure that they are properly disposed at the end of the request.
            //get { return new HierarchicalLifetimeManager(); }

            // Although the PerRequestLifetimeManager class works correctly
            // and can help you to work with stateful or thread-unsafe dependencies within the scope of an HTTP request,
            // it is generally not a good idea to use it if you can avoid it.
            // ...not a good idea to use...
            //get { return new PerRequestLifetimeManager(); }

            // Just one Singleton (Single IIS Thread) for ALL connections leads to EF errors
            //get { return new PerThreadLifetimeManager(); }

            // A new object for every Resolve()
            get { return new TransientLifetimeManager(); }
        }

        #endregion Properties

        #region Methods

        public static void Setup(IUnityContainer container)
        {
            Container = container;

            //Container.RegisterType<Authentication.AuthenticationController>(new InjectionConstructor()); // Web API

            SetupActivity();
            SetupAuditTrail();
            SetupEasyLOB();
            SetupExtensions();
            SetupIdentity();
            SetupLog();

            Container.RegisterType(typeof(IDIManager), typeof(DIManager), AppLifetimeManager,
                new InjectionConstructor(Container));

            //Container.RegisterType(typeof(IEnvironmentManager), typeof(EnvironmentManagerDesktop), AppLifetimeManager);
            Container.RegisterType(typeof(IEnvironmentManager), typeof(EnvironmentManagerWeb), AppLifetimeManager);

            ManagerHelper.Setup(Container.Resolve<IDIManager>(),
                Container.Resolve<IEnvironmentManager>(),
                Container.Resolve<ILogManager>());

            //ManagerHelper.Setup(DependencyResolver.Current.GetService<IDIManager>(),
            //    DependencyResolver.Current.GetService<IEnvironmentManager>(),
            //    DependencyResolver.Current.GetService<ILogManager>());
        }

        #endregion Methods
    }
}