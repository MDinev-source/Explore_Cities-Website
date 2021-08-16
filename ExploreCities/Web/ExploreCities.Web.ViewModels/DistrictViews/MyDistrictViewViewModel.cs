namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    public class MyDistrictViewViewModel : DistrictViewsViewModel
    {
        [Display(Name = "City name")]
        public string CityName { get; set; }

        [Display(Name = "District name")]
        public string DistricName { get; set; }
    }
}
