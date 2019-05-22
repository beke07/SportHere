using Microsoft.AspNetCore.Identity;
using SportHere.Dal.Entities.Events;
using System.Collections.Generic;

namespace SportHere.Dal.Entities.Users
{
    public abstract class ApplicationUser : IdentityUser<int>
    {
        public string MobilNumber { get; set; }

        public string Address { get; set; }

        public virtual List<Partition> Participatings { get; set; }

        public virtual List<Settlement> Settlements { get; set; } = new List<Settlement>();

        public virtual List<Sport> Sports { get; set; } = new List<Sport>();

        public virtual List<Event> Events { get; set; } = new List<Event>();
    }
}
