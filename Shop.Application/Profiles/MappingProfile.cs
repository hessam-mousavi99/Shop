using AutoMapper;
using Shop.Application.DTOs.Accounts;
using Shop.Application.DTOs.Wallet;
using Shop.Domain.Models.Account;
using Shop.Domain.Models.Wallet;

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
            CreateMap<UserWallet, ChargeWalletDto>().ReverseMap();
            #endregion
        }
    }
}
