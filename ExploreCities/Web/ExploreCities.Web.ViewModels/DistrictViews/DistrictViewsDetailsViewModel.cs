namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.Collections.Generic;

    using ExploreCities.Data.Models.Enums;
    using ExploreCities.Web.ViewModels.DistrictViewObjects;

    public class DistrictViewsDetailsViewModel
    {
        public string Id { get; set; }

        public string CityName { get; set; }

        public string DistrictName { get; set; }

        public int ArrivalYear { get; set; }

        public int? DepartureYear { get; set; }

        public string Comment { get; set; }

        public string PictureUrl { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public ParkingSpacesExistence ParkingSpacesExistence { get; set; }

        public ChildrenPlaygroundsExistence ChildrenPlaygroundsExistence { get; set; }

        public AirPollutionRating AirPollutionRating { get; set; }

        public NoiseRating NoiseRating { get; set; }

        public PublicTransportRating PublicTransportRating { get; set; }

        public ICollection<CreateDistrictViewObjectInputModel> DistrictViewObjects { get; set; }
    }
}
