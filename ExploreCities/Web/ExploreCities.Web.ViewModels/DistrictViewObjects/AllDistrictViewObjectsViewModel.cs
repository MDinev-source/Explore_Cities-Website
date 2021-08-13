namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.Collections.Generic;

    public class AllDistrictViewObjectsViewModel
    {
        public string DistrictViewId { get; set; }

        public IEnumerable<DistrictViewObjectViewModel> DistrictViewObjects { get; set; }
    }
}
