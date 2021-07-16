namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;

    public class CityHistory : BaseDeletableModel<string>
    {
        public CityHistory()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Picture = new HashSet<Picture>();
        }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public string MaterialLinks { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public string CityId { get; set; }

        public virtual City City { get; set; }

        public ICollection<Picture> Picture { get; set; }
    }
}
