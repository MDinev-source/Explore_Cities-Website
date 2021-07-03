﻿namespace ResearchLocations.Models.Location.Area.AreaComponents
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ResearchLocations.Models.User;
    public class Comment
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
