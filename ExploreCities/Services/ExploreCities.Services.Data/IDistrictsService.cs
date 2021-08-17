namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Districts;
    using ExploreCities.Web.ViewModels.Enums;

    public interface IDistrictsService
    {
        Task CreateAsync(string name, string cityId);

        Task<IEnumerable<DistrictsViewModel>> GetAllDistrictsAsync(string cityId, string userId);

        IEnumerable<DistrictsViewModel> GetDistrictsFromSearch(string searchString, string cityId);

        IEnumerable<DistrictsViewModel> SortBy(DistrictsViewModel[] districts, DistrictsSorter sorter);

        Task<bool> AddUserToDistrict(string userId, string districtId);

        Task<bool> RemoveUserFromDistrict(string userId, string districtId);

        Task<bool> RemoveDistrict(District district);

        Task<bool> RateDistrict(string districtId, string userId);

        bool CheckUserDistrictByCity(string userId, string cityId);

        string GetDistrictId(string name, string cityId);

        District GetDistrict(string districtId);
    }
}
