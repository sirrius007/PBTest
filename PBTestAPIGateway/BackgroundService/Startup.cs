using PBTestAPIGateway.TokenProvider;

namespace PBTestAPIGateway.BackgroundService;

public static class Startup
{
    public static void AddJwtBackgoundService(this IServiceCollection services)
    {
        services.AddSingleton<JWTBackgroundService>();
        services.AddSingleton<IHostedService>(s => s.GetService<JWTBackgroundService>() ?? throw new InvalidOperationException());
    }
}