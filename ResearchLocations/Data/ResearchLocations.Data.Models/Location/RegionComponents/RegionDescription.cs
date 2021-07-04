namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;
    using System.Collections.Generic;

    using ResearchLocations.Data.Common.Models;
    using ResearchLocations.Data.Models.Enums;

    public class RegionDescription : BaseDeletableModel<string>
    {
        public RegionDescription()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }

        public string Comment { get; set; }

        public string RegionViewId { get; set; }

        public RegionView Region { get; set; }

        public StreetLightingRating StreetLighting { get; set; }

        public StreetQualityRating StreetQuality { get; set; }

        public StreetPollutionRating StreetPollution { get; set; }

        public ParkingSpacesExistense ParkingSpaces { get; set; }

        public BikeAreaExistence BikeArea { get; set; }

        public ChildrenPlaygroundsExistense ChildrenPlaygrounds { get; set; }

        public AirPollutionRating AirPollution { get; set; }

        public NoiseRating Noise { get; set; }

        public PublicTransportRating PublicTransport { get; set; }

        public virtual ICollection<PictureVideo> PictureVideos { get; set; }
    }
}
