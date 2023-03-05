using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Common.JWTAuth;

public class AuthOptions
{
    public const string ISSUER = "PBTestAuthServer";
    public const string AUDIENCE = "PBTestAuthClient";
    const string KEY = "pbtestsupersecretkey";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}