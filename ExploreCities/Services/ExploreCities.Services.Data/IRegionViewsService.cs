namespace ExploreCities.Services.Data
{
    using System.Threading.Tasks;

    using ExploreCities.Web.ViewModels.RegionViews;

    public interface IRegionViewsService
    {
        Task CreateAsync(CreateRegionViewInputModel input, string userId);
    }
}
