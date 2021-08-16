using System.ComponentModel.DataAnnotations;

namespace ExploreCities.Web.ViewModels.Districts
{
    public class DistrictsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "District name")]
        public string Name { get; set; }

        public string CityId { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Views count")]
        public int DistrictViewsCount { get; set; }

        [Display(Name = "Users count")]
        public int UsersCount { get; set; }
    }
}
