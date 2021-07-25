namespace ExploreCities.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.CitiesViews;
    using Microsoft.AspNetCore.Mvc;

    public class CitiesController : Controller
    {
        private readonly ICitiesService citiesService;

        public CitiesController(
            ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }

        public async Task<IActionResult> All(ListCitiesViewModel listCitiesViewModel)
        {
            IEnumerable<CitiesViewModel> cities;

            if (listCitiesViewModel.SearchString == null)
            {
                 cities = await this.citiesService.GetAllCitiesAsync();
            }
            else
            {
                cities = this.citiesService.GetCitiesFromSearch(listCitiesViewModel.SearchString, listCitiesViewModel.OptionSearch).ToList();
            }

            cities = this.citiesService.SortBy(cities.ToArray(), listCitiesViewModel.Sorter);

            listCitiesViewModel.AllCities = cities;

            return this.View(listCitiesViewModel);
        }
    }
}
