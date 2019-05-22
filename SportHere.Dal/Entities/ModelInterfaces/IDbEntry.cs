namespace SportHere.DAL.Entities.ModelInterfaces
{
    public interface IDbEntry<T>
    {
        T Id { get; set; }

        bool IsDeleted { get; set; }
    }
}
