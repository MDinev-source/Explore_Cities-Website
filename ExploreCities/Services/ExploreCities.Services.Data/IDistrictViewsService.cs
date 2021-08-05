namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Web.ViewModels.DistrictViews;
    using ExploreCities.Web.ViewModels.Enums;

    public interface IDistrictViewsService
    {
        Task CreateAsync(CreateDistrictViewInputModel input, string userId);

        Task<IEnumerable<DistrictViewsViewModel>> GetAllDistrictViewsAsync(string districtId);

        IEnumerable<DistrictViewsViewModel> SortBy(DistrictViewsViewModel[] districtViews, DistrictViewsSorter sorter);

        Task<DistrictViewsDetailsViewModel> GetViewModelByIdAsync(string id);
    }
}
