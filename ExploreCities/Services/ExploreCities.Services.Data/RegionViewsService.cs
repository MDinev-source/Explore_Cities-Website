namespace ExploreCities.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.RegionViews;

    public class RegionViewsService : IRegionViewsService
    {
        private readonly IDeletableEntityRepository<RegionView> regionViewsRepository;
        private readonly IRegionsService regionService;

        public RegionViewsService(
            IDeletableEntityRepository<RegionView> regionViewsRepository,
            IRegionsService createRegionService)
        {
            this.regionViewsRepository = regionViewsRepository;
            this.regionService = createRegionService;
        }

        public async Task CreateAsync(CreateRegionViewInputModel input, string userId)
        {
            var regionName = input.RegionName;
            var cityId = input.CityId;

            await this.regionService.CreateAsync(regionName, cityId);

            var regionId = this.regionService.GetRegionId(regionName);

            var regionView = new RegionView
            {
                ArrivalYear = input.ArrivalYear,
                DepartureYear = input.DepartureYear != null ? input.DepartureYear : null,
                RegionId = regionId,
                Comment = input.Comment,
                PictureUrl = input.PictureUrl,
                ParkingSpaces = Enum.Parse<ParkingSpacesExistence>(input.ParkingSpacesExistence),
                ChildrenPlaygrounds = Enum.Parse<ChildrenPlaygroundsExistence>(input.ChildrenPlaygroundsExistence),
                AirPollution = Enum.Parse<AirPollutionRating>(input.AirPollutionRating),
                Noise = Enum.Parse<NoiseRating>(input.NoiseRating),
                PublicTransport = Enum.Parse<PublicTransportRating>(input.PublicTransportRating),
                AddedByUserId = userId,
            };

            await this.regionViewsRepository.AddAsync(regionView);
            await this.regionViewsRepository.SaveChangesAsync();
        }
    }
}
