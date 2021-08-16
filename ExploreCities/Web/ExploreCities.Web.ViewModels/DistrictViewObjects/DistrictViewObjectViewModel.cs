namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    public class DistrictViewObjectViewModel : BaseEditDetailsModel
    {
        [Display(Name = "Pictures count")]
        public int PicturesCount { get; set; }
    }
}
