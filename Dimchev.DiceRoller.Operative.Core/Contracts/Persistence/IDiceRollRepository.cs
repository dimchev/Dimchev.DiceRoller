using Dimchev.DiceRoller.Operative.Core.Dtos;
using Dimchev.DiceRoller.Operative.Core.Models;

namespace Dimchev.DiceRoller.Operative.Core.Contracts.Persistence
{
    public interface IDiceRollRepository : IRepository<DiceRollModel>
    {
        public Task<List<DiceRollModel>> GetDiceRollsAsync(Guid userId, GetDiceRollsRequest getRollsRequest);
    }
}
