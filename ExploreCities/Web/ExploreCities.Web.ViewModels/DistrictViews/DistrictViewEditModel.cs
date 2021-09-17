namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class DistrictViewEditModel : BaseCreateEditModel, IHaveCustomMappings, IMapFrom<DistrictView>
    {
        [Required]
        public string Id { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DistrictView, DistrictViewsViewModel>()
               .ForMember(vm => vm.DistrictName, o => o.MapFrom(x => x.District.Name));
        }
    }
}
