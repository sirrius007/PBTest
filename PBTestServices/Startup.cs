using Microsoft.Extensions.DependencyInjection;
using PBTestServices.Services;
using PBTestServices.Services.Interfaces;

namespace PBTestServices;

public static class Startup
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPBTestService, PBTestService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}