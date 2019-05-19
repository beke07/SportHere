using Microsoft.EntityFrameworkCore;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Bll.Services;
using SportHere.Dal;
using SportHere.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportHere.BLL.Services
{
    public class SettlementService : ServiceBase, ISettlementService
    {
        public SettlementService(ApplicationDbContext DbContext) : base(DbContext) { }

        public async Task AddSettlementsToUserAsync(int userId, List<int> selectedIds)
        {
            var user = await DbContext.Users.Include(u => u.Settlements).SingleOrDefaultAsync(e => e.Id == userId);

            if (user != null)
            {
                var telepulesek = await DbContext.Settlements.Where(e => selectedIds.Contains(e.Id)).ToListAsync();

                user.Settlements.Clear();
                user.Settlements.AddRange(telepulesek);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Settlement>> FindSettlementsAsync(string term)
        {
            return await DbContext.Settlements
                .Where(s => s.Name.ToLower().Contains(term.ToLower()))
                .ToListAsync();
        }

        public async Task<IList<Settlement>> GetSettlementsAsync()
        {
            return await DbContext.Settlements.ToListAsync();
        }

        public async Task<IList<Settlement>> GetUserSettlementsAsync(int userId)
        {
            return (await DbContext.Users.Include(e => e.Settlements)
                .SingleAsync(u => u.Id == userId)).Settlements.ToList();
        }
    }
}
