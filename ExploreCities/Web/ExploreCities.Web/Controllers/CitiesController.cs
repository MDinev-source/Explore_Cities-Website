namespace ExploreCities.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.Cities;
    using Microsoft.AspNetCore.Mvc;
    using X.PagedList;

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
            var cities = await this.citiesService.GetAllCitiesAsync();

            if (listCitiesViewModel.SearchString != null)
            {
                cities = this.citiesService.GetCitiesFromSearch(listCitiesViewModel.SearchString, listCitiesViewModel.OptionSearch).ToList();
            }

            cities = this.citiesService.SortBy(cities.ToArray(), listCitiesViewModel.Sorter).ToList();

            var pageNumber = listCitiesViewModel.PageNumber ?? 1;
            var pageSize = listCitiesViewModel.PageSize ?? 6;
            var pageCitiesViewModel = cities.ToPagedList(pageNumber, pageSize);

            listCitiesViewModel.AllCities = pageCitiesViewModel;

            return this.View(listCitiesViewModel);
        }
    }
}
