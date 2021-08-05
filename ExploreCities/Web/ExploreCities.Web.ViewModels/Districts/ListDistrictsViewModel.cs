namespace ExploreCities.Web.ViewModels.Districts
{
    using ExploreCities.Web.ViewModels.Enums;
    using X.PagedList;

    public class ListDistrictsViewModel
    {
        public string CityName { get; set; }

        public string CityId { get; set; }

        public string SearchString { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public DistrictsSorter Sorter { get; set; }

        public IPagedList<DistrictsViewModel> AllDistricts { get; set; }
    }
}
