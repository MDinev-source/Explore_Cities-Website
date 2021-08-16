namespace ExploreCities.Data.Models.Discussions
{
    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Location;

    public class DistrictViewDislike : BaseDeletableModel<string>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string DistrictViewId { get; set; }

        public DistrictView DistrictView { get; set; }
    }
}
