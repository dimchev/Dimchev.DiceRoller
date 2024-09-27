﻿using AutoMapper;
using Dimchev.DiceRoller.Operative.Core.Contracts.Persistence;
using Dimchev.DiceRoller.Operative.Core.Contracts.Services;
using Dimchev.DiceRoller.Operative.Core.Dtos;
using Dimchev.DiceRoller.Operative.Core.Models;
using Dimchev.DiceRoller.Operative.Domain.Entities;

namespace Dimchev.DiceRoller.Operative.Infrastructure.Services
{
    public class DiceRollService(IDiceRollRepository diceRollRepository, IMapper mapper) : IDiceRollService
    {
        public async Task<List<DiceRoll>> GetRollsAsync(Guid userId, GetDiceRollsRequest getRollsRequest)
        {
            var models = await diceRollRepository.GetDiceRollsAsync(userId, getRollsRequest);
            return mapper.Map<List<DiceRoll>>(models);
        }

        public async Task<DiceRollResponse> DiceRollAsync(Guid userId)
        {
            Random random = new Random();

            var model = new DiceRollModel
            {
                UserId = userId,
                FirstDice = random.Next(1, 7),
                SecondDice = random.Next(1, 7),
                CreatedAt = DateTime.UtcNow
            };

            model = await diceRollRepository.AddAsync(model);
            var result = mapper.Map<DiceRollResponse>(model);

            return result;
        }
    }
}
