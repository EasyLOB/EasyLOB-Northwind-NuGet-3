using EasyLOB.Data;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityRoleViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("RoleName", isGridVisible: true);
            profile.SetProfileProperty("Operations", isGridVisible: true);

            profile.SetProfileProperty("ActivityLookupText", isGridVisible: true);
        }

        #endregion Methods
    }
}
