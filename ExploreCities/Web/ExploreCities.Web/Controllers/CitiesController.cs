namespace ExploreCities.Web.Controllers
{
    using System.Linq;

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

        public IActionResult All(string searchString, string optionSearch)
        {
            var viewModel = new ListCitiesViewModel();

            if (searchString == null)
            {
                viewModel.AllCities = this.citiesService.GetAll();
            }
            else
            {
                if (optionSearch == "Name" || optionSearch == null)
                {
                    viewModel.AllCities = this.citiesService.GetAll()
                   .Where(x => x.Name.ToLower()
                   .Contains(searchString.ToLower()));
                }
                else
                {
                    viewModel.AllCities = this.citiesService.GetAll()
                   .Where(x => x.Region.ToLower()
                   .Contains(searchString.ToLower()));
                }
            }

            return this.View(viewModel);
        }
    }
}
