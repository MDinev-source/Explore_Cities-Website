namespace ExploreCities.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Web.ViewModels.Cities;
    using ExploreCities.Web.ViewModels.Enums;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class CitiesTest : BaseServiceTests
    {
        private ICitiesService CitiesServiceMock => this.ServiceProvider.GetRequiredService<ICitiesService>();

        [Fact]
        public void SortMethodSortNamesCorrectCorrect()
        {
            var testCollection = new CitiesViewModel[]
     {
                new CitiesViewModel
            {
                Id = "Test1",
                Name = "BTestFirst",
                Area = "A"
            },
                new CitiesViewModel
            {
                Id = "Test2",
                Name ="ATestSecond",
                Area = "B",
            },
     };

            CitiesSorter sorter = CitiesSorter.CityName;

            var actual = this.CitiesServiceMock.SortBy(testCollection, sorter);

            Assert.Collection(
            actual,
            elem1 =>
            {
                Assert.Equal(testCollection[1].Id, elem1.Id);
                Assert.Equal(testCollection[1].Name, elem1.Name);
                Assert.Equal(testCollection[1].Area, elem1.Area);
            },
            elem2 =>
            {
                Assert.Equal(testCollection[0].Id, elem2.Id);
                Assert.Equal(testCollection[0].Name, elem2.Name);
                Assert.Equal(testCollection[0].Area, elem2.Area);
            });
        }

        [Fact]
        public async void GetDistrictFromeSearch()
        {

            var citieFirst = new City
            {
                Id = "Test1",
                Name = "Abcd",
                Area = "A",
            };

            var citieSecond = new City
            {
                Id = "Test2",
                Name = "Efgh",
                Area = "B",
            };

            this.DbContext.Cities.Add(citieFirst);
            this.DbContext.Cities.Add(citieSecond);

            await this.DbContext.SaveChangesAsync();

            string searchString = "Abcd";

            var actual = this.CitiesServiceMock.GetCitiesFromSearch(searchString, "Name").ToList();

            Assert.Equal(1, actual.Count);
        }

    }
}
