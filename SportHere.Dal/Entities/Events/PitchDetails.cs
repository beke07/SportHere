using Microsoft.EntityFrameworkCore;

namespace SportHere.Dal.Entities.Events
{
    [Owned]
    public class PitchDetails
    {
        public bool IsLighting { get; set; }

        public bool HasBall { get; set; }

        public bool HasDressingRoom { get; set; }
    }
}
