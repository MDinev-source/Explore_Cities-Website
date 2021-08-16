namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    public class DistrictViewObjectEditModel : BaseEditDetailsModel
    {
        [Required]
        [MinLength(30)]
        [Display(Name = "Opinion")]
        public string Opinion { get; set; }
    }
}
