namespace ExploreCities.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.Pictures;
    using Microsoft.AspNetCore.Mvc;

    public class PicturesController : AdministrationController
    {
        private readonly IPicturesService picturesService;

        public PicturesController(
            IPicturesService picturesService)
        {
            this.picturesService = picturesService;
        }

        public async Task<IActionResult> All(AllObjectPicturesViewModel allObjectPicturesViewModel)
        {
            var objectPictures = await this.picturesService.GetAllDbPicturesAsync();

            allObjectPicturesViewModel.Pictures = objectPictures;

            return this.View(allObjectPicturesViewModel);
        }

        public async Task<IActionResult> Carousel(AllObjectPicturesViewModel allObjectPicturesViewModel, string pictureId)
        {
            var objectPictures = await this.picturesService.GetAllDbPicturesAsync();

            allObjectPicturesViewModel.Pictures = objectPictures;

            allObjectPicturesViewModel.CarouselIndex = this.picturesService.GetIndexForAllPics(pictureId);

            return this.View(allObjectPicturesViewModel);
        }

        public async Task<IActionResult> Delete(string id, string objectId)
        {
            var pictureToDelete = await this.picturesService.GetDeleteViewModelByIdAsync(id, objectId);

            return this.View(pictureToDelete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PictureDeleteViewModel pictureDeleteViewModel)
        {
            var id = pictureDeleteViewModel.Id;

            var objectId = this.picturesService.GetPicture(id).DistrictObjectId;

            await this.picturesService.DeleteByIdAsync(id);

            return this.RedirectToAction(nameof(this.All), new { objectId });
        }
    }
}
