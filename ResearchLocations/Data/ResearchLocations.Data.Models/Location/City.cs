namespace ResearchLocations.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ResearchLocations.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Histories = new HashSet<CityHistory>();
            this.Regions = new HashSet<RegionView>();
            this.Users = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Region { get; set; }

        public virtual ICollection<CityHistory> Histories { get; set; }

        public virtual ICollection<RegionView> Regions { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
