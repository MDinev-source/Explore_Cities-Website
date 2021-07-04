namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;

    using ResearchLocations.Data.Common.Models;
    using ResearchLocations.Data.Models.Enums;

    public class PictureVideo : BaseDeletableModel<string>
    {
        public PictureVideo()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ObjectName { get; set; }

        public FotoType Type { get; set; }

        public string Extension { get; set; }

        public string Comment { get; set; }

        public string RegionViewId { get; set; }

        public virtual RegionView Region { get; set; }

        public string HospitalId { get; set; }

        public virtual Hospital Hospital { get; set; }

        public string LandmarkId { get; set; }

        public virtual Landmark Landmark { get; set; }

        public string MarketId { get; set; }

        public virtual Market Market { get; set; }

        public string NonStopId { get; set; }

        public virtual NonStop NonStop { get; set; }

        public string OtherObjectId { get; set; }

        public virtual OtherObject OtherObject { get; set; }

        public string ParkId { get; set; }

        public virtual Park Park { get; set; }

        public string PharmacyId { get; set; }

        public virtual Pharmacy Pharmacy { get; set; }

        public string PoliceStationId { get; set; }

        public virtual PoliceStation PoliceStation { get; set; }

        public string RestaurantId { get; set; }

        public virtual Restaurant Restaurant { get; set; }

        public string RetailParkId { get; set; }

        public virtual RetailPark RetailPark { get; set; }

        public string SchoolId { get; set; }

        public virtual School School { get; set; }

        public string ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        public string SportHobbyId { get; set; }

        public virtual SportHobby SportHobby { get; set; }

        public string StationId { get; set; }

        public virtual Station Station { get; set; }
    }
}
