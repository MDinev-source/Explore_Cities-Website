namespace ExploreCities.Data.Models.Discussions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Discussion
    {
        public Discussion()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Comments = new HashSet<Comment>();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Topic { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
