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
        [RegularExpression(@"^[A-Z][a-z]+\s?[A-Za-z0-9]+$")]
        [Display(Name = "Object name")]
        public string Name { get; set; }
    }
}
