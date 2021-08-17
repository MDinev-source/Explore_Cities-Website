namespace ExploreCities.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Common.Repositories;
    using ExploreCities.Data.Models;
    using ExploreCities.Data.Models.Discussions;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Districts;
    using ExploreCities.Web.ViewModels.Enums;
    using Microsoft.EntityFrameworkCore;

    public class DistrictsService : IDistrictsService
    {
        private readonly IDeletableEntityRepository<District> districtsRepository;
        private readonly IRepository<UserDistrict> userDistrictsRepository;
        private readonly IRepository<DistrictLike> districtLikes;

        public DistrictsService(
            IDeletableEntityRepository<District> districtsRepository,
            IRepository<UserDistrict> userDistrictsRepository,
            IRepository<DistrictLike> districtLikes)
        {
            this.districtsRepository = districtsRepository;
            this.userDistrictsRepository = userDistrictsRepository;
            this.districtLikes = districtLikes;
        }

        public async Task CreateAsync(string name, string cityId)
        {
            if (!this.districtsRepository
                .AllAsNoTracking()
                .Any(x => x.Name == name && x.CityId == cityId))
            {
                var district = new District
                {
                    Name = name,
                    CityId = cityId,
                };

                await this.districtsRepository.AddAsync(district);
                await this.districtsRepository.SaveChangesAsync();
            }
        }

        public string GetDistrictId(string name, string cityId)
        {
            var district = this.districtsRepository.AllAsNoTracking()
                .Where(x => x.Name == name && x.CityId == cityId)
                .FirstOrDefault();

            return district.Id;
        }

        public IEnumerable<DistrictsViewModel> GetDistrictsFromSearch(string searchString, string cityId)
        {
            var escapedSearchTokens = searchString.Split(new char[] { ' ', ',', '.', ':', '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var districts = this.districtsRepository
                .AllAsNoTracking()
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
             .AllAsNoTracking()
             .Where(x => x.CityId == cityId)
             .Select(x => new DistrictsViewModel
             {
                 Id = x.Id,
                 Name = x.Name,
                 CityId = x.CityId,
                 DistrictViewsCount = x.DistrictViews.Count,
                 UsersCount = x.UserDistricts.Count,
                 Rating = x.Raiting,
             })
             .ToListAsync();

            return districts;
        }

        public async Task<bool> AddUserToDistrict(string userId, string districtId)
        {
            var userInDistrict = this.userDistrictsRepository
                 .AllAsNoTracking()
                 .Any(x => x.UserId == userId && x.DistrictId == districtId);

            if (userInDistrict)
            {
                return false;
            }

            var userDistrict = new UserDistrict
            {
                UserId = userId,
                DistrictId = districtId,
            };

            await this.userDistrictsRepository.AddAsync(userDistrict);
            await this.districtsRepository.SaveChangesAsync();

            return true;
        }

        public string GetDistrictName(string districtId)
        {
            var district = this.districtsRepository
                   .AllAsNoTracking()
                   .FirstOrDefault(x => x.Id == districtId);

            return district.Name;
        }

        public District GetDistrict(string districtId)
        {
            var district = this.districtsRepository
              .AllAsNoTracking()
              .FirstOrDefault(x => x.Id == districtId);

            return district;
        }

        public async Task<bool> RemoveUserFromDistrict(string userId, string districtId)
        {
            var userInDistrict = this.userDistrictsRepository
           .AllAsNoTracking()
           .Any(x => x.UserId == userId && x.DistrictId == districtId);

            var userDistrict = new UserDistrict
            {
                UserId = userId,
                DistrictId = districtId,
            };

            this.userDistrictsRepository.Delete(userDistrict);
            await this.districtsRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveDistrict(District district)
        {
            this.districtsRepository.Delete(district);
            await this.districtsRepository.SaveChangesAsync();

            return true;
        }

        public bool CheckUserDistrictByCity(string userId, string cityId)
        {
            var districtInCity = this.districtsRepository
                .AllAsNoTracking()
                .Where(x => x.CityId == cityId)
                .ToList();

            foreach (var district in districtInCity)
            {
                var userDistrict = this.userDistrictsRepository
                        .AllAsNoTracking()
                        .Where(x => x.DistrictId == district.Id && x.UserId == userId);

                if (userDistrict != null)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> RateDistrict(string districtId, string userId)
        {
            var district = await this.districtsRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == districtId);

            var districtLike = this.districtLikes
                .AllAsNoTracking()
                .Any(x => x.DistrictId == district.Id && x.UserId == userId);

            if (districtLike)
            {
                return false;
            }

            var dbDistrictLike = new DistrictLike
            {
                UserId = userId,
                DistrictId = district.Id,
            };

            district.Raiting += 1;

            this.districtsRepository.Update(district);
            await this.districtsRepository.SaveChangesAsync();

            await this.districtLikes.AddAsync(dbDistrictLike);
            await this.districtLikes.SaveChangesAsync();

            return true;
        }
    }
}
