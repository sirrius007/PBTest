using Common.JWTAuth;
using PBTestServices.Services.Interfaces;
using static Common.JWTAuth.JWTGenerator;

namespace PBTestAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/OwnersDapper", GetOwnersViaDapper).RequireAuthorization();
        app.MapGet("/OwnersEF", GetOwnersViaEF).RequireAuthorization();
        app.MapGet("/Authenticate/{username}", Authenticate);
    }

    private static async Task<IResult> GetOwnersViaDapper(
        IPBTestService service)
    {
        try
        {
            var result = await service.GetOwnersViaDapperAsync();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetOwnersViaEF(
        IPBTestService service)
    {
        try
        {
            var result = await service.GetOwnersViaEFCoreAsync();
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static IResult Authenticate(string username)
    {
        var result = new JWTTokenReponse
        {
            UserName = username,
            JWTToken = GenerateJWT(username)
        };

        return Results.Ok(result);
    }
}