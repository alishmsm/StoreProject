using Microsoft.EntityFrameworkCore;
using Store.Persistence.Contexts;

namespace Site.EndPoint.Extensions;

public static class DbConfigExtensions
{
    public static IServiceCollection AddDbConfig(this IServiceCollection service, IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("SqlServer")
            ?? throw new InvalidOperationException("Connection string"
                                                   + "'SqlServer' not found.");

        service.AddDbContext<DataBaseContext>(options =>
            options.UseSqlServer(connectionString));
        
        service.AddDbContext<IdentityDataBaseContext>(options =>
            options.UseSqlServer(connectionString));
        return service;
    }
}