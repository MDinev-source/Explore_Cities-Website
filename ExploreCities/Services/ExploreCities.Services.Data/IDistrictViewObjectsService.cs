namespace ExploreCities.Services.Data
{
    using System.Threading.Tasks;

    using ExploreCities.Web.ViewModels.DistrictViewObjects;

    public interface IDistrictViewObjectsService
    {
        Task CreateAsync(CreateDistrictViewObjectInputModel input, string imagePath);
    }
}
