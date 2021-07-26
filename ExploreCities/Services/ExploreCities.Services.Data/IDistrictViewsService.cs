namespace ExploreCities.Services.Data
{
    using System.Threading.Tasks;

    using ExploreCities.Web.ViewModels.DistrictViews;

    public interface IDistrictViewsService
    {
        Task CreateAsync(CreateDistrictViewInputModel input, string userId);
    }
}
