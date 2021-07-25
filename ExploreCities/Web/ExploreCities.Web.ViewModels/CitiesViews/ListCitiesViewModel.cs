namespace ExploreCities.Web.ViewModels.CitiesViews
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Web.ViewModels.Enums;

    public class ListCitiesViewModel
    {
        public string SearchString { get; set; }

        [Required]
        public string OptionSearch { get; set; }

        public CitiesSorter Sorter { get; set; }

        public IEnumerable<CitiesViewModel> AllCities { get; set; }
    }
}
