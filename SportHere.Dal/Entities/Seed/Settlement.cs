using SportHere.DAL.Entities.ModelBase;

namespace SportHere.Dal.Entities
{
    public class Settlement : IntDbEntry
    {
        public string Name { get; set; }

        public int ZipCode { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

    }
}
