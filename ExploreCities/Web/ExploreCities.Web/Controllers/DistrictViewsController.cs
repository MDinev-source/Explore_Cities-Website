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

            var districtView = await this.districtViewsService.CreateAsync(input, user.Id);

            var id = districtView.Id;

            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        public async Task<IActionResult> All(AllDistrictViewsViewModel allDistrictViewsViewModel, string districtId)
        {
            var districtViews = await this.districtViewsService.GetAllDistrictViewsAsync(allDistrictViewsViewModel.DistrictId ?? districtId);

            districtViews = this.districtViewsService.SortBy(districtViews.ToArray(), allDistrictViewsViewModel.Sorter).ToList();

            var pageNumber = allDistrictViewsViewModel.PageNumber ?? 1;
            var pageSize = allDistrictViewsViewModel.PageSize ?? 6;
            var pageDistrictViewsViewModel = districtViews.ToPagedList(pageNumber, pageSize);

            allDistrictViewsViewModel.AllDistrictViews = pageDistrictViewsViewModel;

            allDistrictViewsViewModel.DistrictName = this.districtsService.GetDistrict(allDistrictViewsViewModel.DistrictId).Name;

            return this.View(allDistrictViewsViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var districtView = await this.districtViewsService.GetDetailViewModelByIdAsync(id);

            return this.View(districtView);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var districtViewToEdit = await this.districtViewsService.GetEditViewModelByIdAsync(id);

            return this.View(districtViewToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DistrictViewEditModel districtViewEditModel)
        {
            await this.districtViewsService.EditAsync(districtViewEditModel);

            var id = districtViewEditModel.Id;

            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var districtViewToDelete = await this.districtViewsService.GetDeleteViewModelByIdAsync(id);
            return this.View(districtViewToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DistrictViewDeleteViewModel districtViewDeleteViewModel)
        {
            var id = districtViewDeleteViewModel.Id;

            string districtId = this.districtViewsService.GetDistrictView(id).DistrictId;

            await this.districtViewsService.DeleteByIdAsync(id);

            return this.RedirectToAction(nameof(this.All), new { districtId });
        }

        public async Task<IActionResult> MyAll(MyAllDistrictViewsViewModel myAllDistrictViewsViewModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var districtViews = await this.districtViewsService
                .GetMyAllDistrictViewsAsync(user.Id);

            myAllDistrictViewsViewModel.AllDistrictViews = districtViews;

            return this.View(myAllDistrictViewsViewModel);
        }

        public async Task<IActionResult> Like(string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.districtViewsService.LikeDistrictView(id, user.Id);

            return this.RedirectToAction(nameof(this.Details), new { id });
        }

        public async Task<IActionResult> Dislike(string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            await this.districtViewsService.DislikeDistrictView(id, user.Id);

            return this.RedirectToAction(nameof(this.Details), new { id });
        }
    }
}
