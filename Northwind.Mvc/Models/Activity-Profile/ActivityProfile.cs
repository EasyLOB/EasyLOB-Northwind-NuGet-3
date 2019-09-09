using EasyLOB.Data;

namespace EasyLOB.Activity.Data
{
    public partial class ActivityViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("Id", isEditVisible: false);
        }

        #endregion Methods
    }
}
