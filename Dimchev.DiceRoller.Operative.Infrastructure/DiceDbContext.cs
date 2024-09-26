using Dimchev.DiceRoller.Operative.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimchev.DiceRoller.Operative.Infrastructure
{
    public class DiceDbContext : DbContext
    {
        public DiceDbContext(DbContextOptions<DiceDbContext> options)
           : base(options)
        {
        }

        public DbSet<DiceRollModel> DiceRolls { get; set; }
    }
}
