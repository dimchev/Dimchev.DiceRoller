using Dimchev.DiceRoller.Auth.Core.Contracts.Services;
using Dimchev.DiceRoller.Auth.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Dimchev.DiceRoller.Auth.Infrastructure.Services
{
    public class HashingService(IPasswordHasher<User> passwordHasher) : IHashingService
    {
        public string HashPassword(User user, string password)
        {
            var result = passwordHasher.HashPassword(user, password);
            return result;
        }

        public bool Verify(User user, string passwordHash, string password)
        {
            return passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success;
        }
    }
}
