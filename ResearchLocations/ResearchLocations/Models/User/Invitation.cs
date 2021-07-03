namespace ResearchLocations.Models.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Invitation
    {
        public Invitation()
        {
            this.Id = Guid.NewGuid().ToString();

            this.ContactLinks = new HashSet<Link>();
        }
        public string Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }

        public bool IsRead { get; set; }

        [Required]
        public string CreatorId { get; set; }
        public User User { get; set; }
        public DateTime CreateOn { get; set; }
        public ICollection<Link> ContactLinks { get; set; }
    }
}
