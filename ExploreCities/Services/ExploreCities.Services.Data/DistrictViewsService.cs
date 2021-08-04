namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
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

        public DistrictViewsService(
            IDeletableEntityRepository<DistrictView> districtViewsRepository,
            ICitiesService citiesService,
            IDistrictsService createDistrictService)
        {
            this.districtViewsRepository = districtViewsRepository;
            this.citiesService = citiesService;
            this.districtService = createDistrictService;
        }

        public async Task CreateAsync(CreateDistrictViewInputModel input, string userId)
        {
            var districtName = input.DistrictName;
            var cityId = input.CityId;

            await this.districtService.CreateAsync(districtName, cityId);

            var districtId = this.districtService.GetDistrictId(districtName);

            this.districtService.AddUserToDistrict(userId, districtId);
            this.citiesService.AddUserToCity(userId, cityId);

            var districtView = new DistrictView
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

            await this.districtViewsRepository.AddAsync(districtView);
            await this.districtViewsRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<DistrictViewsViewModel>> GetAllDistrictViewsAsync(string districtId)
        {
            var districtViews = await this.districtViewsRepository
                .All()
                .Where(x => x.DistrictId == districtId)
                .Select(x => new DistrictViewsViewModel
                {
                    Id = x.Id,
                    DistrictName = this.districtService.GetDistrictName(districtId),
                    PictureUrl = x.PictureUrl,
                    UserId = x.AddedByUserId,
                    Username = x.AddedByUser.UserName,
                    CreatedOn = x.CreatedOn.ToString("dd/MM/yyyy"),
                    ModifiedOn = x.ModifiedOn != null ? x.ModifiedOn.ToString() : "not update",
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
                case DistrictViewsSorter.ObjectsCount:
                    return districtViews.OrderByDescending(c => c.ObjectsCount).ThenBy(c => c.CreatedOn).ToList();
                case DistrictViewsSorter.ModifiedOn:
                    return districtViews.OrderByDescending(c => c.ModifiedOn).ThenBy(c => c.CreatedOn).ToList();
                case DistrictViewsSorter.CreatedOn:
                    return districtViews.OrderByDescending(c => c.CreatedOn).ThenBy(c => c.Username).ToList();

                default:
                    return districtViews.OrderBy(d => d.Username).ThenBy(d => d.CreatedOn).ToList();
            }
        }
    }
}
