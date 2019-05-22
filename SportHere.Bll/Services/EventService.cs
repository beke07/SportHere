using Microsoft.EntityFrameworkCore;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal;
using SportHere.Dal.Entities;
using SportHere.Dal.Entities.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportHere.Bll.Services
{
    public class EventService : ServiceBase, IEventService
    {
        public EventService(ApplicationDbContext DbContext) : base(DbContext) { }

        private async Task<T> SetEvent<T>(T eventToSet, T eventToAdd, int userId) where T : Event
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(u => u.Id == userId);
            var sport = await DbContext.Sports.SingleOrDefaultAsync(u => u.Id == eventToAdd.Sport.Id);

            eventToSet.Color = eventToAdd.Color;
            eventToSet.Comment = eventToAdd.Comment;
            eventToSet.Date = eventToAdd.Date;
            eventToSet.To = eventToAdd.To;
            eventToSet.Description = eventToAdd.Description;
            eventToSet.MapDetails = eventToAdd.MapDetails;
            eventToSet.MaxNumberOfParticipants = eventToAdd.MaxNumberOfParticipants;
            eventToSet.PitchDetails = eventToAdd.PitchDetails;
            eventToSet.Sport = sport;
            eventToSet.CreatedBy = user;
            eventToSet.Price = eventToAdd.Price;
            eventToSet.CreationDate = DateTime.Now;
            
            return eventToSet;
        }

        public async Task CreateEventAsync(Event eventToAdd, int userId)
        {
            Event eVent = await SetEvent(new Event(), eventToAdd, userId);

            DbContext.Events.Add(eVent);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int id)
        {
            var eventToDelete = DbContext.Events.SingleOrDefault(e => e.Id == id);
            if(eventToDelete != null)
            {
                await DeleteAsnyc(eventToDelete);
            }
        }

        public async Task EditEventAsync(Event ev, int userId)
        {
            Event eventToEdit = await DbContext.Events.SingleOrDefaultAsync(e => e.Id == ev.Id);

            await SetEvent(eventToEdit, ev, userId);
            await DbContext.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await DbContext.Events
                .Include(e => e.CreatedBy)
                .Include(e => e.Sport)
                .SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Event>> GetEventsToUserAsync(int userId)
        {
            var user = await DbContext.Users.Include(u => u.Events).SingleOrDefaultAsync(u => u.Id == userId);
            return user.Events;
        }

        public async Task CreateChallengeAsync(Challenge challenge, int userId)
        {
            Challenge challengeToAdd = await SetEvent(new Challenge(), challenge, userId);
            challengeToAdd.Prize = challenge.Prize;

            DbContext.Challenges.Add(challengeToAdd);
            await DbContext.SaveChangesAsync();
        }

        private bool checkDistances(List<Settlement> settlements, MapDetails map)
        {
            foreach (var settlement in settlements)
            {
                if (Math.Abs(settlement.Lat - map.Lat) <= 0.2 || Math.Abs(settlement.Long - map.Long) <= 0.2)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<Event>> GetEventsByNear(int userId)
        {
            var user = await DbContext.Users
                .Include(e => e.Sports)
                .Include(e => e.Settlements)
                .SingleOrDefaultAsync(e => e.Id == userId);

            var events = await DbContext.Events
                .Include(e => e.Sport)
                .Include(e => e.Participants)
                .Include(e => e.CreatedBy)
                .Where(e => e.CreatedBy.Id != user.Id && checkDistances(user.Settlements, e.MapDetails))
                .Where(e => user.Sports.Contains(e.Sport) && e.Date > DateTime.Now)
                .ToListAsync();

            return events;
        }

        public async Task ParticipateAsync(int id, int userId)
        {
            var ev = await DbContext.Events.Include(e=> e.Participants).SingleOrDefaultAsync(e => e.Id == id);
            var user = await DbContext.Users.Include(e => e.Participatings).SingleOrDefaultAsync(e => e.Id == userId);

            if(user.Participatings.Count > 0)
            {
                foreach (var part in user.Participatings)
                {
                    if (part.EventId == ev.Id)
                    {
                        user.Participatings.Remove(part);
                        await DbContext.SaveChangesAsync();
                        return;
                    }
                }
            }

            user.Participatings.Add(new Partition() { EventId = ev.Id, UserId = user.Id });
            await DbContext.SaveChangesAsync();
        }
    }
}
