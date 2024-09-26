using Dimchev.DiceRoller.Auth.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimchev.DiceRoller.Auth.Infrastructure
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}