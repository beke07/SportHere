using AutoMapper;
using SportHere.Dal.Entities;
using SportHere.Dal.Entities.Events;
using SportHere.Dal.Entities.Users;
using SportHere.Web.ViewModels.Event;
using System;

namespace SportHere.Web.Mappers
{
    public class EventMapperProfile : Profile
    {
        public EventMapperProfile()
        {
            CreateMap<MapViewModel, MapDetails>()
                .ReverseMap();

            CreateMap<string, Time>()
                .ForMember(m => m.Hour, opt => opt.MapFrom(m => Convert.ToInt32(m.Split(":", StringSplitOptions.None)[0])))
                .ForMember(m => m.Minute, opt => opt.MapFrom(m => Convert.ToInt32(m.Split(":", StringSplitOptions.None)[1])));

            CreateMap<EventViewModel, Sport>()
                .ForMember(m => m.Id, opt => opt.MapFrom(m => m.SportId))
                .ReverseMap();

            CreateMap<EventViewModel, PitchDetails>()
                .ForMember(m => m.HasBall, opt => opt.MapFrom(m => m.HasBall))
                .ForMember(m => m.HasDressingRoom, opt => opt.MapFrom(m => m.HasDressingRoom))
                .ForMember(m => m.IsLighting, opt => opt.MapFrom(m => m.IsLighting))
                .ReverseMap();

            CreateMap<Event, EventGridViewModel>()
                .ForMember(m => m.DateTime, opt => opt.MapFrom(m => m.Date.ToString("yyyy.MM.dd. HH:mm - ") + m.To.Hour + ":" + m.To.Minute))
                .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(m => m.IsChallenge, opt => opt.MapFrom(m => m is Challenge))
                .ForMember(m => m.IsExpired, opt => opt.MapFrom(m => m.Date < DateTime.Now))
                .ForMember(m => m.MaxNumberOfParticipants, opt => opt.MapFrom(m => m.MaxNumberOfParticipants))
                .ForMember(m => m.NumberofParcitipans, opt => opt.MapFrom(m => m.Participants.Count));

            CreateMap<EventViewModel, Event>()
                .ForMember(m => m.Color, opt => opt.MapFrom(m => m.Color))
                .ForMember(m => m.Comment, opt => opt.MapFrom(m => m.Comment))
                .ForMember(m => m.Date, opt => opt.MapFrom(m => m.Date))
                .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(m => m.MapDetails, opt => opt.MapFrom(m => m.Map))
                .ForMember(m => m.MaxNumberOfParticipants, opt => opt.MapFrom(m => m.MaxNumberOfParticipants))
                .ForMember(m => m.PitchDetails, opt => opt.MapFrom(m => m))
                .ForMember(m => m.Sport, opt => opt.MapFrom(m => m))
                .ForMember(m => m.Price, opt => opt.MapFrom(m => m.Price))
                .ForMember(m => m.To, opt => opt.MapFrom(m => m.TimeTo))
                .ReverseMap();

            CreateMap<EventViewModel, Challenge>()
                .IncludeBase<EventViewModel, Event>()
                .ForMember(m => m.Prize, opt => opt.MapFrom(m => m.Prize))
                .ReverseMap();

            CreateMap<Event, EventCardViewModel>()
                .ForMember(m => m.Comment, opt => opt.MapFrom(m => m.Comment))
                .ForMember(m => m.HasBall, opt => opt.MapFrom(m => m.PitchDetails.HasBall))
                .ForMember(m => m.HasDressingRoom, opt => opt.MapFrom(m => m.PitchDetails.HasDressingRoom))
                .ForMember(m => m.IsChallenge, opt => opt.MapFrom(m => m is Challenge))
                .ForMember(m => m.IsLighting, opt => opt.MapFrom(m => m.PitchDetails.IsLighting))
                .ForMember(m => m.Price, opt => opt.MapFrom(m => m.Price))
                .ForMember(m => m.Lat, opt => opt.MapFrom(m => m.MapDetails.Lat))
                .ForMember(m => m.Long, opt => opt.MapFrom(m => m.MapDetails.Long))
                .ForMember(m => m.MaxParticipants, opt => opt.MapFrom(m => m.MaxNumberOfParticipants))
                .ForMember(m => m.Prize, opt => opt.MapFrom(m => m is Challenge ? (m as Challenge).Prize : 0))
                .ForMember(m => m.Sport, opt => opt.MapFrom(m => m.Sport.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(m => m.Description))
                .ForMember(m => m.Date, opt => opt.MapFrom(m => m.Date.ToString("yyyy.MM.dd. HH:MM") + " - " + m.To.Hour + ":" + m.To.Minute))
                .ForMember(m => m.CreatorName, opt => opt.MapFrom(m => m.CreatedBy is User ? (m.CreatedBy as User).FirstName + " " + (m.CreatedBy as User).LastName : (m.CreatedBy as Team).UserName));
        }
    }
}
