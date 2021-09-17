namespace ExploreCities.Web.ViewModels.Districts
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class DistrictsViewModel : IHaveCustomMappings, IMapFrom<District>
    {
        public string Id { get; set; }

        [Display(Name = "District name")]
        public string Name { get; set; }

        public string CityId { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        [Display(Name = "Views count")]
        public int DistrictViewsCount { get; set; }

        [Display(Name = "Users count")]
        public int UsersCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<District, DistrictsViewModel>()
               .ForMember(vm => vm.DistrictViewsCount, o => o.MapFrom(x => x.DistrictViews.Count))
               .ForMember(vm => vm.UsersCount, o => o.MapFrom(x => x.UserDistricts.Count));
        }
    }
}
