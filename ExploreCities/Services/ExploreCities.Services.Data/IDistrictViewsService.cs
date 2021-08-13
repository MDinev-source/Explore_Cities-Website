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

        Task<IEnumerable<MyDistrictViewViewModel>> GetMyAllDistrictViewsAsync(string userId);

        Task EditAsync(DistrictViewEditModel districtViewEditModel);

        IEnumerable<DistrictViewsViewModel> SortBy(DistrictViewsViewModel[] districtViews, DistrictViewsSorter sorter);

        Task<DistrictViewsDetailsViewModel> GetDetailViewModelByIdAsync(string id);

        Task<DistrictViewEditModel> GetEditViewModelByIdAsync(string id);

        Task<DistrictViewDeleteViewModel> GetDeleteViewModelByIdAsync(string id);

        Task DeleteByIdAsync(string id);

        string GetDistrictViewId(string userId);
    }
}
