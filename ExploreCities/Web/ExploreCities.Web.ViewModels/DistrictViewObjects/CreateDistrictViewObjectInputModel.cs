namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class CreateDistrictViewObjectInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Z][a-z]+\s?[A-Za-z0-9]+$")]
        [Display(Name = "Object name")]
        public string Name { get; set; }

        [Required]
        [MinLength(50)]
        [Display(Name = "Opinion")]
        public string Opinion { get; set; }

        [Required]
        [Display(Name = "Object type")]
        public DistrictObjectType ObjectType { get; set; }

        public string DistrictViewId { get; set; }

        public ICollection<IFormFile> Pictures { get; set; }
    }
}
