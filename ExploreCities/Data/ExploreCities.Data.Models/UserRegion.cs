﻿namespace ExploreCities.Data.Models
{
    using ExploreCities.Data.Models.Location;

    public class UserRegion
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string RegionId { get; set; }

        public Region Region { get; set; }
    }
}
