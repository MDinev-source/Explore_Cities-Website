namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Enums;

    public class DistrictObject : BaseDeletableModel<string>
    {
        public DistrictObject()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Pictures = new HashSet<Picture>();
        }

        [Required]
        public DistrictObjectType ObjectType { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Opinion { get; set; }

        [Required]
        public string DistrictViewId { get; set; }

        public virtual DistrictView DistrictView { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
