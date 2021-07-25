namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Web.ViewModels.CitiesViews;
    using ExploreCities.Web.ViewModels.Enums;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<CitiesViewModel>> GetAllCitiesAsync();

        IEnumerable<CitiesViewModel> SortBy(CitiesViewModel[] cities, CitiesSorter sorter);

        IEnumerable<CitiesViewModel> GetCitiesFromSearch(string searchString, string optionsSearch);
    }
}
