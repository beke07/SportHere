using AutoMapper;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Register;

namespace SportHere.Web.Mappers
{
    public class RegisterMapperProfile : Profile
    {
        public RegisterMapperProfile()
        {
            CreateMap<RegisterViewModel, ApplicationUser>()
                .ForMember(e => e.PhoneNumber, opt => opt.MapFrom(e => e.PhoneNumber))
                .ForMember(e => e.MobilNumber, opt => opt.MapFrom(e => e.MobilNumber))
                .ForMember(e => e.UserName, opt => opt.MapFrom(e => e.UserName))
                .ForMember(e => e.Address, opt => opt.MapFrom(e => e.Address))
                .ForMember(e => e.Email, opt => opt.MapFrom(e => e.Email))
                .ReverseMap();

            CreateMap<RegisterViewModel, Team>();
            CreateMap<RegisterViewModel, User>();

            CreateMap<UserRegisterViewModel, User>()
                .IncludeBase<RegisterViewModel, ApplicationUser>()
                .ForMember(e => e.FirstName, opt => opt.MapFrom(e => e.FirstName))
                .ForMember(e => e.LastName, opt => opt.MapFrom(e => e.LastName))
                .ReverseMap();

            CreateMap<TeamRegisterViewModel, Team>()
                .IncludeBase<RegisterViewModel, ApplicationUser>()
                .ForMember(e => e.HeadCount, opt => opt.MapFrom(e => e.HeadCount))
                .ReverseMap();

            CreateMap<UserProfilViewModel, User>()
                .ReverseMap();

            CreateMap<TeamProfilViewModel, Team>()
                .ReverseMap();
        }
    }
}
