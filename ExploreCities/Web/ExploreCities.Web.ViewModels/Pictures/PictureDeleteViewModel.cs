namespace ExploreCities.Web.ViewModels.Pictures
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PictureDeleteViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Picture")]
        public string Path { get; set; }

        [Display(Name = "Object type")]
        public string ObjectType { get; set; }

        [Display(Name = "Object name")]
        public string ObjectName { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreateOn { get; set; }
    }
}
