namespace ExploreCities.Web.ViewModels.Cities
{
    using System.ComponentModel.DataAnnotations;

    public class CitiesViewModel
    {
        public string Id { get; set; }

        [Display(Name = "City name")]
        public string Name { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "District count name")]
        public int DistrictsCount { get; set; }

        [Display(Name = "Users count")]
        public int UsersCount { get; set; }
    }
}
