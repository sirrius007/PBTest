using Common.JWTAuth;
using Microsoft.Extensions.Caching.Memory;
using static PBTestAPIGateway.SharedConstants;

namespace PBTestAPIGateway.TokenProvider;

public class JWTBackgroundService : IHostedService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _cache;

    public JWTBackgroundService(
        HttpClient httpClient,
        IConfiguration configuration,
        IMemoryCache cache)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _cache = cache;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var tokenEndpoint = _configuration[TokenEndpoint];

        var tokenResponse = await _httpClient.GetAsync(tokenEndpoint);
        tokenResponse.EnsureSuccessStatusCode();

        var token = await tokenResponse.Content.ReadFromJsonAsync<JWTTokenReponse>();
        _cache.Set(Jwt_Token, token?.JWTToken, new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(1)));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}