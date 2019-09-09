using EasyLOB.AuditTrail.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace EasyLOB.AuditTrail.Data
{
    public partial class AuditTrailConfigurationViewModel
    {
        #region Properties

        [Display(Name = "PropertyDomain", ResourceType = typeof(AuditTrailConfigurationResources))]
        //[Required]
        [StringLength(256)]
        //[Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public virtual string Domain { get; set; }

        #endregion Properties

        #region Methods

        public override void OnConstructor()
        {
            Domain = "";
            LogMode = "N";
        }

        #endregion Methods
    }
}