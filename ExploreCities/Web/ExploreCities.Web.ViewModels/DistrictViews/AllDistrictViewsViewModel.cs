namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Web.ViewModels.Enums;
    using X.PagedList;

    public class AllDistrictViewsViewModel
    {
        [Display(Name = "District name")]
        public string DistrictName { get; set; }

        public string DistrictId { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public DistrictViewsSorter Sorter { get; set; }

        public IPagedList<DistrictViewsViewModel> AllDistrictViews { get; set; }
    }
}
