namespace ExploreCities.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models;
    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.Districts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using X.PagedList;

    public class DistrictsController : Controller
    {
        private readonly IDistrictsService districtsService;
        private readonly ICitiesService citiesService;
        private readonly UserManager<ApplicationUser> userManager;

        public DistrictsController(
            IDistrictsService districtsService,
            ICitiesService citiesService,
            UserManager<ApplicationUser> userManager)
        {
            this.districtsService = districtsService;
            this.citiesService = citiesService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All(ListDistrictsViewModel listDistrictsViewModel, string cityId)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var districts = await this.districtsService.GetAllDistrictsAsync(listDistrictsViewModel.CityId ?? cityId, user.Id);

            if (listDistrictsViewModel.SearchString == null)
            {
                districts = await this.districtsService.GetAllDistrictsAsync(listDistrictsViewModel.CityId, user.Id);
            }

            districts = this.districtsService.SortBy(districts.ToArray(), listDistrictsViewModel.Sorter);

            var pageNumber = listDistrictsViewModel.PageNumber ?? 1;
            var pageSize = listDistrictsViewModel.PageSize ?? 6;
            var pageCitiesViewModel = districts.ToPagedList(pageNumber, pageSize);

            listDistrictsViewModel.AllDistricts = pageCitiesViewModel;

            listDistrictsViewModel.CityName = this.citiesService.GetCityName(listDistrictsViewModel.CityId);

            return this.View(listDistrictsViewModel);
        }
    }
}
