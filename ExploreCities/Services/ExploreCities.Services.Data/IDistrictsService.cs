namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Web.ViewModels.Districts;
    using ExploreCities.Web.ViewModels.Enums;

    public interface IDistrictsService
    {
        Task CreateAsync(string name, string cityId);

        Task<IEnumerable<DistrictsViewModel>> GetAllDistrictsAsync(string cityId, string userId);

        IEnumerable<DistrictsViewModel> GetDistrictsFromSearch(string searchString, string cityId);

        IEnumerable<DistrictsViewModel> SortBy(DistrictsViewModel[] districts, DistrictsSorter sorter);

        void AddUserToDistrict(string userId, string districtId);

        string GetDistrictId(string name);

        string GetDistrictName(string districtId);
    }
}
