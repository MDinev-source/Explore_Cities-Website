// ReSharper disable VirtualMemberCallInConstructor
namespace ExploreCities.Data.Models
{
    using System;
    using System.Collections.Generic;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Discussions;
    using ExploreCities.Data.Models.Location;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();

            this.UserCities = new HashSet<UserCity>();
            this.UserDistricts = new HashSet<UserDistrict>();
            this.DistrictLikes = new HashSet<DistrictLike>();
            this.DistrictViewLikes = new HashSet<DistrictViewLike>();
            this.DistrictViewDislikes = new HashSet<DistrictViewDislike>();
            this.Pictures = new HashSet<Picture>();
            this.DistrictObjects = new HashSet<DistrictObject>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        // My properties
        public virtual ICollection<UserCity> UserCities { get; set; }

        public virtual ICollection<UserDistrict> UserDistricts { get; set; }

        public virtual ICollection<DistrictLike> DistrictLikes { get; set; }

        public virtual ICollection<DistrictViewLike> DistrictViewLikes { get; set; }

        public virtual ICollection<DistrictViewDislike> DistrictViewDislikes { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<DistrictObject> DistrictObjects { get; set; }
    }
}
