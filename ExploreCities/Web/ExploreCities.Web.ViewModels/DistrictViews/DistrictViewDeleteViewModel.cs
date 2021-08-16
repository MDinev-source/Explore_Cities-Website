namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    public class DistrictViewDeleteViewModel : BasePropertiesModel
    {
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "City name")]
        public string CityName { get; set; }
    }
}
