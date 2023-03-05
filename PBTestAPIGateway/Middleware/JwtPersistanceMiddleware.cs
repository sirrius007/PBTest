using Microsoft.Extensions.Caching.Memory;
using static PBTestAPIGateway.SharedConstants;

namespace PBTestAPIGateway.Middleware;

public static class JwtPersistanceMiddleware
{
    public static void AddJwtPersistance(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            var memoryCache = context.RequestServices.GetService<IMemoryCache>();
            var token = memoryCache?.Get<string>(Jwt_Token);

            if (!string.IsNullOrEmpty(token))
            {
                context.Request.Headers.Add("Authorization", $"Bearer {token}");
            }

            await next.Invoke();
        });
    }
}