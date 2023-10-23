using AutoMapper;
using Shop.Application.DTOs.Accounts;
using Shop.Application.DTOs.Wallet;
using Shop.Web.Models.VM.Account;
using Shop.Web.Models.VM.Wallet;

namespace Shop.Web.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User Mapping

            CreateMap<CreateUserDto, RegisterVM>().ReverseMap();
            CreateMap<LoginDto, LoginVm>().ReverseMap();
            CreateMap<ActiveAccountDto, ActiveAccountVM>().ReverseMap();
            CreateMap<UserDto, UserVM>().ReverseMap();
            CreateMap<EditUserProfileDto, EditUserProfileVM>().ReverseMap();
            CreateMap<ChangePasswordDto, ChangePasswordVM>().ReverseMap();

            #endregion

            #region Wallet Mapping

            CreateMap<ChargeWalletDto, ChargeWalletVM>().ReverseMap();
            CreateMap<WalletDto, WalletVM>().ReverseMap();
            CreateMap<FilterWalletDto, FilterWalletVM>().ReverseMap();
            
            #endregion
        }
    }
}
