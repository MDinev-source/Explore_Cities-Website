namespace ExploreCities.Web.ViewModels.Cities
{
    using ExploreCities.Web.ViewModels.Enums;
    using X.PagedList;

    public class ListCitiesViewModel
    {
        public string SearchString { get; set; }

        public string OptionSearch { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public CitiesSorter Sorter { get; set; }

        public IPagedList<CitiesViewModel> AllCities { get; set; }
    }
}
