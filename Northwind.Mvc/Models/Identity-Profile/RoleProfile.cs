using EasyLOB;

namespace EasyLOB.Identity.Data
{
    public partial class RoleViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("Id", isEditVisible: false);
            profile.SetProfileProperty("Discriminator", isEditVisible: false);
        }

        #endregion Methods
    }
}

