namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using ExploreCities.Data.Models.Enums;

    public class DistrictViewsDetailsViewModel
    {
        public string CityName { get; set; }

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
