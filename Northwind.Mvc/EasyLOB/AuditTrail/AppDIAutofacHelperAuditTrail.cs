using Autofac;
using EasyLOB.AuditTrail;
using EasyLOB.AuditTrail.Application;
using EasyLOB.AuditTrail.Persistence;

namespace EasyLOB
{
    public static partial class AppDIAutofacHelper
    {
        public static void SetupAuditTrail(ContainerBuilder containerBuilder)
        {
            //containerBuilder.RegisterType<AuditTrailManagerMock>().As<IAuditTrailManager>()
            //    .InstancePerRequest();
            containerBuilder.RegisterType<AuditTrailManager>().As<IAuditTrailManager>()
                .InstancePerRequest();

            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplication<>)).As(typeof(IAuditTrailGenericApplication<>))
                .InstancePerRequest();
            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericApplicationDTO<,>)).As(typeof(IAuditTrailGenericApplicationDTO<,>))
                .InstancePerRequest();

            // Entity Framework
            containerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>()
                .InstancePerRequest();
            containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>))
                .InstancePerRequest();

            // LINQ to DB
            //containerBuilder.RegisterType<AuditTrailUnitOfWorkLINQ2DB>().As<IAuditTrailUnitOfWork>()
            //    .InstancePerRequest();
            //containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryLINQ2DB<>)).As(typeof(IAuditTrailGenericRepository<>))
            //    .InstancePerRequest();

            // NHibernate
            //containerBuilder.RegisterType<AuditTrailUnitOfWorkEF>().As<IAuditTrailUnitOfWork>()
            //    .InstancePerRequest();
            //containerBuilder.RegisterGeneric(typeof(AuditTrailGenericRepositoryEF<>)).As(typeof(IAuditTrailGenericRepository<>))
            //    .InstancePerRequest();
        }
    }
}