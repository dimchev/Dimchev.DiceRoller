using AutoMapper;
using Dimchev.DiceRoller.Operative.Core.Dtos;
using Dimchev.DiceRoller.Operative.Core.Models;

namespace Dimchev.DiceRoller.Operative.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DiceRollModel, DiceRollResponse>();
        }
    }
}
