namespace ExploreCities.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models;
    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.DistrictViews;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using X.PagedList;

    public class DistrictViewsController : Controller
    {
        private readonly ICitiesService citiesService;
        private readonly IDistrictViewsService districtViewsService;
        private readonly IDistrictsService districtsService;
        private readonly UserManager<ApplicationUser> userManager;

        public DistrictViewsController(
            ICitiesService citiesService,
            IDistrictViewsService districtViewsService,
            IDistrictsService districtsService,
            UserManager<ApplicationUser> userManager)
        {
            this.citiesService = citiesService;
            this.districtViewsService = districtViewsService;
            this.districtsService = districtsService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateDistrictViewInputModel();

            viewModel.Cities = this.citiesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDistrictViewInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Cities = this.citiesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.districtViewsService.CreateAsync(input, user.Id);

            return this.RedirectToAction("/");
        }

        public async Task<IActionResult> All(AllDistrictViewsViewModel allDistrictViewsViewModel)
        {
            var districtViews = await this.districtViewsService.GetAllDistrictViewsAsync(allDistrictViewsViewModel.DistrictId);

            districtViews = this.districtViewsService.SortBy(districtViews.ToArray(), allDistrictViewsViewModel.Sorter).ToList();

            var pageNumber = allDistrictViewsViewModel.PageNumber ?? 1;
            var pageSize = allDistrictViewsViewModel.PageSize ?? 6;
            var pageDistrictViewsViewModel = districtViews.ToPagedList(pageNumber, pageSize);

            allDistrictViewsViewModel.AllDistrictViews = pageDistrictViewsViewModel;

            allDistrictViewsViewModel.DistrictName = this.districtsService.GetDistrictName(allDistrictViewsViewModel.DistrictId);

            return this.View(allDistrictViewsViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var districtView = await this.districtViewsService.GetViewModelByIdAsync(id);

            return this.View(districtView);
        }
    }
}
