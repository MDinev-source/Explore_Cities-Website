namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BaseCreateEditModel : IValidatableObject
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [RegularExpression(@"^[A-Z][a-z]+\s?[A-Za-z0-9]+$")]
        [Display(Name = "District name")]
        public string DistrictName { get; set; }

        [Range(1930, 2050)]
        [Display(Name = "Arrival year")]
        public int ArrivalYear { get; set; }

        [Range(1930, 2100)]
        [Display(Name = "Departure year")]
        public int? DepartureYear { get; set; }

        [Required]
        [MinLength(30)]
        public string Comment { get; set; }

        public IFormFile Picture { get; set; }

        public string PictureUrl { get; set; }

        [Required]
        [Display(Name = "Parking spaces")]
        public string ParkingSpacesExistence { get; set; }

        [Required]
        [Display(Name = "Playgrounds")]
        public string ChildrenPlaygroundsExistence { get; set; }

        [Required]
        [Display(Name = "Air pollution")]
        public string AirPollutionRating { get; set; }

        [Required]
        [Display(Name = "Noise")]
        public string NoiseRating { get; set; }

        [Required]
        [Display(Name = "Public transport")]
        public string PublicTransportRating { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.DepartureYear != null && this.DepartureYear < this.ArrivalYear)
            {
                yield return new ValidationResult("Departure year cannot be less than arrival year");
            }
        }
    }
}
