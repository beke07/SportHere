using AutoMapper;
using SportHere.Dal.Entities;
using SportHere.Web.ViewModels.Select;
using SportHere.Web.ViewModels.Sport;

namespace SportHere.Web.Mappers
{
    public class SportMapperProfile : Profile
    {
        public SportMapperProfile()
        {
            CreateMap<Sport, SportViewModel>()
                .ReverseMap();

            CreateMap<Sport, SelectViewModel>()
                .ForMember(e => e.Text, opt => opt.MapFrom(e => e.Name))
                .ReverseMap();
        }
    }
}
