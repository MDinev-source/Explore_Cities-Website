namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;

    public interface IDistrictViewObjectsService
    {
        Task CreateAsync(CreateDistrictViewObjectInputModel input, string userId, string imagePath);

        Task<IEnumerable<DistrictViewObjectViewModel>> GetAllDistrictViewObjectsAsync(string districtViewId, string userId);

        Task<BaseEditDetailsDeleteModel> GetViewModelByIdAsync(string id);

        Task EditAsync(BaseEditDetailsDeleteModel districtViewObjectEditModel);

        Task DeleteAllObjectsFromCurrentView(string districtViewId);

        Task DeleteByIdAsync(string id);
    }
}
