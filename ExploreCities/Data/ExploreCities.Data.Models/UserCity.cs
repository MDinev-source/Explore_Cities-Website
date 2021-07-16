﻿namespace ExploreCities.Data.Models
{
    using ExploreCities.Data.Models.Location;

    public class UserCity
    {
        public string UserId { get; set; }

        public ApplicationUser USer { get; set; }

        public string CityId { get; set; }

        public City City { get; set; }
    }
}