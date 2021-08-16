namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.Collections.Generic;

    using ExploreCities.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class CreateDistrictViewObjectInputModel : BaseCreateDeleteModel
    {
        public string DistrictViewId { get; set; }

        public ICollection<IFormFile> Pictures { get; set; }
    }
}
