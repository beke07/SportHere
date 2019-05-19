using Microsoft.EntityFrameworkCore;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal;
using SportHere.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportHere.Bll.Services
{
    public class SportService : ServiceBase, ISportService
    {
        public SportService(ApplicationDbContext DbContext) : base(DbContext) { }

        public async Task AddSportsToUserAsync(int userId, IList<int> kivalasztottSportok)
        {
            var user = await DbContext.Users.SingleOrDefaultAsync(e => e.Id == userId);

            if (user != null)
            {
                var sportok = await DbContext.Sports.Where(e => kivalasztottSportok.Contains(e.Id)).ToListAsync();

                user.Sports.Clear();
                user.Sports.AddRange(sportok);
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<int> GetCountAsync()
        {
            return await DbContext.Sports.CountAsync();
        }

        public async Task<List<Sport>> GetPaginatedSportListAsync(int currentPage, int pageSize = 10)
        {
            var sports = await DbContext.Sports.ToListAsync();
            return ToPagedList(sports, currentPage, pageSize);
        }

        public async Task<List<int>> GetSportIdListToUserAsync(int userId)
        {
            return (await DbContext.Users.Include(u => u.Sports).SingleOrDefaultAsync(u => u.Id == userId))
                .Sports.Select(s => s.Id).ToList();
        }

        private List<Sport> ToPagedList(IList<Sport> sports, int currentPage, int pageSize)
        {
            return sports.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
