namespace ExploreCities.Web.ViewModels.Cities
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class CitiesViewModel : IHaveCustomMappings, IMapFrom<City>
    {
        public string Id { get; set; }

        [Display(Name = "City name")]
        public string Name { get; set; }

        [Display(Name = "Area")]
        public string Area { get; set; }

        [Display(Name = "District count name")]
        public int DistrictsCount { get; set; }

        [Display(Name = "Users count")]
        public int UsersCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, CitiesViewModel>()
               .ForMember(vm => vm.DistrictsCount, o => o.MapFrom(x => x.Districts.Count))
               .ForMember(vm => vm.UsersCount, o => o.MapFrom(x => x.UserCities.Count));
        }
    }
}
