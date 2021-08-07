namespace ExploreCities.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;

    public class DistrictViewObjectsController : Controller
    {
        private readonly IDistrictViewObjectsService districtViewObjectsService;
        private readonly IWebHostEnvironment environment;

        public DistrictViewObjectsController(
            IDistrictViewObjectsService districtViewObjectsService,
            IWebHostEnvironment environment)
        {
            this.districtViewObjectsService = districtViewObjectsService;
            this.environment = environment;
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
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            try
            {
            await this.districtViewObjectsService.CreateAsync(input, $"{this.environment.WebRootPath}/Pictures");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(input);
            }

            return this.RedirectToAction("/");
        }
    }
}
