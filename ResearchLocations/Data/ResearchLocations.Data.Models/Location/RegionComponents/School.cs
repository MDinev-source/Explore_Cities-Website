namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;
    using System.Collections.Generic;

    using ResearchLocations.Data.Common.Models;

    public class School : BaseDeletableModel<string>
    {
        public School()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }

        public string Opinion { get; set; }

        public string RegionViewId { get; set; }

        public virtual RegionView Region { get; set; }

        public virtual ICollection<PictureVideo> PictureVideos { get; set; }
    }
}
