using Dimchev.DiceRoller.Auth.Core.Contracts.Persistence;
using Dimchev.DiceRoller.Auth.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimchev.DiceRoller.Auth.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        private readonly AuthDbContext dbContext;

        public UserRepository(AuthDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            return await dbContext.Set<UserModel>().FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
