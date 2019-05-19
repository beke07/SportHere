using AutoMapper;
using SportHere.Dal.Entities;
using SportHere.Web.ViewModels.Sport;

namespace SportHere.Web.Mappers
{
    public class SportMapperProfile : Profile
    {
        public SportMapperProfile()
        {
            CreateMap<Sport, SportViewModel>()
                .ReverseMap();
        }
    }
}
