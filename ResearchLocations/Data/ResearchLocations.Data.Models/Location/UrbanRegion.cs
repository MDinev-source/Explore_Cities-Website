namespace ResearchLocations.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ResearchLocations.Data.Common.Models;

    public class UrbanRegion : BaseDeletableModel<string>
    {
        public UrbanRegion()
        {
            this.Id = Guid.NewGuid().ToString();

            this.RegionViews = new HashSet<RegionView>();

            this.Users = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public int? Rating { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<RegionView> RegionViews { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
