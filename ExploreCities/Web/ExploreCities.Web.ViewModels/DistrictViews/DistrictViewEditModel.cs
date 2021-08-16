namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    public class DistrictViewEditModel : BaseCreateEditModel
    {
        [Required]
        public string Id { get; set; }
    }
}
