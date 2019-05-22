using System.Collections.Generic;
using System.Threading.Tasks;
using SportHere.Dal.Entities.Events;

namespace SportHere.Bll.ServiceInterfaces
{
    public interface IEventService
    {
        Task CreateEventAsync(Event eventToAdd, int userId);

        Task<List<Event>> GetEventsToUserAsync(int userId);

        Task<Event> GetEventByIdAsync(int id);

        Task DeleteEventAsync(int id);

        Task EditEventAsync(Event ev, int userId);

        Task CreateChallengeAsync(Challenge challenge, int userId);

        Task<List<Event>> GetEventsByNear(int userId);

        Task ParticipateAsync(int id, int userId);
    }
}
