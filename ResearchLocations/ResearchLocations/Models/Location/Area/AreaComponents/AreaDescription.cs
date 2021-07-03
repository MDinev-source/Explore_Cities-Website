namespace ResearchLocations.Models.Location.Area.AreaComponents
{
    using System;
    using System.Collections.Generic;
    using ResearchLocations.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    public class AreaDescription
    {
        public AreaDescription()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdateOn { get; set; }

        [Required]
        public StreetLightingRating StreetLighting { get; set; }

        [Required]
        public StreetQualityRating StreetQuality { get; set; }

        [Required]
        public StreetPollutionRating StreetPollution { get; set; }

        [Required]
        public ParkingSpacesExistense ParkingSpaces { get; set; }

        [Required]
        public BikeAreaExistence BikeArea { get; set; }

        [Required]
        public ChildrenPlaygroundsExistense ChildrenPlaygrounds { get; set; }

        [Required]
        public AirPollutionRating AirPollution { get; set; }

        [Required]
        public NoiseRating Noise { get; set; }

        public virtual ICollection<PictureVideo> PictureVideos { get; set; }
    }
}
