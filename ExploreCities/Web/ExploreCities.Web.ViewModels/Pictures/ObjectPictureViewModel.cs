namespace ExploreCities.Web.ViewModels.Pictures
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ObjectPictureViewModel
    {
        public string Id { get; set; }

        public string DistrictViewObjectId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Path { get; set; }

        public string UserId { get; set; }
    }
}
