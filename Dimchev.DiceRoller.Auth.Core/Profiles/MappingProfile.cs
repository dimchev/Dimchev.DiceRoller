using AutoMapper;
using Dimchev.DiceRoller.Auth.Core.Dtos;
using Dimchev.DiceRoller.Auth.Domain.Entities;
using Dimchev.DiceRoller.Auth.Infrastructure.Models;

namespace Dimchev.DiceRoller.Auth.Core.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserDto, User>()
            .ForMember(dest => dest.Image, opt => opt.Ignore());

            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
