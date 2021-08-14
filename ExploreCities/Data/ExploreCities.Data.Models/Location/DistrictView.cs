namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Discussions;
    using ExploreCities.Data.Models.Enums;

    public class DistrictView : BaseDeletableModel<string>
    {
        public DistrictView()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pictures = new HashSet<Picture>();
            this.DistrictObjects = new HashSet<DistrictObject>();
            this.DistrictViewLikes = new HashSet<DistrictViewLike>();
            this.DistrictViewDislikes = new HashSet<DistrictViewDislike>();
        }

        public int ArrivalYear { get; set; }

        public int? DepartureYear { get; set; }

        [Required]
        public string DistrictId { get; set; }

        public District District { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        [Required]
        public ParkingSpacesExistence ParkingSpaces { get; set; }

        [Required]
        public ChildrenPlaygroundsExistence ChildrenPlaygrounds { get; set; }

        [Required]
        public AirPollutionRating AirPollution { get; set; }

        [Required]
        public NoiseRating Noise { get; set; }

        [Required]
        public PublicTransportRating PublicTransport { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<DistrictObject> DistrictObjects { get; set; }

        public virtual ICollection<DistrictViewLike> DistrictViewLikes { get; set; }

        public virtual ICollection<DistrictViewDislike> DistrictViewDislikes { get; set; }
    }
}
