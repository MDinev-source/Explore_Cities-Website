namespace ResearchLocations.Models.User
{
    using System;
    using ResearchLocations.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    public class Education
    {
        public Education()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        [Required]
        public EducationType EducationType { get; set; }

        [Required]
        [MaxLength(30)]
        public string SchoolTitle { get; set; }

        [Required]
        [MaxLength(30)]
        public string CityTitle { get; set; }

        [Required]
        [MaxLength(30)]
        public string Qualification { get; set; }

        public DateTime StartDate { get; set; }

        public string EndDate => EndDate == null ? "Present" : this.EndDate;

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
