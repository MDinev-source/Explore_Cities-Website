namespace ExploreCities.Web.Middlewares
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using ExploreCities.Data;
    using ExploreCities.Data.Models.Location;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    public class SeedCitiesMiddleware
    {
        private readonly RequestDelegate next;
        private ApplicationDbContext dbContext;

        public SeedCitiesMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(
        HttpContext context,
        ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;

            await this.SeedCities();
            await this.next(context);
        }

        private async Task SeedCities()
        {
            var seededCities = this.dbContext.Cities;

            if (seededCities.Any())
            {
                return;
            }

            var jsonString = File.ReadAllText("bg.json");

            var citiesImport = JsonConvert.DeserializeObject<ImportCitiesDTO[]>(jsonString);

            var cities = new List<City>();

            foreach (var cityDto in citiesImport)
            {
                var city = new City
                {
                    Name = cityDto.City,
                    Area = cityDto.Admin_name,
                };

                cities.Add(city);
            }

            await this.dbContext.Cities.AddRangeAsync(cities);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
