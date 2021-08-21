namespace ExploreCities.Services.Data.Tests
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models;
    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViews;
    using ExploreCities.Web.ViewModels.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class DistrictViewsServiceTest : BaseServiceTests
    {
        private const string TestCityId = "TestCityId";
        private const string TestCityName = "TestCityName";
        private const string TestCityArea = "TestCityArea";

        private const string TestDistrictId = "TestDistrictId";
        private const string TestDistrictName = "TestDistrictName";

        private const string TestUserId = "TestUserId";
        private const string TestUsernameEmail = "TestEmail@abv.bg";

        private const string TestDViewId = "TestViewId";
        private const string TestDViewComment = "Test Test Test Test Test Test Test Test Test Test Test Test";
        private const int TestDVParkingSpaces = 2;
        private const int TestDVPlaygrounds = 3;
        private const int TestDVAirPollution = 2;
        private const int TestDVNoise = 2;
        private const int TestDVPublicTransport = 1;
        private const string TestDVImageUrl = "https://someurl.com";
        private DateTime testDVCreatedOn = DateTime.Parse("2021 - 08 - 18 17:02:44.4734298", CultureInfo.InvariantCulture);
        private DateTime? testDVModifiedOn = null;

        private IDistrictViewsService DistrictViewsServiceMock => this.ServiceProvider.GetRequiredService<IDistrictViewsService>();

        private ICitiesService CitiesServiceMock => this.ServiceProvider.GetRequiredService<ICitiesService>();


        [Fact]
        public async Task CreateAsyncThrowsArgumentExceptionIfUserAlreadyCreateView()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            var viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.UserDistricts.Add(new UserDistrict
            {
                UserId = TestUserId,
                DistrictId = TestDistrictId,
            });

            await this.DbContext.SaveChangesAsync();

            var invalidCreateInputModel =
             new CreateDistrictViewInputModel
             {
                 CityId = TestCityId,
                 ArrivalYear = 2000,
                 DepartureYear = 1940,
                 DistrictName = TestDistrictName,
                 PictureUrl = TestDVImageUrl,
                 Comment = TestDViewComment,
                 ParkingSpacesExistence = ParkingSpacesExistence.Many.ToString(),
                 ChildrenPlaygroundsExistence = ChildrenPlaygroundsExistence.Many.ToString(),
                 AirPollutionRating = AirPollutionRating.Fresh.ToString(),
                 NoiseRating = NoiseRating.Medium.ToString(),
                 PublicTransportRating = PublicTransportRating.Irregular.ToString(),
             };

            await this.CitiesServiceMock.AddUserToCity(TestUserId, TestCityId);

            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                this.DistrictViewsServiceMock.CreateAsync(invalidCreateInputModel, TestUserId));
            Assert.Equal("User already create district view.", exception.Message);
        }

        [Fact]
        public async Task CreateAsyncThrowsNullArgumentNullExceptionIfRequiredPropertiesIsNull()
        {
            var invalidCreateInputModel =
         new CreateDistrictViewInputModel
         {
             CityId = TestCityId,
             DistrictName = TestDistrictName,
         };

            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() =>
                this.DistrictViewsServiceMock.CreateAsync(invalidCreateInputModel, TestUserId));
            Assert.Equal("Value cannot be null. (Parameter 'value')", exception.Message);
        }

        [Fact]
        public async Task CreateAsyncAddsDistrictViewToDbContextCorrect()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            var createInputModel = new CreateDistrictViewInputModel
            {
                CityId = TestCityId,
                ArrivalYear = 2000,
                DepartureYear = 2020,
                DistrictName = TestDistrictName,
                PictureUrl = TestDVImageUrl,
                Comment = TestDViewComment,
                ParkingSpacesExistence = ParkingSpacesExistence.Many.ToString(),
                ChildrenPlaygroundsExistence = ChildrenPlaygroundsExistence.Many.ToString(),
                AirPollutionRating = AirPollutionRating.Fresh.ToString(),
                NoiseRating = NoiseRating.Medium.ToString(),
                PublicTransportRating = PublicTransportRating.Irregular.ToString(),
            };

            await this.DistrictViewsServiceMock.CreateAsync(createInputModel, TestUserId);

            DistrictView expected = await this.DbContext.DistrictViews.FirstAsync();

            Assert.Equal(1, this.DbContext.DistrictViews.Count());
        }

        [Fact]
        public async Task GetAllAsyncReturnsAllActivities()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            DistrictView viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.DistrictViews.Add(viewToAdded);

            await this.DbContext.SaveChangesAsync();

            var expected = new DistrictViewsViewModel[]
            {
                new DistrictViewsViewModel
            {
                Id = TestDViewId,
                UserId = TestUserId,
                Username = TestUsernameEmail,
                CreatedOn = viewToAdded.CreatedOn,
                ModifiedOn = viewToAdded.ModifiedOn,
            },
            };

            var actual = await this.DistrictViewsServiceMock.GetAllDistrictViewsAsync(TestDistrictId);

            Assert.Collection(
                actual,
                elem1 =>
                {
                    Assert.Equal(expected[0].Id, elem1.Id);
                    Assert.Equal(expected[0].UserId, elem1.UserId);
                    Assert.Equal(expected[0].Username, elem1.Username);
                    Assert.Equal(expected[0].CreatedOn, elem1.CreatedOn);
                    Assert.Equal(expected[0].ModifiedOn, elem1.ModifiedOn);
                });

            Assert.Equal(expected.Length, actual.Count());
        }

        [Fact]
        public async Task GetAllAsyncThrowExceptionWhenDistrictIdIsNull()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            DistrictView viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.DistrictViews.Add(viewToAdded);

            await this.DbContext.SaveChangesAsync();

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                     this.DistrictViewsServiceMock.GetAllDistrictViewsAsync(null));
        }

        [Fact]
        public void SortMethodSortNamesCorrectCorrect()
        {
            var testCollection = new DistrictViewsViewModel[]
     {
                new DistrictViewsViewModel
            {
                Id = TestDViewId + "Test",
                UserId = TestUserId + "Test",
                Username = "BSecondUser",
                CreatedOn = this.testDVCreatedOn,
                ModifiedOn = this.testDVModifiedOn,
            },
                new DistrictViewsViewModel
            {
                Id = TestDViewId,
                UserId = TestUserId,
                Username = "AFirstUser",
                CreatedOn = this.testDVCreatedOn,
                ModifiedOn = this.testDVModifiedOn,
            },
     };

            DistrictViewsSorter sorter = DistrictViewsSorter.Username;

            var actual = this.DistrictViewsServiceMock.SortBy(testCollection, sorter);

            Assert.Collection(
            actual,
            elem1 =>
            {
                Assert.Equal(testCollection[1].Id, elem1.Id);
                Assert.Equal(testCollection[1].UserId, elem1.UserId);
                Assert.Equal(testCollection[1].Username, elem1.Username);
                Assert.Equal(testCollection[1].CreatedOn, elem1.CreatedOn);
                Assert.Equal(testCollection[1].ModifiedOn, elem1.ModifiedOn);
            },
            elem2 =>
            {
                Assert.Equal(testCollection[0].Id, elem2.Id);
                Assert.Equal(testCollection[0].UserId, elem2.UserId);
                Assert.Equal(testCollection[0].Username, elem2.Username);
                Assert.Equal(testCollection[0].CreatedOn, elem2.CreatedOn);
                Assert.Equal(testCollection[0].ModifiedOn, elem2.ModifiedOn);
            });
        }

        [Fact]
        public async void SortShouldThrowExceptionWhenCollectionIsNull()
        {
            DistrictViewsSorter sorter = DistrictViewsSorter.Username;

            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                (Task)this.DistrictViewsServiceMock.SortBy(null, sorter));
        }

        [Fact]
        public async void GetDetailViewModelByIdAsyncShouldWorkCorrectly()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            DistrictView viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.DistrictViews.Add(viewToAdded);

            await this.DbContext.SaveChangesAsync();

            DistrictViewsDetailsViewModel expected = await this.DistrictViewsServiceMock.GetDetailViewModelByIdAsync(viewToAdded.Id);

            Assert.Equal(expected.Id, TestDViewId);
            Assert.Equal(expected.DistrictName, TestDistrictName);
            Assert.Equal(expected.PictureUrl, TestDVImageUrl);
            Assert.Equal(expected.Comment, TestDViewComment);
        }

        [Fact]
        public async void GetDetailViewModelByIdAsyncShouldReturnNullIfIdIsIncorrect()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            DistrictView viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.DistrictViews.Add(viewToAdded);

            await this.DbContext.SaveChangesAsync();

            var expected = await this.DistrictViewsServiceMock.GetDetailViewModelByIdAsync("ErrorId");

            Assert.Null(expected);
        }

        [Fact]
        public async void GetEditViewModelByIdAsyncShouldWorkCorrectly()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            DistrictView viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.DistrictViews.Add(viewToAdded);

            await this.DbContext.SaveChangesAsync();

            DistrictViewEditModel expected = await this.DistrictViewsServiceMock.GetEditViewModelByIdAsync(TestDViewId);

            Assert.Equal(expected.Id, TestDViewId);
            Assert.Equal(expected.DistrictName, TestDistrictName);
            Assert.Equal(expected.PictureUrl, TestDVImageUrl);
            Assert.Equal(expected.Comment, TestDViewComment);
        }


        [Fact]
        public async void GetDeleteViewModelByIdAsyncShouldWorkCorrectly()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            DistrictView viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.DistrictViews.Add(viewToAdded);

            await this.DbContext.SaveChangesAsync();

            DistrictViewDeleteViewModel expected = await this.DistrictViewsServiceMock.GetDeleteViewModelByIdAsync(TestDViewId);

            Assert.Equal(expected.Id, TestDViewId);
            Assert.Equal(expected.DistrictName, TestDistrictName);
            Assert.Equal(expected.PictureUrl, TestDVImageUrl);
            Assert.Equal(expected.Comment, TestDViewComment);
        }

        [Fact]
        public async void GetDeleteViewModelByIdAsyncShouldReturnNullIfIdIsIncorrect()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            DistrictView viewToAdded = this.CorrectDistrictViewDbModel();

            this.DbContext.DistrictViews.Add(viewToAdded);

            await this.DbContext.SaveChangesAsync();

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                         this.DistrictViewsServiceMock.GetDeleteViewModelByIdAsync("ErrorId"));
        }

        private DistrictView CorrectDistrictViewDbModel()
        {
            var view = new DistrictView
            {
                Id = TestDViewId,
                AddedByUserId = TestUserId,
                CreatedOn = this.testDVCreatedOn,
                ModifiedOn = this.testDVModifiedOn,
                ArrivalYear = 2000,
                DepartureYear = 2020,
                DistrictId = TestDistrictId,
                PictureUrl = TestDVImageUrl,
                Comment = TestDViewComment,
                ParkingSpaces = (ParkingSpacesExistence)Enum.ToObject(typeof(ParkingSpacesExistence), TestDVParkingSpaces),
                ChildrenPlaygrounds = (ChildrenPlaygroundsExistence)Enum.ToObject(typeof(ChildrenPlaygroundsExistence), TestDVPlaygrounds),
                AirPollution = (AirPollutionRating)Enum.ToObject(typeof(AirPollutionRating), TestDVAirPollution),
                Noise = (NoiseRating)Enum.ToObject(typeof(NoiseRating), TestDVNoise),
                PublicTransport = (PublicTransportRating)Enum.ToObject(typeof(PublicTransportRating), TestDVPublicTransport),
            };

            return view;
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
