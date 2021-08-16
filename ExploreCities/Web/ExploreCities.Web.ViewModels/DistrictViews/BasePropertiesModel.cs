using System.ComponentModel.DataAnnotations;

namespace ExploreCities.Web.ViewModels.DistrictViews
{
    public class BasePropertiesModel
    {
        public string Id { get; set; }

        public string DistrictId { get; set; }

        [Display(Name = "District name")]
        public string DistrictName { get; set; }

        [Display(Name = "Image URL")]
        public string PictureUrl { get; set; }
    }
}
