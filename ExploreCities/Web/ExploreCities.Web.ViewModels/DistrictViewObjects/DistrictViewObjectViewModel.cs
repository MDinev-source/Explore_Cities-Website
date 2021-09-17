namespace ExploreCities.Web.ViewModels.DistrictViewObjects
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class DistrictViewObjectViewModel : BaseEditDetailsDeleteModel, IHaveCustomMappings, IMapFrom<DistrictObject>
    {
        [Display(Name = "Pictures count")]
        public int PicturesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DistrictObject, DistrictViewObjectViewModel>()
                .ForMember(vm => vm.PicturesCount, o => o.MapFrom(x => x.Pictures.Count));
        }
    }
}
