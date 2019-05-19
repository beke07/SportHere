using SportHere.Dal;

namespace SportHere.Bll.Services
{
    public abstract class ServiceBase
    {
        protected internal ApplicationDbContext DbContext { get; set; }

        public ServiceBase(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }   
    }
}
