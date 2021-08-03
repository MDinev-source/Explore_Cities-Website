namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Articles = new HashSet<CityArticle>();
            this.Districts = new HashSet<District>();
            this.UserCities = new HashSet<UserCity>();
        }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Area { get; set; }

        public virtual ICollection<CityArticle> Articles { get; set; }

        public virtual ICollection<District> Districts { get; set; }

        public ICollection<UserCity> UserCities { get; set; }
    }
}
