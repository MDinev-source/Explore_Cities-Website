namespace ResearchLocations.Data.Models.Location
{
    using System;
    using System.Collections.Generic;

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

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<CityHistory> Histories { get; set; }

        public virtual ICollection<RegionView> Regions { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
