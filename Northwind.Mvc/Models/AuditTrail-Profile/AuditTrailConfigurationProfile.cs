using EasyLOB;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfigurationViewModel
    {
        #region Methods

        public static void OnSetupProfile(IZProfile profile)
        {
            profile.SetProfileProperty("Domain", isGridVisible: false, isEditVisible: false);
            profile.SetProfileProperty("Entity", isGridVisible: true);
            profile.SetProfileProperty("LogMode", isGridVisible: true, editCSS: "col-md-2");
            profile.SetProfileProperty("LogOperations", isGridVisible: true);
        }

        #endregion Methods
    }
}

