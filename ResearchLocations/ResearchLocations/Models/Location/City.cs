namespace ResearchLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ResearchLocations.Models.Location.Area;
    public class City
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Histories = new HashSet<History>();
            this.Areas = new HashSet<Area>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ICollection<History> Histories { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }
}
