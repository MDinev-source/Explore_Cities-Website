namespace ExploreCities.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Location;

    public class RegionsService : IRegionsService
    {
        private readonly IDeletableEntityRepository<Region> regionsRepository;

        public RegionsService(IDeletableEntityRepository<Region> regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }

        public async Task CreateAsync(string name, string cityId)
        {
            if (!this.regionsRepository.AllAsNoTrackingWithDeleted().Any(x => x.Name == name))
            {
                var region = new Region
                {
                    Name = name,
                    CityId = cityId,
                };

                await this.regionsRepository.AddAsync(region);
                await this.regionsRepository.SaveChangesAsync();
            }
        }

        public string GetRegionId(string name)
        {
            var region = this.regionsRepository.AllAsNoTrackingWithDeleted()
                .Where(x => x.Name == name).FirstOrDefault();

            return region.Id;
        }
    }
}
