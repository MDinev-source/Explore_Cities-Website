namespace ExploreCities.Web.Controllers
{
    using System.Threading.Tasks;

    using ExploreCities.Data.Models;
    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.RegionViews;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RegionViewsController : Controller
    {
        private readonly ICitiesService citiesService;
        private readonly IRegionViewsService regionViewsService;
        private readonly UserManager<ApplicationUser> userManager;

        public RegionViewsController(
            ICitiesService citiesService,
            IRegionViewsService regionViewsService,
            UserManager<ApplicationUser> userManager)
        {
            this.citiesService = citiesService;
            this.regionViewsService = regionViewsService;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRegionViewInputModel();

            viewModel.Cities = this.citiesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRegionViewInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Cities = this.citiesService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            await this.regionViewsService.CreateAsync(input, user.Id);

            return this.RedirectToAction("/");
        }
    }
}
