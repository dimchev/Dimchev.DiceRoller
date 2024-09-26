using Dimchev.DiceRoller.Auth.Core.Contracts.Services;
using Dimchev.DiceRoller.Auth.Domain.Entities;
using Dimchev.DiceRoller.Auth.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dimchev.DiceRoller.Auth.Infrastructure.Services
{
    public class JwtTokenService(IOptions<JwtSettings> jwtOptions) : ITokenService
    {
        private readonly JwtSettings jwtSettings = jwtOptions.Value;

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Name, user.FirstName),
                new(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new(JwtRegisteredClaimNames.Email, user.Email),
                new("id", user.UserId.ToString()),
            };

            var token = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(jwtSettings.TokenExpirationInMinutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
