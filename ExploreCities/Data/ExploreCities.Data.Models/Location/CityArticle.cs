namespace ExploreCities.Data.Models.Location
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ExploreCities.Data.Common.Models;
    using ExploreCities.Data.Models.Enums;

    public class CityArticle : BaseDeletableModel<string>
    {
        public CityArticle()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Picture = new HashSet<Picture>();
        }

        [Required]
        public ArticleType Type { get; set; }

        [Required]
        [MaxLength(80)]
        public string Title { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public string MaterialLinks { get; set; }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public string CityId { get; set; }

        public City City { get; set; }

        public virtual ICollection<Picture> Picture { get; set; }
    }
}
