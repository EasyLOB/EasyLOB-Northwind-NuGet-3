using EasyLOB;

namespace Northwind.Data
{
    public partial class TerritorieViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.Collections["EmployeeTerritories"] = false;

            //profile.SetProfileProperty("RegionLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}
