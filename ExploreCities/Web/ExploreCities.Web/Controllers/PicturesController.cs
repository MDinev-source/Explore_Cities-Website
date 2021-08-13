namespace ExploreCities.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Services.Data;
    using ExploreCities.Web.ViewModels.Pictures;
    using Microsoft.AspNetCore.Mvc;

    public class PicturesController : Controller
    {
        private readonly IPicturesService picturesService;

        public PicturesController(
            IPicturesService picturesService)
        {
            this.picturesService = picturesService;
        }

        public async Task<IActionResult> All(AllObjectPicturesViewModel allObjectPicturesViewModel)
        {
            var objectPictures = await this.picturesService.GetAllPicturesAsync(allObjectPicturesViewModel.ObjectId);

            allObjectPicturesViewModel.Pictures = objectPictures;

            return this.View(allObjectPicturesViewModel);
        }

        public async Task<IActionResult> Carousel(AllObjectPicturesViewModel allObjectPicturesViewModel, string pictureId, string objectId)
        {
            var objectPictures = await this.picturesService.GetAllPicturesAsync(objectId);

            allObjectPicturesViewModel.Pictures = objectPictures;

            allObjectPicturesViewModel.CarouselIndex = this.picturesService.GetIndex(pictureId, objectId);

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

            await this.picturesService.DeleteByIdAsync(id);

            return this.RedirectToAction("/");
        }
    }
}
