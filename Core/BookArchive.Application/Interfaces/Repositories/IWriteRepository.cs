namespace BookArchive.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T>
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        void DeleteRange(IList<T> entities);

    }
}
