using BookArchive.Application.Interfaces.Repositories;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Persistence.Contexts;
using BookArchive.Persistence.Repositories;

namespace BookArchive.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MssqlDbContext _dbContext;

        public UnitOfWork(MssqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
