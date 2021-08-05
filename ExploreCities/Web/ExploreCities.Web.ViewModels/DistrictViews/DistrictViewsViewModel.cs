namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System;

    public class DistrictViewsViewModel
    {
        public string Id { get; set; }

        public string DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string PictureUrl { get; set; }

        public string UserId { get; set; }

        public string Username { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int ObjectsCount { get; set; }
    }
}
