namespace ExploreCities.Services.Data.Tests
{
    using ExploreCities.Data.Models;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Districts;
    using ExploreCities.Web.ViewModels.Enums;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class DistrictsTest : BaseServiceTests
    {
        private const string TestCityId = "TestCityId";
        private const string TestCityName = "TestCityName";
        private const string TestCityArea = "TestCityArea";

        private const string TestDistrictId = "TestDistrictId";
        private const string TestDistrictName = "TestDistrictName";

        private const string TestUserId = "TestUserId";
        private const string TestUsernameEmail = "TestEmail@abv.bg";

        private IDistrictsService DistrictsServiceMock => this.ServiceProvider.GetRequiredService<IDistrictsService>();

        [Fact]
        public async Task CreateAsyncAddsDistrictToDbContextCorrect()
        {
            await this.AddCityToDb();

            await this.AddUserToDb();

            await this.DistrictsServiceMock.CreateAsync(TestCityName, TestCityId);

            Assert.Equal(1, this.DbContext.Districts.Count());
        }

        [Fact]
        public async Task GetAllAsyncReturnsAllActivities()
        {
            await this.AddCityToDb();

            await this.AddUserToDb();

            District district = new District
            {
                Id = TestDistrictId,
                Name = TestDistrictName,
                CityId = TestCityId,   
            };

            this.DbContext.Districts.Add(district);

            await this.DbContext.SaveChangesAsync();

            var expected = new DistrictsViewModel[]
            {
                new DistrictsViewModel
            {
                Id = TestDistrictId,
                Name = TestDistrictName,
                CityId = TestCityId,
            },
            };

            var actual = await this.DistrictsServiceMock.GetAllDistrictsAsync(TestCityId, TestUserId);

            Assert.Collection(
                actual,
                elem1 =>
                {
                    Assert.Equal(expected[0].Id, elem1.Id);
                    Assert.Equal(expected[0].Name, elem1.Name);
                    Assert.Equal(expected[0].CityId, elem1.CityId);
                });

            Assert.Equal(expected.Length, actual.Count());
        }

        [Fact]
        public void SortMethodSortNamesCorrectCorrect()
        {
            var testCollection = new DistrictsViewModel[]
     {
                new DistrictsViewModel
            {
                Id = TestDistrictId + "Test1",
                Name = TestDistrictName + "BTestFirst",
                CityId = TestCityId,
            },
                new DistrictsViewModel
            {
                Id = TestDistrictId + "Test2",
                Name = TestDistrictName + "ATestSecond",
                CityId = TestCityId,
            },
     };

            DistrictsSorter sorter = DistrictsSorter.DistrictName;

            var actual = this.DistrictsServiceMock.SortBy(testCollection, sorter);

            Assert.Collection(
            actual,
            elem1 =>
            {
                Assert.Equal(testCollection[1].Id, elem1.Id);
                Assert.Equal(testCollection[1].Name, elem1.Name);
                Assert.Equal(testCollection[1].CityId, elem1.CityId);
            },
            elem2 =>
            {
                Assert.Equal(testCollection[0].Id, elem2.Id);
                Assert.Equal(testCollection[0].Name, elem2.Name);
                Assert.Equal(testCollection[0].CityId, elem2.CityId);
            });
        }

        [Fact]
        public async void GetDistrictFromeSearch()
        {
            await this.AddCityToDb();

            await this.AddUserToDb();

            var districtFirst = new District
            {
                Id = TestDistrictId + "Test1",
                Name = TestDistrictName + "Abcd",
                CityId = TestCityId,
            };

            var districtSecond = new District
            {
                Id = TestDistrictId + "Test2",
                Name = TestDistrictName + "Efgh",
                CityId = TestCityId,
            };

            this.DbContext.Districts.Add(districtFirst);
            this.DbContext.Districts.Add(districtSecond);

            await this.DbContext.SaveChangesAsync();

            string searchString = TestDistrictName + "Abcd";

            var actual = this.DistrictsServiceMock.GetDistrictsFromSearch(searchString, TestCityId).ToList();

            Assert.Equal(actual[0].Id, districtFirst.Id);
            Assert.Equal(actual[0].Name, TestDistrictName + "Abcd");
            Assert.Equal(actual[0].CityId, TestCityId);

            Assert.Equal(1, actual.Count());
        }

        private async Task AddCityToDb()
        {
            var city = new City
            {
                Id = TestCityId,
                Name = TestCityName,
                Area = TestCityArea,
            };

            this.DbContext.Cities.Add(city);

            await this.DbContext.SaveChangesAsync();
        }

        private async Task AdDistrictToDb()
        {
            var district = new District
            {
                Id = TestDistrictId,
                Name = TestDistrictName,
                CityId = TestCityId,
            };

            this.DbContext.Districts.Add(district);

            await this.DbContext.SaveChangesAsync();
        }

        private async Task AddUserToDb()
        {
            var user = new ApplicationUser
            {
                Id = TestUserId,
                Email = TestUsernameEmail,
                UserName = TestUsernameEmail,
            };

            this.DbContext.Users.Add(user);

            await this.DbContext.SaveChangesAsync();
        }
    }
}
