namespace ExploreCities.Web.ViewModels.CitiesViews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ListCitiesViewModel
    {
        public string SearchString { get; set; }

        [Required]
        public string OptionSearch { get; set; }

        public IEnumerable<CitiesViewModel> AllCities { get; set; }
    }
}
