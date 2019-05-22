using Microsoft.EntityFrameworkCore;

namespace SportHere.Dal.Entities.Events
{
    [Owned]
    public class Time
    {
        public int Hour { get; set; }

        public int Minute { get; set; }
    }
}
