using Dimchev.DiceRoller.Operative.Core.Dtos;
using Dimchev.DiceRoller.Operative.Domain.Entities;

namespace Dimchev.DiceRoller.Operative.Core.Contracts.Services
{
    public interface IDiceRollService
    {
        public Task<DiceRollResponse> DiceRollAsync(Guid userId);

        public Task<List<DiceRoll>> GetRollsAsync(Guid userId, GetDiceRollsRequest getRollsRequest);
    }
}
