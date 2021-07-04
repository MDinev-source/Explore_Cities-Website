namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;
    using System.Collections.Generic;

    using ResearchLocations.Data.Common.Models;
    using ResearchLocations.Data.Models.Enums;

    public class Station : BaseDeletableModel<string>
    {
        public Station()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }

        public string Opinion { get; set; }

        public StationType StationType { get; set; }

        public string RegionViewId { get; set; }

        public RegionView Region { get; set; }

        public virtual ICollection<PictureVideo> PictureVideos { get; set; }
    }
}
