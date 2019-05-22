using SportHere.Dal.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportHere.Dal.Entities.Events
{
    public class Partition
    {
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
