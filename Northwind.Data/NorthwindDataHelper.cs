using EasyLOB;
using EasyLOB.Data;
using System;
using System.Reflection;

namespace Northwind.Data
{
    public static class NorthwindDataHelper
    {
        #region Methods

        public static void SetupProfiles()
        {
            Assembly dataAssembly = Assembly.GetExecutingAssembly();

            Type baseType = typeof(ZDataBase);
            Type[] types = dataAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(baseType))
                {
                    string viewModel = type.FullName + "ViewModel";
                    Type typeViewModel = dataAssembly.GetType(viewModel);

                    IZProfile profile = DataHelper.SetDataProfile(type);

                    //IZProfileProperty property;
                    switch (type.Name)
                    {
                        case "Employee":
                            profile.Collections["Employees"] = false;
                            break;
                        case "Product":
                            profile.Collections["OrderDetails"] = false;
                            break;
                    }
                }
            }
        }

        #endregion Methods
    }
}