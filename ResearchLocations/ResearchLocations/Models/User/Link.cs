namespace ResearchLocations.Models.User
{
    using System;
    using ResearchLocations.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    public class Link
    {
        public Link()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        public ContactLinkType ContactLink { get; set; }

        [Required]
        [MaxLength(30)]
        public string Text { get; set; }
        public string LinkUrl { get; set; }

    }
}
