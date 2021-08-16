namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Models.Enums;

    public class BaseCreateDeleteModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9]+\s[a-zA-Z0-9]+$")]
        [Display(Name = "Object name")]
        public string Name { get; set; }

        [Required]
        [MinLength(50)]
        [Display(Name = "Opinion")]
        public string Opinion { get; set; }

        [Required]
        [Display(Name = "Object type")]
        public DistrictObjectType ObjectType { get; set; }

    }
}
