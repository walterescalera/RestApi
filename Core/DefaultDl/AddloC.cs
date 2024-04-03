using Domain.Services.Persons;
using Infraestructure.Contents;
using Infraestructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DefaultDl
{
    public static class AddloC
    {
        public static IServiceCollection AddInversionOfControl(this IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            return services;
        }
    }
}
