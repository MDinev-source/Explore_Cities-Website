namespace ExploreCities.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models.Location;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;

        public CitiesService(
            IDeletableEntityRepository<City> citiesRepository)
        {
            this.citiesRepository = citiesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.citiesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
