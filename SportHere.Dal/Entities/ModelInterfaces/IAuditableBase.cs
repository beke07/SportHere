using SportHere.Dal.Entities.Users;
using System;

namespace SportHere.DAL.Entities.ModelInterfaces
{
    public interface IAuditableBase
    {
        DateTime CreationDate { get; set; }

        ApplicationUser CreatedBy { get; set; }

        ApplicationUser LastModifiedBy { get; set; }
    }
}
