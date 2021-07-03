namespace ResearchLocations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ResearchLocations.Models.Location.Area;
    using ResearchLocations.Models.Location.Area.AreaComponents;

    public class History
    {
        public History()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public string MaterialLinks { get; set; }

        [Required]
        public string CityId { get; set; }
        public City City { get; set; }

        public string AreaId { get; set; }
        public Area Area { get; set; }

        public ICollection<PictureVideo> PictureVideos { get; set; }

    }
}
