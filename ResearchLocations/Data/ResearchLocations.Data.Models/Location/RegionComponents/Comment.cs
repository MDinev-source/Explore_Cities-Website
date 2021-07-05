namespace ResearchLocations.Data.Models.Location.RegionComponents
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ResearchLocations.Data.Common.Models;

    public class Comment : BaseModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(80)]
        public string Text { get; set; }

        [Required]
        public string RegionViewId { get; set; }

        public virtual RegionView Region { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
