namespace ExploreCities.Web.Controllers
{
    using System.Threading.Tasks;

    using ExploreCities.Data.Models;
    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.DistrictViews;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DistrictViewsController : Controller
    {
        private readonly ICitiesService citiesService;
        private readonly IDistrictViewsService districtViewsService;
        private readonly UserManager<ApplicationUser> userManager;

        public DistrictViewsController(
            ICitiesService citiesService,
            IDistrictViewsService regionViewsService,
            UserManager<ApplicationUser> userManager)
        {
            this.citiesService = citiesService;
            this.districtViewsService = regionViewsService;
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
    }
}
