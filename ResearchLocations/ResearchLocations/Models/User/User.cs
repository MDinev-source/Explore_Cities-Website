namespace ResearchLocations.Models.User
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using ResearchLocations.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {

        public User()
        {
            this.Interests = new HashSet<Interest>();
            this.Educations = new HashSet<Education>();
            this.Cities = new HashSet<City>();
            this.Invitations = new HashSet<Invitation>();
        }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public GenderType Gender { get; set; }

        public virtual ICollection<Interest> Interests { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
