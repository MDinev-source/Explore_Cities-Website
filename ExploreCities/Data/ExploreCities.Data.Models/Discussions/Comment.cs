﻿namespace ExploreCities.Data.Models.Discussions
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Location;

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
        public string DistrictViewId { get; set; }

        public virtual DistrictView DistrictView { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
