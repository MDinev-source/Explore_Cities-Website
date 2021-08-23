namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Pictures;
    using Microsoft.EntityFrameworkCore;

    public class PicturesService : IPicturesService
    {
        private const string BasePath = "/Pictures/districtViewObjects/";
        private readonly IDeletableEntityRepository<Picture> pictureRepository;

        public PicturesService(
              IDeletableEntityRepository<Picture> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }

        public async Task DeleteAllPicuresFromCurrentobject(string districtViewObjectId)
        {
            var pictures = this.pictureRepository
                .AllAsNoTracking()
                .Where(x => x.DistrictObjectId == districtViewObjectId)
                .ToList();

            foreach (var pic in pictures)
            {
                this.pictureRepository.Delete(pic);
                await this.pictureRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            var pictureToDelete = await this.pictureRepository
              .AllAsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);

            this.pictureRepository
                .Delete(pictureToDelete);

            await this.pictureRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<ObjectPictureViewModel>> GetAllPicturesAsync(string objectId)
        {
            var pictures = await this.pictureRepository
                   .AllAsNoTracking()
                   .Where(x => x.DistrictObjectId == objectId)
                   .Select(x => new ObjectPictureViewModel
                   {
                       Id = x.Id,
                       DistrictViewObjectId = x.DistrictObjectId,
                       CreatedOn = x.CreatedOn,
                       Path = BasePath + $"{x.Id}" + "." + $"{x.Extension}",
                       UserId = x.AddedByUserId,
                   }).ToListAsync();

            return pictures.OrderByDescending(x => x.CreatedOn);
        }

        public async Task<IEnumerable<ObjectPictureViewModel>> GetAllDbPicturesAsync()
        {
            var pictures = await this.pictureRepository
                 .AllAsNoTracking()
                 .Select(x => new ObjectPictureViewModel
                 {
                     Id = x.Id,
                     DistrictViewObjectId = x.DistrictObjectId,
                     ObjectName = x.DistrictObject.Name,
                     ObjectType = x.DistrictObject.ObjectType.ToString(),
                     CreatedOn = x.CreatedOn,
                     Path = BasePath + $"{x.Id}" + "." + $"{x.Extension}",
                     UserId = x.AddedByUserId,
                 }).ToListAsync();

            return pictures.OrderByDescending(x => x.CreatedOn);
        }

        public async Task<PictureDeleteViewModel> GetDeleteViewModelByIdAsync(string id, string objectId)
        {
            var districtViewObject = await this.pictureRepository
               .AllAsNoTracking()
               .Where(x => x.Id == id)
               .Select(x => new PictureDeleteViewModel
               {
                   Id = id,
                   Path = BasePath + $"{x.Id}" + "." + $"{x.Extension}",
                   CreateOn = x.CreatedOn,
               })
               .FirstOrDefaultAsync();

            return districtViewObject;
        }

        public Picture GetPicture(string id)
        {
            var picture = this.pictureRepository
            .AllAsNoTracking()
            .FirstOrDefault(x => x.Id == id);

            return picture;
        }

        public int GetIndex(string pictureId, string objectId)
        {
            var allPictures = this
                   .pictureRepository
                   .AllAsNoTracking()
                   .Where(x => x.DistrictObjectId == objectId)
                   .OrderByDescending(x => x.CreatedOn)
                   .ToList();

            var index = 0;

            for (int i = 0; i <= allPictures.Count - 1; i++)
            {
                if (allPictures[i].Id == pictureId)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int GetIndexForAllPics(string pictureId)
        {
            var allPictures = this
                  .pictureRepository
                  .AllAsNoTracking()
                  .OrderByDescending(x => x.CreatedOn)
                  .ToList();

            var index = 0;

            for (int i = 0; i <= allPictures.Count - 1; i++)
            {
                if (allPictures[i].Id == pictureId)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
