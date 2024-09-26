using Dimchev.DiceRoller.Operative.Core.Contracts.Persistence;
using Dimchev.DiceRoller.Operative.Core.Dtos;
using Dimchev.DiceRoller.Operative.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dimchev.DiceRoller.Operative.Infrastructure.Repositories
{
    public class DiceRollRepository : BaseRepository<DiceRollModel>, IDiceRollRepository
    {
        private readonly DiceDbContext dbContext;

        public DiceRollRepository(DiceDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<DiceRollModel>> GetDiceRollsAsync(Guid userId, GetRollsRequest getRollsRequest)
        {
            var query = dbContext.DiceRolls.AsQueryable().Where(x => x.UserId == userId);

            if (getRollsRequest.Year.HasValue)
                query = query.Where(x => x.CreatedAt.Year == getRollsRequest.Year.Value.Year);

            if (getRollsRequest.Month.HasValue)
                query = query.Where(x => x.CreatedAt.Month == getRollsRequest.Month.Value.Month);

            if (getRollsRequest.Day.HasValue)
                query = query.Where(x => x.CreatedAt.Day == getRollsRequest.Day.Value.Day);

            query = getRollsRequest.SortBy switch
            {
                "Sum" => getRollsRequest.Descending
                    ? query.OrderByDescending(x => x.FirstDice + x.SecondDice)
                    : query.OrderBy(x => x.FirstDice + x.SecondDice),
                _ => getRollsRequest.Descending
                    ? query.OrderByDescending(x => x.CreatedAt)
                    : query.OrderBy(x => x.CreatedAt)
            };

            query = query.Skip((getRollsRequest.Page - 1) * getRollsRequest.PageSize)
                         .Take(getRollsRequest.PageSize);

            return await query.ToListAsync();
        }
    }
}
