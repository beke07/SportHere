using SportHere.DAL.Entities.ModelInterfaces;

namespace SportHere.DAL.Entities.ModelBase
{
    public class IntDbEntry : IDbEntry<int>
    {
        public int Id { get; set; }
    }
}
