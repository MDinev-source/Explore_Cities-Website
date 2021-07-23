namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;

    public class Region : BaseDeletableModel<string>
    {
        public Region()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RegionViews = new HashSet<RegionView>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string CityId { get; set; }

        public City City { get; set; }

        public virtual ICollection<RegionView> RegionViews { get; set; }
    }
}
