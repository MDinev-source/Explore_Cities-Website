namespace ExploreCities.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViews;

    public class DistrictViewsService : IDistrictViewsService
    {
        private readonly IDeletableEntityRepository<DistrictView> districtViewsRepository;
        private readonly IDistrictsService districtService;

        public DistrictViewsService(
            IDeletableEntityRepository<DistrictView> regionViewsRepository,
            IDistrictsService createDistrictService)
        {
            this.districtViewsRepository = regionViewsRepository;
            this.districtService = createDistrictService;
        }

        public async Task CreateAsync(CreateDistrictViewInputModel input, string userId)
        {
            var regionName = input.DistrictName;
            var cityId = input.CityId;

            await this.districtService.CreateAsync(regionName, cityId);

            var districtId = this.districtService.GetDistrictId(regionName);

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
    }
}
