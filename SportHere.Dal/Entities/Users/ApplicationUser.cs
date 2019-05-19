using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SportHere.Dal.Entities.Users
{
    public abstract class ApplicationUser : IdentityUser<int>
    {
        public string MobilNumber { get; set; }

        public string Address { get; set; }

        public virtual List<Settlement> Settlements { get; set; } = new List<Settlement>();

        public virtual List<Sport> Sports { get; set; } = new List<Sport>();
    }
}
