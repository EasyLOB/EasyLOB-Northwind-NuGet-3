using AutoMapper;
using EasyLOB.Activity.Data;
using EasyLOB.AuditTrail.Data;
using EasyLOB.Data;
using EasyLOB.Identity.Data;
using Northwind.Data;
using System.Reflection;

namespace EasyLOB
{
    public static partial class AppHelper
    {
        #region Properties

        public static string[] AppPath // !!!
        {
            get
            {
                return new string[] {
                    "Northwind", // !!!
                    "Northwind-Custom", // !!!
                    "Activity",
                    "Activity-Custom",
                    "AuditTrail",
                    "AuditTrail-Custom",
                    "Authentication",
                    "Dashboards",
                    "Identity",
                    "Identity-Custom",
                    "Reports",
                    "Tasks"
                };
            }
        }

        #endregion

        #region Methods

        public static IMapper SetupMappers()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => {
                // ZDataModel <-> ZDTOModel
                // Activity
                cfg.AddProfile<ActivityDataAutoMapper>();
                // Audit Trail
                cfg.AddProfile<AuditTrailDataAutoMapper>();
                // Identity
                cfg.AddProfile<IdentityDataAutoMapper>();
                // Application
                cfg.AddProfile<NorthwindDataAutoMapper>(); // !!!

                // ZViewModel <-> ZDTOModel
                // Activity
                cfg.AddProfile<ActivityViewAutoMapper>();
                // Audit Trail
                cfg.AddProfile<AuditTrailViewAutoMapper>();
                // Identity
                cfg.AddProfile<IdentityViewAutoMapper>();
                // Application
                cfg.AddProfile<NorthwindViewAutoMapper>(); // !!!
            });

            config.CompileMappings();
            config.AssertConfigurationIsValid();

            return config.CreateMapper();
        }

        public static void SetupProfiles()
        {
            // ZDataModel
            // Activity
            DataHelper.SetupDataProfile("EasyLOB.Activity.Data");
            // Audit Trail
            DataHelper.SetupDataProfile("EasyLOB.AuditTrail.Data");
            // Identity
            DataHelper.SetupDataProfile("EasyLOB.Identity.Data");
            // Application
            DataHelper.SetupDataProfile("Northwind.Data"); // !!!

            // ZViewModel
            string viewAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            // Activity
            DataHelper.SetupViewProfile("EasyLOB.Activity.Data", viewAssemblyName);
            // Audit Trail
            DataHelper.SetupViewProfile("EasyLOB.AuditTrail.Data", viewAssemblyName);
            // Identity
            DataHelper.SetupViewProfile("EasyLOB.Identity.Data", viewAssemblyName);
            // Application
            DataHelper.SetupViewProfile("Northwind.Data", viewAssemblyName); // !!!
        }

        #endregion Methods
    }
}