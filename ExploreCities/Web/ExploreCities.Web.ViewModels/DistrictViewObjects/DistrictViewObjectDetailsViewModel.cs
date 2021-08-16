namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    public class DistrictViewObjectDetailsViewModel : BaseEditDetailsModel
    {
        [Display(Name = "Opinion")]
        public string Opinion { get; set; }

        public string UserId { get; set; }
    }
}
