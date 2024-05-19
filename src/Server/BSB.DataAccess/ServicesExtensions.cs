using BSB.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceExtension
{
    public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BSBDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IRepositoryManager, RepositoryManager>();

    }
}