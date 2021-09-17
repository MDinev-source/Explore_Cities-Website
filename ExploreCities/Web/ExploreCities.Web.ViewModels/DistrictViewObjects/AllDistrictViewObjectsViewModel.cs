namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using X.PagedList;

    public class AllDistrictViewObjectsViewModel
    {
        public string DistrictViewId { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public IPagedList<DistrictViewObjectViewModel> DistrictViewObjects { get; set; }
    }
}
