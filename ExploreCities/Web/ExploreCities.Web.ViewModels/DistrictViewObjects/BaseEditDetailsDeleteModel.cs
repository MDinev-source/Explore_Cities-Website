namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class BaseEditDetailsDeleteModel : IHaveCustomMappings, IMapFrom<DistrictObject>
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Object type")]
        public string ObjectType { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        [RegularExpression(@"^[A-Z][a-z]+\s?[A-Za-z0-9]+$", ErrorMessage = "Name is incorrect.")]
        [Display(Name = "Object name")]
        public string Name { get; set; }

        [Required]
        [MinLength(30)]
        [Display(Name = "Opinion")]
        public string Opinion { get; set; }

        public string UserId { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DistrictObject, DistrictViewObjectViewModel>()
                .ForMember(vm => vm.UserId, o => o.MapFrom(x => x.AddedByUserId));
        }
    }
}
