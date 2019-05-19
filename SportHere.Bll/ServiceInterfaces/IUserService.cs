using SportHere.Dal.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportHere.Bll.ServiceInterfaces
{
    public interface IApplicationUserService
    {
        /// <summary>
        /// Frissít egy csapatot
        /// </summary>
        /// <param name="userId">csapat azonosítója</param>
        /// <param name="team">csapat adatai</param>
        /// <returns></returns>
        Task SetTeamAsync(int userId, Team team);

        /// <summary>
        /// Frissít egy játékost
        /// </summary>
        /// <param name="userId">játékos azonosítója</param>
        /// <param name="team">játékos adatai</param>
        /// <returns></returns>
        Task SetUserAsync(int userId, User user);
    }
}
