using Dimchev.DiceRoller.Operative.Core.Contracts.Services;
using Dimchev.DiceRoller.Operative.Core.Dtos;
using Dimchev.DiceRoller.Operative.Domain.Entities;

namespace Dimchev.DiceRoller.Operative.Infrastructure.Services
{
    public class DiceRollService : IDiceRollService
    {
        public Task<List<DiceRoll>> GetRollsAsync(Guid userId, GetDiceRollsRequest getRollsRequest)
        {
            throw new NotImplementedException();
        }

        public Task<DiceRoll> RollDiceAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
