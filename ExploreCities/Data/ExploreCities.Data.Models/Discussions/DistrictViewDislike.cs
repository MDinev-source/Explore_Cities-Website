namespace ExploreCities.Data.Models.Discussions
{
    using ExploreCities.Data.Models.Location;

    public class DistrictViewDislike
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string DistrictViewId { get; set; }

        public DistrictView DistrictView { get; set; }
    }
}
