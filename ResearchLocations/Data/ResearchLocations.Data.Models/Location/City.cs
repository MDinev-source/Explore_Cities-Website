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
            this.Histories = new HashSet<History>();
            this.Regions = new HashSet<RegionView>();
        }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<History> Histories { get; set; }

        public virtual ICollection<RegionView> Regions { get; set; }
    }
}
