using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BookArchive.Application.Interfaces.Repositories
{
    public interface IReadRepository<T>
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            bool tracking = false);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            bool tracking = false);

    }
}
