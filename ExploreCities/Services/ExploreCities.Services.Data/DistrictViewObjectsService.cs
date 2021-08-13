namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;
    using Microsoft.EntityFrameworkCore;

    public class DistrictViewObjectsService : IDistrictViewObjectsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<DistrictObject> districtViewObjectsRepository;
        private readonly IPicturesService picturesService;

        public DistrictViewObjectsService(
            IDeletableEntityRepository<DistrictObject> districtViewObjectsRepository,
            IPicturesService picturesService)
        {
            this.districtViewObjectsRepository = districtViewObjectsRepository;
            this.picturesService = picturesService;
        }

        public async Task CreateAsync(CreateDistrictViewObjectInputModel cratedObjectInput, string imagePath)
        {
            var districtViewObject = new DistrictObject
            {
                ObjectType = cratedObjectInput.ObjectType,
                Name = cratedObjectInput.Name,
                Opinion = cratedObjectInput.Opinion,
                DistrictViewId = cratedObjectInput.DistrictViewId,
            };

            Directory.CreateDirectory($"{imagePath}/districtViewObjects/");
            foreach (var picture in cratedObjectInput.Pictures)
            {
                var extension = Path.GetExtension(picture.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.ToLower().EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbPicture = new Picture
                {
                    Extension = extension,
                };
                districtViewObject.Pictures.Add(dbPicture);

                var physicalPath = $"{imagePath}/districtViewObjects/{dbPicture.Id}.{extension}";

                dbPicture.RemoteImageUrl = physicalPath;

                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await picture.CopyToAsync(fileStream);
            }

            await this.districtViewObjectsRepository.AddAsync(districtViewObject);
            await this.districtViewObjectsRepository.SaveChangesAsync();
        }

        public async Task DeleteAllObjectsFromCurrentView(string districtViewId)
        {
            var objects = this.districtViewObjectsRepository
                 .AllAsNoTracking()
                 .Where(x => x.DistrictViewId == districtViewId)
                 .ToList();

            foreach (var obj in objects)
            {
                await this.picturesService.DeleteAllPicuresFromCurrentobject(obj.Id);

                this.districtViewObjectsRepository.Delete(obj);
                await this.districtViewObjectsRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteByIdAsync(string id)
        {
            var objectToDelete = await this.districtViewObjectsRepository
              .AllAsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);

            await this.picturesService
                .DeleteAllPicuresFromCurrentobject(objectToDelete.Id);

            this.districtViewObjectsRepository
                .Delete(objectToDelete);
            await this.districtViewObjectsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(DistrictViewObjectEditModel districtViewObjectEditModel)
        {
            var districtViewObject = this.districtViewObjectsRepository
                 .AllAsNoTracking()
                 .Where(x => x.Id == districtViewObjectEditModel.Id)
                 .FirstOrDefault();

            districtViewObject.ObjectType = Enum.Parse<DistrictObjectType>(districtViewObjectEditModel.ObjectType);
            districtViewObject.Name = districtViewObjectEditModel.Name;
            districtViewObject.Opinion = districtViewObjectEditModel.Opinion;

            this.districtViewObjectsRepository.Update(districtViewObject);
            await this.districtViewObjectsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<DistrictViewObjectViewModel>> GetAllDistrictViewObjectsAsync(string districtViewId, string userId)
        {
            var districtViewObject = await this.districtViewObjectsRepository
            .AllAsNoTracking()
            .Where(x => x.DistrictViewId == districtViewId)
            .Select(x => new DistrictViewObjectViewModel
            {
                Id = x.Id,
                ObjectType = x.ObjectType.ToString(),
                Name = x.Name,
                PicturesCount = x.Pictures.Count,
            })
            .ToListAsync();

            return districtViewObject;
        }

        public async Task<DistrictViewObjectDeleteViewModel> GetDeleteViewModelByIdAsync(string id)
        {
            var districtViewObject = await this.districtViewObjectsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new DistrictViewObjectDeleteViewModel
                {
                    Id = x.Id,
                    ObjectType = x.ObjectType,
                    Name = x.Name,
                    Opinion = x.Opinion,
                })
                .FirstOrDefaultAsync();

            return districtViewObject;
        }

        public async Task<DistrictViewObjectEditModel> GetEditViewModelByIdAsync(string id)
        {
            var districtViewObject = await this.districtViewObjectsRepository
                  .AllAsNoTracking()
                  .Where(x => x.Id == id)
                  .Select(x => new DistrictViewObjectEditModel
                  {
                      Id = x.Id,
                      ObjectType = x.ObjectType.ToString(),
                      Name = x.Name,
                      Opinion = x.Opinion,
                  })
                  .FirstOrDefaultAsync();

            return districtViewObject;
        }

        public async Task<DistrictViewObjectDetailsViewModel> GetViewModelByIdAsync(string id)
        {
            var districtViewObject = await this.districtViewObjectsRepository.AllAsNoTracking()
           .Where(d => d.Id == id)
            .Select(x => new DistrictViewObjectDetailsViewModel
            {
                Id = id,
                Name = x.Name,
                ObjectType = x.ObjectType.ToString(),
                Opinion = x.Opinion,
            })
           .FirstOrDefaultAsync();

            return districtViewObject;
        }
    }
}
