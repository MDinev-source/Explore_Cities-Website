namespace ResearchLocations.Models.Location.Area.AreaComponents
{
    using ResearchLocations.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class PictureVideo
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string ObjectName { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdateOn { get; set; }

        [Required]
        public FotoType Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Comment { get; set; }
    }
}
