namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExploreCities.Web.ViewModels.CitiesViews;

    public interface ICitiesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<CitiesViewModel> GetAll();
    }
}
