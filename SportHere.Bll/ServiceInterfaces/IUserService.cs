using SportHere.Dal.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportHere.Bll.ServiceInterfaces
{
    public interface IApplicationUserService
    {
        Task SetTeamAsync(int userId, Team team);

        Task SetUserAsync(int userId, User user);
    }
}
