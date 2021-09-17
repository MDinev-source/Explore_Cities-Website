namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class DistrictViewDeleteViewModel : BasePropertiesModel, IHaveCustomMappings, IMapFrom<DistrictView>
    {
        [Display(Name = "Comment")]
        public string Comment { get; set; }

        [Display(Name = "City name")]
        public string CityName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DistrictView, DistrictViewDeleteViewModel>()
          .ForMember(vm => vm.CityName, o => o.MapFrom(x => x.District.City.Name))
          .ForMember(vm => vm.DistrictName, o => o.MapFrom(x => x.District.Name));
        }
    }
}
