using DataAccess.Data;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static DataAccess.SharedConstants;

namespace DataAccess;


public static class Startup
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<PBTestContext>(options =>
            options.UseSqlite(config.GetConnectionString(ConnectionString)));

        services.AddScoped<IOwnerRepository, OwnerEFCoreRepository>();
        services.AddScoped<IOwnerRepository>(c => new OwnerDapperRepository(config));
    }
}