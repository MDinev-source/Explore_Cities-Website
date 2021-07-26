namespace ExploreCities.Services.Data
{
    using System.Threading.Tasks;

    public interface IDistrictsService
    {
        Task CreateAsync(string name, string cityId);

        string GetDistrictId(string name);
    }
}
