namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Discussions;
    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViews;
    using ExploreCities.Web.ViewModels.Enums;
    using Microsoft.EntityFrameworkCore;

    public class DistrictViewsService : IDistrictViewsService
    {
        private readonly IDeletableEntityRepository<DistrictView> districtViewsRepository;
        private readonly ICitiesService citiesService;
        private readonly IDistrictsService districtService;
        private readonly IDistrictViewObjectsService districtViewObjectsService;
        private readonly IRepository<DistrictViewLike> districtViewLikes;
        private readonly IRepository<DistrictViewDislike> districtViewDislikes;

        public DistrictViewsService(
            IDeletableEntityRepository<DistrictView> districtViewsRepository,
            ICitiesService citiesService,
            IDistrictsService districtService,
            IDistrictViewObjectsService districtViewObjectsService,
            IRepository<DistrictViewLike> districtViewLikes,
            IRepository<DistrictViewDislike> districtViewDislikes)
        {
            this.districtViewsRepository = districtViewsRepository;
            this.citiesService = citiesService;
            this.districtService = districtService;
            this.districtViewObjectsService = districtViewObjectsService;
            this.districtViewLikes = districtViewLikes;
            this.districtViewDislikes = districtViewDislikes;
        }

        public async Task CreateAsync(CreateDistrictViewInputModel input, string userId)
        {
            var districtName = input.DistrictName;
            var cityId = input.CityId;

            await this.districtService.CreateAsync(districtName, cityId);

            var districtId = this.districtService.GetDistrictId(districtName, cityId);

            DistrictView districtView;

            if (await this.districtService.AddUserToDistrict(userId, districtId))
            {
                districtView = new DistrictView
                {
                    ArrivalYear = input.ArrivalYear,
                    DepartureYear = input.DepartureYear != null ? input.DepartureYear : null,
                    DistrictId = districtId,
                    Comment = input.Comment,
                    PictureUrl = input.PictureUrl,
                    ParkingSpaces = Enum.Parse<ParkingSpacesExistence>(input.ParkingSpacesExistence),
                    ChildrenPlaygrounds = Enum.Parse<ChildrenPlaygroundsExistence>(input.ChildrenPlaygroundsExistence),
                    AirPollution = Enum.Parse<AirPollutionRating>(input.AirPollutionRating),
                    Noise = Enum.Parse<NoiseRating>(input.NoiseRating),
                    PublicTransport = Enum.Parse<PublicTransportRating>(input.PublicTransportRating),
                    AddedByUserId = userId,
                };
            }
            else
            {
                throw new ArgumentException("User already create district view.");
            }

            await this.citiesService.AddUserToCity(userId, cityId);
            await this.districtViewsRepository.AddAsync(districtView);
            await this.districtViewsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<DistrictViewsViewModel>> GetAllDistrictViewsAsync(string districtId)
        {
            var districtViews = await this.districtViewsRepository
                .AllAsNoTracking()
                .Where(x => x.DistrictId == districtId)
                .Select(x => new DistrictViewsViewModel
                {
                    Id = x.Id,
                    DistrictName = this.districtService.GetDistrict(districtId).Name,
                    PictureUrl = x.PictureUrl,
                    UserId = x.AddedByUserId,
                    Username = x.AddedByUser.UserName,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    ObjectsCount = x.DistrictObjects.Count,
                })
                .ToListAsync();

            return districtViews;
        }

        public IEnumerable<DistrictViewsViewModel> SortBy(DistrictViewsViewModel[] districtViews, DistrictViewsSorter sorter)
        {
            switch (sorter)
            {
                case DistrictViewsSorter.Username:
                    return districtViews.OrderBy(d => d.Username).ThenBy(d => d.CreatedOn).ToList();
                case DistrictViewsSorter.CreatedOn:
                    return districtViews.OrderByDescending(c => c.CreatedOn).ThenBy(d => d.ModifiedOn).ToList();
                case DistrictViewsSorter.ModifiedOn:
                    return districtViews.OrderByDescending(c => c.ModifiedOn).ThenBy(d => d.CreatedOn).ToList();

                default:
                    return districtViews.OrderBy(d => d.Username).ThenBy(d => d.CreatedOn).ToList();
            }
        }

        public async Task<DistrictViewsDetailsViewModel> GetDetailViewModelByIdAsync(string id)
        {
            var districtView = await this.districtViewsRepository
                .AllAsNoTracking()
                .Where(d => d.Id == id)
                 .Select(x => new DistrictViewsDetailsViewModel
                 {
                     Id = id,
                     DistrictName = x.District.Name,
                     PictureUrl = x.PictureUrl,
                     ArrivalYear = x.ArrivalYear,
                     DepartureYear = x.DepartureYear,
                     Comment = x.Comment,
                     ParkingSpacesExistence = x.ParkingSpaces,
                     ChildrenPlaygroundsExistence = x.ChildrenPlaygrounds,
                     AirPollutionRating = x.AirPollution,
                     NoiseRating = x.Noise,
                     PublicTransportRating = x.PublicTransport,
                     Likes = x.Likes,
                     Dislikes = x.Dislikes,
                     UserId = x.AddedByUserId,
                 })
                .FirstOrDefaultAsync();

            return districtView;
        }

        public async Task<DistrictViewEditModel> GetEditViewModelByIdAsync(string id)
        {
            var districtView = await this.districtViewsRepository
                .AllAsNoTracking()
                .Where(d => d.Id == id)
                 .Select(x => new DistrictViewEditModel
                 {
                     Id = id,
                     DistrictName = x.District.Name,
                     PictureUrl = x.PictureUrl,
                     ArrivalYear = x.ArrivalYear,
                     DepartureYear = x.DepartureYear,
                     Comment = x.Comment,
                     ParkingSpacesExistence = x.ParkingSpaces.ToString(),
                     ChildrenPlaygroundsExistence = x.ChildrenPlaygrounds.ToString(),
                     AirPollutionRating = x.AirPollution.ToString(),
                     NoiseRating = x.Noise.ToString(),
                     PublicTransportRating = x.PublicTransport.ToString(),
                 })
                .FirstOrDefaultAsync();

            return districtView;
        }

        public string GetDistrictViewId(string userId)
        {
            var districtView = this.districtViewsRepository
                 .AllAsNoTracking()
                 .FirstOrDefault(x => x.AddedByUserId == userId);

            return districtView.Id;
        }

        public async Task EditAsync(DistrictViewEditModel districtViewEditModel)
        {
            var districtView = this.districtViewsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == districtViewEditModel.Id)
                .FirstOrDefault();

            var oldDistrictName = this.districtService.GetDistrict(districtView.DistrictId).Name;

            if (oldDistrictName != districtViewEditModel.DistrictName)
            {
                var district = this.districtService.GetDistrict(districtView.DistrictId);

                await this.districtService.CreateAsync(districtViewEditModel.DistrictName, district.CityId);

                var districtId = this.districtService.GetDistrictId(districtViewEditModel.DistrictName, district.CityId);

                await this.districtService.RemoveUserFromDistrict(districtView.AddedByUserId, districtView.DistrictId);

                districtView.DistrictId = districtId;

                await this.districtService.AddUserToDistrict(districtView.AddedByUserId, districtId);

                if (this.districtViewsRepository
                    .AllAsNoTracking()
                    .Where(x => x.DistrictId == district.Id).ToList().Count - 1 == 0)
                {
                    await this.districtService.RemoveDistrict(district);
                }
            }

            districtView.ArrivalYear = districtViewEditModel.ArrivalYear;
            districtView.DepartureYear = districtViewEditModel.DepartureYear != null ? districtViewEditModel.DepartureYear : null;
            districtView.Comment = districtViewEditModel.Comment;
            districtView.PictureUrl = districtViewEditModel.PictureUrl;
            districtView.ParkingSpaces = Enum.Parse<ParkingSpacesExistence>(districtViewEditModel.ParkingSpacesExistence);
            districtView.ChildrenPlaygrounds = Enum.Parse<ChildrenPlaygroundsExistence>(districtViewEditModel.ChildrenPlaygroundsExistence);
            districtView.AirPollution = Enum.Parse<AirPollutionRating>(districtViewEditModel.AirPollutionRating);
            districtView.Noise = Enum.Parse<NoiseRating>(districtViewEditModel.NoiseRating);
            districtView.PublicTransport = Enum.Parse<PublicTransportRating>(districtViewEditModel.PublicTransportRating);

            this.districtViewsRepository.Update(districtView);
            await this.districtViewsRepository.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            var districtView = this.districtViewsRepository
                 .AllAsNoTracking()
                 .Where(x => x.Id == id)
                 .FirstOrDefault();

            var district = this.districtService.GetDistrict(districtView.DistrictId);

            await this.districtService.RemoveUserFromDistrict(districtView.AddedByUserId, districtView.DistrictId);

            if (this.districtViewsRepository
                .AllAsNoTracking()
                .Where(x => x.DistrictId == district.Id).ToList().Count - 1 == 0)
            {
                await this.districtService.RemoveDistrict(district);
            }

            if (this.districtService.CheckUserDistrictByCity(districtView.AddedByUserId, district.CityId) == false)
            {
                await this.citiesService.RemoveUserFromCity(districtView.AddedByUserId, district.CityId);
            }

            await this.districtViewObjectsService.DeleteAllObjectsFromCurrentView(districtView.Id);

            this.districtViewsRepository
                .Delete(districtView);

            this.districtViewsRepository.Update(districtView);
            await this.districtViewsRepository.SaveChangesAsync();
        }

        public async Task<DistrictViewDeleteViewModel> GetDeleteViewModelByIdAsync(string id)
        {
            var districtId = this.districtViewsRepository
           .AllAsNoTracking()
           .Where(x => x.Id == id).FirstOrDefault().DistrictId;

            var district = this.districtService.GetDistrict(districtId);

            var city = this.citiesService.GetCity(district.CityId);

            var districtView = await this.districtViewsRepository
                .AllAsNoTracking()
                .Where(d => d.Id == id)
                .Select(x => new DistrictViewDeleteViewModel
                {
                    Id = id,
                    PictureUrl = x.PictureUrl,
                    Comment = x.Comment,
                    DistrictId = districtId,
                    DistrictName = x.District.Name,
                    CityName = city.Name,
                })
                .FirstOrDefaultAsync();

            return districtView;
        }

        public async Task<IEnumerable<MyDistrictViewViewModel>> GetMyAllDistrictViewsAsync(string userId)
        {
            var districtViews = await this.districtViewsRepository
                .AllAsNoTracking()
                .Where(x => x.AddedByUserId == userId)
                .Select(x => new MyDistrictViewViewModel
                {
                    Id = x.Id,
                    DistrictId = x.DistrictId,
                    PictureUrl = x.PictureUrl,
                    UserId = x.AddedByUserId,
                    Username = x.AddedByUser.UserName,
                    CreatedOn = x.CreatedOn,
                    ModifiedOn = x.ModifiedOn,
                    ObjectsCount = x.DistrictObjects.Count,
                })
                .ToListAsync();

            foreach (var view in districtViews)
            {
                var district = this.districtService.GetDistrict(view.DistrictId);

                view.DistricName = district.Name;

                var city = this.citiesService.GetCity(district.CityId);

                view.CityName = city.Name;
            }

            return districtViews.OrderBy(x => x.CityName).ThenBy(x => x.DistricName);
        }

        public async Task<bool> LikeDistrictView(string districtViewId, string userId)
        {
            var districtView = await this.districtViewsRepository
                 .AllAsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == districtViewId);

            var districtViewLike = this.districtViewLikes
                .AllAsNoTracking()
                .Any(x => x.DistrictViewId == districtView.Id && x.UserId == userId);

            var districtViewDisLike = this.districtViewDislikes
            .AllAsNoTracking()
            .Any(x => x.DistrictViewId == districtView.Id && x.UserId == userId);

            if (districtViewLike)
            {
                return false;
            }

            if (districtViewDisLike)
            {
                return false;
            }

            var dbDistrictViewLike = new DistrictViewLike
            {
                UserId = userId,
                DistrictViewId = districtView.Id,
            };

            districtView.Likes += 1;

            this.districtViewsRepository.Update(districtView);
            await this.districtViewsRepository.SaveChangesAsync();

            await this.districtViewLikes.AddAsync(dbDistrictViewLike);
            await this.districtViewLikes.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DislikeDistrictView(string districtViewId, string userId)
        {
            var districtView = await this.districtViewsRepository
                    .AllAsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == districtViewId);

            var districtViewLike = this.districtViewLikes
                .AllAsNoTracking()
                .Any(x => x.DistrictViewId == districtView.Id && x.UserId == userId);

            var districtViewDisLike = this.districtViewDislikes
            .AllAsNoTracking()
            .Any(x => x.DistrictViewId == districtView.Id && x.UserId == userId);

            if (districtViewLike)
            {
                return false;
            }

            if (districtViewDisLike)
            {
                return false;
            }

            var dbDistrictViewDisLike = new DistrictViewDislike
            {
                UserId = userId,
                DistrictViewId = districtView.Id,
            };

            districtView.Dislikes += 1;

            this.districtViewsRepository.Update(districtView);
            await this.districtViewsRepository.SaveChangesAsync();

            await this.districtViewDislikes.AddAsync(dbDistrictViewDisLike);
            await this.districtViewDislikes.SaveChangesAsync();

            return true;
        }
    }
}
