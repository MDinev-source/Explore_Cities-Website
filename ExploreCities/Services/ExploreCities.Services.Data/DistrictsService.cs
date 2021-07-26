namespace ExploreCities.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Location;

    public class DistrictsService : IDistrictsService
    {
        private readonly IDeletableEntityRepository<District> districtsRepository;

        public DistrictsService(IDeletableEntityRepository<District> districtsRepository)
        {
            this.districtsRepository = districtsRepository;
        }

        public async Task CreateAsync(string name, string cityId)
        {
            if (!this.districtsRepository.AllAsNoTrackingWithDeleted().Any(x => x.Name == name))
            {
                var region = new District
                {
                    Name = name,
                    CityId = cityId,
                };

                await this.districtsRepository.AddAsync(region);
                await this.districtsRepository.SaveChangesAsync();
            }
        }

        public string GetDistrictId(string name)
        {
            var region = this.districtsRepository.AllAsNoTrackingWithDeleted()
                .Where(x => x.Name == name).FirstOrDefault();

            return region.Id;
        }
    }
}
