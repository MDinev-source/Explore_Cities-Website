namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;

    using ResearchLocations.Data.Common.Models;
    using ResearchLocations.Data.Models.Enums;

    public class PictureVideo : BaseDeletableModel<string>
    {
        public PictureVideo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ObjectName { get; set; }

        public FotoType Type { get; set; }

        public string Extension { get; set; }

        public string Comment { get; set; }

        public string RegionViewId { get; set; }

        public RegionView Region { get; set; }
    }
}
