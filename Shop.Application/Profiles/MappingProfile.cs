using AutoMapper;
using Shop.Application.DTOs.Accounts;
using Shop.Domain.Models.Account;

namespace Shop.Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            #region User Mapping
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, ActiveAccountDto>().ReverseMap();
            CreateMap<User, EditUserProfileDto>().ReverseMap();
            CreateMap<User, ChangePasswordDto>().ReverseMap();
            #endregion
        }
    }
}
