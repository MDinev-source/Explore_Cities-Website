namespace ExploreCities.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models;
    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DistrictViewObjectsController : Controller
    {

        private readonly IDistrictViewObjectsService districtViewObjectsService;
        private readonly IWebHostEnvironment environment;
        private readonly UserManager<ApplicationUser> userManager;

        public DistrictViewObjectsController(
            IDistrictViewObjectsService districtViewObjectsService,
            IWebHostEnvironment environment,
            UserManager<ApplicationUser> userManager)
        {
            this.districtViewObjectsService = districtViewObjectsService;
            this.environment = environment;
            this.userManager = userManager;
        }

        public IActionResult Create(string districtViewId)
        {
            var model = new CreateDistrictViewObjectInputModel()
            {
                DistrictViewId = districtViewId,
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDistrictViewObjectInputModel input)
        {
            var imagePath = $"{this.environment.WebRootPath}/Pictures";
            var user = await this.userManager.GetUserAsync(this.User);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
                await this.districtViewObjectsService.CreateAsync(input, user.Id, imagePath);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("/");
        }

        public async Task<IActionResult> All(AllDistrictViewObjectsViewModel listDistrictViewObjectsViewModel, string districtViewId)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            listDistrictViewObjectsViewModel.DistrictViewObjects = await this.districtViewObjectsService.GetAllDistrictViewObjectsAsync(listDistrictViewObjectsViewModel.DistrictViewId ?? districtViewId, user.Id);

            return this.View(listDistrictViewObjectsViewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var districtViewObjects = await this.districtViewObjectsService.GetViewModelByIdAsync(id);

            return this.View(districtViewObjects);
        }

        public async Task<IActionResult> Edit(string id, string objectType)
        {
            var districtViewObjectToEdit = await this.districtViewObjectsService.GetEditViewModelByIdAsync(id);

            districtViewObjectToEdit.ObjectType = objectType;

            return this.View(districtViewObjectToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DistrictViewObjectEditModel districtViewObjectEditModel)
        {
            await this.districtViewObjectsService.EditAsync(districtViewObjectEditModel);

            return this.RedirectToAction("Details", "DistrictViewObjects", new { area = "", id = districtViewObjectEditModel.Id });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var districtViewObjectToDelete = await this.districtViewObjectsService.GetDeleteViewModelByIdAsync(id);

            return this.View(districtViewObjectToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DistrictViewObjectDeleteViewModel districtViewObjectDeleteViewModel)
        {
            var id = districtViewObjectDeleteViewModel.Id;

            await this.districtViewObjectsService.DeleteByIdAsync(id);

            return this.RedirectToAction("/");
        }
    }
}
