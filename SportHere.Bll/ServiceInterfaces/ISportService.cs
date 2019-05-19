using SportHere.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportHere.Bll.ServiceInterfaces
{
    public interface ISportService
    {
        /// <summary>
        /// Visszaadja a lapozható sportok listáját
        /// </summary>
        /// <param name="currentPage">aktuális oldal</param>
        /// <param name="pageSize">egy oldalon lévő sportok száma</param>
        /// <returns></returns>
        Task<List<Sport>> GetPaginatedSportListAsync(int currentPage, int pageSize = 10);

        /// <summary>
        /// Visszaaja egy felhasználó sportjait
        /// </summary>
        /// <param name="userId">felhasználó egyedi azonosítója</param>
        /// <returns></returns>
        Task<List<int>> GetSportIdListToUserAsync(int userId);

        /// <summary>
        /// A kiválasztott sportokat a felhasználóhoz adja
        /// </summary>
        /// <param name="userId">felhasználó egyedi azonosítója</param>
        /// <param name="kivalasztottSportok">kiválasztott sportok listája</param>
        /// <returns></returns>
        Task AddSportsToUserAsync(int userId, IList<int> kivalasztottSportok);

        /// <summary>
        /// A sportok számát adja vissza
        /// </summary>
        /// <returns></returns>
        Task<int> GetCountAsync();
    }
}
