using Dimchev.DiceRoller.Auth.Domain.Entities;

namespace Dimchev.DiceRoller.Auth.Core.Contracts.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
