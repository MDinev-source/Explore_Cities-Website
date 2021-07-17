﻿namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Discussions;
    using ExploreCities.Data.Models.Enums;

    public class RegionView : BaseDeletableModel<string>
    {
        public RegionView()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pictures = new HashSet<Picture>();
            this.Discussions = new HashSet<Discussion>();
            this.Objects = new HashSet<RegionObject>();
        }

        public int ArrivalYear { get; set; }

        public int? DepartureYear { get; set; }

        [Required]
        public string RegionId { get; set; }

        public Region Region { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        public string PictureUrl { get; set; }

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

        [Required]
        public BusStationDistance BusStationDistance { get; set; }

        [Required]
        public TrainStationDistance TrainStationDistance { get; set; }

        [Required]
        public MetroStationDistance MetroStationDistance { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<Discussion> Discussions { get; set; }

        public virtual ICollection<RegionObject> Objects { get; set; }
    }
}
