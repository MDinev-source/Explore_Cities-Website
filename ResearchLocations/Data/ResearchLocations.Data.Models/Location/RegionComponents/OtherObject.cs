﻿namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;
    using System.Collections.Generic;

    using ResearchLocations.Data.Common.Models;

    public class OtherObject : BaseDeletableModel<string>
    {
        public OtherObject()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }

        public string Name { get; set; }

        public string RegionViewId { get; set; }

        public RegionView Region { get; set; }

        public string Opinion { get; set; }

        public virtual ICollection<PictureVideo> PictureVideos { get; set; }
    }
}