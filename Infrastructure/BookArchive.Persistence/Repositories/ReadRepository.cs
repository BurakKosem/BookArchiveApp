using BookArchive.Application.Interfaces.Repositories;
using BookArchive.Domain.Common;
using BookArchive.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookArchive.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly MssqlDbContext _dbContext;

        public ReadRepository(MssqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Table => _dbContext.Set<T>();

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, bool tracking = false)
        {
            IQueryable<T> query = Table;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate is not null)
            {
                query = query.Where(predicate);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool tracking = false)
        {
            IQueryable<T> query = Table;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (predicate is not null)
            {
                query = query.Where(predicate);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
