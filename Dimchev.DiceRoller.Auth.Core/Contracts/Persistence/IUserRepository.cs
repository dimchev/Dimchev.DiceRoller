using Dimchev.DiceRoller.Auth.Infrastructure.Models;

namespace Dimchev.DiceRoller.Auth.Core.Contracts.Persistence
{
    public interface IUserRepository : IRepository<UserModel>
    {
        Task<UserModel> GetByEmailAsync(string email);
    }
}
