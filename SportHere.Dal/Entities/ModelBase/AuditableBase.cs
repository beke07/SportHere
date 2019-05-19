using SportHere.Dal.Entities.Users;
using SportHere.DAL.Entities.ModelInterfaces;
using System;

namespace SportHere.DAL.Entities.ModelBase
{
    public class AuditableBase : IAuditableBase
    {
        public DateTime CreationDate { get; set; }

        public ApplicationUser CreatedBy { get; set; }

        public ApplicationUser LastModifiedBy { get; set; }
    }
}
