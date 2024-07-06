using BookArchive.Application.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookArchive.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection service) 
        {
            var assembly = Assembly.GetExecutingAssembly();

            service.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

            service.AddAutoMapper(assembly);

            service.AddFluentValidationAutoValidation();
            service.AddValidatorsFromAssemblyContaining<BookValidator>();
        }
    }
}
