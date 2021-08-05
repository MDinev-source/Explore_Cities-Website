namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Districts;
    using ExploreCities.Web.ViewModels.Enums;
    using Microsoft.EntityFrameworkCore;

    public class DistrictsService : IDistrictsService
    {
        private readonly IDeletableEntityRepository<District> districtsRepository;
        private readonly IRepository<UserDistrict> userDistrictsRepository;

        public DistrictsService(
            IDeletableEntityRepository<District> districtsRepository,
            IRepository<UserDistrict> userDistrictsRepository)
        {
            this.districtsRepository = districtsRepository;
            this.userDistrictsRepository = userDistrictsRepository;
        }

        public async Task CreateAsync(string name, string cityId)
        {
            if (!this.districtsRepository
                .AllAsNoTrackingWithDeleted()
                .Any(x => x.Name == name))
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

        public IEnumerable<DistrictsViewModel> GetDistrictsFromSearch(string searchString, string cityId)
        {
            var escapedSearchTokens = searchString.Split(new char[] { ' ', ',', '.', ':', '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var districts = this.districtsRepository
                .All()
                .ToList()
                .Where(c => escapedSearchTokens.All(t => c.Name.ToLower().Contains(t.ToLower())))
                .Select(x => new DistrictsViewModel
                {
                    Name = x.Name,
                    DistrictViewsCount = x.DistrictViews.Count,
                    UsersCount = x.UserDistricts.Count,
                })
                .ToList();

            return districts;
        }

        public IEnumerable<DistrictsViewModel> SortBy(DistrictsViewModel[] districts, DistrictsSorter sorter)
        {
            switch (sorter)
            {
                case DistrictsSorter.DistrictName:
                    return districts.OrderBy(c => c.Name).ThenBy(c => c.DistrictViewsCount).ToList();
                case DistrictsSorter.DistrictViewsCount:
                    return districts.OrderByDescending(c => c.DistrictViewsCount).ThenBy(c => c.Name).ToList();
                case DistrictsSorter.UsersCount:
                    return districts.OrderByDescending(c => c.UsersCount).ThenBy(c => c.Name).ToList();
                default:
                    return districts.OrderBy(c => c.Name).ThenBy(c => c.DistrictViewsCount).ToList();
            }
        }

        public async Task<IEnumerable<DistrictsViewModel>> GetAllDistrictsAsync(string cityId, string userId)
        {
            var districts = await this.districtsRepository
             .All()
             .Where(x => x.CityId == cityId)
             .Select(x => new DistrictsViewModel
             {
                 Id = x.Id,
                 Name = x.Name,
                 CityId = x.CityId,
                 DistrictViewsCount = x.DistrictViews.Count,
                 UsersCount = x.UserDistricts.Count,
             })
             .ToListAsync();

            return districts;
        }

        public void AddUserToDistrict(string userId, string districtId)
        {
            var userInDistrict = this.userDistrictsRepository
                 .All()
                 .Any(x => x.UserId == userId && x.DistrictId == districtId);

            if (userInDistrict)
            {
                return;
            }

            var userDistrict = new UserDistrict
            {
                UserId = userId,
                DistrictId = districtId,
            };

            this.userDistrictsRepository.AddAsync(userDistrict);
            this.districtsRepository.SaveChangesAsync();
        }

        public string GetDistrictName(string districtId)
        {
            var district = this.districtsRepository
                   .All()
                   .FirstOrDefault(x => x.Id == districtId);

            return district.Name;
        }
    }
}
