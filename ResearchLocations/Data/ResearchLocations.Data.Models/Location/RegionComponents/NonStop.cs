namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ResearchLocations.Data.Common.Models;

    public class NonStop : BaseDeletableModel<string>
    {
        public NonStop()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Pictures = new HashSet<Picture>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Opinion { get; set; }

        [Required]
        public string RegionViewId { get; set; }

        public virtual RegionView Region { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
