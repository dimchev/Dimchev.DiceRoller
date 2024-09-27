using AutoMapper;
using Dimchev.DiceRoller.Operative.Core.Dtos;
using Dimchev.DiceRoller.Operative.Core.Models;
using Dimchev.DiceRoller.Operative.Domain.Entities;

namespace Dimchev.DiceRoller.Operative.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DiceRollModel, DiceRollResponse>();
            CreateMap<DiceRollModel, DiceRoll>();
        }
    }
}
