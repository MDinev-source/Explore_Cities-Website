namespace ResearchLocations.Models.Location.Area.AreaComponents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Hospital
    {
        public Hospital()
        {
            this.Id = Guid.NewGuid().ToString();

            this.PictureVideos = new HashSet<PictureVideo>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Opinion { get; set; }

        public virtual ICollection<PictureVideo> PictureVideos { get; set; }
    }
}
