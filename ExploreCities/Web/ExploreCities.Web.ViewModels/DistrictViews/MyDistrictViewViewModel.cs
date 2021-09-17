namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class MyDistrictViewViewModel : DistrictViewsViewModel, IHaveCustomMappings, IMapFrom<DistrictView>
    {
        [Display(Name = "City name")]
        public string CityName { get; set; }

        [Display(Name = "District name")]
        public string DistricName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DistrictView, MyDistrictViewViewModel>()
               .ForMember(vm => vm.Username, o => o.MapFrom(x => x.AddedByUser.UserName))
               .ForMember(vm => vm.ObjectsCount, o => o.MapFrom(x => x.DistrictObjects.Count));
        }
    }
}
