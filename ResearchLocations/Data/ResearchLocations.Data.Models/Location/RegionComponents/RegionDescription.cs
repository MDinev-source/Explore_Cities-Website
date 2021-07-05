namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ResearchLocations.Data.Common.Models;
    using ResearchLocations.Data.Models.Enums;

    public class RegionDescription : BaseDeletableModel<string>
    {
        public RegionDescription()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Pictures = new HashSet<Picture>();
        }

        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }

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

        [Required]
        public PublicTransportRating PublicTransport { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
