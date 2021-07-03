namespace ResearchLocations.Models.Location.Area
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ResearchLocations.Models.Location.Area.AreaComponents;

    public class Area
    {
        public Area()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Parks = new HashSet<Park>();
            this.Landmarks = new HashSet<Landmark>();
            this.Shops = new HashSet<Shop>();
            this.Markets = new HashSet<Market>();
            this.RetailParks = new HashSet<RetailPark>();
            this.NonStops = new HashSet<NonStop>();
            this.Restaurants = new HashSet<Restaurant>();
            this.Hobbies = new HashSet<Hobby>();
            this.Schools = new HashSet<School>();
            this.Stations = new HashSet<Station>();
            this.PoliceStations = new HashSet<PoliceStation>();
            this.Hospitals = new HashSet<Hospital>();
            this.Pharmacies = new HashSet<Pharmacy>();
            this.OtherObjects = new HashSet<OtherObject>();
            this.PictureVideos = new HashSet<PictureVideo>();
            this.Histories = new HashSet<History>();
            this.Comments = new HashSet<Comment>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public string Street { get; set; }

        public int Rating { get; set; }

        public DateTime YearOfResidence { get; set; }

        public DateTime? YearOfDeparture { get; set; }

        [Required]
        public string AreaDescriptionId { get; set; }
        public AreaDescription Description { get; set; }

        public virtual ICollection<Park> Parks { get; set; }
        public virtual ICollection<Landmark> Landmarks { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Market> Markets { get; set; }
        public virtual ICollection<RetailPark> RetailParks { get; set; }
        public virtual ICollection<NonStop> NonStops { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
        public virtual ICollection<Hobby> Hobbies { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<Station> Stations { get; set; }
        public virtual ICollection<PoliceStation> PoliceStations { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
        public virtual ICollection<Pharmacy> Pharmacies { get; set; }
        public virtual ICollection<OtherObject> OtherObjects { get; set; }
        public virtual ICollection<PictureVideo> PictureVideos { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
