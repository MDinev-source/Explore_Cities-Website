namespace ResearchLocations.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ResearchLocations.Data.Common.Models;
    using ResearchLocations.Data.Models.Location.RegionComponents;

    public class RegionView : BaseDeletableModel<string>
    {
        public RegionView()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Parks = new HashSet<Park>();
            this.Landmarks = new HashSet<Landmark>();
            this.Shops = new HashSet<Shop>();
            this.Markets = new HashSet<Market>();
            this.RetailParks = new HashSet<RetailPark>();
            this.NonStops = new HashSet<NonStop>();
            this.Restaurants = new HashSet<Restaurant>();
            this.Hobbies = new HashSet<SportHobby>();
            this.Schools = new HashSet<School>();
            this.Stations = new HashSet<Station>();
            this.PoliceStations = new HashSet<PoliceStation>();
            this.Hospitals = new HashSet<Hospital>();
            this.Pharmacies = new HashSet<Pharmacy>();
            this.OtherObjects = new HashSet<OtherObject>();
            this.Pictures = new HashSet<Picture>();
            this.Histories = new HashSet<CityHistory>();
            this.Comments = new HashSet<Comment>();
        }

        public string StreetLocation { get; set; }

        public DateTime YearOfResidence { get; set; }

        public DateTime? YearOfDeparture { get; set; }

        [Required]
        public string RegionDescriptionId { get; set; }

        public virtual RegionDescription Description { get; set; }

        [Required]
        public string RegionId { get; set; }

        public virtual UrbanRegion Region { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Park> Parks { get; set; }

        public virtual ICollection<Landmark> Landmarks { get; set; }

        public virtual ICollection<Shop> Shops { get; set; }

        public virtual ICollection<Market> Markets { get; set; }

        public virtual ICollection<RetailPark> RetailParks { get; set; }

        public virtual ICollection<NonStop> NonStops { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }

        public virtual ICollection<SportHobby> Hobbies { get; set; }

        public virtual ICollection<School> Schools { get; set; }

        public virtual ICollection<Station> Stations { get; set; }

        public virtual ICollection<PoliceStation> PoliceStations { get; set; }

        public virtual ICollection<Hospital> Hospitals { get; set; }

        public virtual ICollection<Pharmacy> Pharmacies { get; set; }

        public virtual ICollection<OtherObject> OtherObjects { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<CityHistory> Histories { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
