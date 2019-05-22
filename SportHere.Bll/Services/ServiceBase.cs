using System;
using System.Threading.Tasks;
using SportHere.Bll.ServiceInterfaces;
using SportHere.Dal;
using SportHere.DAL.Entities.ModelInterfaces;

namespace SportHere.Bll.Services
{
    public abstract class ServiceBase : IServiceBase<int>
    {
        protected internal ApplicationDbContext DbContext { get; set; }

        public ServiceBase(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task DeleteAsnyc(IDbEntry<int> dbEntry)
        {
            DbContext.Entry(dbEntry).Entity.IsDeleted = true;
            await DbContext.SaveChangesAsync();
        }
    }
}
