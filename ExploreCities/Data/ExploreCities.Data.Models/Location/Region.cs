namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Region
    {
        public Region()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RegionViews = new HashSet<RegionView>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string CityId { get; set; }

        public City City { get; set; }

        public virtual ICollection<RegionView> RegionViews { get; set; }
    }
}
