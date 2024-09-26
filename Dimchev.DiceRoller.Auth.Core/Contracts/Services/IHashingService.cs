using Dimchev.DiceRoller.Auth.Domain.Entities;

namespace Dimchev.DiceRoller.Auth.Core.Contracts.Services
{
    public interface IHashingService
    {
        public string HashPassword(User user, string password);

        public bool Verify(User user, string passwordHash, string password);
    }
}
