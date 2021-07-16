namespace ExploreCities.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using ExploreCities.Data.Models.Location;
    using Newtonsoft.Json;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var path = Directory.GetCurrentDirectory()
                .Replace(@"\Web\", @"\Data\")
                .Replace(".Web", ".Data")
                + @"/Seeding/CitiesSeeder/bg.json";

            var jsonString = File.ReadAllText(path);

            var citiesImport = JsonConvert.DeserializeObject<ImportCitiesDto[]>(jsonString);

            var cities = new List<City>();

            foreach (var cityDto in citiesImport)
            {
                var city = new City
                {
                    Name = cityDto.City,
                    Region = cityDto.Admin_name,
                };

                cities.Add(city);
            }

            await dbContext.Cities.AddRangeAsync(cities);
            await dbContext.SaveChangesAsync();
        }
    }
}
