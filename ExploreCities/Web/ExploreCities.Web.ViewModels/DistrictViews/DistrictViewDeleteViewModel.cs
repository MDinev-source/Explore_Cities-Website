using ExploreCities.Data.Models.Enums;

namespace ExploreCities.Web.ViewModels.DistrictViews
{
    public class DistrictViewDeleteViewModel
    {
        public string Id { get; set; }

        public string DistrictName { get; set; }

        public int ArrivalYear { get; set; }

        public int? DepartureYear { get; set; }

        public string Comment { get; set; }

        public string PictureUrl { get; set; }

        public ParkingSpacesExistence ParkingSpacesExistence { get; set; }

        public ChildrenPlaygroundsExistence ChildrenPlaygroundsExistence { get; set; }

        public AirPollutionRating AirPollutionRating { get; set; }

        public NoiseRating NoiseRating { get; set; }

        public PublicTransportRating PublicTransportRating { get; set; }
    }
}
