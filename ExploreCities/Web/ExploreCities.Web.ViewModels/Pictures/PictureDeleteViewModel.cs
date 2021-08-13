namespace ExploreCities.Web.ViewModels.Pictures
{
    using System;

    public class PictureDeleteViewModel
    {
        public string Id { get; set; }

        public string Path { get; set; }

        public string ObjectType { get; set; }

        public string ObjectName { get; set; }

        public DateTime CreateOn { get; set; }
    }
}
