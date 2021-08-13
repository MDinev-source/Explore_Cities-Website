namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DistrictViewEditModel
    {
        public string Id { get; set; }

        public string DistrictName { get; set; }

        [Range(1930, 2200)]
        [Display(Name = "Arrival year")]
        public int ArrivalYear { get; set; }

        [Display(Name = "Departure year")]
        public int? DepartureYear { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        [Url]
        [Display(Name = "Image URL")]
        public string PictureUrl { get; set; }

        [Required]
        [Display(Name = "Parking Spaces")]
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
    }
}
