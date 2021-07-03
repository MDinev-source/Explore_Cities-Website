namespace ResearchLocations.Models.User
{
    using System;
    using ResearchLocations.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    public class Interest
    {
        public Interest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public InterestType InterestType { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
