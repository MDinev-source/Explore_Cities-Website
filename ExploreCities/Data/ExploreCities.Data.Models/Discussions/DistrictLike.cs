namespace ExploreCities.Data.Models.Discussions
{
    using ExploreCities.Data.Models.Location;

    public class DistrictLike
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string DistrictId { get; set; }

        public District District { get; set; }
    }
}
