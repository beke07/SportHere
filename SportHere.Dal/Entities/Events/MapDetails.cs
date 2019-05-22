using Microsoft.EntityFrameworkCore;

namespace SportHere.Dal.Entities.Events
{
    [Owned]
    public class MapDetails
    {
        public double Lat { get; set; }

        public double Long { get; set; }
    }
}
