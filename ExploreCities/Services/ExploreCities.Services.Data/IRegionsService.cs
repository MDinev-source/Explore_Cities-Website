namespace ExploreCities.Services.Data
{
    using System.Threading.Tasks;

    public interface IRegionsService
    {
        Task CreateAsync(string name, string cityId);

        string GetRegionId(string name);
    }
}
