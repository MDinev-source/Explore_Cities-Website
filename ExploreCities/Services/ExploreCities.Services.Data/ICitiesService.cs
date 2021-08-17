namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Cities;
    using ExploreCities.Web.ViewModels.Enums;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<CitiesViewModel>> GetAllCitiesAsync();

        IEnumerable<CitiesViewModel> SortBy(CitiesViewModel[] cities, CitiesSorter sorter);

        IEnumerable<CitiesViewModel> GetCitiesFromSearch(string searchString, string optionsSearch);

        Task<bool> AddUserToCity(string userId, string citytId);

        Task<bool> RemoveUserFromCity(string userId, string cityId);

        City GetCity(string cityId);
    }
}
