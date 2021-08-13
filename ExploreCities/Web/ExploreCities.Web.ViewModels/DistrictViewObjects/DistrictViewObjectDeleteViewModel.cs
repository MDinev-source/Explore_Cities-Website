namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using ExploreCities.Data.Models.Enums;

    public class DistrictViewObjectDeleteViewModel
    {
        public string Id { get; set; }

        public DistrictObjectType ObjectType { get; set; }

        public string Name { get; set; }

        public string Opinion { get; set; }
    }
}
