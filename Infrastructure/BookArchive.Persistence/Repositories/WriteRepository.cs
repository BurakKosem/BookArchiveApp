using BookArchive.Application.Interfaces.Repositories;
using BookArchive.Domain.Common;
using BookArchive.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BookArchive.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly MssqlDbContext _dbContext;

        public WriteRepository(MssqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table => _dbContext.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public void DeleteRange(IList<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}
