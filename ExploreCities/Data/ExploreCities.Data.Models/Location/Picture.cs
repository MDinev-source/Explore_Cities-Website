namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;

    public class Picture : BaseDeletableModel<string>
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string ObjectName { get; set; }

        [Required]
        public string Extension { get; set; }

        [Required]
        [MaxLength(80)]
        public string Comment { get; set; }

        [Required]
        public string DistrictObjectId { get; set; }

        public DistrictObject DistrictObject { get; set; }
    }
}
