namespace ResearchLocations.Data.Models.Location
{
    using System;
    using System.Collections.Generic;

    using ResearchLocations.Data.Common.Models;

    public class Region : BaseDeletableModel<string>
    {
        public Region()
        {
            this.Id = Guid.NewGuid().ToString();

            this.RegionViews = new HashSet<RegionView>();
        }

        public string Name { get; set; }

        public string Location { get; set; }

        public int Rating { get; set; }

        public string CityId { get; set; }

        public City City { get; set; }

        public virtual ICollection<RegionView> RegionViews { get; set; }
    }
}
