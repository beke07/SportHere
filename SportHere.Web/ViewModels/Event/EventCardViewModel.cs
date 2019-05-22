using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportHere.Web.ViewModels.Event
{
    public class EventCardViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Sport { get; set; }

        public string Date { get; set; }

        public int MaxParticipants { get; set; }

        public int Participants { get; set; }

        public string CreatorName { get; set; }

        public string Comment { get; set; }

        public bool IsLighting { get; set; }

        public bool HasBall { get; set; }

        public bool HasDressingRoom { get; set; }

        public bool IsChallenge { get; set; }

        public int Price { get; set; }

        public int Prize { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public bool ImParticipant { get; set; }
    }
}
