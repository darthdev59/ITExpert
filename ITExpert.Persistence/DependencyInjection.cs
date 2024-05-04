using ITExpert.Domain.Repositories;
using ITExpert.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ITExpert.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseInMemoryDatabase("ValuesDB")

                #if DEBUG
                .EnableSensitiveDataLogging();
                #endif
            });

            services.AddTransient<IValueRepository, ValueRepository>();
            return services;
        }
    }
}
