using AutoMapper;
using SportHere.Dal.Entities;
using SportHere.Web.ViewModels.Select;

namespace SportHere.Web.Mappers
{
    public class SettlementMapperProfile : Profile
    {
        public SettlementMapperProfile()
        {
            CreateMap<Settlement, SelectViewModel>()
                .ForMember(s => s.Text, opt => opt.MapFrom(s => s.Name + " - " + s.ZipCode))
                .ReverseMap();
        }
    }
}
