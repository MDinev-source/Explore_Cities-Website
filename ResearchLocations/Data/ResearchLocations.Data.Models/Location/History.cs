namespace ResearchLocations.Data.Models.Location
{
    using System;
    using System.Collections.Generic;

    using ResearchLocations.Data.Common.Models;
    using ResearchLocations.Data.Models.Location.RegionComponents;

    public class History : BaseDeletableModel<string>
    {
        public History()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }

        public string Title { get; set; }

        public string Text { get; set; }

        public string MaterialLinks { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }

        public string CityId { get; set; }

        public City City { get; set; }

        public ICollection<PictureVideo> PictureVideos { get; set; }
    }
}
