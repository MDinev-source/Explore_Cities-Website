namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using ExploreCities.Web.ViewModels.Enums;
    using X.PagedList;

    public class AllDistrictViewsViewModel
    {
        public string DistrictId { get; set; }

        public string SearchString { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public DistrictViewsSorter Sorter { get; set; }

        public IPagedList<DistrictViewsViewModel> AllDistrictViews { get; set; }
    }
}
