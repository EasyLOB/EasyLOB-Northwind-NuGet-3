using EasyLOB;

namespace Northwind.Data
{
    public partial class EmployeeTerritorieViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            //profile.SetProfileProperty("EmployeeLookupText", isGridVisible: true);
            //profile.SetProfileProperty("TerritorieLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}
