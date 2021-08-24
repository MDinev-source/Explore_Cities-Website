namespace ExploreCities.Web.ViewModels.Pictures
{
    using System;

    public class ObjectPictureViewModel
    {
        public string Id { get; set; }

        public string DistrictViewObjectId { get; set; }

        public string ObjectName { get; set; }

        public string ObjectType { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Path { get; set; }

        public string UserId { get; set; }
    }
}
