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

        public async Task<bool> AddUserToCity(string userId, string citytId)
        {
            var userInCity = this.userCitiesRepository
            .All()
            .Any(x => x.UserId == userId && x.CityId == citytId);

            if (userInCity)
            {
                return false;
            }

            var userCities = new UserCity
            {
                UserId = userId,
                CityId = citytId,
            };

            await this.userCitiesRepository.AddAsync(userCities);
            await this.citiesRepository.SaveChangesAsync();

            return true;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.citiesRepository.All()
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

        public City GetCity(string cityId)
        {
            var city = this.citiesRepository
          .AllAsNoTracking()
          .FirstOrDefault(x => x.Id == cityId);

            return city;
        }

        public async Task<bool> RemoveUserFromCity(string userId, string cityId)
        {
            var userInDistrict = this.userCitiesRepository
            .AllAsNoTracking()
            .Any(x => x.UserId == userId && x.CityId == cityId);

            var userCity = new UserCity
            {
                UserId = userId,
                CityId = cityId,
            };

            this.userCitiesRepository.Delete(userCity);
            await this.citiesRepository.SaveChangesAsync();

            return true;
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
