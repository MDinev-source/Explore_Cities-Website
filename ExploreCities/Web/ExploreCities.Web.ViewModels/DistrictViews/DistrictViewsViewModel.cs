namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class DistrictViewsViewModel : BasePropertiesModel
    {
        public string UserId { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified on")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Objects count")]
        public int ObjectsCount { get; set; }
    }
}
