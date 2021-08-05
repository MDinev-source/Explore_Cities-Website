namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Cities;
    using ExploreCities.Web.ViewModels.Enums;
    using Microsoft.EntityFrameworkCore;

    public class CitiesService : ICitiesService
    {
        private readonly IDeletableEntityRepository<City> citiesRepository;
        private readonly IRepository<UserCity> userCitiesRepository;

        public CitiesService(
            IDeletableEntityRepository<City> citiesRepository,
            IRepository<UserCity> userCitiesRepository)
        {
            this.citiesRepository = citiesRepository;
            this.userCitiesRepository = userCitiesRepository;
        }

        public void AddUserToCity(string userId, string citytId)
        {
            var userInCity = this.userCitiesRepository
            .All()
            .Any(x => x.UserId == userId && x.CityId == citytId);

            if (userInCity)
            {
                return;
            }

            var userCities = new UserCity
            {
                UserId = userId,
                CityId = citytId,
            };

            this.userCitiesRepository.AddAsync(userCities);
            this.citiesRepository.SaveChangesAsync();
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

        public async Task<IEnumerable<CitiesViewModel>> GetAllCitiesAsync()
        {
            var cities = await this.citiesRepository
                  .All()
                  .Select(x => new CitiesViewModel
                  {
                      Id = x.Id,
                      Name = x.Name,
                      Area = x.Area,
                      DistrictsCount = x.Districts.Count,
                      UsersCount = x.UserCities.Count,
                  })
                  .ToListAsync();

            return cities;
        }

        public IEnumerable<CitiesViewModel> GetCitiesFromSearch(string searchString, string optionSearch)
        {
            IEnumerable<CitiesViewModel> cities = null;

            var escapedSearchTokens = searchString
                .Split(new char[] { ' ', ',', '.', ':', '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (optionSearch == "Name")
            {
                cities = this.citiesRepository
               .All()
               .ToList()
               .Where(c => escapedSearchTokens.All(t => c.Name.ToLower().Contains(t.ToLower())))
               .Select(x => new CitiesViewModel
               {
                   Name = x.Name,
                   Area = x.Area,
                   DistrictsCount = x.Districts.Count,
                   UsersCount = x.UserCities.Count,
               })
               .ToList();
            }
            else
            {
                cities = this.citiesRepository
               .All()
               .ToList()
               .Where(c => escapedSearchTokens.All(t => c.Area.ToLower().Contains(t.ToLower())))
               .Select(x => new CitiesViewModel
               {
                   Name = x.Name,
                   Area = x.Area,
                   DistrictsCount = x.Districts.Count,
                   UsersCount = x.UserCities.Count,
               })
               .ToList();
            }

            return cities;
        }

        public string GetCityName(string cityId)
        {
            var city = this.citiesRepository
             .All()
             .FirstOrDefault(x => x.Id == cityId);

            return city.Name;
        }

        public IEnumerable<CitiesViewModel> SortBy(CitiesViewModel[] cities, CitiesSorter sorter)
        {
            switch (sorter)
            {
                case CitiesSorter.CityName:
                    return cities.OrderBy(c => c.Name).ThenBy(c => c.Area).ToList();
                case CitiesSorter.DistrictsCount:
                    return cities.OrderByDescending(c => c.DistrictsCount).ThenBy(c => c.Name).ToList();
                case CitiesSorter.UsersCount:
                    return cities.OrderByDescending(c => c.UsersCount).ThenBy(c => c.Name).ToList();
                default:
                    return cities.OrderBy(c => c.Name).ThenBy(c => c.Area).ToList();
            }
        }
    }
}
