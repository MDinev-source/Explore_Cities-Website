namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEditDetailsDeleteModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Object type")]
        public string ObjectType { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Z][a-z]+\s?[A-Za-z0-9]+$")]
        [Display(Name = "Object name")]
        public string Name { get; set; }

        [Required]
        [MinLength(30)]
        [Display(Name = "Opinion")]
        public string Opinion { get; set; }

        public string UserId { get; set; }
    }
}
