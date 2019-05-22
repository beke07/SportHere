using SportHere.Dal.Entities.Users;
using SportHere.DAL.Entities.ModelBase;
using System;
using System.Collections.Generic;

namespace SportHere.Dal.Entities.Events
{
    public class Event : AuditableBase
    {
        public string Description { get; set; }

        public List<Partition> Participants { get; set; }

        public DateTime Date { get; set; }

        public Time To { get; set; }

        public Sport Sport { get; set; }

        public int MaxNumberOfParticipants { get; set; }

        public string Comment { get; set; }

        public int? Price { get; set; }

        public string Color { get; set; }

        public MapDetails MapDetails { get; set; }

        public PitchDetails PitchDetails { get; set; }
    }
}
