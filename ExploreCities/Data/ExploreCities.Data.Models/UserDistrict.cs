namespace ExploreCities.Data.Models
{
    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Location;

    public class UserDistrict : BaseDeletableModel<string>
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string DistrictId { get; set; }

        public District District { get; set; }
    }
}
