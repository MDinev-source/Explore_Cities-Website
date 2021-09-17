namespace ExploreCities.Web.ViewModels.DistrictViews
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ExploreCities.Data.Models.Location;
    using ExploreCities.Services.Mapping;

    public class DistrictViewsViewModel : BasePropertiesModel, IHaveCustomMappings, IMapFrom<DistrictView>
    {
        public string UserId { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified on")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Objects count")]
        public int ObjectsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<DistrictView, DistrictViewsViewModel>()
               .ForMember(vm => vm.DistrictName, o => o.MapFrom(x => x.District.Name))
               .ForMember(vm => vm.UserId, o => o.MapFrom(x => x.AddedByUserId))
               .ForMember(vm => vm.Username, o => o.MapFrom(x => x.AddedByUser.UserName))
               .ForMember(vm => vm.ObjectsCount, o => o.MapFrom(x => x.DistrictObjects.Count));
        }
    }
}
