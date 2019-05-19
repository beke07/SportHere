using Microsoft.EntityFrameworkCore;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal;
using SportHere.Dal.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportHere.Bll.Services
{
    public class ApplicationUserService : ServiceBase, IApplicationUserService
    {
        public ApplicationUserService(ApplicationDbContext DbContext) : base(DbContext)
        {
        }

        public async Task SetTeamAsync(int userId, Team team)
        {
            Team teamToUpdate = await DbContext.Users.OfType<Team>().SingleOrDefaultAsync(u => u.Id == userId);

            teamToUpdate.Email = team.Email;
            teamToUpdate.Address = team.Address;
            teamToUpdate.HeadCount = team.HeadCount;
            teamToUpdate.MobilNumber = team.MobilNumber;
            teamToUpdate.PhoneNumber = team.PhoneNumber;

            await DbContext.SaveChangesAsync();
        }

        public async Task SetUserAsync(int userId, User user)
        {
            User userToUpdate = await DbContext.Users.OfType<User>().SingleOrDefaultAsync(u => u.Id == userId);

            userToUpdate.Email = user.Email;
            userToUpdate.Address = user.Address;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.MobilNumber = user.MobilNumber;
            userToUpdate.PhoneNumber = user.PhoneNumber;

            await DbContext.SaveChangesAsync();
        }
    }
}
