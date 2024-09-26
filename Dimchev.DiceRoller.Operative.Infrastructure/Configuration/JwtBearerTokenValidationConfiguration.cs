using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Dimchev.DiceRoller.Operative.Infrastructure.Configuration
{
    public class JwtBearerTokenValidationConfiguration(IOptions<JwtSettings> jwtSettings)
        : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly JwtSettings jwtSettings = jwtSettings.Value;

        public void Configure(string? name, JwtBearerOptions options) => Configure(options);

        public void Configure(JwtBearerOptions options)
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            };
        }
    }
}
