using SportHere.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportHere.Bll.ServiceInterfaces
{
    public interface ISettlementService
    {
        /// <summary>
        /// Visszaadja a települések listáját
        /// </summary>
        /// <returns></returns>
        Task<IList<Settlement>> GetSettlementsAsync();

        /// <summary>
        /// Név alapján megkeresi a megfelelő településeket
        /// </summary>
        /// <param name="term"></param>
        /// <returns>települések litájátval</returns>
        Task<IList<Settlement>> FindSettlementsAsync(string term);

        /// <summary>
        /// Hozzáadja a kiválasztott teleüléseket a felhasználó településeihez
        /// </summary>
        /// <param name="userId">felhasználó egyedi azonosítója</param>
        /// <param name="selectedIds">kiválasztott települések azonosítói</param>
        /// <returns></returns>
        Task AddSettlementsToUserAsync(int userId, List<int> selectedIds);

        Task<IList<Settlement>> GetUserSettlementsAsync(int userId);
        
    }
}
