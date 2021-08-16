namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEditDetailsModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Object type")]
        public string ObjectType { get; set; }

        [Required(ErrorMessage = "The name is incorrect")]
        [MinLength(5)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9]+\s[a-zA-Z0-9]+$")]
        [Display(Name = "Object name")]
        public string Name { get; set; }
    }
}
