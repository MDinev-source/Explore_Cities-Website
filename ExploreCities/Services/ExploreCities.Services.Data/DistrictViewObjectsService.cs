namespace ExploreCities.Services.Data
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;

    public class DistrictViewObjectsService : IDistrictViewObjectsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<DistrictObject> districtViewObjectsRepository;

        public DistrictViewObjectsService(
            IDeletableEntityRepository<DistrictObject> districtViewObjectsRepository)
        {
            this.districtViewObjectsRepository = districtViewObjectsRepository;
        }

        public async Task CreateAsync(CreateDistrictViewObjectInputModel input, string imagePath)
        {
            var districtViewObject = new DistrictObject
            {
                ObjectType = input.ObjectType,
                Name = input.Name,
                Opinion = input.Opinion,
                DistrictViewId = input.DistrictViewId,
            };

            Directory.CreateDirectory($"{imagePath}/districtViewObjects/");
            foreach (var picture in input.Pictures)
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
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await picture.CopyToAsync(fileStream);
            }

            await this.districtViewObjectsRepository.AddAsync(districtViewObject);
            await this.districtViewObjectsRepository.SaveChangesAsync();
        }
    }
}
