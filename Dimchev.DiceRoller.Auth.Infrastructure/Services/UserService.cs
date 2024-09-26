using AutoMapper;
using Dimchev.DiceRoller.Auth.Core.Contracts.Persistence;
using Dimchev.DiceRoller.Auth.Core.Contracts.Services;
using Dimchev.DiceRoller.Auth.Core.Dtos;
using Dimchev.DiceRoller.Auth.Domain.Entities;
using Dimchev.DiceRoller.Auth.Infrastructure.Models;

namespace Dimchev.DiceRoller.Auth.Infrastructure.Services
{
    public class UserService(IHashingService hashingService, ITokenService tokenService, IMapper mapper, IUserRepository userRepository) : IUserService
    {
        public async Task<User> CreateUserAsync(CreateUserDto dto)
        {
            var user = mapper.Map<User>(dto);

            if (dto.Image != null && dto.Image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await dto.Image.CopyToAsync(memoryStream);
                    user.Image = memoryStream.ToArray();
                }
            }
            user.Password = hashingService.HashPassword(user, user.Password);

            var model = mapper.Map<UserModel>(user);
            var result = await userRepository.AddAsync(model);

            return mapper.Map<User>(result);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var model = await userRepository.GetByEmailAsync(dto.Email);
            var user = mapper.Map<User>(model);

            if (user == null || !hashingService.Verify(user, user.Password, dto.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            var token = tokenService.GenerateToken(user);

            return token;
        }
    }
}
