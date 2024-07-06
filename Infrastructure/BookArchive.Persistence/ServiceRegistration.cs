using BookArchive.Application.Interfaces.Repositories;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Persistence.Contexts;
using BookArchive.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookArchive.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration config)
        {
            var assebly = Assembly.GetExecutingAssembly();

            services.AddDbContext<MssqlDbContext>(options => options.UseSqlServer(config.GetConnectionString("MssqlConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();


        }
    }
}
