using SportHere.Dal.Entities.Users;
using SportHere.DAL.Entities.ModelInterfaces;
using System;

namespace SportHere.DAL.Entities.ModelBase
{
    public class AuditableBase : IntDbEntry, IAuditableBase
    {
        public DateTime CreationDate { get; set; }

        public ApplicationUser CreatedBy { get; set; }
    }
}
