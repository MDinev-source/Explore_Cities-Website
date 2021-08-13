namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;

    public interface IDistrictViewObjectsService
    {
        Task CreateAsync(CreateDistrictViewObjectInputModel input, string imagePath);

        Task<IEnumerable<DistrictViewObjectViewModel>> GetAllDistrictViewObjectsAsync(string districtViewId, string userId);

        Task<DistrictViewObjectDetailsViewModel> GetViewModelByIdAsync(string id);

        Task EditAsync(DistrictViewObjectEditModel districtViewObjectEditModel);

        Task<DistrictViewObjectEditModel> GetEditViewModelByIdAsync(string id);

        Task DeleteAllObjectsFromCurrentView(string districtViewId);

        Task<DistrictViewObjectDeleteViewModel> GetDeleteViewModelByIdAsync(string id);

        Task DeleteByIdAsync(string id);
    }
}
