using SportHere.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportHere.Bll.ServiceInterfaces
{
    public interface ISettlementService
    {
        Task<IList<Settlement>> GetSettlements();

        Task<IList<Settlement>> FindSettlements(string term);

        Task AddSettlementsToUser(int userId, List<int> selectedIds);

        Task<IList<Settlement>> GetUserSettlements(int userId);

    }
}
