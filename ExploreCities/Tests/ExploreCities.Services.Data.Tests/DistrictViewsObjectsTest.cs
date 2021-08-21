namespace ExploreCities.Services.Data.Tests
{
    using ExploreCities.Data.Models;
    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using System.IO;

    using Xunit;

    public class DistrictViewsObjectsTest : BaseServiceTests
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

        private const string TestObjectName = "TestObjectName";
        private const string TestObjectId = "TestObjectId";
        private const string TestObjectOpinion = "Test Test Test Test Test Test Test Test Test Test Test Test";

        private IDistrictViewObjectsService DistrictViewObjectsServiceMock => this.ServiceProvider.GetRequiredService<IDistrictViewObjectsService>();

        [Fact]
        public async Task CreateAsyncAddsDistrictViewObjectToDbReturnExceptionInvalidImagePath()
        {
            await this.AddCityToDb();

            await this.AdDistrictToDb();

            await this.AddUserToDb();

            await this.AddDistrictViewToDb();

            var createInputModel = new CreateDistrictViewObjectInputModel
            {
                Name = TestObjectName,
                Opinion = TestObjectOpinion,
                ObjectType = DistrictObjectType.Hospital,
                DistrictViewId = TestDViewId,
            };

            await Assert.ThrowsAsync<NullReferenceException>(() =>
                 this.DistrictViewObjectsServiceMock.CreateAsync(createInputModel, TestUserId, "ErrorPath"));
        }

        private async Task AddDistrictViewToDb()
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

            this.DbContext.DistrictViews.Add(view);

            await this.DbContext.SaveChangesAsync();
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
