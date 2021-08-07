namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.Collections.Generic;

    using ExploreCities.Data.Models.Enums;
    using Microsoft.AspNetCore.Http;

    public class CreateDistrictViewObjectInputModel
    {
        public DistrictObjectType ObjectType { get; set; }

        public string Name { get; set; }

        public string Opinion { get; set; }

        public string DistrictViewId { get; set; }

        public ICollection<IFormFile> Pictures { get; set; }
    }
}
