using SportHere.DAL.Entities.ModelBase;
using SportHere.DAL.Entities.ModelInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportHere.Bll.ServiceInterfaces
{
    public interface IServiceBase<T>
    {
        Task DeleteAsnyc(IDbEntry<T> dbEntry);
    }
}
