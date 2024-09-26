using Dimchev.DiceRoller.Auth.Core.Dtos;
using Dimchev.DiceRoller.Auth.Domain.Entities;

namespace Dimchev.DiceRoller.Auth.Core.Contracts.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(CreateUserDto dto);

        Task<string> LoginAsync(LoginDto dto);
    }
}
