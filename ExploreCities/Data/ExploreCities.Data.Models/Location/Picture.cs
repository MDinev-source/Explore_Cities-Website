namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;

    public class Picture : BaseDeletableModel<string>
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        [Required]
        public string DistrictObjectId { get; set; }

        public DistrictObject DistrictObject { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
