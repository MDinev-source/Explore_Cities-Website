namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateDistrictViewInputModel : BaseCreateEditModel
    {
        [Required]
        [Display(Name = "City name")]
        public string CityId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> Cities { get; set; }
    }
}
