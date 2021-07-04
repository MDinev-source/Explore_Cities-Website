namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;

    using ResearchLocations.Data.Common.Models;

    public class Comment : BaseModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Text { get; set; }

        public string RegionViewId { get; set; }

        public RegionView Region { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
